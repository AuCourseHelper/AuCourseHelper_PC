<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlRTBTool
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlRTBTool))
        Me.rtbMain = New System.Windows.Forms.RichTextBox()
        Me.tosMain = New System.Windows.Forms.ToolStrip()
        Me.btnCut = New System.Windows.Forms.ToolStripButton()
        Me.btnCopy = New System.Windows.Forms.ToolStripButton()
        Me.btnPaste = New System.Windows.Forms.ToolStripButton()
        Me.btnPasteText = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnUndo = New System.Windows.Forms.ToolStripButton()
        Me.btnRedo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnB = New System.Windows.Forms.ToolStripButton()
        Me.btnI = New System.Windows.Forms.ToolStripButton()
        Me.btnU = New System.Windows.Forms.ToolStripButton()
        Me.btnUp = New System.Windows.Forms.ToolStripButton()
        Me.btnDown = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnList = New System.Windows.Forms.ToolStripButton()
        Me.btnLeft = New System.Windows.Forms.ToolStripButton()
        Me.btnCenter = New System.Windows.Forms.ToolStripButton()
        Me.btnRight = New System.Windows.Forms.ToolStripButton()
        Me.btnTabR = New System.Windows.Forms.ToolStripButton()
        Me.btnTabL = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCol = New System.Windows.Forms.ToolStripButton()
        Me.btnColBk = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnOpen = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.tmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.staMain = New System.Windows.Forms.StatusStrip()
        Me.tssLeft = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblPoint = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblLength = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblZoom = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tosMain.SuspendLayout()
        Me.staMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbMain
        '
        Me.rtbMain.BulletIndent = 4
        Me.rtbMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbMain.EnableAutoDragDrop = True
        Me.rtbMain.Location = New System.Drawing.Point(0, 30)
        Me.rtbMain.Name = "rtbMain"
        Me.rtbMain.Size = New System.Drawing.Size(800, 370)
        Me.rtbMain.TabIndex = 0
        Me.rtbMain.Text = ""
        Me.rtbMain.WordWrap = False
        '
        'tosMain
        '
        Me.tosMain.AutoSize = False
        Me.tosMain.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.tosMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tosMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tosMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.tosMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCut, Me.btnCopy, Me.btnPaste, Me.btnPasteText, Me.ToolStripSeparator1, Me.btnUndo, Me.btnRedo, Me.ToolStripSeparator2, Me.btnB, Me.btnI, Me.btnU, Me.btnUp, Me.btnDown, Me.ToolStripSeparator3, Me.btnList, Me.btnLeft, Me.btnCenter, Me.btnRight, Me.btnTabR, Me.btnTabL, Me.ToolStripSeparator4, Me.btnCol, Me.btnColBk, Me.ToolStripSeparator5, Me.btnOpen, Me.btnSave})
        Me.tosMain.Location = New System.Drawing.Point(0, 0)
        Me.tosMain.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.tosMain.Name = "tosMain"
        Me.tosMain.Size = New System.Drawing.Size(800, 30)
        Me.tosMain.TabIndex = 1
        Me.tosMain.Text = "ToolStrip1"
        '
        'btnCut
        '
        Me.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCut.Enabled = False
        Me.btnCut.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.editcut
        Me.btnCut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCut.Name = "btnCut"
        Me.btnCut.Size = New System.Drawing.Size(28, 27)
        Me.btnCut.Text = "ToolStripButton1"
        Me.btnCut.ToolTipText = "剪下"
        '
        'btnCopy
        '
        Me.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCopy.Enabled = False
        Me.btnCopy.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.editcopy
        Me.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(28, 27)
        Me.btnCopy.Text = "ToolStripButton2"
        Me.btnCopy.ToolTipText = "複製"
        '
        'btnPaste
        '
        Me.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPaste.Enabled = False
        Me.btnPaste.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.editpaste
        Me.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.Size = New System.Drawing.Size(28, 27)
        Me.btnPaste.Text = "ToolStripButton3"
        Me.btnPaste.ToolTipText = "貼上"
        '
        'btnPasteText
        '
        Me.btnPasteText.BackColor = System.Drawing.SystemColors.Info
        Me.btnPasteText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPasteText.Enabled = False
        Me.btnPasteText.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.editpaste
        Me.btnPasteText.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPasteText.Name = "btnPasteText"
        Me.btnPasteText.Size = New System.Drawing.Size(28, 27)
        Me.btnPasteText.Text = "ToolStripButton1"
        Me.btnPasteText.ToolTipText = "貼上純文字"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 30)
        '
        'btnUndo
        '
        Me.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUndo.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.editundo
        Me.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(28, 27)
        Me.btnUndo.Text = "ToolStripButton4"
        Me.btnUndo.ToolTipText = "還原"
        '
        'btnRedo
        '
        Me.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRedo.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.editredo
        Me.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRedo.Name = "btnRedo"
        Me.btnRedo.Size = New System.Drawing.Size(28, 27)
        Me.btnRedo.Text = "ToolStripButton5"
        Me.btnRedo.ToolTipText = "重做"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 30)
        '
        'btnB
        '
        Me.btnB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnB.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnB.Image = CType(resources.GetObject("btnB.Image"), System.Drawing.Image)
        Me.btnB.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnB.Name = "btnB"
        Me.btnB.Size = New System.Drawing.Size(24, 27)
        Me.btnB.Text = "B"
        Me.btnB.ToolTipText = "粗體"
        '
        'btnI
        '
        Me.btnI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnI.Font = New System.Drawing.Font("微軟正黑體", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnI.Image = CType(resources.GetObject("btnI.Image"), System.Drawing.Image)
        Me.btnI.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnI.Name = "btnI"
        Me.btnI.Size = New System.Drawing.Size(23, 27)
        Me.btnI.Text = "I"
        Me.btnI.ToolTipText = "斜體"
        '
        'btnU
        '
        Me.btnU.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnU.Font = New System.Drawing.Font("微軟正黑體", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnU.Image = CType(resources.GetObject("btnU.Image"), System.Drawing.Image)
        Me.btnU.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnU.Name = "btnU"
        Me.btnU.Size = New System.Drawing.Size(26, 27)
        Me.btnU.Text = "U"
        Me.btnU.ToolTipText = "底線"
        '
        'btnUp
        '
        Me.btnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUp.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.charactergrowfont
        Me.btnUp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(28, 27)
        Me.btnUp.Text = "ToolStripButton9"
        Me.btnUp.ToolTipText = "放大字型"
        '
        'btnDown
        '
        Me.btnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDown.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.charactershrinkfont
        Me.btnDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(28, 27)
        Me.btnDown.Text = "ToolStripButton10"
        Me.btnDown.ToolTipText = "縮小字型"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 30)
        '
        'btnList
        '
        Me.btnList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnList.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.listbullets
        Me.btnList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnList.Name = "btnList"
        Me.btnList.Size = New System.Drawing.Size(28, 27)
        Me.btnList.Text = "ToolStripButton11"
        Me.btnList.ToolTipText = "符號清單"
        '
        'btnLeft
        '
        Me.btnLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLeft.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.paragraphleftjustify
        Me.btnLeft.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLeft.Name = "btnLeft"
        Me.btnLeft.Size = New System.Drawing.Size(28, 27)
        Me.btnLeft.Text = "ToolStripButton13"
        Me.btnLeft.ToolTipText = "靠左對齊"
        '
        'btnCenter
        '
        Me.btnCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCenter.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.paragraphcenterjustify
        Me.btnCenter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCenter.Name = "btnCenter"
        Me.btnCenter.Size = New System.Drawing.Size(28, 27)
        Me.btnCenter.Text = "ToolStripButton14"
        Me.btnCenter.ToolTipText = "置中對齊"
        '
        'btnRight
        '
        Me.btnRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRight.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.paragraphrightjustify
        Me.btnRight.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRight.Name = "btnRight"
        Me.btnRight.Size = New System.Drawing.Size(28, 27)
        Me.btnRight.Text = "ToolStripButton15"
        Me.btnRight.ToolTipText = "靠右對齊"
        '
        'btnTabR
        '
        Me.btnTabR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnTabR.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.paragraphincreaseindentation
        Me.btnTabR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnTabR.Name = "btnTabR"
        Me.btnTabR.Size = New System.Drawing.Size(28, 27)
        Me.btnTabR.Text = "ToolStripButton17"
        Me.btnTabR.ToolTipText = "向右縮排"
        '
        'btnTabL
        '
        Me.btnTabL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnTabL.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.paragraphdecreaseindentation
        Me.btnTabL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnTabL.Name = "btnTabL"
        Me.btnTabL.Size = New System.Drawing.Size(28, 27)
        Me.btnTabL.Text = "ToolStripButton18"
        Me.btnTabL.ToolTipText = "向左縮排"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 30)
        '
        'btnCol
        '
        Me.btnCol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnCol.Image = CType(resources.GetObject("btnCol.Image"), System.Drawing.Image)
        Me.btnCol.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCol.Name = "btnCol"
        Me.btnCol.Size = New System.Drawing.Size(77, 27)
        Me.btnCol.Text = "字型顏色"
        Me.btnCol.ToolTipText = "字型顏色"
        '
        'btnColBk
        '
        Me.btnColBk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnColBk.Image = CType(resources.GetObject("btnColBk.Image"), System.Drawing.Image)
        Me.btnColBk.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnColBk.Name = "btnColBk"
        Me.btnColBk.Size = New System.Drawing.Size(77, 27)
        Me.btnColBk.Text = "背景顏色"
        Me.btnColBk.ToolTipText = "字型背景顏色"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 30)
        '
        'btnOpen
        '
        Me.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnOpen.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.fileopen
        Me.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(28, 27)
        Me.btnOpen.Text = "ToolStripButton1"
        Me.btnOpen.ToolTipText = "開啟RTF檔案"
        '
        'btnSave
        '
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSave.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.filesave
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(28, 27)
        Me.btnSave.Text = "ToolStripButton2"
        Me.btnSave.ToolTipText = "儲存RTF檔案"
        '
        'tmrMain
        '
        Me.tmrMain.Enabled = True
        Me.tmrMain.Interval = 1000
        '
        'staMain
        '
        Me.staMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.staMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLeft, Me.lblPoint, Me.lblLength, Me.lblZoom})
        Me.staMain.Location = New System.Drawing.Point(0, 375)
        Me.staMain.Name = "staMain"
        Me.staMain.Size = New System.Drawing.Size(800, 25)
        Me.staMain.SizingGrip = False
        Me.staMain.TabIndex = 2
        Me.staMain.Text = "StatusStrip1"
        '
        'tssLeft
        '
        Me.tssLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tssLeft.Name = "tssLeft"
        Me.tssLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tssLeft.Size = New System.Drawing.Size(583, 20)
        Me.tssLeft.Spring = True
        '
        'lblPoint
        '
        Me.lblPoint.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblPoint.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.lblPoint.Name = "lblPoint"
        Me.lblPoint.Size = New System.Drawing.Size(101, 20)
        Me.lblPoint.Text = "第0列，第0行"
        '
        'lblLength
        '
        Me.lblLength.Name = "lblLength"
        Me.lblLength.Size = New System.Drawing.Size(60, 20)
        Me.lblLength.Text = "0個字元"
        '
        'lblZoom
        '
        Me.lblZoom.Name = "lblZoom"
        Me.lblZoom.Size = New System.Drawing.Size(41, 20)
        Me.lblZoom.Text = "100%"
        '
        'ctrlRTBTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.staMain)
        Me.Controls.Add(Me.rtbMain)
        Me.Controls.Add(Me.tosMain)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctrlRTBTool"
        Me.Size = New System.Drawing.Size(800, 400)
        Me.tosMain.ResumeLayout(False)
        Me.tosMain.PerformLayout()
        Me.staMain.ResumeLayout(False)
        Me.staMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtbMain As System.Windows.Forms.RichTextBox
    Friend WithEvents tosMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnCut As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCopy As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPaste As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRedo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnB As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnI As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnU As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUp As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDown As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnList As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLeft As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCenter As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRight As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnTabR As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnTabL As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCol As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnColBk As System.Windows.Forms.ToolStripButton
    Friend WithEvents tmrMain As System.Windows.Forms.Timer
    Friend WithEvents btnPasteText As System.Windows.Forms.ToolStripButton
    Friend WithEvents staMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblPoint As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblLength As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblZoom As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton

End Class
