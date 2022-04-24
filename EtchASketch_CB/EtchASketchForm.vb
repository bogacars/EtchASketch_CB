'Carson Bogart
'RCET 0265
'Spring 22
'Etch A Sketch
'https://github.com/bogacars/EtchASketch_CB.git

Option Explicit On
Option Strict On
Public Class EtchASketchForm
    'Globals
    Dim MainPen As New Pen(Color.Black)
    Dim G As Graphics
    Private Sub EtchASketchForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        PictureBox.BackColor = Color.White
    End Sub
    Sub MouseDraw(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer)
        Dim G As Graphics = PictureBox.CreateGraphics
        'This handles the drawing of the lines
        G.DrawLine(Me.MainPen, x1, y1, x2, y2)
        G.Dispose()
    End Sub
    Private Sub PictureBox_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseDown, PictureBox.MouseMove
        Static oldX As Integer
        Static oldY As Integer
        'Allows the user to draw
        'Using the left mouse button click
        Dim MyPoint As Point
        MyPoint.Y = 0
        MyPoint.X = 0
        Me.Text = $"({e.X},{e.Y}) Button: {e.Button.ToString} Color: {Me.MainPen.Color.ToString}"
        'Shows user what button on mouse is clicked
        Select Case e.Button.ToString
            Case "Left"
                MouseDraw(oldX, oldY, e.X, e.Y)
            Case "Right"
            Case "Middle"
                ColorDialog.ShowDialog()
                Me.MainPen.Color = ColorDialog.Color
            Case "None"
            Case Else
                MsgBox("What did you just press?")
        End Select
        oldX = e.X
        Oldy = e.Y
    End Sub
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click, ClearToolStripMenuItem.Click
        'Clear button
        Shake()
        PictureBox.BackColor = Color.White
        PictureBox.Refresh()
    End Sub
    Sub Shake()
        Dim MoveAmount = 50
        'Moves screen when called
        For i = 1 To 10
            Me.Top += MoveAmount
            Me.Left += MoveAmount
            System.Threading.Thread.Sleep(100)
            MoveAmount *= -1
        Next
    End Sub
    Private Sub ChangeColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectColorToolStripMenuItem.Click
        'Tool strip menu change color
        ColorDialog.ShowDialog()
        Me.MainPen.Color = ColorDialog.Color
    End Sub
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click, ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutForm.Show()
        Me.Hide()
    End Sub

    Private Sub FillButton_Click(sender As Object, e As EventArgs) Handles FillButton.Click
        ColorDialog.ShowDialog() 'Changes backround color
        PictureBox.BackColor = ColorDialog.Color
    End Sub

End Class
