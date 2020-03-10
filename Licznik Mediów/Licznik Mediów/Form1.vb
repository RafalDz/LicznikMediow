Public Class Form1

    Dim Wersja As String


    Dim Xuz, Yuz, Xspd, Yspd, Xods, Yods, Ilosc, Il_bigow, Xark, Yark, Margines, Znacznik As Single
    Dim Pierwszy_uz_x, Pierwszy_uz_y, Kolejne_uz_x, Kolejne_uz_y As Single
    Dim PoleDrukX, PoleDrukY, IleArkuszy, DrukSide As Single
    Dim IleX, IleY, WyborUzy As Integer
    Dim Pic_x_str, Pic_y_str, Pic_x_uzt, Pic_y_uzt As Integer
    Dim KrokX, KrokY, Format, DrukColor, RabatByl As Integer
    Dim KrokX_suma, KrokY_suma, CentrujX, CentrujY As Integer
    Dim wielkosc_rys_uzytków_pkt_x, wielkosc_rys_uzytków_pkt_y As Integer
    Dim zazn, rabIlosc As Boolean

    Dim Medium, DrukRodzaj, wybranyArkusz As String

    Dim filename1, filename2, filename3, filename4, filename5, filename6 As String

    Dim druk_ilosc, papier_ilosc, ciecie_ilosc, bigowanie_ilosc, inne_ilosc As Integer
    Dim WB_cena, WN_cena, druk_cena, druk_cenaJ, papier_cena, papier_cenaJ, ciecie_cena, ciecie_cenaJ, bigowanie_cena, bigowanie_cenaJ, inne_cena, inne_cenaJ As Single




    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Wersja = "Licznik Mediów 0.5e (Beta)"
        Me.Text = Wersja

        ' sciezki przy projektowaniu
        ' filename1 = "C:\Users\Blondyn\Desktop\Licznik_mediów_pliki\\kolor.dat"
        ' filename2 = "C:\Users\Blondyn\Desktop\Licznik_mediów_pliki\\czarny.dat"
        ' filename3 = "C:\Users\Blondyn\Desktop\Licznik_mediów_pliki\\dcp.dat"
        ' filename4 = "C:\Users\Blondyn\Desktop\Licznik_mediów_pliki\\mat.dat"
        ' filename5 = "C:\Users\Blondyn\Desktop\Licznik_mediów_pliki\\blysk.dat"
        ' filename6 = "C:\Users\Blondyn\Desktop\Licznik_mediów_pliki\\inne.dat"

        'sciezki docelowe
        filename1 = Application.StartupPath & "\kolor.dat"
        filename2 = Application.StartupPath & "\czarny.dat"
        filename3 = Application.StartupPath & "\dcp.dat"
        filename4 = Application.StartupPath & "\mat.dat"
        filename5 = Application.StartupPath & "\blysk.dat"
        filename6 = Application.StartupPath & "\inne.dat"

        WczytajCennikKolor()
        WczytajCennikCzarny()
        WczytajCennikDCP()
        WczytajCennikMat()
        WczytajCennikBlysk()
        WczytajCennikInne()
        zazn = True
        odswierz()

    End Sub

    ' obsługa klawiszy w tle
    Private Sub Form1_Klawisz(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        Ekran.Text = e.KeyCode
        If e.KeyCode = 13 Then Button10.BackColor = Color.Gainsboro  ' 13- enter
        If e.KeyCode = 112 Then RB_uzytki.Checked = True             ' 112- F1
        If e.KeyCode = 113 Then RB_strony.Checked = True             ' 113- F2
        If e.KeyCode = 17 Then                                       ' 17- Ctrl
            If CB_Obrot.Checked = True Then
                CB_Obrot.Checked = False
            Else
                CB_Obrot.Checked = True
            End If
        End If
        odswierz()
    End Sub

    Private Sub Form1_Klawisz_down(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = 13 Then ' 13- enter
            Oblicz()
            Button10.BackColor = Color.AntiqueWhite
        End If

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.MouseUp
        Oblicz()
    End Sub

    Private Sub Button10_down(sender As Object, e As EventArgs) Handles Button10.MouseDown
        odswierz()
    End Sub

    Sub WczytajCennikKolor()
        ' '' Odczyt pliku i wypelnienie danymi DataGirdView

        Dim ciag As String
        ciag = My.Computer.FileSystem.ReadAllText(filename1)

        'deklaracja zmiennych
        Dim ccc() As String = ciag.Split("/"c) ' znak oddzielajacy dane to /
        Dim dl As Integer = (ccc.Length / 5) - 1 ' 5- ilosc danych w jednym wierszu... 1/2/3/4/5/
        Dim licznik = 0
        'jesli tabelka nie ma wierszy dodaj wiersze
        If DataGridView_kolor.RowCount = 0 Then DataGridView_kolor.Rows.Add(dl + 1)

        For wiersz = 0 To dl
            For komorka = 0 To 4 '4- to ilosc kolumn liczone od 0
                If komorka = 0 Then
                    Dim PoleFormat As String = (ccc(licznik))
                    DataGridView_kolor.Rows(wiersz).Cells(komorka).Value = PoleFormat
                Else
                    Dim PoleCena As Single = (ccc(licznik))
                    DataGridView_kolor.Rows(wiersz).Cells(komorka).Value = PoleCena
                End If
                licznik = licznik + 1
            Next komorka
        Next wiersz

    End Sub

    Sub WczytajCennikCzarny()
        ' '' Odczyt pliku i wypelnienie danymi DataGirdView

        Dim ciag As String
        ciag = My.Computer.FileSystem.ReadAllText(filename2)

        'deklaracja zmiennych
        Dim ccc() As String = ciag.Split("/"c) ' znak oddzielajacy dane to /
        Dim dl As Integer = (ccc.Length / 6) - 1 ' 6- ilosc danych w jednym wierszu... 1/2/3/4/5/
        Dim licznik = 0
        'jesli tabelka nie ma wierszy dodaj wiersze
        If DataGridView_czarny.RowCount = 0 Then DataGridView_czarny.Rows.Add(dl + 1)

        For wiersz = 0 To dl
            For komorka = 0 To 5 '5- to ilosc kolumn liczone od 0
                If komorka = 0 Then
                    Dim PoleFormat As String = (ccc(licznik))
                    DataGridView_czarny.Rows(wiersz).Cells(komorka).Value = PoleFormat
                Else
                    Dim PoleCena As Single = (ccc(licznik))
                    DataGridView_czarny.Rows(wiersz).Cells(komorka).Value = PoleCena
                End If
                licznik = licznik + 1
            Next komorka
        Next wiersz

    End Sub

    Sub WczytajCennikDCP()
        ' '' Odczyt pliku i wypelnienie danymi DataGirdView

        Dim ciag As String
        ciag = My.Computer.FileSystem.ReadAllText(filename3)

        'deklaracja zmiennych
        Dim ccc() As String = ciag.Split("/"c) ' znak oddzielajacy dane to /
        Dim dl As Integer = (ccc.Length / 7) - 1 ' 7- ilosc danych w jednym wierszu... 1/2/3/4/5/
        Dim licznik = 0
        'jesli tabelka nie ma wierszy dodaj wiersze
        If DataGridView_dcp.RowCount = 0 Then DataGridView_dcp.Rows.Add(dl + 1)

        For wiersz = 0 To dl
            For komorka = 0 To 6 '6- to ilosc kolumn liczone od 0
                If komorka = 0 Then
                    Dim PoleFormat As String = (ccc(licznik))
                    DataGridView_dcp.Rows(wiersz).Cells(komorka).Value = PoleFormat
                Else
                    Dim PoleCena As Single = (ccc(licznik))
                    DataGridView_dcp.Rows(wiersz).Cells(komorka).Value = PoleCena
                End If
                licznik = licznik + 1
            Next komorka
        Next wiersz

    End Sub

    Sub WczytajCennikMat()
        ' '' Odczyt pliku i wypelnienie danymi DataGirdView

        Dim ciag As String
        ciag = My.Computer.FileSystem.ReadAllText(filename4)

        'deklaracja zmiennych
        Dim ccc() As String = ciag.Split("/"c) ' znak oddzielajacy dane to /
        Dim dl As Integer = (ccc.Length / 7) - 1 ' 7- ilosc danych w jednym wierszu... 1/2/3/4/5/
        Dim licznik = 0
        'jesli tabelka nie ma wierszy dodaj wiersze
        If DataGridView_mat.RowCount = 0 Then DataGridView_mat.Rows.Add(dl + 1)

        For wiersz = 0 To dl
            For komorka = 0 To 6 '6- to ilosc kolumn liczone od 0
                If komorka = 0 Then
                    Dim PoleFormat As String = (ccc(licznik))
                    DataGridView_mat.Rows(wiersz).Cells(komorka).Value = PoleFormat
                Else
                    Dim PoleCena As Single = (ccc(licznik))
                    DataGridView_mat.Rows(wiersz).Cells(komorka).Value = PoleCena
                End If
                licznik = licznik + 1
            Next komorka
        Next wiersz

    End Sub

    Sub WczytajCennikBlysk()
        ' '' Odczyt pliku i wypelnienie danymi DataGirdView

        Dim ciag As String
        ciag = My.Computer.FileSystem.ReadAllText(filename5)

        'deklaracja zmiennych
        Dim ccc() As String = ciag.Split("/"c) ' znak oddzielajacy dane to /
        Dim dl As Integer = (ccc.Length / 7) - 1 ' 7- ilosc danych w jednym wierszu... 1/2/3/4/5/
        Dim licznik = 0
        'jesli tabelka nie ma wierszy dodaj wiersze
        If DataGridView_blysk.RowCount = 0 Then DataGridView_blysk.Rows.Add(dl + 1)

        For wiersz = 0 To dl
            For komorka = 0 To 6 '6- to ilosc kolumn liczone od 0
                If komorka = 0 Then
                    Dim PoleFormat As String = (ccc(licznik))
                    DataGridView_blysk.Rows(wiersz).Cells(komorka).Value = PoleFormat
                Else
                    Dim PoleCena As Single = (ccc(licznik))
                    DataGridView_blysk.Rows(wiersz).Cells(komorka).Value = PoleCena
                End If
                licznik = licznik + 1
            Next komorka
        Next wiersz

    End Sub

    Sub WczytajCennikInne()
        ' '' Odczyt pliku i wypelnienie danymi DataGirdView

        Dim ciag As String
        ciag = My.Computer.FileSystem.ReadAllText(filename6)

        'deklaracja zmiennych
        Dim ccc() As String = ciag.Split("/"c) ' znak oddzielajacy dane to /
        Dim dl As Integer = (ccc.Length / 3) - 1 ' 3- ilosc danych w jednym wierszu... 1/2/3/
        Dim licznik = 0
        'jesli tabelka nie ma wierszy dodaj wiersze
        If DataGridView_inne.RowCount = 0 Then DataGridView_inne.Rows.Add(dl + 1)

        For wiersz = 0 To dl
            For komorka = 0 To 2 '2- to ilosc kolumn liczone od 0
                If komorka <= 1 Then
                    Dim PoleFormat As String = (ccc(licznik))
                    DataGridView_inne.Rows(wiersz).Cells(komorka).Value = PoleFormat
                Else
                    Dim PoleCena As Single = (ccc(licznik))
                    DataGridView_inne.Rows(wiersz).Cells(komorka).Value = PoleCena
                End If
                licznik = licznik + 1
            Next komorka
        Next wiersz

    End Sub

    Sub drukCenaJednostkowa()

        If Format = 4 And DrukColor = 0 Then
            Select Case druk_ilosc
                Case 1 To 10
                    Txt_WB_druk_cenaJ.Text = DataGridView_czarny.Rows(0).Cells(1).Value
                Case 11 To 100
                    Txt_WB_druk_cenaJ.Text = DataGridView_czarny.Rows(0).Cells(2).Value : rabIlosc = True
                Case 101 To 1000
                    Txt_WB_druk_cenaJ.Text = DataGridView_czarny.Rows(0).Cells(3).Value : rabIlosc = True
                Case 1001 To 10000
                    Txt_WB_druk_cenaJ.Text = DataGridView_czarny.Rows(0).Cells(4).Value : rabIlosc = True
                Case > 10000
                    Txt_WB_druk_cenaJ.Text = DataGridView_czarny.Rows(0).Cells(5).Value : rabIlosc = True
            End Select
        End If

        If Format = 3 And DrukColor = 0 Then
            Select Case druk_ilosc
                Case 1 To 10
                    Txt_WB_druk_cenaJ.Text = DataGridView_czarny.Rows(1).Cells(1).Value
                Case 11 To 100
                    Txt_WB_druk_cenaJ.Text = DataGridView_czarny.Rows(1).Cells(2).Value : rabIlosc = True
                Case 101 To 1000
                    Txt_WB_druk_cenaJ.Text = DataGridView_czarny.Rows(1).Cells(3).Value : rabIlosc = True
                Case 1001 To 10000
                    Txt_WB_druk_cenaJ.Text = DataGridView_czarny.Rows(1).Cells(4).Value : rabIlosc = True
                Case > 10000
                    Txt_WB_druk_cenaJ.Text = DataGridView_czarny.Rows(1).Cells(5).Value : rabIlosc = True
            End Select
        End If

        If Format = 4 And DrukColor = 1 Then
            Select Case druk_ilosc
                Case 1 To 20
                    Txt_WB_druk_cenaJ.Text = DataGridView_kolor.Rows(0).Cells(1).Value
                Case 21 To 100
                    Txt_WB_druk_cenaJ.Text = DataGridView_kolor.Rows(0).Cells(2).Value : rabIlosc = True
                Case 101 To 300
                    Txt_WB_druk_cenaJ.Text = DataGridView_kolor.Rows(0).Cells(3).Value : rabIlosc = True
                Case > 300
                    Txt_WB_druk_cenaJ.Text = DataGridView_kolor.Rows(0).Cells(4).Value : rabIlosc = True
            End Select
        End If

        If Format = 3 And DrukColor = 1 Then
            Select Case druk_ilosc
                Case 1 To 20
                    Txt_WB_druk_cenaJ.Text = DataGridView_kolor.Rows(1).Cells(1).Value
                Case 21 To 100
                    Txt_WB_druk_cenaJ.Text = DataGridView_kolor.Rows(1).Cells(2).Value : rabIlosc = True
                Case 101 To 300
                    Txt_WB_druk_cenaJ.Text = DataGridView_kolor.Rows(1).Cells(3).Value : rabIlosc = True
                Case > 300
                    Txt_WB_druk_cenaJ.Text = DataGridView_kolor.Rows(1).Cells(4).Value : rabIlosc = True
            End Select
        End If


    End Sub

    Sub CenaPapierDcp()

        Dim pozycja As Integer

        If Format = 4 And RB_DCP_100.Checked = True Then pozycja = 0 : Medium = "papier DCP 100g"
        If Format = 4 And RB_DCP_160.Checked = True Then pozycja = 1 : Medium = "papier DCP 160g"
        If Format = 4 And RB_DCP_200.Checked = True Then pozycja = 2 : Medium = "papier DCP 200g"
        If Format = 4 And RB_DCP_250.Checked = True Then pozycja = 3 : Medium = "papier DCP 250g"
        If Format = 4 And RB_DCP_300.Checked = True Then pozycja = 4 : Medium = "papier DCP 300g"
        If Format = 4 And RB_DCP_350.Checked = True Then pozycja = 5 : Medium = "papier DCP 350g"

        If Format = 3 And RB_DCP_100.Checked = True Then pozycja = 6 : Medium = "papier DCP 100g"
        If Format = 3 And RB_DCP_160.Checked = True Then pozycja = 7 : Medium = "papier DCP 160g"
        If Format = 3 And RB_DCP_200.Checked = True Then pozycja = 8 : Medium = "papier DCP 200g"
        If Format = 3 And RB_DCP_250.Checked = True Then pozycja = 9 : Medium = "papier DCP 250g"
        If Format = 3 And RB_DCP_300.Checked = True Then pozycja = 10 : Medium = "papier DCP 300g"
        If Format = 3 And RB_DCP_350.Checked = True Then pozycja = 11 : Medium = "papier DCP 350g"

        Select Case papier_ilosc
            Case 1 To 20
                Txt_WB_papier_cenaJ.Text = DataGridView_dcp.Rows(pozycja).Cells(2).Value
            Case 21 To 100
                Txt_WB_papier_cenaJ.Text = DataGridView_dcp.Rows(pozycja).Cells(3).Value : rabIlosc = True
            Case 101 To 200
                Txt_WB_papier_cenaJ.Text = DataGridView_dcp.Rows(pozycja).Cells(4).Value : rabIlosc = True
            Case 201 To 300
                Txt_WB_papier_cenaJ.Text = DataGridView_dcp.Rows(pozycja).Cells(5).Value : rabIlosc = True
            Case > 300
                Txt_WB_papier_cenaJ.Text = DataGridView_dcp.Rows(pozycja).Cells(6).Value : rabIlosc = True
        End Select

    End Sub

    Sub CenaPapierMat()

        Dim pozycja As Integer

        If Format = 4 And RB_MAT_150.Checked = True Then pozycja = 0 : Medium = "papier matowy 150g"
        If Format = 4 And RB_MAT_200.Checked = True Then pozycja = 1 : Medium = "papier matowy 200g"
        If Format = 4 And RB_MAT_250.Checked = True Then pozycja = 2 : Medium = "papier matowy 250g"
        If Format = 4 And RB_MAT_300.Checked = True Then pozycja = 3 : Medium = "papier matowy 300g"
        If Format = 4 And RB_MAT_350.Checked = True Then pozycja = 4 : Medium = "papier matowy 350g"

        If Format = 3 And RB_MAT_150.Checked = True Then pozycja = 5 : Medium = "papier matowy 150g"
        If Format = 3 And RB_MAT_200.Checked = True Then pozycja = 6 : Medium = "papier matowy 200g"
        If Format = 3 And RB_MAT_250.Checked = True Then pozycja = 7 : Medium = "papier matowy 250g"
        If Format = 3 And RB_MAT_300.Checked = True Then pozycja = 8 : Medium = "papier matowy 300g"
        If Format = 3 And RB_MAT_350.Checked = True Then pozycja = 9 : Medium = "papier matowy 350g"

        Select Case papier_ilosc
            Case 1 To 20
                Txt_WB_papier_cenaJ.Text = DataGridView_mat.Rows(pozycja).Cells(2).Value
            Case 21 To 100
                Txt_WB_papier_cenaJ.Text = DataGridView_mat.Rows(pozycja).Cells(3).Value : rabIlosc = True
            Case 101 To 200
                Txt_WB_papier_cenaJ.Text = DataGridView_mat.Rows(pozycja).Cells(4).Value : rabIlosc = True
            Case 201 To 300
                Txt_WB_papier_cenaJ.Text = DataGridView_mat.Rows(pozycja).Cells(5).Value : rabIlosc = True
            Case > 300
                Txt_WB_papier_cenaJ.Text = DataGridView_mat.Rows(pozycja).Cells(6).Value : rabIlosc = True
        End Select

    End Sub

    Sub CenaPapierBlysk()

        Dim pozycja As Integer

        If Format = 4 And RB_BLYSK_150.Checked = True Then pozycja = 0 : Medium = "papier błyszczący 150g"
        If Format = 4 And RB_BLYSK_200.Checked = True Then pozycja = 1 : Medium = "papier błyszczący 200g"
        If Format = 4 And RB_BLYSK_250.Checked = True Then pozycja = 2 : Medium = "papier błyszczący 250g"
        If Format = 4 And RB_BLYSK_300.Checked = True Then pozycja = 3 : Medium = "papier błyszczący 300g"
        If Format = 4 And RB_BLYSK_350.Checked = True Then pozycja = 4 : Medium = "papier błyszczący 350g"

        If Format = 3 And RB_BLYSK_150.Checked = True Then pozycja = 5 : Medium = "papier błyszczący 150g"
        If Format = 3 And RB_BLYSK_200.Checked = True Then pozycja = 6 : Medium = "papier błyszczący 200g"
        If Format = 3 And RB_BLYSK_250.Checked = True Then pozycja = 7 : Medium = "papier błyszczący 250g"
        If Format = 3 And RB_BLYSK_300.Checked = True Then pozycja = 8 : Medium = "papier błyszczący 300g"
        If Format = 3 And RB_BLYSK_350.Checked = True Then pozycja = 9 : Medium = "papier błyszczący 350g"

        Select Case papier_ilosc
            Case 1 To 20
                Txt_WB_papier_cenaJ.Text = DataGridView_blysk.Rows(pozycja).Cells(2).Value
            Case 21 To 100
                Txt_WB_papier_cenaJ.Text = DataGridView_blysk.Rows(pozycja).Cells(3).Value : rabIlosc = True
            Case 101 To 200
                Txt_WB_papier_cenaJ.Text = DataGridView_blysk.Rows(pozycja).Cells(4).Value : rabIlosc = True
            Case 201 To 300
                Txt_WB_papier_cenaJ.Text = DataGridView_blysk.Rows(pozycja).Cells(5).Value : rabIlosc = True
            Case > 300
                Txt_WB_papier_cenaJ.Text = DataGridView_blysk.Rows(pozycja).Cells(6).Value : rabIlosc = True
        End Select

    End Sub

    Sub CenaInne()

        If RB_papSam.Checked = True Then Txt_WB_papier_cenaJ.Text = DataGridView_inne.Rows(0).Cells(2).Value : Medium = "papier samoprzylepny (etykiety)"
        If RB_folRz.Checked = True Then Txt_WB_papier_cenaJ.Text = DataGridView_inne.Rows(1).Cells(2).Value : Medium = "folia do rzutnika"
        If RB_folSam.Checked = True And Format = 4 Then Txt_WB_papier_cenaJ.Text = DataGridView_inne.Rows(2).Cells(2).Value : Medium = "folia samoprzylepna"
        If RB_folSam.Checked = True And Format = 3 Then Txt_WB_papier_cenaJ.Text = DataGridView_inne.Rows(3).Cells(2).Value : Medium = "folia samoprzylepna"
        If RB_inne.Checked = True Then Txt_WB_papier_cenaJ.Text = 0 : Medium = "inne:  .............................."

    End Sub

    Sub UstawButony()

        'ustawia podswietlenie aktywnego klawisza od uzytku
        Butt_uzt_A7.BackColor = Color.Transparent
        Butt_uzt_A6.BackColor = Color.Transparent
        Butt_uzt_A5.BackColor = Color.Transparent
        Butt_uzt_A4.BackColor = Color.Transparent
        Butt_uzt_A3.BackColor = Color.Transparent
        Butt_uzt_LTR.BackColor = Color.Transparent
        Butt_uzt_SRA4.BackColor = Color.Transparent
        Butt_uzt_SRA3.BackColor = Color.Transparent
        Butt_uzt_DL.BackColor = Color.Transparent
        Butt_uzt_90x50.BackColor = Color.Transparent
        Butt_uzt_85x55.BackColor = Color.Transparent
        Butt_uzt_90x100.BackColor = Color.Transparent
        If (Xuz = 74.25 And Yuz = 105) Or (Xuz = 105 And Yuz = 74.25) Then Butt_uzt_A7.BackColor = Color.Lime
        If (Xuz = 105 And Yuz = 148.5) Or (Xuz = 148.5 And Yuz = 105) Then Butt_uzt_A6.BackColor = Color.Lime
        If (Xuz = 148.5 And Yuz = 210) Or (Xuz = 210 And Yuz = 148.5) Then Butt_uzt_A5.BackColor = Color.Lime
        If (Xuz = 210 And Yuz = 297) Or (Xuz = 297 And Yuz = 210) Then Butt_uzt_A4.BackColor = Color.Lime
        If (Xuz = 297 And Yuz = 420) Or (Xuz = 420 And Yuz = 297) Then Butt_uzt_A3.BackColor = Color.Lime
        If (Xuz = 216 And Yuz = 279) Or (Xuz = 279 And Yuz = 216) Then Butt_uzt_LTR.BackColor = Color.Lime
        If (Xuz = 225 And Yuz = 320) Or (Xuz = 320 And Yuz = 225) Then Butt_uzt_SRA4.BackColor = Color.Lime
        If (Xuz = 320 And Yuz = 450) Or (Xuz = 450 And Yuz = 320) Then Butt_uzt_SRA3.BackColor = Color.Lime
        If (Xuz = 99 And Yuz = 210) Or (Xuz = 210 And Yuz = 99) Then Butt_uzt_DL.BackColor = Color.Lime
        If (Xuz = 90 And Yuz = 50) Or (Xuz = 50 And Yuz = 90) Then Butt_uzt_90x50.BackColor = Color.Lime
        If (Xuz = 85 And Yuz = 55) Or (Xuz = 55 And Yuz = 85) Then Butt_uzt_85x55.BackColor = Color.Lime
        If (Xuz = 90 And Yuz = 100) Or (Xuz = 100 And Yuz = 90) Then Butt_uzt_90x100.BackColor = Color.Lime

        'ustawia podswietlenie aktywnego klawisza odstepu
        Butt_ods0.BackColor = Color.Transparent
        Butt_ods3.BackColor = Color.Transparent
        Butt_ods5.BackColor = Color.Transparent
        Butt_ods10.BackColor = Color.Transparent
        If Xods = 0 And Yods = 0 Then Butt_ods0.BackColor = Color.Lime
        If Xods = 3 And Yods = 3 Then Butt_ods3.BackColor = Color.Lime
        If Xods = 5 And Yods = 5 Then Butt_ods5.BackColor = Color.Lime
        If Xods = 10 And Yods = 10 Then Butt_ods10.BackColor = Color.Lime

        'ustawia podswietlenie aktywnego klawisza spadu
        Butt_spd0.BackColor = Color.Transparent
        Butt_spd3.BackColor = Color.Transparent
        Butt_spd5.BackColor = Color.Transparent
        Butt_spd10.BackColor = Color.Transparent
        If Xspd = 0 And Yspd = 0 Then Butt_spd0.BackColor = Color.Lime
        If Xspd = 3 And Yspd = 3 Then Butt_spd3.BackColor = Color.Lime
        If Xspd = 5 And Yspd = 5 Then Butt_spd5.BackColor = Color.Lime
        If Xspd = 10 And Yspd = 10 Then Butt_spd10.BackColor = Color.Lime

        'ustawia podswietlenie aktywnego klawisza bigowania
        Butt_bigo0.BackColor = Color.Transparent
        Butt_bigo1.BackColor = Color.Transparent
        Butt_bigo2.BackColor = Color.Transparent
        Butt_bigo3.BackColor = Color.Transparent
        Butt_bigo4.BackColor = Color.Transparent
        If Il_bigow = 0 Then Butt_bigo0.BackColor = Color.Lime
        If Il_bigow = 1 Then Butt_bigo1.BackColor = Color.Lime
        If Il_bigow = 2 Then Butt_bigo2.BackColor = Color.Lime
        If Il_bigow = 3 Then Butt_bigo3.BackColor = Color.Lime
        If Il_bigow = 4 Then Butt_bigo4.BackColor = Color.Lime

        'ustawia podswietlenie aktywnego klawisza margines
        Butt_m_0.BackColor = Color.Transparent
        Butt_m_5.BackColor = Color.Transparent
        If Margines = 0 Then Butt_m_0.BackColor = Color.Lime
        If Margines = 5 Then Butt_m_5.BackColor = Color.Lime

        'ustawia podswietlenie aktywnego klawisza znacznika
        Butt_zc_0.BackColor = Color.Transparent
        Butt_zc_3.BackColor = Color.Transparent
        If Znacznik = 0 Then Butt_zc_0.BackColor = Color.Lime
        If Znacznik = 3 Then Butt_zc_3.BackColor = Color.Lime


        'ustawia podswietlenie aktywnego klawisza od arkusza
        Butt_ark_A4.BackColor = Color.Transparent
        Butt_ark_A3.BackColor = Color.Transparent
        Butt_ark_SRA4.BackColor = Color.Transparent
        Butt_ark_SRA3.BackColor = Color.Transparent
        Butt_ark_niestd.BackColor = Color.Lime : wybranyArkusz = "Niestandardowy " & Txt_x_ark.Text & " mm x " & Txt_y_ark.Text & " mm"
        If (Xark = 210 And Yark = 297) Or (Xark = 297 And Yark = 210) Then Butt_ark_A4.BackColor = Color.Lime : Butt_ark_niestd.BackColor = Color.Transparent : Format = 4 : wybranyArkusz = "A4"
        If (Xark = 297 And Yark = 420) Or (Xark = 420 And Yark = 297) Then Butt_ark_A3.BackColor = Color.Lime : Butt_ark_niestd.BackColor = Color.Transparent : Format = 3 : wybranyArkusz = "A3"
        If (Xark = 225 And Yark = 320) Or (Xark = 320 And Yark = 225) Then Butt_ark_SRA4.BackColor = Color.Lime : Butt_ark_niestd.BackColor = Color.Transparent : Format = 4 : wybranyArkusz = "SRA4"
        If (Xark = 320 And Yark = 450) Or (Xark = 450 And Yark = 320) Then Butt_ark_SRA3.BackColor = Color.Lime : Butt_ark_niestd.BackColor = Color.Transparent : Format = 3 : wybranyArkusz = "SRA3"

        'ustawia ktore wcisniety (1+1,1+0, 4+4, 4+0)
        RB_10.BackgroundImage = My.Resources._1_0_x
        RB_11.BackgroundImage = My.Resources._1_1_x
        RB_40.BackgroundImage = My.Resources._4_0_x
        RB_44.BackgroundImage = My.Resources._4_4_x
        CB_Obrot.BackgroundImage = My.Resources._90_pion

        If RB_10.Checked = True Then RB_10.BackgroundImage = My.Resources._1_0_v : DrukSide = 1 : DrukColor = 0 : DrukRodzaj = "czarno-biały jednostronny   (1+0)"
        If RB_11.Checked = True Then RB_11.BackgroundImage = My.Resources._1_1_v : DrukSide = 2 : DrukColor = 0 : DrukRodzaj = "czarno-biały dwustronny   (1+1)"
        If RB_40.Checked = True Then RB_40.BackgroundImage = My.Resources._4_0_v : DrukSide = 1 : DrukColor = 1 : DrukRodzaj = "kolorowy jednostronny   (4+0)"
        If RB_44.Checked = True Then RB_44.BackgroundImage = My.Resources._4_4_v : DrukSide = 2 : DrukColor = 1 : DrukRodzaj = "kolorowy dwustronny   (4+4)"
        If CB_Obrot.Checked = True Then CB_Obrot.BackgroundImage = My.Resources._90_poziom

        If RB_uzytki.Checked = True Then WyborUzy = 1
        If RB_strony.Checked = True Then WyborUzy = 0

        If Butt_ark_niestd.Enabled = False Then Txt_x_ark.Enabled = False : Txt_y_ark.Enabled = False
        If Butt_ark_niestd.Enabled = True Then Txt_x_ark.Enabled = True : Txt_y_ark.Enabled = True

    End Sub


    Sub odswierz()

        If CB_Obrot.Checked = True And Int(Txt_x_ark.Text) < Int(Txt_y_ark.Text) Then Obrot()
        If CB_Obrot.Checked = False And Int(Txt_x_ark.Text) > Int(Txt_y_ark.Text) Then Obrot()

        GroupBox7.Controls.Clear()
        Lab_Azm.Visible = False
        Lab_min_big.Visible = False
        Lab_min_cut.Visible = False
        Lab_rabat.Visible = False

        Xuz = Txt_x_uz.Text
        Yuz = Txt_y_uz.Text
        Xspd = Txt_x_spd.Text
        Yspd = Txt_y_spd.Text
        Xods = Txt_x_ods.Text
        Yods = Txt_y_ods.Text
        Ilosc = Txt_ilosc.Text
        Xark = Txt_x_ark.Text
        Yark = Txt_y_ark.Text
        Margines = Txt_mar.Text
        Znacznik = Txt_zc.Text
        Il_bigow = Txt_il_bigow.Text

        UstawButony()

        Lab_PA.Text = 0
        Lab_Un1a.Text = 0
        Lab_Ou.Text = 0
        Lab_Nu.Text = 0
        Lab_x_ilosc.Text = 0
        Lab_y_ilosc.Text = 0

        wielkosc_rys_uzytków_pkt_x = 0
        wielkosc_rys_uzytków_pkt_y = 0

        RabatByl = 0

        'czyszczenie wyceny
        Txt_WB_druk_cena.Text = 0
        Txt_WB_papier_cena.Text = 0
        Txt_WB_ciecie_cena.Text = 0
        Txt_WB_bigowanie_cena.Text = 0
        Txt_WB_inne_cena.Text = 0
        Txt_WB_cena.Text = 0
        Txt_WN_cena.Text = 0
        Lab_A.Text = ""

        Txt_WB_druk_ilosc.Text = 0
        Txt_WB_papier_ilosc.Text = 0
        Txt_WB_ciecie_ilosc.Text = 0
        Txt_WB_bigowanie_ilosc.Text = 0

        If CB_AutoCennik.Checked = True Then
            Txt_WB_druk_cenaJ.Text = 0
            Txt_WB_papier_cenaJ.Text = 0
            Txt_WB_ciecie_cenaJ.Text = 0
            Txt_WB_bigowanie_cenaJ.Text = 0
        End If

        druk_cena = 0
        papier_cena = 0
        ciecie_cena = 0
        bigowanie_cena = 0
        inne_cena = 0
        WB_cena = 0
        WN_cena = 0

        GB_GramaturaDCP.Visible = False
        GB_GramaturaMat.Visible = False
        GB_GramaturaBlysk.Visible = False

        If RB_pap80.Checked = True Then Butt_ark_A4.Enabled = True : Butt_ark_A3.Enabled = True : Butt_ark_SRA4.Enabled = False : Butt_ark_SRA3.Enabled = False : Butt_ark_niestd.Enabled = False : RB_11.Visible = True : RB_44.Visible = True
        If RB_papDCP.Checked = True Then Butt_ark_A4.Enabled = True : Butt_ark_A3.Enabled = True : Butt_ark_SRA4.Enabled = True : Butt_ark_SRA3.Enabled = True : Butt_ark_niestd.Enabled = False : RB_11.Visible = True : RB_44.Visible = True : GB_GramaturaDCP.Visible = True : GB_GramaturaDCP.Location = New Point(199, 11)
        If RB_papKmat.Checked = True Then Butt_ark_A4.Enabled = True : Butt_ark_A3.Enabled = True : Butt_ark_SRA4.Enabled = True : Butt_ark_SRA3.Enabled = True : Butt_ark_niestd.Enabled = False : RB_11.Visible = True : RB_44.Visible = True : GB_GramaturaMat.Visible = True : GB_GramaturaMat.Location = New Point(199, 11)
        If RB_papKblysk.Checked = True Then Butt_ark_A4.Enabled = True : Butt_ark_A3.Enabled = True : Butt_ark_SRA4.Enabled = True : Butt_ark_SRA3.Enabled = True : Butt_ark_niestd.Enabled = False : RB_11.Visible = True : RB_44.Visible = True : GB_GramaturaBlysk.Visible = True : GB_GramaturaBlysk.Location = New Point(199, 11)
        If RB_papSam.Checked = True Then Butt_ark_A4.Enabled = True : Butt_ark_A3.Enabled = False : Butt_ark_SRA4.Enabled = False : Butt_ark_SRA3.Enabled = False : Butt_ark_niestd.Enabled = False : RB_11.Visible = False : RB_44.Visible = False
        If RB_folSam.Checked = True Then Butt_ark_A4.Enabled = True : Butt_ark_A3.Enabled = True : Butt_ark_SRA4.Enabled = True : Butt_ark_SRA3.Enabled = True : Butt_ark_niestd.Enabled = False : RB_11.Visible = False : RB_44.Visible = False
        If RB_folRz.Checked = True Then Butt_ark_A4.Enabled = True : Butt_ark_A3.Enabled = False : Butt_ark_SRA4.Enabled = False : Butt_ark_SRA3.Enabled = False : Butt_ark_niestd.Enabled = False : RB_11.Visible = False : RB_44.Visible = False
        If RB_inne.Checked = True Then Butt_ark_A4.Enabled = True : Butt_ark_A3.Enabled = True : Butt_ark_SRA4.Enabled = True : Butt_ark_SRA3.Enabled = True : Butt_ark_niestd.Enabled = True : RB_11.Visible = True : RB_44.Visible = True


        'likwidacja zaznaczania w tabelach
        CzyscZaznaczenie()

    End Sub

    Sub CzyscZaznaczenie()

        'likwidacja zaznaczania w tabelach
        DataGridView_kolor.ClearSelection()
        DataGridView_czarny.ClearSelection()
        DataGridView_dcp.ClearSelection()
        DataGridView_mat.ClearSelection()
        DataGridView_blysk.ClearSelection()
        DataGridView_inne.ClearSelection()

    End Sub


    Sub Oblicz()

        Ekran.Text = ""
        rabIlosc = False

        odswierz()
        GroupBox7.Controls.Clear()
        KrokX = 0
        KrokY = 0

        PoleDrukX = (Xark + 0.001) - 2 * Margines
        PoleDrukY = (Yark + 0.001) - 2 * Margines

        Pierwszy_uz_x = Xuz + 2 * Znacznik
        Pierwszy_uz_y = Yuz + 2 * Znacznik

        If PoleDrukX < Pierwszy_uz_x Or PoleDrukY < Pierwszy_uz_y Then

            Ekran.Text = "za mały arkusz !!!"
            Lab_Azm.Visible = True

            Exit Sub
        End If

        If WyborUzy = 1 Then

            Kolejne_uz_x = Xuz + Xods
            Kolejne_uz_y = Yuz + Yods

            IleX = Math.Ceiling((PoleDrukX - Pierwszy_uz_x) / Kolejne_uz_x)
            IleY = Math.Ceiling((PoleDrukY - Pierwszy_uz_y) / Kolejne_uz_y)
            IleArkuszy = Math.Ceiling(Ilosc / (IleX * IleY))

            Lab_Un1a.Text = IleX * IleY 'Na 1 arkuszu zmiesci sie 
            Lab_Ou.Text = IleArkuszy * (IleX * IleY) 'wydrukuje uzytków
            Lab_Nu.Text = IleArkuszy * (IleX * IleY) - Ilosc 'nadplanowe uzytki 

            druk_ilosc = IleArkuszy * DrukSide

        ElseIf WyborUzy = 0 Then

            If DrukSide = 1 Then IleArkuszy = Ilosc
            If DrukSide = 2 Then IleArkuszy = Math.Ceiling(Ilosc / 2)

            IleX = 1
            IleY = 1

            Lab_Un1a.Text = DrukSide 'Na 1 arkuszu zmiesci sie 
            Lab_Ou.Text = DrukSide * IleArkuszy 'wydrukuje uzytków
            Lab_Nu.Text = (DrukSide * IleArkuszy) - Ilosc 'nadplanowe uzytki 

            druk_ilosc = Ilosc

        End If


        Lab_PA.Text = IleArkuszy 'na takie zamowienie potrzeba Arkuszy
        Lab_x_ilosc.Text = IleX
        Lab_y_ilosc.Text = IleY


        ' rysowanie obiektów Visaul
        ' obliczanie wielkosci ARKUSZA
        If Xark >= Yark Then
            Pic_x_str = 310
            Pic_y_str = Yark * 310 / Xark

        ElseIf Xark < Yark Then
            Pic_y_str = 310
            Pic_x_str = Xark * 310 / Yark
        End If


        'rysowanie ARKUSZA
        Dim Pic_strona As New PictureBox
        Pic_strona.BackColor = Color.White
        Pic_strona.Size = New Size(Pic_x_str, Pic_y_str)
        Pic_strona.Location = New Point(10, 13)
        GroupBox7.Controls.Add(Pic_strona)


        'obliczenie powieszchni rysunku uzytkow

        'For Poziom_suma = 1 To IleX
        'If Poziom_suma > 1 Then KrokX_suma = KrokX_suma + (ObliczX(Xuz) + ObliczX(Xods))
        '
        '            For Pion_suma = 1 To IleY
        'If Pion_suma > 1 Then KrokY_suma = KrokY_suma + (ObliczY(Yuz) + ObliczY(Yods))
        '
        '    Next
        '     KrokY_suma = 0
        '  Next
        '   KrokX_suma = 0


        wielkosc_rys_uzytków_pkt_x = ObliczX((Xuz * IleX) + ((Xods - 1) * IleX) + ((Margines + Znacznik) * 2))
        wielkosc_rys_uzytków_pkt_y = ObliczY((Yuz * IleY) + ((Yods - 1) * IleY) + ((Margines + Znacznik) * 2))


        '  wielkosc_rys_uzytków_pkt_x = (ObliczX(Xuz) * IleX) + ObliczX(Margines + Znacznik) + KrokX_suma
        '  wielkosc_rys_uzytków_pkt_y = (ObliczY(Yuz) * IleY) + ObliczY(Margines + Znacznik) + KrokY_suma




        ' wielkosc_rys_uzytków_pkt_x = wielkosc_rys_uzytków_pkt_x + 10
        'wielkosc_rys_uzytków_pkt_y = wielkosc_rys_uzytków_pkt_y + 13

        CentrujX = Math.Truncate((Pic_x_str - wielkosc_rys_uzytków_pkt_x) / 2)
        CentrujY = Math.Truncate((Pic_y_str - wielkosc_rys_uzytków_pkt_y) / 2)

        ' CentrujX = 1
        ' CentrujY = 2

        'rysowanie uzytków  
        For Poziom = 1 To IleX
            If Poziom > 1 Then KrokX = KrokX + (ObliczX(Xuz) + ObliczX(Xods))

            For Pion = 1 To IleY
                If Pion > 1 Then KrokY = KrokY + (ObliczY(Yuz) + ObliczY(Yods))

                Dim Pic_uzytek As New PictureBox
                Pic_uzytek.BackColor = Color.Green
                Pic_uzytek.Size = New Size(ObliczX(Xuz), ObliczY(Yuz))
                Pic_uzytek.Location = New Point(ObliczX(2 * (Margines + Znacznik)) + KrokX + CentrujX + 10, ObliczY(2 * (Margines + Znacznik)) + KrokY + CentrujY + 13) ' 10 i 13 stale presuniecie obiektu 

                Ekran.Text = Ekran.Text & vbNewLine & "ObliczX(2 * (Margines + Znacznik)) " & ObliczX(2 * (Margines + Znacznik))
                Ekran.Text = Ekran.Text & vbNewLine & "punkt x " & ObliczX(2 * (Margines + Znacznik)) + KrokX + CentrujX + 10
                Pic_uzytek.Visible = True
                GroupBox7.Controls.Add(Pic_uzytek)

                Ekran.Text = Ekran.Text & vbNewLine & "KrokX_suma " & KrokX_suma
                Ekran.Text = Ekran.Text & vbNewLine & "KrokX " & KrokX
            Next
            KrokY = 0
        Next
        KrokX = 0


        Ekran.Text = Ekran.Text & vbNewLine & "wielkosc_rys_uzytków_pkt_x" & wielkosc_rys_uzytków_pkt_x
        Ekran.Text = Ekran.Text & vbNewLine & "wielkosc_rys_uzytków_pkt_y " & wielkosc_rys_uzytków_pkt_y
        Ekran.Text = Ekran.Text & vbNewLine & "papier_x" & Pic_x_str
        Ekran.Text = Ekran.Text & vbNewLine & "papier_y " & Pic_y_str
        Ekran.Text = Ekran.Text & vbNewLine & "centruj_x" & CentrujX
        Ekran.Text = Ekran.Text & vbNewLine & "centruj_y " & CentrujY



        Ekran.Text = Ekran.Text & vbNewLine


        Pic_strona.SendToBack()

        Txt_WB_druk_ilosc.Text = druk_ilosc

        papier_ilosc = IleArkuszy
        Txt_WB_papier_ilosc.Text = papier_ilosc

        ciecie_ilosc = ((IleX * 2) + (IleY * 2)) * IleArkuszy
        If Xuz = Xark And Yuz = Yark Then ciecie_ilosc = 0 ' jezeli uzytek i arkusz takie same nie licz ciecia
        Txt_WB_ciecie_ilosc.Text = ciecie_ilosc

        bigowanie_ilosc = Il_bigow * Ilosc
        Txt_WB_bigowanie_ilosc.Text = bigowanie_ilosc

        If CB_AutoCennik.Checked = True Then
            'wstawia cene w zaleznosci od ilosci
            drukCenaJednostkowa()

            'wstawia ceny mediów
            If RB_pap80.Checked = True Then Txt_WB_papier_cenaJ.Text = 0 : Medium = "papier 80g"
            If RB_papDCP.Checked = True Then CenaPapierDcp()
            If RB_papKmat.Checked = True Then CenaPapierMat()
            If RB_papKblysk.Checked = True Then CenaPapierBlysk()
            If RB_papSam.Checked = True Then CenaInne()
            If RB_folRz.Checked = True Then CenaInne()
            If RB_folSam.Checked = True Then CenaInne()
            If RB_inne.Checked = True Then CenaInne()

            Txt_WB_ciecie_cenaJ.Text = 0.02
            Txt_WB_bigowanie_cenaJ.Text = 0.35
        End If

        druk_cenaJ = Txt_WB_druk_cenaJ.Text
        papier_cenaJ = Txt_WB_papier_cenaJ.Text
        ciecie_cenaJ = Txt_WB_ciecie_cenaJ.Text
        bigowanie_cenaJ = Txt_WB_bigowanie_cenaJ.Text

        inne_cenaJ = Txt_WB_inne_cenaJ.Text
        inne_ilosc = Txt_WB_inne_ilosc.Text


        ' wyliczenie wyceny 
        If CBox_WB_druk.Checked = True Then druk_cena = druk_cenaJ * druk_ilosc
        If CBox_WB_papier.Checked = True Then papier_cena = papier_cenaJ * papier_ilosc
        If CBox_WB_ciecie.Checked = True Then ciecie_cena = ciecie_cenaJ * ciecie_ilosc : If ciecie_cena > 0 And ciecie_cena < 5 Then ciecie_cena = 5 : Lab_min_cut.Visible = True
        If CBox_WB_bigowanie.Checked = True Then bigowanie_cena = bigowanie_cenaJ * bigowanie_ilosc : If bigowanie_cena > 0 And bigowanie_cena < 25 Then bigowanie_cena = 25 : Lab_min_big.Visible = True
        If CBox_WB_inne.Checked = True Then inne_cena = inne_cenaJ * inne_ilosc

        WB_cena = druk_cena + papier_cena + ciecie_cena + bigowanie_cena + inne_cena
        WN_cena = WB_cena / 1.23


        'wyswietlenie wyceny
        Txt_WB_druk_cena.Text = FormatNumber(druk_cena, 2)
        Txt_WB_papier_cena.Text = FormatNumber(papier_cena, 2)
        Txt_WB_ciecie_cena.Text = FormatNumber(ciecie_cena, 2)
        Txt_WB_bigowanie_cena.Text = FormatNumber(bigowanie_cena, 2)
        Txt_WB_inne_cena.Text = FormatNumber(inne_cena, 2)
        Txt_WB_cena.Text = FormatNumber(WB_cena, 2)
        Txt_WN_cena.Text = FormatNumber(Math.Round(WN_cena, 2), 2)

        If Format = 4 Then Lab_A.Text = "A4"
        If Format = 3 Then Lab_A.Text = "A3"

        Txt_ilosc.SelectionStart = 0
        Txt_ilosc.SelectionLength = Txt_ilosc.TextLength
        Txt_ilosc.Focus()

    End Sub
    Function ObliczX(X1 As Integer) As Integer
        ObliczX = X1 * Pic_x_str / Xark
    End Function

    Function ObliczY(Y1 As Integer) As Integer
        ObliczY = Y1 * Pic_y_str / Yark
    End Function

    Sub Obrot()
        Dim RotX, RotY As String
        RotX = Txt_x_ark.Text
        RotY = Txt_y_ark.Text
        Txt_x_ark.Text = RotY
        Txt_y_ark.Text = RotX
    End Sub


    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Butt_spd0.Click
        Txt_x_spd.Text = 0
        Txt_y_spd.Text = 0
        odswierz()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Butt_spd3.Click
        Txt_x_spd.Text = 3
        Txt_y_spd.Text = 3
        odswierz()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Butt_spd5.Click
        Txt_x_spd.Text = 5
        Txt_y_spd.Text = 5
        odswierz()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Butt_spd10.Click
        Txt_x_spd.Text = 10
        Txt_y_spd.Text = 10
        odswierz()
    End Sub

    Private Sub Butt_ods0_Click(sender As Object, e As EventArgs) Handles Butt_ods0.Click
        Txt_x_ods.Text = 0
        Txt_y_ods.Text = 0
        odswierz()
    End Sub

    Private Sub Txt_il_bigow_TextChanged(sender As Object, e As EventArgs) Handles Txt_il_bigow.TextChanged

    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click

    End Sub

    Private Sub Butt_ods3_Click(sender As Object, e As EventArgs) Handles Butt_ods3.Click
        Txt_x_ods.Text = 3
        Txt_y_ods.Text = 3
        odswierz()
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        If zazn = True Then
            CBox_WB_druk.Checked = True
            CBox_WB_papier.Checked = True
            CBox_WB_ciecie.Checked = True
            CBox_WB_bigowanie.Checked = True
            CBox_WB_inne.Checked = True
            zazn = False
            Exit Sub
        Else
            CBox_WB_druk.Checked = False
            CBox_WB_papier.Checked = False
            CBox_WB_ciecie.Checked = False
            CBox_WB_bigowanie.Checked = False
            CBox_WB_inne.Checked = False
            zazn = True
            Exit Sub
        End If
    End Sub


    Private Sub DataGridView_inne_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_inne.CellContentClick

        If IsNumeric(DataGridView_inne.CurrentCell.Value) Then Txt_WB_inne_cenaJ.Text = DataGridView_inne.CurrentCell.Value

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        'pokazuje formularz drukowania 
        Form2.Show()

        'pokazuje aktualny czas 
        Dim Teraz As Date = DateTime.Now
        Dim Potem As Date = DateAdd(DateInterval.Day, 10, Teraz)
        Form2.Lab_CzasDruku.Text = Teraz.ToString("dd") & "-" & Teraz.ToString("MM") & "-" & Teraz.ToString("yyyy") & "  " & Teraz.ToString("HH") & ":" & Teraz.ToString("mm")
        Form2.Lbl_obowiazuje.Text = "obowiązuje do: " & Potem.ToString("dd") & "-" & Potem.ToString("MM") & "-" & Potem.ToString("yyyy") & " (10 dni)"


        'pokazuje ramki do pol tekstowych i ustawia kolor
        Form2.TextBox1.BorderStyle = BorderStyle.FixedSingle
        Form2.TextBox2.BorderStyle = BorderStyle.FixedSingle
        Form2.TextBox1.BackColor = Color.LightYellow
        Form2.TextBox2.BackColor = Color.LightYellow

        ' ustawia kursor na polui do wpisania danych
        Form2.TextBox1.Focus()

        'wypełnienie danymi formularza do druku
        Form2.Lab_wersja.Text = Wersja & " by R.Dziankowski © 2017/2018"

        Form2.Lab_drk_ilosc.Text = Ilosc & " szt. "
        Form2.Lab_drk_rozmiar.Text = Xuz & " mm x " & Yuz & " mm "
        Form2.Lab_drk_medium.Text = Medium
        Form2.Lab_drk_druk.Text = DrukRodzaj

        If Txt_il_bigow.Text < 1 Then Form2.Lab_drk_bigi.Visible = False : Form2.Lab_drk_bigowanie.Visible = False
        If Txt_il_bigow.Text >= 1 Then Form2.Lab_drk_bigi.Visible = True : Form2.Lab_drk_bigowanie.Visible = True : Form2.Lab_drk_bigowanie.Text = Txt_il_bigow.Text

        Form2.Lab_koszt_brutto.Text = Txt_WB_cena.Text
        Form2.Lab_koszt_netto.Text = Txt_WN_cena.Text


        Form2.Lab_WB_druk_ilosc.Text = Txt_WB_druk_ilosc.Text
        Form2.Lab_WB_papier_ilosc.Text = Txt_WB_papier_ilosc.Text
        Form2.Lab_WB_ciecie_ilosc.Text = Txt_WB_ciecie_ilosc.Text
        Form2.Lab_WB_bigowanie_ilosc.Text = Txt_WB_bigowanie_ilosc.Text
        Form2.Lab_WB_inne_ilosc.Text = Txt_WB_inne_ilosc.Text

        Form2.Lab_WB_druk_cenaJ.Text = Txt_WB_druk_cenaJ.Text
        Form2.Lab_WB_papier_cenaJ.Text = Txt_WB_papier_cenaJ.Text
        Form2.Lab_WB_ciecie_cenaJ.Text = Txt_WB_ciecie_cenaJ.Text
        Form2.Lab_WB_bigowanie_cenaJ.Text = Txt_WB_bigowanie_cenaJ.Text
        Form2.Lab_WB_inne_cenaJ.Text = Txt_WB_inne_cenaJ.Text

        Form2.Lab_WB_druk_cena.Text = Txt_WB_druk_cena.Text
        Form2.Lab_WB_papier_cena.Text = Txt_WB_papier_cena.Text
        Form2.Lab_WB_ciecie_cena.Text = Txt_WB_ciecie_cena.Text
        Form2.Lab_WB_bigowanie_cena.Text = Txt_WB_bigowanie_cena.Text
        Form2.Lab_WB_inne_cena.Text = Txt_WB_inne_cena.Text


        If rabIlosc = True Then Form2.Lab_Rabat_ILosc.Visible = True
        If rabIlosc = False Then Form2.Lab_Rabat_ILosc.Visible = False

        If RabatByl = 0 Then Form2.Lab_rabatPRC.Visible = False
        If RabatByl <> 0 Then Form2.Lab_rabatPRC.Visible = True : Form2.Lab_rabatPRC.Text = "Udzielono " & Lab_rabat.Text

        If RB_uzytki.Checked = True Then
            Form2.Lab_arkuszy.Text = "Arkuszy do druku potrzeba: " & Lab_PA.Text & " szt., formatu: " & wybranyArkusz
            Form2.Lab_naArkuszu.Text = "Użytków na arkuszu będzie: " & Lab_Un1a.Text
            Form2.Lab_uzytkow.Text = "Wydrukowanych użytków będzie: " & Lab_Ou.Text & " szt., w tym nadplanowych: " & Lab_Nu.Text & " szt."
            If CB_Obrot.Checked = False Then Form2.Lab_jakDrukowac.Text = "Druk w orientacji PIONOWEJ, rozkład użytków: kolumn= " & IleX & ", wierszy= " & IleY
            If CB_Obrot.Checked = True Then Form2.Lab_jakDrukowac.Text = "Druk w orientacji POZIOMEJ, rozkład użytków: kolumn= " & IleX & ", wierszy= " & IleY
        End If

        If RB_strony.Checked = True Then
            Form2.Lab_arkuszy.Text = "Kartek do druku potrzeba: " & Lab_PA.Text & " szt., formatu: " & wybranyArkusz
            Form2.Lab_naArkuszu.Text = "Zadrukowane strony: " & Lab_Un1a.Text & " na 1 kartce"
            Form2.Lab_uzytkow.Text = "Wszystkich zadrukowanych stron: " & Lab_Ou.Text
            Form2.Lab_jakDrukowac.Text = ""
        End If
    End Sub

    Private Sub CB_AutoCennik_CheckedChanged(sender As Object, e As EventArgs) Handles CB_AutoCennik.CheckedChanged
        If CB_AutoCennik.Checked = False Then
            Txt_WB_druk_cenaJ.ForeColor = Color.Red
            Txt_WB_papier_cenaJ.ForeColor = Color.Red
            Txt_WB_ciecie_cenaJ.ForeColor = Color.Red
            Txt_WB_bigowanie_cenaJ.ForeColor = Color.Red
        Else
            Txt_WB_druk_cenaJ.ForeColor = Color.Black
            Txt_WB_papier_cenaJ.ForeColor = Color.Black
            Txt_WB_ciecie_cenaJ.ForeColor = Color.Black
            Txt_WB_bigowanie_cenaJ.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Butt_ods5_Click(sender As Object, e As EventArgs) Handles Butt_ods5.Click
        Txt_x_ods.Text = 5
        Txt_y_ods.Text = 5
        odswierz()
    End Sub

    Private Sub Butt_ods10_Click(sender As Object, e As EventArgs) Handles Butt_ods10.Click
        Txt_x_ods.Text = 10
        Txt_y_ods.Text = 10
        odswierz()
    End Sub

    Private Sub RB_uzytki_CheckedChanged(sender As Object, e As EventArgs) Handles RB_uzytki.CheckedChanged
        Txt_mar.Text = 5
        Txt_zc.Text = 3
        Txt_x_ods.Text = 3
        Txt_y_ods.Text = 3
        Txt_x_spd.Text = 3
        Txt_y_spd.Text = 3
        Txt_x_uz.Text = 90
        Txt_y_uz.Text = 50
        Lbl_Uz_Str.Text = " Ilość użytków"
        RB_uzytki.BackgroundImage = My.Resources.UZT_on
        RB_uzytki.BackColor = Color.Lime
        RB_strony.BackgroundImage = My.Resources.STR_off
        RB_strony.BackColor = Color.WhiteSmoke
        WyborUzy = 1
        GroupOdstep.Visible = True
        Lab_x_ilosc.Visible = True
        Lab_y_ilosc.Visible = True
        PictureBox1.Visible = True
        Lab_01.Text = "Ilość arkuszy"
        Lab_02.Text = "Użytków na 1 arkuszu"
        Lab_03.Text = "Wszystkich użytków"
        Lab_04.Text = "Nadplanowe użytki"

    End Sub

    Private Sub RB_uzytki_Clik(sender As Object, e As EventArgs) Handles RB_uzytki.Click
        odswierz()
    End Sub

    Private Sub RB_strony_CheckedChanged(sender As Object, e As EventArgs) Handles RB_strony.CheckedChanged
        Txt_mar.Text = 0
        Txt_zc.Text = 0
        Txt_x_ods.Text = 0
        Txt_y_ods.Text = 0
        Txt_x_spd.Text = 0
        Txt_y_spd.Text = 0
        Txt_x_uz.Text = 210
        Txt_y_uz.Text = 297
        Lbl_Uz_Str.Text = " Ilość stron"
        RB_uzytki.BackgroundImage = My.Resources.UZT_off
        RB_uzytki.BackColor = Color.WhiteSmoke
        RB_strony.BackgroundImage = My.Resources.STR_on
        RB_strony.BackColor = Color.Lime
        WyborUzy = 0
        GroupOdstep.Visible = False
        Lab_x_ilosc.Visible = False
        Lab_y_ilosc.Visible = False
        PictureBox1.Visible = False
        Lab_01.Text = "Ilość kartek"
        Lab_02.Text = "Druków na 1 kartce"
        Lab_03.Text = "Zadrukowane strony"
        Lab_04.Text = "Nadplanowe strony"

    End Sub

    Private Sub RB_strony_Clik(sender As Object, e As EventArgs) Handles RB_strony.Click
        odswierz()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button_5.Click
        If RabatByl <> 0 Then Exit Sub
        RabatByl = 1
        WB_cena = WB_cena - (WB_cena * 5 / 100)
        WN_cena = WB_cena / 1.23
        Lab_rabat.Visible = True
        Lab_rabat.Text = "Rabat -5 %"

        'wyswietlenie wyceny
        Txt_WB_cena.Text = FormatNumber(WB_cena, 2)
        Txt_WN_cena.Text = FormatNumber(Math.Round(WN_cena, 2), 2)


    End Sub

    Private Sub Button_10_Click(sender As Object, e As EventArgs) Handles Button_10.Click
        If RabatByl <> 0 Then Exit Sub

        RabatByl = 1
        WB_cena = WB_cena - (WB_cena * 10 / 100)
        WN_cena = WB_cena / 1.23
        Lab_rabat.Visible = True
        Lab_rabat.Text = "Rabat -10 %"

        'wyswietlenie wyceny
        Txt_WB_cena.Text = FormatNumber(WB_cena, 2)
        Txt_WN_cena.Text = FormatNumber(Math.Round(WN_cena, 2), 2)

    End Sub

    Private Sub Button_15_Click(sender As Object, e As EventArgs) Handles Button_15.Click
        If RabatByl <> 0 Then Exit Sub

        RabatByl = 1
        WB_cena = WB_cena - (WB_cena * 15 / 100)
        WN_cena = WB_cena / 1.23
        Lab_rabat.Visible = True
        Lab_rabat.Text = "Rabat -15 %"

        'wyswietlenie wyceny
        Txt_WB_cena.Text = FormatNumber(WB_cena, 2)
        Txt_WN_cena.Text = FormatNumber(Math.Round(WN_cena, 2), 2)

    End Sub

    Private Sub Butt_m_0_Click(sender As Object, e As EventArgs) Handles Butt_m_0.Click
        Txt_mar.Text = 0
        odswierz()
    End Sub

    Private Sub Butt_m_5_Click(sender As Object, e As EventArgs) Handles Butt_m_5.Click
        Txt_mar.Text = 5
        odswierz()
    End Sub

    Private Sub Txt_ilosc_TextChanged(sender As Object, e As EventArgs) Handles Txt_ilosc.TextChanged
        '   odswierz()
    End Sub

    Private Sub CB_Obrot_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Obrot.CheckedChanged
        odswierz()
    End Sub

    Private Sub RB_10_CheckedChanged(sender As Object, e As EventArgs) Handles RB_10.CheckedChanged
        TabControl1.SelectedTab = TabCZB
        odswierz()
    End Sub

    Private Sub RB_11_CheckedChanged(sender As Object, e As EventArgs) Handles RB_11.CheckedChanged
        TabControl1.SelectedTab = TabCZB
        odswierz()
    End Sub

    Private Sub RB_40_CheckedChanged(sender As Object, e As EventArgs) Handles RB_40.CheckedChanged
        TabControl1.SelectedTab = TabKOLOR
        odswierz()
    End Sub

    Private Sub RB_44_CheckedChanged(sender As Object, e As EventArgs) Handles RB_44.CheckedChanged
        TabControl1.SelectedTab = TabKOLOR
        odswierz()
    End Sub

    Private Sub Butt_bigo0_Click(sender As Object, e As EventArgs) Handles Butt_bigo0.Click
        Txt_il_bigow.Text = 0
        odswierz()
    End Sub

    Private Sub Butt_bigo1_Click(sender As Object, e As EventArgs) Handles Butt_bigo1.Click
        Txt_il_bigow.Text = 1
        odswierz()
    End Sub

    Private Sub Butt_bigo2_Click(sender As Object, e As EventArgs) Handles Butt_bigo2.Click
        Txt_il_bigow.Text = 2
        odswierz()
    End Sub

    Private Sub RB_pap80_CheckedChanged(sender As Object, e As EventArgs) Handles RB_pap80.CheckedChanged
        Txt_x_ark.Text = 210
        Txt_y_ark.Text = 297
        odswierz()
    End Sub

    Private Sub RB_papDCP_CheckedChanged(sender As Object, e As EventArgs) Handles RB_papDCP.CheckedChanged
        TabControl1.SelectedTab = TabDCP
        odswierz()
    End Sub

    Private Sub RB_papKmat_CheckedChanged(sender As Object, e As EventArgs) Handles RB_papKmat.CheckedChanged
        TabControl1.SelectedTab = TabMAT
        odswierz()
    End Sub

    Private Sub RB_papKblysk_CheckedChanged(sender As Object, e As EventArgs) Handles RB_papKblysk.CheckedChanged
        TabControl1.SelectedTab = TabBLYSK
        odswierz()
    End Sub

    Private Sub RB_papSam_CheckedChanged(sender As Object, e As EventArgs) Handles RB_papSam.CheckedChanged
        RB_40.Checked = True
        Txt_x_ark.Text = 210
        Txt_y_ark.Text = 297
        odswierz()
        TabControl1.SelectedTab = TabINNE
    End Sub

    Private Sub RB_folSam_CheckedChanged(sender As Object, e As EventArgs) Handles RB_folSam.CheckedChanged
        RB_40.Checked = True
        Txt_x_ark.Text = 320
        Txt_y_ark.Text = 450
        odswierz()
        TabControl1.SelectedTab = TabINNE
    End Sub

    Private Sub RB_folRz_CheckedChanged(sender As Object, e As EventArgs) Handles RB_folRz.CheckedChanged
        RB_40.Checked = True
        Txt_x_ark.Text = 210
        Txt_y_ark.Text = 297
        odswierz()
        TabControl1.SelectedTab = TabINNE
    End Sub

    Private Sub RB_inne_CheckedChanged(sender As Object, e As EventArgs) Handles RB_inne.CheckedChanged
        odswierz()
    End Sub

    Private Sub Butt_bigo3_Click(sender As Object, e As EventArgs) Handles Butt_bigo3.Click
        Txt_il_bigow.Text = 3
        odswierz()
    End Sub

    Private Sub Butt_bigo4_Click(sender As Object, e As EventArgs) Handles Butt_bigo4.Click
        Txt_il_bigow.Text = 4
        odswierz()
    End Sub

    Private Sub Butt_ark_A4_Click(sender As Object, e As EventArgs) Handles Butt_ark_A4.Click
        Txt_x_ark.Text = 210
        Txt_y_ark.Text = 297
        odswierz()
    End Sub

    Private Sub Butt_ark_A3_Click(sender As Object, e As EventArgs) Handles Butt_ark_A3.Click
        Txt_x_ark.Text = 297
        Txt_y_ark.Text = 420
        odswierz()
    End Sub

    Private Sub Butt_zc_0_Click(sender As Object, e As EventArgs) Handles Butt_zc_0.Click
        Txt_zc.Text = 0
        odswierz()
    End Sub

    Private Sub Butt_zc_3_Click(sender As Object, e As EventArgs) Handles Butt_zc_3.Click
        Txt_zc.Text = 3
        odswierz()
    End Sub

    Private Sub Butt_ark_SRA4_Click(sender As Object, e As EventArgs) Handles Butt_ark_SRA4.Click
        Txt_x_ark.Text = 225
        Txt_y_ark.Text = 320
        odswierz()
    End Sub

    Private Sub Butt_ark_SRA3_Click(sender As Object, e As EventArgs) Handles Butt_ark_SRA3.Click
        Txt_x_ark.Text = 320
        Txt_y_ark.Text = 450
        odswierz()
    End Sub

    Private Sub Butt_ark_niestd_Click(sender As Object, e As EventArgs) Handles Butt_ark_niestd.Click
        Txt_x_ark.Text = 100
        Txt_y_ark.Text = 100
        odswierz()
    End Sub

    Private Sub Butt_uzt_A7_Click(sender As Object, e As EventArgs) Handles Butt_uzt_A7.Click
        Txt_x_uz.Text = 74.25
        Txt_y_uz.Text = 105
        odswierz()
    End Sub

    Private Sub Butt_uzt_A6_Click(sender As Object, e As EventArgs) Handles Butt_uzt_A6.Click
        Txt_x_uz.Text = 105
        Txt_y_uz.Text = 148.5
        odswierz()
    End Sub

    Private Sub Butt_uzt_A5_Click(sender As Object, e As EventArgs) Handles Butt_uzt_A5.Click
        Txt_x_uz.Text = 148.5
        Txt_y_uz.Text = 210
        odswierz()
    End Sub

    Private Sub Butt_uzt_A4_Click(sender As Object, e As EventArgs) Handles Butt_uzt_A4.Click
        Txt_x_uz.Text = 210
        Txt_y_uz.Text = 297
        odswierz()
    End Sub

    Private Sub Butt_uzt_A3_Click(sender As Object, e As EventArgs) Handles Butt_uzt_A3.Click
        Txt_x_uz.Text = 297
        Txt_y_uz.Text = 420
        odswierz()
    End Sub

    Private Sub Butt_uzt_A2_Click(sender As Object, e As EventArgs) Handles Butt_uzt_90x100.Click
        Txt_x_uz.Text = 90
        Txt_y_uz.Text = 100
        odswierz()
    End Sub

    Private Sub Butt_uzt_SRA4_Click(sender As Object, e As EventArgs) Handles Butt_uzt_SRA4.Click
        Txt_x_uz.Text = 225
        Txt_y_uz.Text = 320
        odswierz()
    End Sub

    Private Sub Butt_uzt_SRA3_Click(sender As Object, e As EventArgs) Handles Butt_uzt_SRA3.Click
        Txt_x_uz.Text = 320
        Txt_y_uz.Text = 450
        odswierz()
    End Sub

    Private Sub Butt_uzt_DL_Click(sender As Object, e As EventArgs) Handles Butt_uzt_DL.Click
        Txt_x_uz.Text = 99
        Txt_y_uz.Text = 210
        odswierz()
    End Sub

    Private Sub Butt_uzt_90x50_Click(sender As Object, e As EventArgs) Handles Butt_uzt_90x50.Click
        Txt_x_uz.Text = 90
        Txt_y_uz.Text = 50
        odswierz()
    End Sub

    Private Sub Butt_uzt_85x55_Click(sender As Object, e As EventArgs) Handles Butt_uzt_85x55.Click
        Txt_x_uz.Text = 85
        Txt_y_uz.Text = 55
        odswierz()
    End Sub

    Private Sub Butt_uzt_LTR_Click(sender As Object, e As EventArgs) Handles Butt_uzt_LTR.Click
        Txt_x_uz.Text = 216
        Txt_y_uz.Text = 279
        odswierz()
    End Sub

End Class

