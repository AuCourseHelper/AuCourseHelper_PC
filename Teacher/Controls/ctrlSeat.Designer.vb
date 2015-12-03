<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlSeat
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnSeat = New System.Windows.Forms.Button()
        Me.lblId = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnSeat, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblId, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblName, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(96, 76)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnSeat
        '
        Me.btnSeat.BackColor = System.Drawing.Color.LightBlue
        Me.btnSeat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSeat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSeat.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSeat.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSeat.ForeColor = System.Drawing.Color.Blue
        Me.btnSeat.Location = New System.Drawing.Point(0, 0)
        Me.btnSeat.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSeat.Name = "btnSeat"
        Me.btnSeat.Size = New System.Drawing.Size(96, 25)
        Me.btnSeat.TabIndex = 0
        Me.btnSeat.Text = "SEAT"
        Me.btnSeat.UseVisualStyleBackColor = False
        '
        'lblId
        '
        Me.lblId.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblId.Font = New System.Drawing.Font("微軟正黑體", 9.0!)
        Me.lblId.Location = New System.Drawing.Point(0, 25)
        Me.lblId.Margin = New System.Windows.Forms.Padding(0)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(96, 25)
        Me.lblId.TabIndex = 1
        Me.lblId.Text = "AM000000"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblName
        '
        Me.lblName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblName.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblName.Location = New System.Drawing.Point(0, 50)
        Me.lblName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(96, 26)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "ＸＸＸ"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ctrlSeat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ctrlSeat"
        Me.Size = New System.Drawing.Size(96, 76)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnSeat As System.Windows.Forms.Button
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label

End Class
