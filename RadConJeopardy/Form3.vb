Public Class Form3
    Dim resetChar As Char
    Dim startChar As Char
    Dim oneChar As Char
    Dim twoChar As Char
    Dim threeChar As Char
    Dim wrongChar As Char
    Dim oneBuzz As Boolean
    Dim twoBuzz As Boolean
    Dim threeBuzz As Boolean
    Dim timeLeft As Single
    Dim thinkTimer As Single
    Dim ansChar As Char
    Dim endChar As Char
    Public answers(0 To 3) As Int16

    Dim currPlayer As Int16

    Private Sub Form3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'MsgBox(e.KeyChar.ToString)
        If e.KeyChar.Equals(startChar) And Timer1.Enabled Then
            Timer1.Enabled = False
            ProgressBar1.ForeColor = Color.RoyalBlue
        ElseIf e.KeyChar.Equals(startChar) And Not Timer1.Enabled Then
            Timer1.Enabled = True
        End If
        If e.KeyChar.Equals(ansChar) And Timer2.Enabled = True Then
            answers(currPlayer) = 1
            Call resetThink()
        End If
        If e.KeyChar.Equals(endChar) Then

            Me.Close()
        End If
        If e.KeyChar.Equals(wrongChar) And Timer2.Enabled = True Then
            answers(currPlayer) = -1
            Call resetThink()
        End If
        If e.KeyChar.Equals(oneChar) And Not oneBuzz And Timer1.Enabled Then
            Label1.Text = "1"
            Label4.Text = FormatNumber(timeLeft, 2)
            oneBuzz = True
            Timer1.Enabled = False
            ProgressBar1.ForeColor = Color.RoyalBlue
            ProgressBar2.Visible = True
            Timer2.Enabled = True
            Label9.Visible = True
            currPlayer = 1
        End If
        If e.KeyChar.Equals(twoChar) And Not twoBuzz And Timer1.Enabled Then
            Label2.Text = "2"
            twoBuzz = True
            Label5.Text = FormatNumber(timeLeft, 2)
            Timer1.Enabled = False
            ProgressBar1.ForeColor = Color.RoyalBlue
            ProgressBar2.Visible = True
            Timer2.Enabled = True
            Label9.Visible = True
            currPlayer = 2
        End If
        If e.KeyChar.Equals(threeChar) And Not threeBuzz And Timer1.Enabled Then
            Label3.Text = "3"
            threeBuzz = True
            Label6.Text = FormatNumber(timeLeft, 2)
            Timer1.Enabled = False
            ProgressBar1.ForeColor = Color.RoyalBlue
            ProgressBar2.Visible = True
            Timer2.Enabled = True
            Label9.Visible = True
            currPlayer = 3
        End If
        If e.KeyChar.Equals(resetChar) Then
            Call resetBuzzers()
        End If
    End Sub

    Private Sub Form3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Form2.finalJ Then
            Call initBuzzers()
            Call finalJeop()
        Else
            Call initBuzzers()
        End If
    End Sub

    Public Sub resetThink()
        thinkTimer = 5
        ProgressBar2.Value = 500
        Label9.Text = "5.00"
        Label9.Visible = False
        Timer2.Enabled = False
        ProgressBar2.Visible = False
        'Timer1.Enabled = True
        currPlayer = 0
    End Sub

    Public Sub initBuzzers()
        resetChar = "r"
        startChar = "s"
        ansChar = "c"
        wrongChar = "w"
        endChar = "e"
        oneChar = "1"
        twoChar = "2"
        threeChar = "3"
        oneBuzz = False
        twoBuzz = False
        threeBuzz = False
        Timer1.Enabled = False
        timeLeft = 10
        ProgressBar1.Value = 1000
        Call resetThink()
        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""
        Label4.Text = ""
        Label5.Text = ""
        Label6.Text = ""
        Label7.Text = "10.00"
        answers(1) = 0
        answers(2) = 0
        answers(3) = 0
        currPlayer = 0
        ProgressBar1.ForeColor = Color.RoyalBlue

        'Label8.Text = "This person was the announcer for the original version of Jeopardy! and for Saturday Night Live."
    End Sub

    Public Sub resetBuzzers()
        oneBuzz = False
        twoBuzz = False
        threeBuzz = False
        Timer1.Enabled = False
        timeLeft = 10
        ProgressBar1.Value = 1000
        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""
        Label4.Text = ""
        Label5.Text = ""
        Label6.Text = ""
        Label7.Text = "10.00"
        Label9.Text = "5.00"
        Timer2.Enabled = False
        Label9.Visible = False
        ProgressBar2.Visible = False
        thinkTimer = 5
        ProgressBar1.ForeColor = Color.RoyalBlue
        ProgressBar2.Value = 500
        answers(1) = 0
        answers(2) = 0
        answers(3) = 0
        currPlayer = 0
    End Sub

    Public Sub finalJeop()
        oneBuzz = False
        twoBuzz = False
        threeBuzz = False
        Timer1.Enabled = False
        timeLeft = 30
        ProgressBar1.Maximum = 3000
        ProgressBar1.Value = 3000
        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""
        Label4.Text = ""
        Label5.Text = ""
        Label6.Text = ""
        Label7.Text = "30.00"
        Label9.Text = "5.00"
        Timer2.Enabled = False
        Label9.Visible = False
        ProgressBar2.Visible = False
        ProgressBar1.ForeColor = Color.RoyalBlue
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
        If timeLeft >= 0.01 Then
            ProgressBar1.Value = ProgressBar1.Value - 1
            timeLeft = timeLeft - 0.01
            If timeLeft <= 3 Then
                ProgressBar1.ForeColor = Color.Red
            Else
                ProgressBar1.ForeColor = Color.Green
            End If
        Else
            Timer1.Enabled = False
            ProgressBar1.Value = 0
            timeLeft = 0
            Label7.Text = FormatNumber(timeLeft, 2)
            MsgBox("Time is Up!")

        End If
        Label7.Text = FormatNumber(timeLeft, 2)
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If thinkTimer >= 0.01 Then
            ProgressBar2.Value = ProgressBar2.Value - 1
            thinkTimer = thinkTimer - 0.01
            If thinkTimer <= 6 Then
                ProgressBar2.ForeColor = Color.Red
            Else
                ProgressBar2.ForeColor = Color.Green
            End If
        Else
            Timer2.Enabled = False
            ProgressBar2.Value = 0
            thinkTimer = 0
            MsgBox("Time is Up!")
            Call resetThink()
        End If
        Label9.Text = FormatNumber(thinkTimer, 2)
    End Sub

    Private Sub Form3_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Form2.score()
    End Sub
End Class