Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccesoDatos.CargarCombo(cboSexo)
        AccesoDatos.CargarGrid(dgvDatos)

    End Sub

    Private Sub dgvDatos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellContentClick

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        AccesoDatos.AgregarEmpleado(New Empleados() With
                                    {
                                        .Nombre = txtNombre.Text,
                                        .Apellidos = txtApellido.Text,
                                        .FechaNacimiento = dtpFechaNacimiento.Value,
                                        .IdSexo = cboSexo.SelectedValue
                                    })
        AccesoDatos.CargarGrid(dgvDatos)
        MsgBox("El Empledo ha sido Regritados", MsgBoxStyle.Information, "Gestion de empleados")

    End Sub

    Private Sub EliminarEmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarEmpleadoToolStripMenuItem.Click

        If MsgBox("Confirma la Eliminación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirme") = MsgBoxResult.Yes Then

            Dim ide As Integer = dgvDatos.CurrentRow().Cells(0).Value
            AccesoDatos.EliminarEmplado(ide)
            AccesoDatos.CargarGrid(dgvDatos)
        End If


    End Sub

    Private Sub dgvDatos_Click(sender As Object, e As EventArgs) Handles dgvDatos.Click
        Dim ide As Integer = dgvDatos.CurrentRow().Cells(0).Value
        Dim emp As Empleados = AccesoDatos.MostrarInfoEmpleado(ide)

        txtNombre.Text = emp.Nombre
        txtApellido.Text = emp.Apellidos
        dtpFechaNacimiento.Value = emp.FechaNacimiento
        cboSexo.SelectedValue = emp.IdSexo
        txtIDNombre.Text = emp.IdPersonas
    End Sub

    Private Sub btnActualiza_Click(sender As Object, e As EventArgs) Handles btnActualiza.Click
        Dim ide As Integer = dgvDatos.CurrentRow().Cells(0).Value
        AccesoDatos.ActulizarEmpleado(CInt(txtIDNombre.Text), txtNombre.Text, txtApellido.Text, dtpFechaNacimiento.Value, cboSexo.SelectedValue)
        AccesoDatos.CargarGrid(dgvDatos)

    End Sub
End Class
