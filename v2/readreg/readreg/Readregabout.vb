Public NotInheritable Class Readregabout

    'Original change if you want to compile the other
    'Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ' Legen Sie den Titel des Formulars fest.
    'Dim ApplicationTitle As String
    'If My.Application.Info.Title <> "" Then
    '       ApplicationTitle = My.Application.Info.Title
    'Else
    '       ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
    'End If
    'Me.Text = String.Format("Info {0}", ApplicationTitle)
    ' Initialisieren Sie den gesamten Text, der im Infofeld angezeigt wird.
    ' TODO: Die Assemblyinformationen der Anwendung im Bereich "Anwendung" des Dialogfelds für die 
    '    Projekteigenschaften (im Menü "Projekt") anpassen.
    'Me.LabelProductName.Text = My.Application.Info.ProductName
    'Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
    'Me.LabelCopyright.Text = My.Application.Info.Copyright
    ''Me.TextBoxDescription.Text = My.Application.Info.Description
    'End Sub


    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Legen Sie den Titel des Formulars fest.
        Dim ApplicationTitle As String

        ApplicationTitle = "Über Program Hide"

        Me.Text = String.Format("Info {0}", "Program Hide")
        '     Initialisieren Sie den gesamten Text, der im Infofeld angezeigt wird.
        'TODO:   Die Assemblyinformationen der Anwendung im Bereich "Anwendung" des Dialogfelds für die 
        '       Projekteigenschaften(im Menü "Projekt") anpassen.
        Me.LabelProductName.Text = "Program Hide (Readreg)"
        Me.LabelVersion.Text = String.Format("Version {0}", "3.2018.294.559")
        Me.LabelCopyright.Text = "Open Source"
        Me.LabelCompanyName.Text = "Constantin Rom"

        Me.TextBoxDescription.Text = "Programm zum Verstecken von Updates und Programmen aus Programme und Features (Programme und Funktionen)"

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub LabelCompanyName_Click(sender As Object, e As EventArgs) Handles LabelCompanyName.Click

    End Sub
End Class
