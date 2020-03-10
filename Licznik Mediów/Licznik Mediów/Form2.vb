Public Class Form2


    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Lab_PC.Text = GetUserName()

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button_drukuj.Click

        TextBox1.BorderStyle = BorderStyle.None
        TextBox2.BorderStyle = BorderStyle.None
        TextBox1.BackColor = Color.White
        TextBox2.BackColor = Color.White

        PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)
        'PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.Scrollable)
        'PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.FullWindow)

        Me.Hide()

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button_anuluj.Click
        Me.Hide()
    End Sub


    Private Sub Button_czysc_Click(sender As Object, e As EventArgs) Handles Button_czysc.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Focus()
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.BorderStyle = BorderStyle.None
        TextBox2.BorderStyle = BorderStyle.None
        TextBox1.BackColor = Color.White
        TextBox2.BackColor = Color.White

        'PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)
        PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.Scrollable)
        'PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.FullWindow)

        Me.Hide()

    End Sub


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        TextBox1.BorderStyle = BorderStyle.None
        TextBox2.BorderStyle = BorderStyle.None
        TextBox1.BackColor = Color.White
        TextBox2.BackColor = Color.White

        'PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)
        'PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.Scrollable)
        PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.FullWindow)

        Me.Hide()

    End Sub


    'funkcja zweacajaca nazwe komputera
    Function GetUserName() As String
        If TypeOf My.User.CurrentPrincipal Is
          Security.Principal.WindowsPrincipal Then
            ' The application is using Windows authentication.
            ' The name format is DOMAIN\USERNAME.
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            Return username
        Else
            ' The application is using custom authentication.
            Return My.User.Name
        End If
    End Function

End Class