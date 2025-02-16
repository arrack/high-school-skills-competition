﻿Public Class Form1
    Dim map(10, 10), obMap(10, 10) As Integer
    Dim s, t As Point

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize()
        initMap()
        showMap()
    End Sub

    Private Sub initMap()
        s = New Point(0, 0)
        t = New Point(0, 0)
        For i = 1 To 9
            For j = 1 To 9
                map(i, j) = 0
            Next
        Next

        obMap = map.Clone()
    End Sub

    Private Sub showMap()
        Dim k As Integer
        For i = 1 To 9
            For j = 1 To 9
                k = (i - 1) * 9 + j
                Controls("TextBox" & k).Text = ""
                If (map(i, j) = 0 Or map(i, j) = -2) Then
                    Controls("TextBox" & k).BackColor = Color.White
                ElseIf (map(i, j) = -1) Then
                    Controls("TextBox" & k).BackColor = Color.Black
                ElseIf (map(i, j) = -3) Then
                    Controls("TextBox" & k).BackColor = Color.Gray
                Else
                    Controls("TextBox" & k).Text = map(i, j)
                End If
            Next
        Next

        k = (s.X - 1) * 9 + s.Y
        If k >= 1 And k <= 81 Then
            Controls("TextBox" & k).Text = "S"
        End If
        k = (t.X - 1) * 9 + t.Y
        If k >= 1 And k <= 81 Then
            Controls("TextBox" & k).Text = "T"
        End If
    End Sub

    Private Sub randMap()

        Dim i, max As Integer
        Dim p As Point
        max = Rnd() * 30 + 20
        LabelRand.Text = max

        Do While (i < max)
            p = getRandPoint()
            map(p.X, p.Y) = -1
            i += 1
        Loop

        obMap = map.Clone()
    End Sub

    Private Sub findPath()
        Dim w As Integer = 1
        Dim q As Queue = New Queue

        map(s.X, s.Y) = w
        map(t.X, t.Y) = 0
        q.Enqueue(New Point(s.X, s.Y))


        Do Until map(t.X, t.Y) > 0 Or w > 9 * 9

            Dim q2 As Queue = New Queue
            Do While q.Count > 0
                'showMap()
                'Application.DoEvents()
                'Threading.Thread.Sleep(100)
                Dim p As Point = q.Dequeue()
                ' 左
                If p.X > 1 Then If map(p.X - 1, p.Y) = 0 Then map(p.X - 1, p.Y) = w + 1 : q2.Enqueue(New Point(p.X - 1, p.Y))
                ' 右
                If p.X < 9 Then If map(p.X + 1, p.Y) = 0 Then map(p.X + 1, p.Y) = w + 1 : q2.Enqueue(New Point(p.X + 1, p.Y))
                ' 上
                If p.Y > 1 Then If map(p.X, p.Y - 1) = 0 Then map(p.X, p.Y - 1) = w + 1 : q2.Enqueue(New Point(p.X, p.Y - 1))
                ' 下
                If p.Y < 9 Then If map(p.X, p.Y + 1) = 0 Then map(p.X, p.Y + 1) = w + 1 : q2.Enqueue(New Point(p.X, p.Y + 1))
            Loop
            q = q2.Clone()
            w += 1
        Loop

        '標示路徑
        Dim x, y As Integer
        x = t.X
        y = t.Y
        If map(t.X, t.Y) = 0 Then
            LabelResult.Text = "NO"
            Return
        End If

        Do Until w < 1
            'showMap()
            'Threading.Thread.Sleep(100)
            'Application.DoEvents()
            If (x = s.X And y = s.Y) Then
                map(x, y) = -3
                LabelResult.Text = "YES"
                Return
            End If
            ' 左
            If map(x - 1, y) = w - 1 Then
                map(x, y) = -3
                x -= 1
                w -= 1
            End If
            ' 右
            If map(x + 1, y) = w - 1 Then
                map(x, y) = -3
                x += 1
                w -= 1
            End If
            '上
            If map(x, y - 1) = w - 1 Then
                map(x, y) = -3
                y -= 1
                w -= 1
            End If
            '下
            If map(x, y + 1) = w - 1 Then
                map(x, y) = -3
                y += 1
                w -= 1
            End If
        Loop
    End Sub

    Private Function getRandPoint()
        Dim find As Boolean = False
        Dim x, y As Integer

        Do While (Not find)
            x = Rnd() * 8 + 1
            y = Rnd() * 8 + 1
            If map(x, y) = 0 Then
                Return New Point(x, y)
            End If
        Loop

        Return New Point(0, 0)
    End Function

    Private Sub btnInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInit.Click
        initMap()
        showMap()
    End Sub

    Private Sub btnRand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRand.Click
        initMap()
        randMap()
        showMap()
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        map = obMap.Clone()

        s = getRandPoint()
        map(s.X, s.Y) = -2
        t = getRandPoint()
        map(t.X, t.Y) = -2

        showMap()
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        findPath()
        showMap()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub
End Class
