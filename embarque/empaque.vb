Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Text

Public Class empaque
    Public Shared msg As String
    Public Shared locked As Boolean = False
    Public Shared code As String
    Public Shared serie_r As Boolean = False
    Public Shared zln_r As Boolean = False


    Dim conexion = "Data Source=" & My.Settings.servidor & "\" & My.Settings.instancia & " ;Initial Catalog=" & My.Settings.bd & ";Integrated Security=True"
    Dim SQLConn As New SqlConnection()


    Private Function generar_codigo() As String
        Dim randomText As New StringBuilder()
        code = Nothing
        If [String].IsNullOrEmpty(code) Then
            Dim alphabets As String = "1234567890"
            Dim r As New Random()
            For j As Integer = 0 To 4
                randomText.Append(alphabets(r.[Next](alphabets.Length)))
            Next
            code = randomText.ToString()
        End If
        Return code
    End Function

    Function lock_incongruencia(ByVal no_parte_maquina As String,
                                 ByVal no_parte_caja As String,
                                 ByVal serie_maquina As String,
                                 ByVal serie_caja As String,
                                 ByVal zln_maquina As String,
                                 ByVal zln_caja As String)

        Dim _ret_val As Int16

        _ret_val = 0

        If ((no_parte_maquina = no_parte_caja) And (serie_maquina = serie_caja) And (zln_maquina = zln_caja)) Then
            _ret_val = 1
        End If

        Return _ret_val
    End Function

    Function send_password(ByVal empleado As String,
                                  ByVal no_parte_maquina As String,
                                  ByVal no_parte_caja As String,
                                  ByVal serie_maquina As String,
                                  ByVal serie_caja As String,
                                  ByVal zln_maquina As String,
                                  ByVal zln_caja As String,
                           ByVal _msg As String
                           )

        Try

            code = generar_codigo()


            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.office365.com"
            Smtp_Server.Credentials = New System.Net.NetworkCredential("noreply@lancerworldwide.com", "Lancer2013!")


            e_mail = New MailMessage()
            e_mail.From = New MailAddress("noreply@lancercorp.com")
            e_mail.To.Add("empaque_lmx@lancercorp.com")
            e_mail.Subject = "Incidente area de empaque"
            e_mail.IsBodyHtml = False
            e_mail.Body = "Se detecto un incidente en area de empaque con los siguientes parametros :" &
                vbCrLf &
                vbCrLf & "Incidente: " & _msg &
                vbCrLf &
                vbCrLf & "Numero de parte hoja viajera " & empleado &
                vbCrLf & "Numero de parte maquina: " & no_parte_maquina &
                vbCrLf & "Numero de parte caja: " & no_parte_caja &
                vbCrLf & "Serie maquina: " & serie_maquina &
                vbCrLf & "Serie caja: " & serie_caja &
                vbCrLf & "ZLN maquina: " & zln_maquina &
                vbCrLf & "ZLN caja: " & zln_caja &
                vbCrLf & "Usuario: " & Environment.UserDomainName & "\" & Environment.UserName &
                vbCrLf & "Estacion: " & Environment.MachineName &
                vbCrLf &
                vbCrLf & "Codigo para restablecer sistema: " & code &
                vbCrLf &
                vbCrLf & "Powered by IT Mexico"

            Smtp_Server.Send(e_mail)

        Catch error_t As Exception
            MessageBox.Show(error_t.ToString, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return 1

    End Function
    Public Sub ultimo_dato()
        If (lock_datos_faltantes(txt_no_parte_hoja_viajera.Text,
                                 txt_no_parte_maquina.Text,
                                 txt_no_parte_caja.Text,
                                 txt_serie_maquina.Text,
                                 txt_serie_caja.Text,
                                 txt_zln_maquina.Text,
                                 txt_zln_caja.Text) = 1) Then


            If (serie_r = True And zln_r = True) Then
                'estar aqui significa que el numero de parte lleva zln y serie por lo que hay que verificar de uno por uno para poder
                'en caso de error arrojar el error correcto es decir si el zln o el serie estan dupicados.
                'se validara en este orden : que sean iguales y despues que no existan 
                'para poder generar errores separados en caso de que pasen.
                If (txt_no_parte_hoja_viajera.Text = txt_no_parte_caja.Text) And (txt_no_parte_hoja_viajera.Text = txt_no_parte_maquina.Text) Then

                    'los numeros de parte si coinciden

                    If (lock_serie(txt_serie_maquina.Text) = 0) Then
                        'numero de serie no esta duplicado'
                        If (lock_zln(txt_zln_maquina.Text) = 0) Then

                            If txt_zln_caja.Text = txt_zln_maquina.Text Then
                                'en esta parte confirma que ambos ZLN sean iguales
                                'si no lo son pues se bloquea por zln incongruente

                                If txt_serie_caja.Text = txt_serie_maquina.Text Then
                                    'zln limpio
                                    'serie limpia
                                    'todo limpio hasta aqui , se guardan los datos.
                                    guardar_produccion(txt_no_parte_hoja_viajera.Text,
                                   txt_no_parte_maquina.Text,
                                   txt_serie_maquina.Text,
                                           txt_zln_maquina.Text)

                                    MessageBox.Show("El numero de parte: " & txt_no_parte_maquina.Text & " con numero de serie : " & txt_serie_maquina.Text & vbCrLf & "fue capturado exitosamente", "Captura Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)


                                Else
                                    'la serie salio diferente en ambos campos 
                                    'se bloquea por serie incongruente

                                    MessageBox.Show("Serie Incongruente")
                                    lock_sistema(txt_no_parte_hoja_viajera.Text,
                                      txt_no_parte_maquina.Text,
                                      txt_no_parte_caja.Text,
                                      txt_serie_maquina.Text,
                                      txt_serie_caja.Text,
                                      txt_zln_maquina.Text,
                                      txt_zln_caja.Text,
                             "Serie Incongruente")

                                End If

                            Else

                                'zln incongruente'
                                MessageBox.Show("ZLN Incongruente")
                                lock_sistema(txt_no_parte_hoja_viajera.Text,
                                      txt_no_parte_maquina.Text,
                                      txt_no_parte_caja.Text,
                                      txt_serie_maquina.Text,
                                      txt_serie_caja.Text,
                                      txt_zln_maquina.Text,
                                      txt_zln_caja.Text,
                             "ZLN Incongruente")

                            End If



                        Else
                            'zln duplicado
                            MessageBox.Show("ZLN DUplicado")
                            lock_sistema(txt_no_parte_hoja_viajera.Text,
                                  txt_no_parte_maquina.Text,
                                  txt_no_parte_caja.Text,
                                  txt_serie_maquina.Text,
                                  txt_serie_caja.Text,
                                  txt_zln_maquina.Text,
                                  txt_zln_caja.Text,
                         "ZLN Duplicado")
                        End If


                    Else
                        'numero de serie ya existe
                        MessageBox.Show("Serie Duplicada")
                        lock_sistema(txt_no_parte_hoja_viajera.Text,
                                  txt_no_parte_maquina.Text,
                                  txt_no_parte_caja.Text,
                                  txt_serie_maquina.Text,
                                  txt_serie_caja.Text,
                                  txt_zln_maquina.Text,
                                  txt_zln_caja.Text,
                         "Serie Duplicado")
                    End If
                Else

                    'los numeros de parte no coincidieron
                    MessageBox.Show("Numeros de parte no coinciden")
                    lock_sistema(txt_no_parte_hoja_viajera.Text,
                                  txt_no_parte_maquina.Text,
                                  txt_no_parte_caja.Text,
                                  txt_serie_maquina.Text,
                                  txt_serie_caja.Text,
                                  txt_zln_maquina.Text,
                                  txt_zln_caja.Text,
                         "Numeros de parte no coinciden")
                End If


            End If

            If (serie_r = True And zln_r = False) Then
                'estar aqui es por que el nunmero de parte lleva serie pero no zln , solo 
                'necesitamos validar serie , si esta correcta podemos ya guardarlo como produccion
                'se validara en este orden : que sean iguales y despues que no existan 
                'para poder generar errores separados en caso de que pasen.

                If (txt_no_parte_hoja_viajera.Text = txt_no_parte_caja.Text) And (txt_no_parte_hoja_viajera.Text = txt_no_parte_maquina.Text) Then

                    'los numeros de parte si coinciden

                    If (lock_serie(txt_serie_maquina.Text) = 0) Then
                        'numero de serie no esta duplicado'
                        If txt_serie_caja.Text = txt_serie_maquina.Text Then
                            'zln limpio
                            'serie limpia
                            'todo limpio hasta aqui , se guardan los datos.
                            Dim timestamp As String
                            timestamp = Date.Now.Year.ToString & Date.Now.Month.ToString & Date.Now.Day.ToString & Date.Now.Hour.ToString & Date.Now.Minute.ToString & Date.Now.Second.ToString & Date.Now.Millisecond.ToString

                            guardar_produccion(txt_no_parte_hoja_viajera.Text,
                                   txt_no_parte_maquina.Text,
                                   txt_serie_maquina.Text,
                                           timestamp)

                            MessageBox.Show("El numero de parte: " & txt_no_parte_maquina.Text & " con numero de serie : " & txt_serie_maquina.Text & vbCrLf & "fue capturado exitosamente", "Captura Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Else
                            'la serie salio diferente en ambos campos 
                            'se bloquea por serie incongruente

                            MessageBox.Show("Serie Incongruente")



                            lock_sistema(txt_no_parte_hoja_viajera.Text,
                                      txt_no_parte_maquina.Text,
                                      txt_no_parte_caja.Text,
                                      txt_serie_maquina.Text,
                                      txt_serie_caja.Text,
                                      txt_zln_maquina.Text,
                                      txt_zln_caja.Text,
                             "Serie Incongruente")

                        End If

                    Else
                        'numero de serie ya existe
                        MessageBox.Show("Serie Duplicada")
                        lock_sistema(txt_no_parte_hoja_viajera.Text,
                                  txt_no_parte_maquina.Text,
                                  txt_no_parte_caja.Text,
                                  txt_serie_maquina.Text,
                                  txt_serie_caja.Text,
                                  txt_zln_maquina.Text,
                                  txt_zln_caja.Text,
                         "Serie Duplicado")
                    End If
                Else

                    'los numeros de parte no coincidieron
                    MessageBox.Show("Numeros de parte no coinciden")
                    lock_sistema(txt_no_parte_hoja_viajera.Text,
                                  txt_no_parte_maquina.Text,
                                  txt_no_parte_caja.Text,
                                  txt_serie_maquina.Text,
                                  txt_serie_caja.Text,
                                  txt_zln_maquina.Text,
                                  txt_zln_caja.Text,
                         "Numeros de parte no coinciden")
                End If

            End If

            If (serie_r = False And zln_r = False) Then
                'aqui se entiende que es un numero de parte no serializado , directamente se puede cargar el 
                'producto , pensaremos en validar que el numero de parte este en la base
                'se validara en este orden : que sean iguales y despues que no existan 
                'para poder generar errores separados en caso de que pasen.


                If (txt_no_parte_hoja_viajera.Text = txt_no_parte_caja.Text) And (txt_no_parte_hoja_viajera.Text = txt_no_parte_maquina.Text) Then

                    'los numeros de parte si coinciden
                    Dim timestamp As String
                    timestamp = Date.Now.Year.ToString & Date.Now.Month.ToString & Date.Now.Day.ToString & Date.Now.Hour.ToString & Date.Now.Minute.ToString & Date.Now.Second.ToString & Date.Now.Millisecond.ToString

                    guardar_produccion(txt_no_parte_hoja_viajera.Text,
                                   txt_no_parte_maquina.Text,
                                   timestamp,
                                           timestamp)

                    MessageBox.Show("El numero de parte: " & txt_no_parte_maquina.Text & vbCrLf & "fue capturado exitosamente", "Captura Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)


                Else
                    'los numeros de parte no coincidieron
                    MessageBox.Show("Numeros de parte no coinciden")
                    lock_sistema(txt_no_parte_hoja_viajera.Text,
                                  txt_no_parte_maquina.Text,
                                  txt_no_parte_caja.Text,
                                  txt_serie_maquina.Text,
                                  txt_serie_caja.Text,
                                  txt_zln_maquina.Text,
                                  txt_zln_caja.Text,
                         "Numeros de parte no coinciden")
                End If





            End If

        Else
            'si llego aqui es por que le faltaron datos al formulario
            'la funcion locl_datos faltantes toma en cuanta si deberia o no llevar zln es
            'es decir aunque le pases zln en blancos si se supone que no debe llevar
            'te lo va pasar como correcto'
            lock_sistema(txt_no_parte_hoja_viajera.Text,
                                  txt_no_parte_maquina.Text,
                                  txt_no_parte_caja.Text,
                                  txt_serie_maquina.Text,
                                  txt_serie_caja.Text,
                                  txt_zln_maquina.Text,
                                  txt_zln_caja.Text,
                         "El formulario presenta datos incompletos")
        End If




        reset_formulario()

    End Sub

    Sub guardar_produccion(ByVal empleado As String,
                           ByVal no_parte As String,
                           ByVal serie As String,
                           ByVal zln As String)




        If SQLConn.State = ConnectionState.Open Then
            SQLConn.Close()
        Else
            SQLConn.ConnectionString = conexion
        End If


        Dim cmd As New SqlCommand("usp_add_produccion2", SQLConn)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@no_empleado", SqlDbType.VarChar)
        cmd.Parameters("@no_empleado").Value = Environment.UserDomainName & "\" & Environment.UserName

        cmd.Parameters.Add("@no_parte", SqlDbType.VarChar)
        cmd.Parameters("@no_parte").Value = no_parte


        cmd.Parameters.Add("@serie", SqlDbType.VarChar)
        cmd.Parameters("@serie").Value = serie


        cmd.Parameters.Add("@zln", SqlDbType.VarChar)
        cmd.Parameters("@zln").Value = zln

        read_single(cmd)
    End Sub
    Function lock_no_parte(ByVal no_parte As String,
                            ByVal no_parte_a As String)

        Dim _ret_val As Int16

        _ret_val = 0

        If (no_parte = no_parte_a) Then
            _ret_val = 1
        End If



        Return _ret_val
    End Function

    Public Sub reset_formulario()

        txt_no_parte_hoja_viajera.Text = ""
        txt_no_parte_maquina.Text = ""
        txt_no_parte_caja.Text = ""
        txt_serie_maquina.Text = ""
        txt_serie_caja.Text = ""
        txt_zln_maquina.Text = ""
        txt_zln_caja.Text = ""

        txt_zln_caja.Enabled = False
        txt_zln_maquina.Enabled = False
        txt_serie_caja.Enabled = False
        txt_serie_maquina.Enabled = False
    End Sub

    Function lock_datos_faltantes(ByVal no_parte_hoja_viajera As String,
                                  ByVal no_parte_maquina As String,
                                  ByVal no_parte_caja As String,
                                  ByVal serie_maquina As String,
                                  ByVal serie_caja As String,
                                  ByVal zln_maquina As String,
                                  ByVal zln_caja As String)


        Dim _ret_val As Int16 = 0



        If (serie_r = False) And (zln_r = False) Then
            If (no_parte_hoja_viajera <> "") And (no_parte_maquina <> "") And (no_parte_caja <> "") Then
                'si ninguno esta en blanco no hay pedo'
                _ret_val = 1
            Else
                'alguno salio en blanco , aqui hay pedo
                _ret_val = 0
            End If

        End If

        If (serie_r = True) And (zln_r = False) Then
            If (no_parte_hoja_viajera <> "") And (no_parte_maquina <> "") And (no_parte_caja <> "") And (serie_maquina <> "") And (serie_caja <> "") Then
                'si ninguno esta en blanco no hay pedo'
                _ret_val = 1
            Else
                'alguno salio en blanco , aqui hay pedo
                _ret_val = 0
            End If
        End If

        If (serie_r = True) And (zln_r = True) Then
            If (no_parte_hoja_viajera <> "") And (no_parte_maquina <> "") And (no_parte_caja <> "") And (serie_maquina <> "") And (serie_caja <> "") And (zln_maquina <> "") And (zln_caja <> "") Then
                'si ninguno esta en blanco no hay pedo'
                _ret_val = 1
            Else
                'alguno salio en blanco , aqui hay pedo
                _ret_val = 0
            End If

        End If


        Return _ret_val
    End Function

    Function lock_sistema(ByVal empleado As String,
                                  ByVal no_parte_maquina As String,
                                  ByVal no_parte_caja As String,
                                  ByVal serie_maquina As String,
                                  ByVal serie_caja As String,
                                  ByVal zln_maquina As String,
                                  ByVal zln_caja As String,
                                  ByVal _msg As String)

        If SQLConn.State = ConnectionState.Open Then
            SQLConn.Close()
        Else
            SQLConn.ConnectionString = conexion
        End If


        Dim cmd As New SqlCommand("usp_embarque_lock", SQLConn)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@no_parte_caja", SqlDbType.VarChar)
        cmd.Parameters("@no_parte_caja").Value = no_parte_caja

        cmd.Parameters.Add("@no_parte_maquina", SqlDbType.VarChar)
        cmd.Parameters("@no_parte_maquina").Value = no_parte_maquina

        cmd.Parameters.Add("@empleado", SqlDbType.VarChar)
        cmd.Parameters("@empleado").Value = empleado

        cmd.Parameters.Add("@serie_caja", SqlDbType.VarChar)
        cmd.Parameters("@serie_caja").Value = serie_caja

        cmd.Parameters.Add("@serie_maquina", SqlDbType.VarChar)
        cmd.Parameters("@serie_maquina").Value = serie_maquina

        cmd.Parameters.Add("@zln_caja", SqlDbType.VarChar)
        cmd.Parameters("@zln_caja").Value = zln_caja

        cmd.Parameters.Add("@zln_maquina", SqlDbType.VarChar)
        cmd.Parameters("@zln_maquina").Value = zln_maquina

        cmd.Parameters.Add("@username", SqlDbType.VarChar)
        cmd.Parameters("@username").Value = Environment.UserDomainName + "\" + Environment.UserName

        cmd.Parameters.Add("@computer", SqlDbType.VarChar)
        cmd.Parameters("@computer").Value = Environment.MachineName


        send_password(empleado,
                               no_parte_maquina,
                                   no_parte_caja,
                                   serie_maquina,
                                   serie_caja,
                                   zln_maquina,
                                   zln_caja,
                      _msg)

        Me.Hide()
        msg = _msg
        audit.Show()

        Return read_single(cmd)

    End Function

    Function lock_serie(ByVal serie As String
                                  )

        If SQLConn.State = ConnectionState.Open Then
            SQLConn.Close()
        Else
            SQLConn.ConnectionString = conexion
        End If


        Dim cmd As New SqlCommand("usp_embarque_audit_serie", SQLConn)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@serie", SqlDbType.VarChar)
        cmd.Parameters("@serie").Value = serie

        Return read_single(cmd)


    End Function

    Function lock_zln(ByVal zln As String
                                  )

        If SQLConn.State = ConnectionState.Open Then
            SQLConn.Close()
        Else
            SQLConn.ConnectionString = conexion
        End If


        Dim cmd As New SqlCommand("usp_embarque_audit_zln", SQLConn)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@zln", SqlDbType.VarChar)
        cmd.Parameters("@zln").Value = zln

        Return read_single(cmd)


    End Function
    Function read_single(ByVal cmd As SqlCommand)
        Dim _output As String
        _output = 0
        Try
            SQLConn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                If reader(0) = Nothing Then
                    Return 0
                Else
                    _output = reader(0)
                End If

            End While
            reader.Close()

        Catch error_lectura As Exception
            _output = 23
            MsgBox(error_lectura.Message)

        Finally
            SQLConn.Close()

        End Try
        Return _output
    End Function

    Function zln_required(ByVal no_parte As String
                                  )

        If SQLConn.State = ConnectionState.Open Then
            SQLConn.Close()
        Else
            SQLConn.ConnectionString = conexion
        End If


        Dim cmd As New SqlCommand("usp_embarque_ZLN_req", SQLConn)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@no_parte", SqlDbType.VarChar)
        cmd.Parameters("@no_parte").Value = no_parte

        Return read_single(cmd)


    End Function

    Function serie_required(ByVal no_parte As String
                                  )

        If SQLConn.State = ConnectionState.Open Then
            SQLConn.Close()
        Else
            SQLConn.ConnectionString = conexion
        End If


        Dim cmd As New SqlCommand("usp_embarque_serie_req", SQLConn)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@no_parte", SqlDbType.VarChar)
        cmd.Parameters("@no_parte").Value = no_parte

        Return read_single(cmd)


    End Function

    Function lock_no_parte(ByVal no_parte As String
                                  )

        If SQLConn.State = ConnectionState.Open Then
            SQLConn.Close()
        Else
            SQLConn.ConnectionString = conexion
        End If


        Dim cmd As New SqlCommand("usp_embarque_audit_no_parte", SQLConn)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@no_parte", SqlDbType.VarChar)
        cmd.Parameters("@no_parte").Value = no_parte

        Return read_single(cmd)


    End Function

    Private Sub empaque_Load(sender As Object, e As EventArgs)
        lbl_rev.Text = "Rev. " & My.Application.Info.Version.ToString
        txt_serie_maquina.Enabled = False
        txt_serie_caja.Enabled = False
        txt_zln_maquina.Enabled = False
        txt_zln_caja.Enabled = False
    End Sub

    Public Function check_lock()


        If SQLConn.State = ConnectionState.Open Then
            SQLConn.Close()
        Else
            SQLConn.ConnectionString = conexion
        End If


        Dim cmd As New SqlCommand("usp_embarque_lock_status", SQLConn)
        cmd.CommandType = CommandType.StoredProcedure

        Return read_single(cmd)
    End Function

    Public Function unlock_sistema()


        If SQLConn.State = ConnectionState.Open Then
            SQLConn.Close()
        Else
            SQLConn.ConnectionString = conexion
        End If


        Dim cmd As New SqlCommand("usp_embarque_unlock", SQLConn)
        cmd.CommandType = CommandType.StoredProcedure

        Return read_single(cmd)
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles lock_check.Tick


        If check_lock() = 0 Then

        Else
            Me.Hide()
            msg = "Incidente detectado en otro equipo de empaque"
            audit.Show()
            lock_check.Enabled = False
        End If
    End Sub

    Private Sub txt_no_parte_hoja_viajera_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txt_no_parte_hoja_viajera.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then


        End If
        If e.KeyCode = Keys.Enter Then
            'Si detecta Enter hace todo el show
            'primero revisa que ese numero de parte exista , si no hay que darlo de alta

            If lock_no_parte(txt_no_parte_hoja_viajera.Text) = 1 Then
                'si existe el numero de parte

                ' determina si lleva serie y tambien ZLLN
                'para saber que campos va a poner en disable , por default estan apagados


                If (zln_required(txt_no_parte_hoja_viajera.Text) = "True") Then
                    txt_zln_caja.Enabled = True
                    txt_zln_maquina.Enabled = True
                    zln_r = True

                Else
                    txt_zln_caja.Enabled = False
                    txt_zln_maquina.Enabled = False
                    zln_r = False
                End If

                If (serie_required(txt_no_parte_hoja_viajera.Text) = 1) Then
                    txt_serie_caja.Enabled = True
                    txt_serie_maquina.Enabled = True
                    serie_r = True

                Else
                    txt_serie_caja.Enabled = False
                    txt_serie_maquina.Enabled = False
                    serie_r = False

                End If


                If (txt_no_parte_hoja_viajera.Text <> "") Then
                    SendKeys.Send("{TAB}")

                Else
                    'el campo si tiene algo pero no empieza con ZLN
                    MessageBox.Show("El campo no puede estar en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Hand)

                    txt_no_parte_hoja_viajera.SelectAll()
                End If
            Else
                'el numero de parte no existe
                MessageBox.Show("El numero de parte no esta registado", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txt_no_parte_hoja_viajera.SelectAll()

            End If


        End If
    End Sub

    Private Sub txt_no_parte_maquina_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txt_no_parte_maquina.PreviewKeyDown
        'Es la migracion del evento leave al preview key para poder detectar que se presiona un enter

        If e.KeyCode = Keys.Tab Then


        End If
        If (e.KeyCode = Keys.Enter) Then
            If (txt_no_parte_maquina.Text <> "") Then
                SendKeys.Send("{TAB}")
            Else
                MessageBox.Show("El campo no puede estar en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txt_no_parte_maquina.SelectAll()
            End If



        End If
    End Sub

    Private Sub txt_no_parte_caja_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txt_no_parte_caja.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then


        End If
        If e.KeyCode = Keys.Enter Then
            'Si detecta Enter hace todo el show
            'primero determina si lleva serie y tambien ZLLN
            'para saber que campos va a poner en disable , por default estan apagados

            If (txt_no_parte_caja.Text <> "") Then

                If (serie_r = False And zln_r = False) Then
                    'Si esta pieza solo usa serie , escaneando la ultima serie se sale y hace todo el show
                    ultimo_dato()
                    SendKeys.Send("{TAB}")
                Else
                    SendKeys.Send("{TAB}")
                End If
            Else
                MessageBox.Show("El campo no puede estar en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                txt_no_parte_caja.SelectAll()
            End If


        End If

    End Sub

    Private Sub txt_serie_maquina_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txt_serie_maquina.PreviewKeyDown
        If (e.KeyCode = Keys.Enter) Then

            If (txt_serie_maquina.Text <> "") Then
                SendKeys.Send("{TAB}")
            Else
                MessageBox.Show("El campo no puede estar en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                txt_serie_maquina.SelectAll()
            End If

        End If
    End Sub

    Private Sub txt_serie_caja_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txt_serie_caja.PreviewKeyDown
        'Es la migracion del evento leave al preview key para poder detectar que se presiona un enter

        If (e.KeyCode = Keys.Enter) Then

            If (txt_serie_caja.Text <> "") Then

                If (serie_r = True And zln_r = False) Then
                    'Si esta pieza solo usa serie , escaneando la ultima serie se sale y hace todo el show
                    ultimo_dato()
                End If

                If (serie_r = True And zln_r = True) Then
                    SendKeys.Send("{TAB}")
                End If

            Else
                MessageBox.Show("El campo no puede estar en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                txt_serie_caja.SelectAll()
            End If

        End If
    End Sub

    Private Sub txt_zln_maquina_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txt_zln_maquina.PreviewKeyDown
        If (e.KeyCode = Keys.Enter) Then

            If (txt_zln_maquina.Text <> "") Then
                Dim zln_verificacion As String = ""
                Try
                    zln_verificacion = txt_zln_maquina.Text.Substring(0, 3)
                Catch ex As Exception
                    zln_verificacion = ""
                End Try
                If zln_verificacion = "ZIL" Then
                    'el campo empieza con ZLN
                    ' se agrega el OR ZIL por correo de juan hernandez / brian biper 4/2/19 10:am para
                    'agrgar tambien numeracon ZIL
                    SendKeys.Send("{TAB}")
                Else
                    'el campo si tiene algo pero no empieza con ZLN
                    MessageBox.Show("Dato no corresponde a ZLN 04/02", "Error en ZLN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                MessageBox.Show("El campo no puede estar en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Hand)

                txt_zln_maquina.SelectAll()
            End If




        End If
    End Sub
    Private Sub txt_zln_caja_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txt_zln_caja.PreviewKeyDown
        'Es la migracion del evento leave al preview key para poder detectar que se presiona un enter

        If e.KeyCode = Keys.Tab Then

        End If
        If (e.KeyCode = Keys.Enter) Then
            If (txt_zln_caja.Text <> "") Then

                'este pedazo lo que hace es confirmar que lo que se haya escrito comienze con ZLN algo
                Dim zln_verificacion As String = ""
                Try
                    zln_verificacion = txt_zln_caja.Text.Substring(0, 3)
                Catch ex As Exception
                    zln_verificacion = ""
                End Try
                ' hasta aqui lo de la pendejada del zln


                If zln_verificacion = "ZIL" Then
                    'el campo empieza con ZLN
                    ultimo_dato()
                    '                    SendKeys.Send("{TAB}")

                Else
                    'el campo si tiene algo pero no empieza con ZLN
                    MessageBox.Show("Dato no corresponde a ZLN", "Error en ZLN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txt_zln_caja.SelectAll()
                End If

            Else
                MessageBox.Show("El campo no puede estar en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                txt_zln_caja.SelectAll()
            End If

        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub empaque_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        lbl_rev.Text = "Rev. " & My.Application.Info.Version.MinorRevision.ToString
    End Sub
End Class
