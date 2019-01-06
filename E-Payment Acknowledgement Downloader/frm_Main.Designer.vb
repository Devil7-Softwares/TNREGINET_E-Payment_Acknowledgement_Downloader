<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Main
    Inherits XtraFormTemp

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
        Me.lbl_Username = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Password = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Username = New DevExpress.XtraEditors.TextEdit()
        Me.txt_Password = New DevExpress.XtraEditors.TextEdit()
        Me.chk_SavePassword = New DevExpress.XtraEditors.CheckEdit()
        Me.btn_Start = New DevExpress.XtraEditors.SimpleButton()
        Me.lbl_SerialNumbers = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Serial_From = New DevExpress.XtraEditors.SpinEdit()
        Me.lbl_To = New DevExpress.XtraEditors.LabelControl()
        Me.table_Serial = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_Serial_To = New DevExpress.XtraEditors.SpinEdit()
        CType(Me.txt_Username.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Password.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_SavePassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Serial_From.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.table_Serial.SuspendLayout()
        CType(Me.txt_Serial_To.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Username
        '
        Me.lbl_Username.Location = New System.Drawing.Point(35, 15)
        Me.lbl_Username.Name = "lbl_Username"
        Me.lbl_Username.Size = New System.Drawing.Size(55, 13)
        Me.lbl_Username.TabIndex = 0
        Me.lbl_Username.Text = "Username :"
        '
        'lbl_Password
        '
        Me.lbl_Password.Location = New System.Drawing.Point(37, 41)
        Me.lbl_Password.Name = "lbl_Password"
        Me.lbl_Password.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Password.TabIndex = 1
        Me.lbl_Password.Text = "Password :"
        '
        'txt_Username
        '
        Me.txt_Username.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Username.Location = New System.Drawing.Point(96, 12)
        Me.txt_Username.Name = "txt_Username"
        Me.txt_Username.Size = New System.Drawing.Size(288, 20)
        Me.txt_Username.TabIndex = 2
        '
        'txt_Password
        '
        Me.txt_Password.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Password.Location = New System.Drawing.Point(96, 38)
        Me.txt_Password.Name = "txt_Password"
        Me.txt_Password.Size = New System.Drawing.Size(288, 20)
        Me.txt_Password.TabIndex = 3
        '
        'chk_SavePassword
        '
        Me.chk_SavePassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_SavePassword.Location = New System.Drawing.Point(96, 64)
        Me.chk_SavePassword.Name = "chk_SavePassword"
        Me.chk_SavePassword.Properties.Caption = "Save Username && Password"
        Me.chk_SavePassword.Size = New System.Drawing.Size(288, 19)
        Me.chk_SavePassword.TabIndex = 4
        '
        'btn_Start
        '
        Me.btn_Start.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Start.Location = New System.Drawing.Point(309, 127)
        Me.btn_Start.Name = "btn_Start"
        Me.btn_Start.Size = New System.Drawing.Size(75, 23)
        Me.btn_Start.TabIndex = 5
        Me.btn_Start.Text = "Start"
        '
        'lbl_SerialNumbers
        '
        Me.lbl_SerialNumbers.Location = New System.Drawing.Point(12, 95)
        Me.lbl_SerialNumbers.Name = "lbl_SerialNumbers"
        Me.lbl_SerialNumbers.Size = New System.Drawing.Size(78, 13)
        Me.lbl_SerialNumbers.TabIndex = 6
        Me.lbl_SerialNumbers.Text = "Serial Numbers :"
        '
        'txt_Serial_From
        '
        Me.txt_Serial_From.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_Serial_From.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txt_Serial_From.Location = New System.Drawing.Point(3, 3)
        Me.txt_Serial_From.Name = "txt_Serial_From"
        Me.txt_Serial_From.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_Serial_From.Size = New System.Drawing.Size(129, 20)
        Me.txt_Serial_From.TabIndex = 7
        '
        'lbl_To
        '
        Me.lbl_To.Location = New System.Drawing.Point(138, 3)
        Me.lbl_To.Name = "lbl_To"
        Me.lbl_To.Size = New System.Drawing.Size(12, 13)
        Me.lbl_To.TabIndex = 8
        Me.lbl_To.Text = "To"
        '
        'table_Serial
        '
        Me.table_Serial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.table_Serial.ColumnCount = 3
        Me.table_Serial.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.table_Serial.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.table_Serial.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.table_Serial.Controls.Add(Me.txt_Serial_From, 0, 0)
        Me.table_Serial.Controls.Add(Me.lbl_To, 1, 0)
        Me.table_Serial.Controls.Add(Me.txt_Serial_To, 2, 0)
        Me.table_Serial.Location = New System.Drawing.Point(96, 89)
        Me.table_Serial.Name = "table_Serial"
        Me.table_Serial.RowCount = 1
        Me.table_Serial.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.table_Serial.Size = New System.Drawing.Size(288, 26)
        Me.table_Serial.TabIndex = 9
        '
        'txt_Serial_To
        '
        Me.txt_Serial_To.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_Serial_To.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txt_Serial_To.Location = New System.Drawing.Point(156, 3)
        Me.txt_Serial_To.Name = "txt_Serial_To"
        Me.txt_Serial_To.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_Serial_To.Size = New System.Drawing.Size(129, 20)
        Me.txt_Serial_To.TabIndex = 7
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 162)
        Me.Controls.Add(Me.table_Serial)
        Me.Controls.Add(Me.lbl_SerialNumbers)
        Me.Controls.Add(Me.btn_Start)
        Me.Controls.Add(Me.chk_SavePassword)
        Me.Controls.Add(Me.txt_Password)
        Me.Controls.Add(Me.txt_Username)
        Me.Controls.Add(Me.lbl_Password)
        Me.Controls.Add(Me.lbl_Username)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frm_Main"
        Me.Text = "TNREGINET: E-Payment Acknowledgement Downloader"
        CType(Me.txt_Username.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Password.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_SavePassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Serial_From.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.table_Serial.ResumeLayout(False)
        Me.table_Serial.PerformLayout()
        CType(Me.txt_Serial_To.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_Username As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Password As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Username As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txt_Password As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chk_SavePassword As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btn_Start As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbl_SerialNumbers As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Serial_From As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lbl_To As DevExpress.XtraEditors.LabelControl
    Friend WithEvents table_Serial As TableLayoutPanel
    Friend WithEvents txt_Serial_To As DevExpress.XtraEditors.SpinEdit
End Class
