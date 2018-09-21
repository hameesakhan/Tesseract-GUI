<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.SampleImageBox = New System.Windows.Forms.PictureBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.MainMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.AcquireImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FromFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectTeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SetLanguageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PositionLabel = New System.Windows.Forms.Label
        CType(Me.SampleImageBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SampleImageBox
        '
        Me.SampleImageBox.Cursor = System.Windows.Forms.Cursors.Cross
        Me.SampleImageBox.InitialImage = Nothing
        resources.ApplyResources(Me.SampleImageBox, "SampleImageBox")
        Me.SampleImageBox.Name = "SampleImageBox"
        Me.SampleImageBox.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainMenu, Me.SettingsToolStripMenuItem})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        '
        'MainMenu
        '
        Me.MainMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AcquireImageToolStripMenuItem, Me.FromFileToolStripMenuItem})
        Me.MainMenu.Name = "MainMenu"
        resources.ApplyResources(Me.MainMenu, "MainMenu")
        '
        'AcquireImageToolStripMenuItem
        '
        Me.AcquireImageToolStripMenuItem.Name = "AcquireImageToolStripMenuItem"
        resources.ApplyResources(Me.AcquireImageToolStripMenuItem, "AcquireImageToolStripMenuItem")
        '
        'FromFileToolStripMenuItem
        '
        Me.FromFileToolStripMenuItem.Name = "FromFileToolStripMenuItem"
        resources.ApplyResources(Me.FromFileToolStripMenuItem, "FromFileToolStripMenuItem")
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectTeToolStripMenuItem, Me.SetLanguageToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        resources.ApplyResources(Me.SettingsToolStripMenuItem, "SettingsToolStripMenuItem")
        '
        'SelectTeToolStripMenuItem
        '
        Me.SelectTeToolStripMenuItem.Name = "SelectTeToolStripMenuItem"
        resources.ApplyResources(Me.SelectTeToolStripMenuItem, "SelectTeToolStripMenuItem")
        '
        'SetLanguageToolStripMenuItem
        '
        Me.SetLanguageToolStripMenuItem.Name = "SetLanguageToolStripMenuItem"
        resources.ApplyResources(Me.SetLanguageToolStripMenuItem, "SetLanguageToolStripMenuItem")
        '
        'PositionLabel
        '
        resources.ApplyResources(Me.PositionLabel, "PositionLabel")
        Me.PositionLabel.Name = "PositionLabel"
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PositionLabel)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.SampleImageBox)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SampleImageBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SampleImageBox As System.Windows.Forms.PictureBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MainMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcquireImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FromFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectTeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetLanguageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PositionLabel As System.Windows.Forms.Label

End Class
