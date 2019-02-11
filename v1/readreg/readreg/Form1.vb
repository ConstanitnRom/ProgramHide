Imports Microsoft.Win32

Public Class Form1



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListBox1.Items.Add("64 Bit")
        ListBox1.Items.Add(" ")
        FillMachineList("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall")
        ListBox1.Items.Add(" ")
        ListBox1.Items.Add("32 Bit")
        ListBox1.Items.Add(" ")
        FillMachineList("SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall")
        ListBox1.Items.Add(" ")
        ListBox1.Items.Add("64 Bit Cu")
        ListBox1.Items.Add(" ")
        FillCurrentUserList("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall")
        ListBox1.Items.Add(" ")
        ListBox1.Items.Add("32 Bit Cu")
        ListBox1.Items.Add(" ")
        FillCurrentUserList("SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall")
        ComboBox1.Items.Add("Sichtbar")
        ComboBox1.Items.Add("Unsichtbar")
    End Sub

    Public Sub FillMachineList(path As String)
        Dim instance As RegistryKey = Registry.LocalMachine.CreateSubKey(path, False)



        For Each s As String In instance.GetSubKeyNames()

            ListBox1.Items.Add("HKEY_LOCAL_MACHINE\" + path + "\" + s)
        Next
    End Sub

    Public Sub FillCurrentUserList(path As String)
        Dim instance As RegistryKey = Registry.CurrentUser.CreateSubKey(path, False)



        For Each s As String In instance.GetSubKeyNames()

            ListBox1.Items.Add("HKEY_CURRENT_USER\" + path + "\" + s)
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim s As String = ListBox1.GetItemText(ListBox1.SelectedItem)
        Try
            If (ComboBox1.SelectedItem.ToString() = "Sichtbar" And s.Substring(0, 18) = "HKEY_LOCAL_MACHINE") Then
                My.Computer.Registry.LocalMachine.OpenSubKey(s.Substring(19, s.Length - 19), True).SetValue("test", 12, RegistryValueKind.DWord)

            ElseIf (ComboBox1.SelectedItem.ToString() = "Sichtbar" And s.Substring(0, 17) = "HKEY_CURRENT_USER") Then
                My.Computer.Registry.CurrentUser.OpenSubKey(s.Substring(18, s.Length - 18), True).SetValue("SystemComponent", 0, RegistryValueKind.DWord)


            ElseIf (ComboBox1.SelectedItem.ToString() = "Unsichtbar" And s.Substring(0, 18) = "HKEY_LOCAL_MACHINE") Then
                My.Computer.Registry.LocalMachine.OpenSubKey(s.Substring(19, s.Length - 19), True).SetValue("SystemComponent", 1, RegistryValueKind.DWord)


            Else
                My.Computer.Registry.CurrentUser.OpenSubKey(s.Substring(18, s.Length - 18), True).SetValue("SystemComponent", 1, RegistryValueKind.DWord)

            End If


        Catch
            MessageBox.Show("Ungültiger Schlüssel")
        End Try



    End Sub
End Class

Public Class listItem
    Public display As String
    Public value As String
    Public Sub New(ByVal de As KeyValuePair(Of String, Object))
        Me.display = de.Key
        Me.value = de.Value.ToString
    End Sub
    Public Overrides Function tostring() As String
        Return Me.display
    End Function
End Class


