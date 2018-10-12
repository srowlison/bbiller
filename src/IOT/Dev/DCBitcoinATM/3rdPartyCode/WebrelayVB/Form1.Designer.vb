<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.portTextBox = New System.Windows.Forms.TextBox()
        Me.addressTextBox = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.pulseButton = New System.Windows.Forms.Button()
        Me.offButton = New System.Windows.Forms.Button()
        Me.onButton = New System.Windows.Forms.Button()
        Me.inputState = New System.Windows.Forms.TextBox()
        Me.relayState = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(13, 15)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(425, 268)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.portTextBox)
        Me.TabPage1.Controls.Add(Me.addressTextBox)
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(417, 242)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Network Settings"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'portTextBox
        '
        Me.portTextBox.Location = New System.Drawing.Point(32, 155)
        Me.portTextBox.Name = "portTextBox"
        Me.portTextBox.Size = New System.Drawing.Size(100, 20)
        Me.portTextBox.TabIndex = 4
        Me.portTextBox.Text = "80"
        '
        'addressTextBox
        '
        Me.addressTextBox.Location = New System.Drawing.Point(32, 63)
        Me.addressTextBox.Name = "addressTextBox"
        Me.addressTextBox.Size = New System.Drawing.Size(100, 20)
        Me.addressTextBox.TabIndex = 3
        Me.addressTextBox.Text = "192.168.50.254"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(179, 91)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(187, 52)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "Set the IP Address and Port number of the Webrelay unit that will be monitored an" & _
    "d controlled."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Port"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Address"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TextBox2)
        Me.TabPage2.Controls.Add(Me.pulseButton)
        Me.TabPage2.Controls.Add(Me.offButton)
        Me.TabPage2.Controls.Add(Me.onButton)
        Me.TabPage2.Controls.Add(Me.inputState)
        Me.TabPage2.Controls.Add(Me.relayState)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(417, 242)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Control"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(191, 129)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(171, 54)
        Me.TextBox2.TabIndex = 7
        Me.TextBox2.Text = "Monitor the state of the Webrelay unit on the left. Control the state of the rela" & _
    "y with the buttons above."
        '
        'pulseButton
        '
        Me.pulseButton.Location = New System.Drawing.Point(311, 64)
        Me.pulseButton.Name = "pulseButton"
        Me.pulseButton.Size = New System.Drawing.Size(51, 23)
        Me.pulseButton.TabIndex = 6
        Me.pulseButton.Text = "PULSE"
        Me.pulseButton.UseVisualStyleBackColor = True
        '
        'offButton
        '
        Me.offButton.Location = New System.Drawing.Point(252, 64)
        Me.offButton.Name = "offButton"
        Me.offButton.Size = New System.Drawing.Size(53, 23)
        Me.offButton.TabIndex = 5
        Me.offButton.Text = "OFF"
        Me.offButton.UseVisualStyleBackColor = True
        '
        'onButton
        '
        Me.onButton.Location = New System.Drawing.Point(191, 64)
        Me.onButton.Name = "onButton"
        Me.onButton.Size = New System.Drawing.Size(55, 23)
        Me.onButton.TabIndex = 4
        Me.onButton.Text = "ON"
        Me.onButton.UseVisualStyleBackColor = True
        '
        'inputState
        '
        Me.inputState.Location = New System.Drawing.Point(41, 146)
        Me.inputState.Name = "inputState"
        Me.inputState.ReadOnly = True
        Me.inputState.Size = New System.Drawing.Size(100, 20)
        Me.inputState.TabIndex = 3
        '
        'relayState
        '
        Me.relayState.Location = New System.Drawing.Point(37, 67)
        Me.relayState.Name = "relayState"
        Me.relayState.ReadOnly = True
        Me.relayState.Size = New System.Drawing.Size(100, 20)
        Me.relayState.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Input State"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Relay State"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 301)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form1"
        Me.Text = "Webrelay VB Demo"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents portTextBox As System.Windows.Forms.TextBox
    Friend WithEvents addressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents pulseButton As System.Windows.Forms.Button
    Friend WithEvents offButton As System.Windows.Forms.Button
    Friend WithEvents onButton As System.Windows.Forms.Button
    Friend WithEvents inputState As System.Windows.Forms.TextBox
    Friend WithEvents relayState As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
