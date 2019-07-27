Imports System.Threading

Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim g As Graphics = PictureBox1.CreateGraphics()
        Dim n As Integer = 3
        Dim c As String = txtC.Text
        Dim pen As New Pen(Color.Black)
        Dim p As Point = New Point(200, 200)

        g.Clear(Color.White)
        n = Val(txtN.Text)

        Select Case c
            Case "R"
                pen.Color = Color.Red
            Case "G"
                pen.Color = Color.Green
            Case "L"
                pen.Color = Color.Blue
        End Select

        ListBox1.Items.Clear()

        For i = 0 To n - 1
            ListBox1.Items.Add(getNewPoint(p, 360 / n * i, 200))
            'g.DrawLine(pen, getNewPoint(p, 360 / n * i - 90, 200), getNewPoint(p, 360 / n * (i + 1) - 90, 200))

            For j = i + 1 To n - 1
                g.DrawLine(pen, _
                    getNewPoint(p, 360 / n * i, 200), _
                    getNewPoint(p, 360 / n * j, 200))
                Thread.Sleep(100)
            Next
        Next
        'g.DrawEllipse(pen, p.X - 200, p.Y - 200, 400, 400)
    End Sub

    Private Function getNewPoint(ByVal point As Point, ByVal angle As Integer, ByVal length As Integer)
        '弧度 = 角度 * (Math.PI / 180)

        point.X = point.X + Math.Cos(angle * Math.PI / 180) * length
        point.Y = point.Y - Math.Sin(angle * Math.PI / 180) * length

        Return point
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '建立 Graphics
        Dim g As Graphics = PictureBox1.CreateGraphics()
        '建立筆
        Dim pen As New Pen(Color.Black)
        '建立點
        Dim p1 As New Point(100, 100)
        Dim p2 As New Point(200, 200)
        '畫線
        g.DrawLine(pen, p1, p2)

        ' 計算後
        Dim p3 As Point = getNewPoint(p1, 45, 100)
        g.DrawLine(pen, p1, p3)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim g As Graphics = PictureBox1.CreateGraphics()
        Dim pen As New Pen(Color.Black)
        Dim pen2 As New Pen(Color.Red)

        Dim p As New Point(100, 100)
        Dim p1 As Point = getNewPoint(p, 0, 100)
        Dim p2 As Point = getNewPoint(p, 120, 100)
        Dim p3 As Point = getNewPoint(p, 240, 100)


        g.DrawLine(pen, p1, p2)
        Thread.Sleep(100)
        g.DrawLine(pen, p2, p3)
        Thread.Sleep(100)
        g.DrawLine(pen, p3, p1)
        Thread.Sleep(100)

        g.DrawLine(pen2, p, p1)
        g.DrawLine(pen2, p, p2)
        g.DrawLine(pen2, p, p3)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim g As Graphics = PictureBox1.CreateGraphics()
        Dim pen As New Pen(Color.Black)

        Dim p1 As New Point(200, 200)
        Dim p2 As Point = getNewPoint(p1, 0, 100)
        Dim p3 As Point = getNewPoint(p2, 90, 100)
        Dim p4 As Point = getNewPoint(p3, 180, 100)

        g.DrawLine(pen, p1, p2)
        g.DrawLine(pen, p2, p3)
        g.DrawLine(pen, p3, p4)
        g.DrawLine(pen, p4, p1)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim g As Graphics = PictureBox1.CreateGraphics()
        Dim Pen As New Pen(Color.Blue)

        'x y width height
        g.DrawEllipse(Pen, 100, 100, 300, 300)
        'g.DrawRectangle(Pen, 100, 100, 300, 300)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim g As Graphics = PictureBox1.CreateGraphics()
        Dim Pen As New Pen(Color.Blue)
        'DrawPie (Pen, x, y, 寬度, 高度, 起始角度, 角度變化)
        g.DrawPie(Pen, 100, 100, 300, 300, 45, 90)
    End Sub

    '逐步寫
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim g As Graphics = PictureBox1.CreateGraphics()
        Dim pen As New Pen(Color.Black)
        Dim p As Point = New Point(200, 200)

        g.Clear(Color.White)

        g.DrawLine(pen, p, getNewPoint(p, 90 - Now.Second * 6, 100))
        g.DrawLine(pen, p, getNewPoint(p, 90 - Now.Hour * 30, 80))
        g.DrawLine(pen, p, getNewPoint(p, 90 - Now.Minute * 6, 90))

        g.DrawEllipse(pen, p.X - 100, p.Y - 100, 200, 200)

        Dim font As New Font("Arial", 18, FontStyle.Bold)
        For i = 1 To 12
            Dim np As Point = getNewPoint(p, 90 - i * 30, 140)
            g.DrawString(i, font, Brushes.Black, np.X - 10, np.Y - 10)
        Next
    End Sub
End Class
