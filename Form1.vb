Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Add(TextBox1.Text & " : " & TextBox2.Text)
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.RemoveAt(ListBox1.SelectedIndex())

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim palabra As Integer = ListBox1.SelectedIndex
        ListBox1.Items.RemoveAt(palabra)
        ListBox1.Items.Insert(palabra, TextBox1.Text & " : " & TextBox2.Text)

        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim imagen As New OpenFileDialog()
        imagen.Filter = "Archivo JPG|*.jpg"
        If imagen.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(imagen.FileName)
            Button5.Enabled = True
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MsgBox("¿Esta seguro que desea finalizar el guardado...?", MsgBoxStyle.Question + vbYesNo, "Alerta") = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim guardar As New SaveFileDialog
        guardar.Filter = "Archivo.txt | *.txt"
        'condicion
        If guardar.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim archivo_nuevo As New System.IO.StreamWriter(guardar.FileName)
            For Each item In ListBox1.Items
                archivo_nuevo.WriteLine(item.ToString())

            Next
            archivo_nuevo.Close()
            Button5.Enabled = False
        End If
    End Sub
End Class
