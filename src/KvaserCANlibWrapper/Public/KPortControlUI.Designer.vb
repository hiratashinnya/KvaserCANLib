<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KPortControlUI
    Inherits System.Windows.Forms.UserControl

    'UserControl1 は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.OpenBtn = New System.Windows.Forms.Button()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.BitrateCmbBox = New System.Windows.Forms.ComboBox()
        Me.ChannelCmbBox = New System.Windows.Forms.ComboBox()
        Me.KPortControlUIBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.KPortControlUIBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenBtn
        '
        Me.OpenBtn.Location = New System.Drawing.Point(3, 60)
        Me.OpenBtn.Name = "OpenBtn"
        Me.OpenBtn.Size = New System.Drawing.Size(75, 23)
        Me.OpenBtn.TabIndex = 0
        Me.OpenBtn.Text = "BusOnProcess"
        Me.OpenBtn.UseVisualStyleBackColor = True
        '
        'CloseBtn
        '
        Me.CloseBtn.Location = New System.Drawing.Point(84, 60)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(75, 23)
        Me.CloseBtn.TabIndex = 1
        Me.CloseBtn.Text = "BusOff"
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'BitrateCmbBox
        '
        Me.BitrateCmbBox.FormattingEnabled = True
        Me.BitrateCmbBox.Items.AddRange(BitRateConfigs.GetConfigStr())
        Me.BitrateCmbBox.Location = New System.Drawing.Point(3, 3)
        Me.BitrateCmbBox.Name = "BitrateCmbBox"
        Me.BitrateCmbBox.Size = New System.Drawing.Size(156, 23)
        Me.BitrateCmbBox.TabIndex = 2
        '
        'ChannelCmbBox
        '
        Me.ChannelCmbBox.FormattingEnabled = True
        Me.ChannelCmbBox.Location = New System.Drawing.Point(3, 31)
        Me.ChannelCmbBox.Name = "ChannelCmbBox"
        Me.ChannelCmbBox.Size = New System.Drawing.Size(156, 23)
        Me.ChannelCmbBox.TabIndex = 3
        '
        'KPortControlUIBindingSource
        '
        Me.KPortControlUIBindingSource.DataSource = GetType(KvaserCANlibWrapper.KPortControlUI)
        '
        'KPortControlUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ChannelCmbBox)
        Me.Controls.Add(Me.BitrateCmbBox)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.OpenBtn)
        Me.Name = "KPortControlUI"
        Me.Size = New System.Drawing.Size(164, 89)
        CType(Me.KPortControlUIBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OpenBtn As Button
    Friend WithEvents CloseBtn As Button
    Friend WithEvents BitrateCmbBox As ComboBox
    Friend WithEvents ChannelCmbBox As ComboBox
    Friend WithEvents KPortControlUIBindingSource As BindingSource
End Class
