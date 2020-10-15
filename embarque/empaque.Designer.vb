<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class empaque
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(empaque))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_zln_maquina = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_serie_maquina = New System.Windows.Forms.TextBox()
        Me.lbl_no_parte = New System.Windows.Forms.Label()
        Me.txt_no_parte_maquina = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_no_parte_hoja_viajera = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_no_parte_caja = New System.Windows.Forms.TextBox()
        Me.txt_serie_caja = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_zln_caja = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lock_check = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_rev = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(37, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(367, 31)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Area de empaque Lancermex"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(44, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 20)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "ZLN"
        '
        'txt_zln_maquina
        '
        Me.txt_zln_maquina.Enabled = False
        Me.txt_zln_maquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_zln_maquina.Location = New System.Drawing.Point(207, 134)
        Me.txt_zln_maquina.Name = "txt_zln_maquina"
        Me.txt_zln_maquina.Size = New System.Drawing.Size(108, 26)
        Me.txt_zln_maquina.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 20)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Numero de serie"
        '
        'txt_serie_maquina
        '
        Me.txt_serie_maquina.Enabled = False
        Me.txt_serie_maquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_serie_maquina.Location = New System.Drawing.Point(207, 88)
        Me.txt_serie_maquina.Name = "txt_serie_maquina"
        Me.txt_serie_maquina.Size = New System.Drawing.Size(108, 26)
        Me.txt_serie_maquina.TabIndex = 2
        '
        'lbl_no_parte
        '
        Me.lbl_no_parte.AutoSize = True
        Me.lbl_no_parte.BackColor = System.Drawing.Color.Transparent
        Me.lbl_no_parte.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lbl_no_parte.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_no_parte.Location = New System.Drawing.Point(44, 45)
        Me.lbl_no_parte.Name = "lbl_no_parte"
        Me.lbl_no_parte.Size = New System.Drawing.Size(128, 20)
        Me.lbl_no_parte.TabIndex = 17
        Me.lbl_no_parte.Text = "Numero de parte"
        '
        'txt_no_parte_maquina
        '
        Me.txt_no_parte_maquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_no_parte_maquina.Location = New System.Drawing.Point(207, 42)
        Me.txt_no_parte_maquina.Name = "txt_no_parte_maquina"
        Me.txt_no_parte_maquina.Size = New System.Drawing.Size(108, 26)
        Me.txt_no_parte_maquina.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-1, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(464, 560)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_no_parte_hoja_viajera)
        Me.GroupBox1.Location = New System.Drawing.Point(49, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 100)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Hoja Viajera"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(45, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 20)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Numero de  parte"
        '
        'txt_no_parte_hoja_viajera
        '
        Me.txt_no_parte_hoja_viajera.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_no_parte_hoja_viajera.Location = New System.Drawing.Point(207, 37)
        Me.txt_no_parte_hoja_viajera.Name = "txt_no_parte_hoja_viajera"
        Me.txt_no_parte_hoja_viajera.Size = New System.Drawing.Size(108, 26)
        Me.txt_no_parte_hoja_viajera.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox2.Controls.Add(Me.lbl_no_parte)
        Me.GroupBox2.Controls.Add(Me.txt_no_parte_maquina)
        Me.GroupBox2.Controls.Add(Me.txt_serie_maquina)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txt_zln_maquina)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(49, 172)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(352, 172)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Maquina"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txt_no_parte_caja)
        Me.GroupBox3.Controls.Add(Me.txt_serie_caja)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txt_zln_caja)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(49, 362)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(355, 175)
        Me.GroupBox3.TabIndex = 34
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos de la caja"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 20)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Numero de parte"
        '
        'txt_no_parte_caja
        '
        Me.txt_no_parte_caja.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_no_parte_caja.Location = New System.Drawing.Point(207, 42)
        Me.txt_no_parte_caja.Name = "txt_no_parte_caja"
        Me.txt_no_parte_caja.Size = New System.Drawing.Size(108, 26)
        Me.txt_no_parte_caja.TabIndex = 4
        '
        'txt_serie_caja
        '
        Me.txt_serie_caja.Enabled = False
        Me.txt_serie_caja.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_serie_caja.Location = New System.Drawing.Point(207, 88)
        Me.txt_serie_caja.Name = "txt_serie_caja"
        Me.txt_serie_caja.Size = New System.Drawing.Size(108, 26)
        Me.txt_serie_caja.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(44, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 20)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Numero de serie"
        '
        'txt_zln_caja
        '
        Me.txt_zln_caja.Enabled = False
        Me.txt_zln_caja.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_zln_caja.Location = New System.Drawing.Point(207, 134)
        Me.txt_zln_caja.Name = "txt_zln_caja"
        Me.txt_zln_caja.Size = New System.Drawing.Size(108, 26)
        Me.txt_zln_caja.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(44, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 20)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "ZLN"
        '
        'lock_check
        '
        Me.lock_check.Enabled = True
        Me.lock_check.Interval = 5000
        '
        'lbl_rev
        '
        Me.lbl_rev.AutoSize = True
        Me.lbl_rev.Location = New System.Drawing.Point(409, 538)
        Me.lbl_rev.Name = "lbl_rev"
        Me.lbl_rev.Size = New System.Drawing.Size(30, 13)
        Me.lbl_rev.TabIndex = 24
        Me.lbl_rev.Text = "Rev,"
        '
        'empaque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 556)
        Me.Controls.Add(Me.lbl_rev)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "empaque"
        Me.Text = "Empaque LancerMex"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_zln_maquina As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_serie_maquina As TextBox
    Friend WithEvents lbl_no_parte As Label
    Friend WithEvents txt_no_parte_maquina As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_no_parte_hoja_viajera As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txt_no_parte_caja As TextBox
    Friend WithEvents txt_serie_caja As TextBox
    Friend WithEvents txt_zln_caja As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lock_check As Timer
    Friend WithEvents lbl_rev As Label
End Class
