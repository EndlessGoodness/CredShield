Imports System.Drawing.Drawing2D

Public Class RoundedButton
    Inherits Button

    Private _cornerRadius As Integer = 15

    Public Sub New()
        MyBase.New()
        Me.DoubleBuffered = True
        Me.FlatStyle = FlatStyle.Flat
        Me.FlatAppearance.BorderSize = 0
    End Sub

    Public Property CornerRadius As Integer
        Get
            Return _cornerRadius
        End Get
        Set(value As Integer)
            _cornerRadius = value
            Me.Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        ' Draw rounded rectangle background
        Dim path As New GraphicsPath()
        Dim radius = _cornerRadius * 2

        ' Create rounded rectangle path
        path.AddArc(New Rectangle(0, 0, radius, radius), 180, 90)
        path.AddArc(New Rectangle(Me.Width - radius, 0, radius, radius), 270, 90)
        path.AddArc(New Rectangle(Me.Width - radius, Me.Height - radius, radius, radius), 0, 90)
        path.AddArc(New Rectangle(0, Me.Height - radius, radius, radius), 90, 90)
        path.CloseFigure()

        ' Set the button region to the rounded path
        Me.Region = New Region(path)

        ' Draw the background
        Using brush As New SolidBrush(Me.BackColor)
            pevent.Graphics.FillPath(brush, path)
        End Using

        ' Draw the text
        Dim textSize = pevent.Graphics.MeasureString(Me.Text, Me.Font)
        Dim textX = (Me.Width - textSize.Width) / 2
        Dim textY = (Me.Height - textSize.Height) / 2

        Using textBrush As New SolidBrush(Me.ForeColor)
            pevent.Graphics.DrawString(Me.Text, Me.Font, textBrush, textX, textY)
        End Using

        path.Dispose()
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        Me.Invalidate()
    End Sub
End Class
