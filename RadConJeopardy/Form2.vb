Public Class Form2
    Dim questions(0 To 2, 0 To 60) As String
    Dim categories(0 To 12) As String
    Dim doubleQ(0 To 2) As Int16
    Dim finalQ As String
    Public scores(0 To 3) As Int32
    Dim currRound As Int16
    Dim currPoint As Int16
    Dim qCount As Integer
    Dim doubleJeop As Boolean
    Public finalJ As Boolean

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadQuestions()
        currRound = 1
        currPoint = 0
        For x = 1 To 3
            scores(x) = 0
        Next
        Randomize()
        doubleQ(1) = Int(30 * Rnd()) + 1
        dispScores()
        Label1.Text = categories(1)
        Label2.Text = categories(2)
        Label3.Text = categories(3)
        Label4.Text = categories(4)
        Label5.Text = categories(5)
        Label6.Text = categories(6)
        doubleJeop = False
    End Sub

    Private Sub loadQuestions()
        Dim parser As String
        parser = ""
        MsgBox(Form1.questionFile)
        FileOpen(1, Form1.questionFile, OpenMode.Input)
        Do While Not EOF(1)
            For x = 1 To 6
                Input(1, parser)
                categories(x) = parser
            Next
            For x = 1 To 30
                Input(1, parser)
                questions(1, x) = parser
            Next
            For x = 7 To 12
                Input(1, parser)
                categories(x) = parser
            Next
            For x = 31 To 60
                Input(1, parser)
                questions(1, x) = parser
            Next
            Input(1, parser)
            finalQ = parser
        Loop
    End Sub

    Public Sub ask(pointVal As Int16, questionNum As Int32)
        updateScore()
        If finalJ Then
            Form3.Label8.Text = finalQ
            currPoint = 1
        ElseIf questionNum = doubleQ(1) Or questionNum = doubleQ(2) Then
            MsgBox("Daily Double!!!")
            If doubleJeop Then
                Form3.Label8.Text = questions(currRound, questionNum + 30)
            Else
                Form3.Label8.Text = questions(currRound, questionNum)
            End If
            currPoint = 2
        Else
            If doubleJeop Then
                Form3.Label8.Text = questions(currRound, questionNum + 30)
            Else
                Form3.Label8.Text = questions(currRound, questionNum)
            End If
            currPoint = pointVal
        End If
        Form3.Visible = True

    End Sub

    Public Sub updateScore()
        For x = 1 To 3
            Dim rawScore As String
            Select Case x
                Case 1
                    rawScore = TextBox1.Text
                Case 2
                    rawScore = TextBox2.Text
                Case 3
                    rawScore = TextBox3.Text
            End Select
            scores(x) = Int(rawScore)
        Next
    End Sub

    Public Sub score()
        If currPoint = 1 Then
            Dim wager As Int16
            Dim correct As Integer
            For x = 1 To 3
                wager = InputBox("How much did Player " + x.ToString() + " wager?")
                correct = MsgBox("Did they get the answer correct?", 36)
                If correct = 6 Then
                    scores(x) = scores(x) + (wager)
                Else
                    scores(x) = scores(x) - (wager)
                End If
            Next
        ElseIf currPoint = 2 Then
            Dim wager As Int16
            Dim correct As Integer
            Dim playerNum As Integer
            playerNum = InputBox("Which player got the question?")
            wager = InputBox("How much did the player wager?")
            correct = MsgBox("Did they get the answer correct?", 36)
            If correct = 6 Then
                scores(playerNum) = scores(playerNum) + (wager)
            Else
                scores(playerNum) = scores(playerNum) - (wager)
            End If
        Else
            For x = 1 To 3
                If doubleJeop Then
                    scores(x) = scores(x) + (Form3.answers(x) * currPoint * 2)
                Else
                    scores(x) = scores(x) + (Form3.answers(x) * currPoint)
                End If
            Next
        End If
        dispScores()
        qCount = qCount + 1
        checkDouble()
    End Sub

    Public Sub checkDouble()
        If qCount = 30 Then
            'MsgBox("Time for Double Jeopardy!!!")
            doubleRound()
            doubleJeop = True
        ElseIf qCount = 60 Then
            MsgBox("Time for Final Jeopardy!!!")
            Form3.finalJeop()
            finalJ = True
            Button1.Text = "Final"
            Button1.Show()
        Else

        End If
    End Sub

    Public Sub doubleRound()
        Randomize()
        MsgBox("Now on to Double Jeopardy!")
        doubleQ(1) = Int(30 * Rnd()) + 1
        doubleQ(2) = Int(30 * Rnd()) + 1
        Do While doubleQ(2) = doubleQ(1)
            doubleQ(2) = Int(30 * Rnd()) + 1
        Loop
        Button1.Text = "$400"
        Button1.Visible = True
        Button2.Text = "$800"
        Button2.Visible = True
        Button3.Text = "$1200"
        Button3.Visible = True
        Button4.Text = "$1600"
        Button4.Visible = True
        Button5.Text = "$2000"
        Button5.Visible = True
        Button10.Text = "$400"
        Button10.Visible = True
        Button9.Text = "$800"
        Button9.Visible = True
        Button8.Text = "$1200"
        Button8.Visible = True
        Button7.Text = "$1600"
        Button7.Visible = True
        Button6.Text = "$2000"
        Button6.Visible = True
        Button15.Text = "$400"
        Button15.Visible = True
        Button14.Text = "$800"
        Button14.Visible = True
        Button13.Text = "$1200"
        Button13.Visible = True
        Button12.Text = "$1600"
        Button12.Visible = True
        Button11.Text = "$2000"
        Button11.Visible = True
        Button20.Text = "$400"
        Button20.Visible = True
        Button19.Text = "$800"
        Button19.Visible = True
        Button18.Text = "$1200"
        Button18.Visible = True
        Button17.Text = "$1600"
        Button17.Visible = True
        Button16.Text = "$2000"
        Button16.Visible = True
        Button25.Text = "$400"
        Button25.Visible = True
        Button24.Text = "$800"
        Button24.Visible = True
        Button23.Text = "$1200"
        Button23.Visible = True
        Button22.Text = "$1600"
        Button22.Visible = True
        Button21.Text = "$2000"
        Button21.Visible = True
        Button30.Text = "$400"
        Button30.Visible = True
        Button29.Text = "$800"
        Button29.Visible = True
        Button28.Text = "$1200"
        Button28.Visible = True
        Button27.Text = "$1600"
        Button27.Visible = True
        Button26.Text = "$2000"
        Button26.Visible = True
        Label1.Text = categories(7)
        Label2.Text = categories(8)
        Label3.Text = categories(9)
        Label4.Text = categories(10)
        Label5.Text = categories(11)
        Label6.Text = categories(12)
    End Sub

    Public Sub dispScores()
        Dim scoreDisp As String
        For x = 1 To 3
            scoreDisp = "$"
            If scores(x) = 0 Then
                scoreDisp = "$0"
            ElseIf scores(x) Mod 1000 = 0 Then
                scoreDisp = scoreDisp + Int(scores(x) / 1000).ToString()
                scoreDisp = scoreDisp + ",000"
            ElseIf scores(x) >= 1000 Then
                scoreDisp = scoreDisp + Int(scores(x) / 1000).ToString()
                scoreDisp = scoreDisp + ","
                scoreDisp = scoreDisp + (scores(x) Mod 1000).ToString()
            Else
                scoreDisp = scoreDisp + scores(x).ToString()
            End If
            Select Case x
                Case 1
                    TextBox1.Text = scoreDisp
                Case 2
                    TextBox2.Text = scoreDisp
                Case 3
                    TextBox3.Text = scoreDisp
            End Select
        Next
    End Sub

    Private Sub Form2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ask(200, 1)
        Button1.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ask(400, 2)
        Button2.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ask(600, 3)
        Button3.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ask(800, 4)
        Button4.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ask(1000, 5)
        Button5.Hide()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        ask(200, 6)
        Button10.Hide()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ask(400, 7)
        Button9.Hide()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ask(600, 8)
        Button8.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ask(800, 9)
        Button7.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ask(1000, 10)
        Button6.Hide()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        ask(200, 11)
        Button15.Hide()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        ask(400, 12)
        Button14.Hide()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        ask(600, 13)
        Button13.Hide()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        ask(800, 14)
        Button12.Hide()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        ask(1000, 15)
        Button11.Hide()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        ask(200, 16)
        Button20.Hide()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        ask(400, 17)
        Button19.Hide()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        ask(600, 18)
        Button18.Hide()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        ask(800, 19)
        Button17.Hide()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        ask(1000, 20)
        Button16.Hide()
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        ask(200, 21)
        Button25.Hide()
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        ask(400, 22)
        Button24.Hide()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        ask(600, 23)
        Button23.Hide()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        ask(800, 24)
        Button22.Hide()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        ask(1000, 25)
        Button21.Hide()
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        ask(200, 26)
        Button30.Hide()
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        ask(400, 27)
        Button29.Hide()
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        ask(600, 28)
        Button28.Hide()
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        ask(800, 29)
        Button27.Hide()
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        ask(1000, 30)
        Button26.Hide()
    End Sub
End Class