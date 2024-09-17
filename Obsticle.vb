Public Class Obsticles

    Dim x As Integer = 800
    Dim y As Integer
    Public Type As Integer

    Public Function Update(g As Graphics) As Integer

        'MOVE
        x = x - 1

        If Type = 1 Then

            'GROUND OBSTICLE
            g.FillRectangle(Brushes.Gray, New RectangleF(New Point(x, 175), New Size(25, 25)))

        ElseIf Type = 2 Then

            'AIR OBSTICLE
            g.FillRectangle(Brushes.Blue, New RectangleF(New Point(x, 150), New Size(90, 50)))

        End If

        Return x

    End Function




End Class
