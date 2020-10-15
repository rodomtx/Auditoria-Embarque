Imports System.Data.SqlClient

Public Class audit
    Dim conexion = "Data Source=" & My.Settings.servidor & "\" & My.Settings.instancia & " ;Initial Catalog=" & My.Settings.bd & ";Integrated Security=True"
    Dim SQLConn As New SqlConnection()






    Private Sub audit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        check_lock.Enabled = True
        Label3.Text = "   El sistema se encuentra temporalmente inhabilitado debido " + vbCrLf + "a que se encontro un incidente en la informacion capturada " + vbCrLf + "" + vbCrLf + "   Favor de contactar al area de materiales y/o calidad para" + vbCrLf + "verificar el incidente"
        Label2.Text = empaque.msg
        Label4.Text = "Una vez verificado y aclarado el incidente capture el codigo de seguridad enviado por correo " + vbCrLf + "a Materiales / Calidad para liberar el sistema."
        If empaque.msg = "Incidente detectado en otro equipo de empaque" Then
            txt_code.Enabled = False
            btn_restablecer_sistema.Enabled = False
        Else
            txt_code.Enabled = True
            btn_restablecer_sistema.Enabled = True
        End If
    End Sub

    Private Sub check_lock_Tick(sender As Object, e As EventArgs) Handles check_lock.Tick


        If empaque.check_lock() = 0 Then

            sistema_liberado()

        End If
    End Sub

    Sub sistema_liberado()


        empaque.unlock_sistema()
        check_lock.Enabled = False
        empaque.lock_check.Enabled = True
        empaque.Show()
        Me.Close()
    End Sub

    Private Sub btn_restablecer_sistema_Click(sender As Object, e As EventArgs) Handles btn_restablecer_sistema.Click
        If (txt_code.Text = empaque.code) Then
            sistema_liberado()
        Else
            MsgBox("Codigo Invalido", 16, "Error al liberar el sistema")
        End If


    End Sub
End Class