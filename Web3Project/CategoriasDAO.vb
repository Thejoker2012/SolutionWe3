Public Class CategoriasDAO

    Function Adiciona(ByRef categorias As CategoriasTO) As String

        Dim cn As New Conexao
        Dim sql As String

        sql = "INSERT INTO Categorias(nomeCategoria,descricao)" &
              "VALUES('" & categorias.NomeCategoria & "','" & categorias.Descricao & "')"
        Return cn.ExecutaSqlNew(sql)

    End Function

End Class
