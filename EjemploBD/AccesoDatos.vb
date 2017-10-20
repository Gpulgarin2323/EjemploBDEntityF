Public Class AccesoDatos
    Shared ctx As New EjemploBDEntities()

    Shared Sub CargarCombo(cbo As ComboBox)
        Dim datos = (From s In ctx.Sexo
                     Select s).ToList

        cbo.DataSource = datos
        cbo.DisplayMember = "Sexo1"
        cbo.ValueMember = "IdSexo"
        cbo.SelectedValue = -1

    End Sub

    Shared Sub CargarGrid(grid As DataGridView)
        Dim datos = (From e In ctx.Empleados
                     Select e.IdPersonas, e.Nombre, e.Apellidos, e.FechaNacimiento, Genero = e.Sexo.Sexo1).ToList

        grid.DataSource = datos
        grid.Columns(0).Visible = False
    End Sub

    Shared Sub AgregarEmpleado(Emp As Empleados)
        ctx.Empleados.Add(Emp)
        ctx.SaveChanges()

    End Sub

    Shared Sub EliminarEmplado(id As Integer)
        Dim emp = (From e In ctx.Empleados
                   Where e.IdPersonas = id
                   Select e).SingleOrDefault

        ctx.Empleados.Remove(emp)
        ctx.SaveChanges()

    End Sub

    Shared Function MostrarInfoEmpleado(id As Integer) As Empleados
        Dim emp = (From e In ctx.Empleados
                   Where e.IdPersonas = id
                   Select e).SingleOrDefault
        Return emp
    End Function

    Shared Sub ActulizarEmpleado(id As Integer, Nombre As String, Apellido As String, FechaNacimiento As Date, Sexo As Integer)
        Dim emp = (From e In ctx.Empleados
                   Where e.IdPersonas = id
                   Select e).SingleOrDefault

        With emp
            .Nombre = Nombre
            .Apellidos = Apellido
            .FechaNacimiento = FechaNacimiento
            .IdSexo = Sexo
        End With

        ctx.SaveChanges()

    End Sub

End Class
