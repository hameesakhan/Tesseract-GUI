Imports System.Windows.Forms

Public Class ConsoleOutput


    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged
        Me.RichTextBox1.SelectionStart = Me.RichTextBox1.TextLength - 1
        Me.RichTextBox1.SelectionLength = 1
        Me.RichTextBox1.ScrollToCaret()
    End Sub
End Class
