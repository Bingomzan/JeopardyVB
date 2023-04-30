'Imports WMPLib
Imports System.IO
Public Class Form1
    Public questionFile As String
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim di As New IO.DirectoryInfo("./")
        Dim aryFi As IO.FileInfo() = di.GetFiles("*.txt")
        Dim fi As IO.FileInfo
        For Each fi In aryFi
            If fi.Name = ComboBox1.SelectedItem Then
                questionFile = fi.Name
            End If
        Next
        Form2.Show()
        Hide()
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Dim player As WindowsMediaPlayer
        'player = New WindowsMediaPlayer
        'player.URL = "C:\Users\Owner\Music\Amazon MP3\Nobuo Uematsu\Distant Worlds II more music from Final Fantasy\01-02- The Man With The MacHine Gun (Final Fantasy VIII).mp3"
        'player.controls.play()
        ComboBox1.Items.Clear()
        Dim di As New IO.DirectoryInfo("./")
        Dim aryFi As IO.FileInfo() = di.GetFiles("*.txt")
        Dim fi As IO.FileInfo
        For Each fi In aryFi
            ComboBox1.Items.Add(fi.Name)
        Next
    End Sub
End Class
