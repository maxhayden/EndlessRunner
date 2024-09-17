Public Class Player

    Dim Speed As Integer
    Dim X As Integer = 270
    Dim Y As Double
    Dim Gravity As Double = 0.1
    Dim Velocity As Double


    Public Function Update(ByRef g As Graphics) As Double

        'UPDATE LOCATION
        Velocity += Gravity
        Y += Velocity

        If Y >= 180 Then
            Y = 180
            Velocity = 0
        End If

        'DRAW
        g.FillRectangle(Brushes.Black, New RectangleF(New Point(X, Y), New Size(20, 20)))

        Return Y

    End Function

    Public Sub Jump()

        'MAKES UPWARDS VELOCITY
        Velocity = -4

    End Sub

End Class
