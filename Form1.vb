Public Class Form1

    Dim BB As New Bitmap(800, 300)
    Dim G As Graphics = Graphics.FromImage(BB)
    Dim GameRunning As Boolean = True

    Dim blnJump As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'SET UP INITIAL GRAPHICS DISPLAY 
        Show()
        G.Clear(Color.LightPink)
        G.FillRectangle(Brushes.DarkGreen, New RectangleF(New Point(0, 200), New Size(800, 100)))
        'End drawing
        CreateGraphics.DrawImage(BB, 0, 0)


        'START GAME LOOP
        GameLoop()

    End Sub

    Private Sub GameLoop()

        'FRAME COUNT FOR OBSTICLE GENERATION
        Dim Frames As Integer = 0

        'CHARACTER VARIABLES
        Dim BlockBoy As New Player
        Dim BlockBoyY As Double
        Dim blockboyX As Integer = 270

        'OBSTICLE VARIABLES
        Static intRocks As Integer = -1
        Static intPlats As Integer = -1
        Dim Rocks(intRocks) As Obsticles
        Dim Plats(intPlats) As Obsticles
        Dim RockSpacing As Integer = 10
        Dim rndType As Integer = 1

        'RANDOMIZER
        Randomize()


        Do While GameRunning = True

            'COUNTS FRAMES PASSED THROUGH
            Frames += 1
            If Frames = 1000 Then
                Frames = 0
            End If

            rndType = Int((4 - 1 + 1) * Rnd() + 1)

            If rndType > 1 Then

                'MAKES A NEW ROCK
                If Frames Mod RockSpacing = 0 Then
                    RockSpacing = Int((350 - 150 + 1) * Rnd() + 350)
                    Call MakeRock(intRocks, Rocks)
                    For i = 0 To Rocks.Length - 1
                        Rocks(i).Type = 1
                    Next
                    RockSpacing = Int((350 - 150 + 1) * Rnd() + 350)
                End If

            ElseIf rndType = 1 Then

                'MAKES A PLAT
                If Frames Mod RockSpacing = 0 Then
                    RockSpacing = Int((350 - 150 + 1) * Rnd() + 350)
                    Call MakePlat(intPlats, Plats)
                    For i = 0 To Plats.Length - 1
                        Plats(i).Type = 2
                    Next
                    RockSpacing = Int((350 - 150 + 1) * Rnd() + 350)
                End If

            End If




            'DO ALL OTHER TASKS
            Application.DoEvents()

            'DRAW Map
            G.Clear(Color.LightPink)
            G.FillRectangle(Brushes.DarkGreen, New RectangleF(New Point(0, 200), New Size(800, 100)))

            'CHECKS FOR A JUMP
            If blnJump And BlockBoyY = 180 Then
                BlockBoy.Jump()
                blnJump = False
            End If

            'GETS VALUE OF Y/ DRAWS PLAYER
            BlockBoyY = BlockBoy.Update(G)

            'DRAW OBSTICLES
            For i = 0 To Rocks.Length - 1
                Rocks(i).Update(G)
            Next
            For i = 0 To Plats.Length - 1
                Plats(i).Update(G)
            Next


            'END DRAWING
            CreateGraphics.DrawImage(BB, 0, 0)

        Loop

    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

        'KEY PRESS SPACE=JUMP
        If e.KeyChar = ChrW(Keys.Space) Then
            blnJump = True
        End If

    End Sub

    Private Sub MakeRock(ByRef intRocks As Integer, ByRef rocks() As Obsticles)

        intRocks = intRocks + 1
        ReDim Preserve rocks(intRocks)
        Dim rock As New Obsticles
        rocks(intRocks) = rock

    End Sub

    Private Sub MakePlat(ByRef intPLats As Integer, ByRef Plats() As Obsticles)

        intPLats = intPLats + 1
        ReDim Preserve Plats(intPLats)
        Dim plat As New Obsticles
        Plats(intPLats) = plat

    End Sub

    Private Function Collision(PlayerX As Integer, PlayerY As Integer) As Boolean




    End Function




End Class
