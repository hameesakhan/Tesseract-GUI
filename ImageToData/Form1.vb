Public Class Form1
    Public MouseCapture(1, 1) As Integer
    Public RectangleCapture As New Rectangle
    Public TesseractLocation As String = "C:\Program Files (x86)\Tesseract-OCR\tesseract.exe"
    Public ImgName As String
    Public PointerPadding(1) As Integer
    Public PixelSkipping As Integer = 100
    Public LanguageCode As String = "eng"

    '       0   1
    '   0   W1  H1
    '   1   W2  H2
    '
    Private Sub AcquireImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcquireImageToolStripMenuItem.Click


        Try
            Dim CD As New WIA.CommonDialog
            Dim Fetcher As WIA.ImageFile = CD.ShowAcquireImage(WIA.WiaDeviceType.ScannerDeviceType)
            ImgName = "TempImage." + Fetcher.FileExtension
            If My.Computer.FileSystem.FileExists(ImgName) Then Kill(ImgName)

            Fetcher.SaveFile(ImgName)
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        Me.SampleImageBox.ImageLocation = ImgName
        'Me.SampleImageBox.Width = Image.FromFile(ImgName).Width
        'Me.SampleImageBox.Height = Image.FromFile(ImgName).Height

    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ConsoleOutput.Close()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ResetMouseCapture()
        PointerPadding(0) = Me.SampleImageBox.PointToScreen(Me.SampleImageBox.Location).X
        PointerPadding(1) = Me.SampleImageBox.PointToScreen(Me.SampleImageBox.Location).Y
        ConsoleOutput.Show()
    End Sub
    Function ResetMouseCapture()
        MouseCapture(0, 0) = -1
        MouseCapture(0, 1) = -1
        MouseCapture(1, 0) = -1
        MouseCapture(1, 1) = -1
    End Function
    Function SendCapturedAreaToFile()
        Try


            Dim CropRect As New Rectangle(MouseCapture(0, 0), MouseCapture(0, 1), MouseCapture(1, 0) - MouseCapture(0, 0), MouseCapture(1, 1) - MouseCapture(0, 1))
            Dim OriginalImage = Image.FromFile(Me.SampleImageBox.ImageLocation)
            Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)
            Using grp = Graphics.FromImage(CropImage)
                grp.DrawImage(OriginalImage, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                OriginalImage.Dispose()
                CropImage.Save("ForTesseract.png")
                ImgName = "ForTesseract.png"
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Function
        End Try
    End Function
    Private Sub FromFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FromFileToolStripMenuItem.Click
        Try
            Dim myDialog As New OpenFileDialog


            myDialog.ShowDialog()
            ImgName = "TempImage" & My.Computer.FileSystem.GetFileInfo(myDialog.FileName).Extension
            If My.Computer.FileSystem.FileExists(ImgName) Then Kill(ImgName)
            My.Computer.FileSystem.CopyFile(myDialog.FileName, ImgName)
            Me.SampleImageBox.ImageLocation = ImgName

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub SelectTeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectTeToolStripMenuItem.Click
        Try
            Dim myDialog As New OpenFileDialog
            myDialog.ShowDialog()
            TesseractLocation = myDialog.FileName
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Function CallTesseractForImage()
        Dim proc As New Process

        proc.StartInfo.FileName = TesseractLocation
        proc.StartInfo.Arguments = Application.StartupPath & "\" & ImgName & " -l " & LanguageCode & " stdout"
        proc.StartInfo.ErrorDialog = True
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.RedirectStandardOutput = True
        proc.StartInfo.RedirectStandardError = True
        proc.StartInfo.CreateNoWindow = True
        proc.StartInfo.WorkingDirectory = My.Computer.FileSystem.GetParentPath(TesseractLocation)

        ConsoleOutput.RichTextBox1.AppendText(proc.StartInfo.FileName & " " & proc.StartInfo.Arguments & vbCrLf)
        proc.Start()
        'proc.WaitForExit()

        Dim teserror = proc.StandardError.ReadToEnd()
        If Len(teserror) <> 0 Then ConsoleOutput.RichTextBox1.AppendText(teserror & vbCrLf)

        Dim output() As String = proc.StandardOutput.ReadToEnd.Split(CChar(vbLf))
        For Each ln As String In output
            AppendToFile(ln)
            ConsoleOutput.RichTextBox1.AppendText(ln & vbCrLf)
        Next

    End Function
    Function AppendToFile(ByVal TextToWrite As String)
        My.Computer.FileSystem.WriteAllText("DataFile.txt", TextToWrite & vbNewLine, True)
    End Function
    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Up
                If Me.SampleImageBox.Location.Y < 0 Then Me.SampleImageBox.Location = New System.Drawing.Point(Me.SampleImageBox.Location.X, Me.SampleImageBox.Location.Y + PixelSkipping)
            Case Keys.Down
                If Math.Abs(Me.SampleImageBox.Location.Y) + Me.Height < Me.SampleImageBox.Image.Height Then Me.SampleImageBox.Location = New System.Drawing.Point(Me.SampleImageBox.Location.X, Me.SampleImageBox.Location.Y - PixelSkipping)
            Case Keys.Left
                If Me.SampleImageBox.Location.X < 0 Then Me.SampleImageBox.Location = New System.Drawing.Point(Me.SampleImageBox.Location.X + PixelSkipping, Me.SampleImageBox.Location.Y)
            Case Keys.Right
                If Math.Abs(Me.SampleImageBox.Location.X) + Me.Width < Me.SampleImageBox.Image.Width Then Me.SampleImageBox.Location = New System.Drawing.Point(Me.SampleImageBox.Location.X - PixelSkipping, Me.SampleImageBox.Location.Y)
        End Select
    End Sub
    Private Sub SetLanguageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LanguageCode = InputBox("Enter language code supported by Tesserect. Example: English = eng; Urdu = urd;", , "eng")
    End Sub
    Private Sub SampleImageBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SampleImageBox.MouseDown
        MouseCapture(0, 0) = Control.MousePosition.X - Me.SampleImageBox.Location.X - PointerPadding(0)
        MouseCapture(0, 1) = Control.MousePosition.Y - Me.SampleImageBox.Location.Y - PointerPadding(1)
    End Sub
    Private Sub SampleImageBox_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles SampleImageBox.MouseHover
        Me.PositionLabel.Visible = True
    End Sub
    Private Sub SampleImageBox_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles SampleImageBox.MouseLeave
        Me.PositionLabel.Visible = False
    End Sub
    Private Sub SampleImageBox_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SampleImageBox.MouseMove

        Me.PositionLabel.Text = (Control.MousePosition.X - Me.SampleImageBox.Location.X - PointerPadding(0)) & " X " & (Control.MousePosition.Y - Me.SampleImageBox.Location.Y - PointerPadding(1))
        Me.PositionLabel.Location = New System.Drawing.Point(PointToScreen(New System.Drawing.Point(e.Location.X + 10 - Math.Abs(Me.SampleImageBox.Location.X), e.Location.Y + 10 - Math.Abs(Me.SampleImageBox.Location.Y))).X, PointToScreen(New System.Drawing.Point(e.Location.X + 10 - Math.Abs(Me.SampleImageBox.Location.X), e.Location.Y + 10 - Math.Abs(Me.SampleImageBox.Location.Y))).Y)

        If MouseCapture(0, 0) <> -1 And MouseCapture(0, 1) <> 0 Then
            Me.Refresh()
            MouseCapture(1, 0) = Control.MousePosition.X - Me.SampleImageBox.Location.X - PointerPadding(0)
            MouseCapture(1, 1) = Control.MousePosition.Y - Me.SampleImageBox.Location.Y - PointerPadding(1)
            Me.SampleImageBox.CreateGraphics().DrawRectangle(Pens.Red, MouseCapture(0, 0), MouseCapture(0, 1), MouseCapture(1, 0) - MouseCapture(0, 0), MouseCapture(1, 1) - MouseCapture(0, 1))
        End If
    End Sub
    Private Sub SampleImageBox_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SampleImageBox.MouseUp
        MouseCapture(1, 0) = Control.MousePosition.X - Me.SampleImageBox.Location.X - PointerPadding(0)
        MouseCapture(1, 1) = Control.MousePosition.Y - Me.SampleImageBox.Location.Y - PointerPadding(1)


        Me.SampleImageBox.CreateGraphics().DrawRectangle(Pens.Red, MouseCapture(0, 0), MouseCapture(0, 1), MouseCapture(1, 0) - MouseCapture(0, 0), MouseCapture(1, 1) - MouseCapture(0, 1))


        Call SendCapturedAreaToFile()
        Call ResetMouseCapture()
        Call CallTesseractForImage()
    End Sub
End Class
