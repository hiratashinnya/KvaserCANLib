<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SendMessageGenerator
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.StopSend_Btn = New System.Windows.Forms.Button()
        Me.StartSend_Btn = New System.Windows.Forms.Button()
        Me.LoadSetting_Btn = New System.Windows.Forms.Button()
        Me.SaveSetting_Btn = New System.Windows.Forms.Button()
        Me.RemoveMessage_Btn = New System.Windows.Forms.Button()
        Me.AddMessage_Btn = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.NameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExtendColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.RemoteColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DLCColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.D0Column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.D1Column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.D2Column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.D3Column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.D4Column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.D5Column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.D6Column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.D7Column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsPeriodicColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IntervalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.StopSend_Btn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.StartSend_Btn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LoadSetting_Btn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.SaveSetting_Btn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RemoveMessage_Btn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.AddMessage_Btn)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1166, 220)
        Me.SplitContainer1.SplitterDistance = 109
        Me.SplitContainer1.TabIndex = 0
        '
        'StopSend_Btn
        '
        Me.StopSend_Btn.Location = New System.Drawing.Point(5, 186)
        Me.StopSend_Btn.Name = "StopSend_Btn"
        Me.StopSend_Btn.Size = New System.Drawing.Size(101, 23)
        Me.StopSend_Btn.TabIndex = 5
        Me.StopSend_Btn.Text = "StopSend"
        Me.StopSend_Btn.UseVisualStyleBackColor = True
        '
        'StartSend_Btn
        '
        Me.StartSend_Btn.Location = New System.Drawing.Point(5, 157)
        Me.StartSend_Btn.Name = "StartSend_Btn"
        Me.StartSend_Btn.Size = New System.Drawing.Size(101, 23)
        Me.StartSend_Btn.TabIndex = 4
        Me.StartSend_Btn.Text = "StartSend"
        Me.StartSend_Btn.UseVisualStyleBackColor = True
        '
        'LoadSetting_Btn
        '
        Me.LoadSetting_Btn.Location = New System.Drawing.Point(5, 111)
        Me.LoadSetting_Btn.Name = "LoadSetting_Btn"
        Me.LoadSetting_Btn.Size = New System.Drawing.Size(101, 23)
        Me.LoadSetting_Btn.TabIndex = 3
        Me.LoadSetting_Btn.Text = "Load"
        Me.LoadSetting_Btn.UseVisualStyleBackColor = True
        '
        'SaveSetting_Btn
        '
        Me.SaveSetting_Btn.Location = New System.Drawing.Point(5, 82)
        Me.SaveSetting_Btn.Name = "SaveSetting_Btn"
        Me.SaveSetting_Btn.Size = New System.Drawing.Size(101, 23)
        Me.SaveSetting_Btn.TabIndex = 2
        Me.SaveSetting_Btn.Text = "Save"
        Me.SaveSetting_Btn.UseVisualStyleBackColor = True
        '
        'RemoveMessage_Btn
        '
        Me.RemoveMessage_Btn.Location = New System.Drawing.Point(5, 32)
        Me.RemoveMessage_Btn.Name = "RemoveMessage_Btn"
        Me.RemoveMessage_Btn.Size = New System.Drawing.Size(101, 23)
        Me.RemoveMessage_Btn.TabIndex = 1
        Me.RemoveMessage_Btn.Text = "Remove"
        Me.RemoveMessage_Btn.UseVisualStyleBackColor = True
        '
        'AddMessage_Btn
        '
        Me.AddMessage_Btn.Location = New System.Drawing.Point(5, 3)
        Me.AddMessage_Btn.Name = "AddMessage_Btn"
        Me.AddMessage_Btn.Size = New System.Drawing.Size(101, 23)
        Me.AddMessage_Btn.TabIndex = 0
        Me.AddMessage_Btn.Text = "Add"
        Me.AddMessage_Btn.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameColumn, Me.CANIDColumn, Me.ExtendColumn, Me.RemoteColumn, Me.DLCColumn, Me.D0Column, Me.D1Column, Me.D2Column, Me.D3Column, Me.D4Column, Me.D5Column, Me.D6Column, Me.D7Column, Me.IsPeriodicColumn, Me.IntervalColumn})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1053, 220)
        Me.DataGridView1.TabIndex = 0
        '
        'NameColumn
        '
        Me.NameColumn.HeaderText = "Name"
        Me.NameColumn.MinimumWidth = 6
        Me.NameColumn.Name = "NameColumn"
        Me.NameColumn.Width = 125
        '
        'CANIDColumn
        '
        Me.CANIDColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Format = "X8"
        DataGridViewCellStyle1.NullValue = "0"
        Me.CANIDColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.CANIDColumn.HeaderText = "CANID"
        Me.CANIDColumn.MinimumWidth = 6
        Me.CANIDColumn.Name = "CANIDColumn"
        Me.CANIDColumn.Width = 79
        '
        'ExtendColumn
        '
        Me.ExtendColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.ExtendColumn.HeaderText = "IsExtend"
        Me.ExtendColumn.MinimumWidth = 6
        Me.ExtendColumn.Name = "ExtendColumn"
        Me.ExtendColumn.Width = 67
        '
        'RemoteColumn
        '
        Me.RemoteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.RemoteColumn.HeaderText = "IsRemote"
        Me.RemoteColumn.MinimumWidth = 6
        Me.RemoteColumn.Name = "RemoteColumn"
        Me.RemoteColumn.Width = 73
        '
        'DLCColumn
        '
        Me.DLCColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "8"
        Me.DLCColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.DLCColumn.HeaderText = "DLC"
        Me.DLCColumn.MinimumWidth = 6
        Me.DLCColumn.Name = "DLCColumn"
        Me.DLCColumn.Width = 64
        '
        'D0Column
        '
        Me.D0Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle3.Format = "X2"
        DataGridViewCellStyle3.NullValue = "00"
        Me.D0Column.DefaultCellStyle = DataGridViewCellStyle3
        Me.D0Column.HeaderText = "D0"
        Me.D0Column.MinimumWidth = 6
        Me.D0Column.Name = "D0Column"
        Me.D0Column.Width = 54
        '
        'D1Column
        '
        Me.D1Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.D1Column.DefaultCellStyle = DataGridViewCellStyle3
        Me.D1Column.HeaderText = "D1"
        Me.D1Column.MinimumWidth = 6
        Me.D1Column.Name = "D1Column"
        Me.D1Column.Width = 54
        '
        'D2Column
        '
        Me.D2Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.D2Column.DefaultCellStyle = DataGridViewCellStyle3
        Me.D2Column.HeaderText = "D2"
        Me.D2Column.MinimumWidth = 6
        Me.D2Column.Name = "D2Column"
        Me.D2Column.Width = 54
        '
        'D3Column
        '
        Me.D3Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.D3Column.DefaultCellStyle = DataGridViewCellStyle3
        Me.D3Column.HeaderText = "D3"
        Me.D3Column.MinimumWidth = 6
        Me.D3Column.Name = "D3Column"
        Me.D3Column.Width = 54
        '
        'D4Column
        '
        Me.D4Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.D4Column.DefaultCellStyle = DataGridViewCellStyle3
        Me.D4Column.HeaderText = "D4"
        Me.D4Column.MinimumWidth = 6
        Me.D4Column.Name = "D4Column"
        Me.D4Column.Width = 54
        '
        'D5Column
        '
        Me.D5Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.D5Column.DefaultCellStyle = DataGridViewCellStyle3
        Me.D5Column.HeaderText = "D5"
        Me.D5Column.MinimumWidth = 6
        Me.D5Column.Name = "D5Column"
        Me.D5Column.Width = 54
        '
        'D6Column
        '
        Me.D6Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.D6Column.DefaultCellStyle = DataGridViewCellStyle3
        Me.D6Column.HeaderText = "D6"
        Me.D6Column.MinimumWidth = 6
        Me.D6Column.Name = "D6Column"
        Me.D6Column.Width = 54
        '
        'D7Column
        '
        Me.D7Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.D7Column.DefaultCellStyle = DataGridViewCellStyle3
        Me.D7Column.HeaderText = "D7"
        Me.D7Column.MinimumWidth = 6
        Me.D7Column.Name = "D7Column"
        Me.D7Column.Width = 54
        '
        'IsPeriodicColumn
        '
        Me.IsPeriodicColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.IsPeriodicColumn.HeaderText = "IsPeriodic"
        Me.IsPeriodicColumn.MinimumWidth = 6
        Me.IsPeriodicColumn.Name = "IsPeriodicColumn"
        Me.IsPeriodicColumn.Width = 75
        '
        'IntervalColumn
        '
        Me.IntervalColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.IntervalColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.IntervalColumn.HeaderText = "Interval"
        Me.IntervalColumn.MinimumWidth = 6
        Me.IntervalColumn.Name = "IntervalColumn"
        Me.IntervalColumn.Width = 83
        '
        'SendMessageGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "SendMessageGenerator"
        Me.Size = New System.Drawing.Size(1166, 220)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents StopSend_Btn As Button
    Friend WithEvents StartSend_Btn As Button
    Friend WithEvents LoadSetting_Btn As Button
    Friend WithEvents SaveSetting_Btn As Button
    Friend WithEvents RemoveMessage_Btn As Button
    Friend WithEvents AddMessage_Btn As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents NameColumn As DataGridViewTextBoxColumn
    Friend WithEvents CANIDColumn As DataGridViewTextBoxColumn
    Friend WithEvents ExtendColumn As DataGridViewCheckBoxColumn
    Friend WithEvents RemoteColumn As DataGridViewCheckBoxColumn
    Friend WithEvents DLCColumn As DataGridViewTextBoxColumn
    Friend WithEvents D0Column As DataGridViewTextBoxColumn
    Friend WithEvents D1Column As DataGridViewTextBoxColumn
    Friend WithEvents D2Column As DataGridViewTextBoxColumn
    Friend WithEvents D3Column As DataGridViewTextBoxColumn
    Friend WithEvents D4Column As DataGridViewTextBoxColumn
    Friend WithEvents D5Column As DataGridViewTextBoxColumn
    Friend WithEvents D6Column As DataGridViewTextBoxColumn
    Friend WithEvents D7Column As DataGridViewTextBoxColumn
    Friend WithEvents IsPeriodicColumn As DataGridViewCheckBoxColumn
    Friend WithEvents IntervalColumn As DataGridViewTextBoxColumn
End Class
