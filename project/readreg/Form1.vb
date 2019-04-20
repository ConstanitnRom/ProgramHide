Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.Win32


Public Class Form1


    Private Sub Form1_SizeChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.SizeChanged


    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.EnableVisualStyles()
        ComboBox1.Items.Add("Sichtbar")
        ComboBox1.Items.Add("Unsichtbar")
        DataGridView1.ReadOnly = True
        DataGridView1.MultiSelect = False

        FillMachineList("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall")

        FillMachineList("SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall")

        FillCurrentUserList("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall")

        FillCurrentUserList("SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall")

        ComboBox1.SelectedIndex = 0

    End Sub

    Public Sub FillMachineList(path As String)
        Dim instance As RegistryKey = Registry.LocalMachine.CreateSubKey(path, False)
        Dim list As New List(Of String)
        Dim clist As New List(Of String)


        For Each s As String In instance.GetSubKeyNames()
            DataGridView1.Rows.Add(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\" + path + "\" + s, "DisplayName", "HKEY_LOCAL_MACHINE\" + path + "\" + s), "HKEY_LOCAL_MACHINE\" + path + "\" + s)
        Next






    End Sub

    Public Sub FillCurrentUserList(path As String)
        Dim instance As RegistryKey = Registry.CurrentUser.CreateSubKey(path, False)

        Dim list As New List(Of String)
        Dim clist As New List(Of String)

        For Each s As String In instance.GetSubKeyNames()

            DataGridView1.Rows.Add(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\" + path + "\" + s, "DisplayName", "HKEY_CURRENT_USER\" + path + "\" + s), "HKEY_CURRENT_USER\" + path + "\" + s)

        Next















    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If DataGridView1.SelectedRows.Count <> 0 Then
            Dim row As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
            Dim text As String = row.Cells(1).Value





            Try

                If (Operators.CompareString(ComboBox1.SelectedItem.ToString(), "Sichtbar", TextCompare:=False) = 0) And (Operators.CompareString(text.Substring(0, 18), "HKEY_LOCAL_MACHINE", TextCompare:=False) = 0) Then
                    Registry.LocalMachine.OpenSubKey(text.Substring(19, text.Length - 19), writable:=True).SetValue("SystemComponent", 0, RegistryValueKind.DWord)
                ElseIf (Operators.CompareString(ComboBox1.SelectedItem.ToString(), "Sichtbar", TextCompare:=False) = 0) And (Operators.CompareString(text.Substring(0, 17), "HKEY_CURRENT_USER", TextCompare:=False) = 0) Then
                    Registry.CurrentUser.OpenSubKey(text.Substring(18, text.Length - 18), writable:=True).SetValue("SystemComponent", 0, RegistryValueKind.DWord)
                ElseIf (Operators.CompareString(ComboBox1.SelectedItem.ToString(), "Unsichtbar", TextCompare:=False) = 0) And (Operators.CompareString(text.Substring(0, 18), "HKEY_LOCAL_MACHINE", TextCompare:=False) = 0) Then
                    Registry.LocalMachine.OpenSubKey(text.Substring(19, text.Length - 19), writable:=True).SetValue("SystemComponent", 1, RegistryValueKind.DWord)
                Else
                    Registry.CurrentUser.OpenSubKey(text.Substring(18, text.Length - 18), writable:=True).SetValue("SystemComponent", 1, RegistryValueKind.DWord)
                End If





            Catch projectError As Exception

                MessageBox.Show("Ungültiger Schlüssel")

            End Try
        Else
            MessageBox.Show("Keine Zeile ausgewählt")
        End If
    End Sub


    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AboutLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles AboutLink.LinkClicked
        Readregabout.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged



        Dim i As String


        If DataGridView1.SelectedRows.Count <> 0 Then
            Dim row As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
            Dim text As String = row.Cells(1).Value

            Try


                Dim test As String = text.Substring(19, text.Length - 19)

                If (Operators.CompareString(text.Substring(0, 18), "HKEY_LOCAL_MACHINE", TextCompare:=False) = 0) Then
                    i = Registry.LocalMachine.OpenSubKey(text.Substring(19, text.Length - 19)).GetValue("SystemComponent", 0)
                ElseIf (Operators.CompareString(text.Substring(0, 17), "HKEY_CURRENT_USER", TextCompare:=False) = 0) Then
                    i = Registry.CurrentUser.OpenSubKey(text.Substring(18, text.Length - 18)).GetValue("SystemComponent", 0)

                End If

            Catch ex As Exception

            End Try


            If i = 0 Or i = -1 Then
                ComboBox1.SelectedIndex = 0

            Else
                ComboBox1.SelectedIndex = 1
            End If
        End If







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


