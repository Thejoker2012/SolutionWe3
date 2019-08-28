Imports System.Data.SqlClient

Public Class Conexao
    'Variável de conexão
    Private StringConexao As String = My.Settings.BANCO

    Public Function AbreConexao()

        Dim Con As SqlConnection = New SqlConnection()

        Try

            Con.ConnectionString = StringConexao
            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

        Catch ex As Exception
            Throw New Exception("ERRO AcessoDados.AbreConexao(): " & ex.Message)
        End Try

        Return Con

    End Function

    Public Sub FechaConexao(ByVal ConParam As SqlConnection)
        Try
            ConParam.Close()
        Catch ex As Exception
            Throw New Exception("ERRO AcessoDados.FechaConexao(): " & ex.Message)
        End Try
    End Sub

    Public Function ExecutaSqlNew(ByVal Sql As String) As String

        Dim Transacao As SqlTransaction

        Dim Conexao As SqlConnection = AbreConexao()

        Dim retorno As String = "OK"  'Retorno padrão 

        Transacao = Conexao.BeginTransaction()

        Dim N As Integer = -1
        Try
            Dim Comando As SqlCommand = New SqlCommand()
            Comando.Connection = Conexao
            Comando.CommandType = CommandType.Text
            Comando.CommandText = Sql
            Comando.Transaction = Transacao
            N = Comando.ExecuteNonQuery()

            Transacao.Commit()

        Catch ex As Exception
            Transacao.Rollback()
            retorno = ex.Message.ToString 'Retorno da mensagem de ERRO
        Finally
            FechaConexao(Conexao)
            Transacao.Dispose()
        End Try

        Return retorno

    End Function

    Public Function ExecutaSql(ByVal Sql As String) As Integer

        Dim Transacao As SqlTransaction

        Dim Conexao As SqlConnection = AbreConexao()

        Transacao = Conexao.BeginTransaction()

        Dim N As Integer = -1
        Try
            Dim Comando As SqlCommand = New SqlCommand()
            Comando.Connection = Conexao
            Comando.CommandType = CommandType.Text
            Comando.CommandText = Sql
            Comando.Transaction = Transacao
            N = Comando.ExecuteNonQuery()

            Transacao.Commit()

        Catch ex As Exception
            Transacao.Rollback()
            ' Throw New Exception("ERRO AcessoDados.ExecutaSql(Sql): " & ex.Message)
        Finally
            FechaConexao(Conexao)
            Transacao.Dispose()
        End Try

        Return N

    End Function

    Public Function ExecutaSqlRetorno(ByVal Sql As String) As DataSet
        Dim Conexao As SqlConnection = AbreConexao()
        Dim DadosRet As DataSet = New DataSet()
        Try
            Dim Comando As SqlCommand = New SqlCommand()
            Comando.Connection = Conexao
            Comando.CommandType = CommandType.Text
            Comando.CommandText = Sql

            Dim Adaptador As SqlDataAdapter = New SqlDataAdapter()
            Adaptador.SelectCommand = Comando
            Adaptador.Fill(DadosRet)

        Catch ex As Exception
            Throw New Exception("ERRO AcessoDados.ExecutaSqlRetorno(Sql): " & ex.Message)
        Finally
            FechaConexao(Conexao)
        End Try

        Return DadosRet
    End Function

    Public Function ExecutaSqlScalar(ByVal Sql As String) As Double
        Dim Transacao As SqlTransaction
        Dim Conexao As SqlConnection = AbreConexao()
        Transacao = Conexao.BeginTransaction()
        Dim N As Double = -1
        Try
            Dim Comando As SqlCommand = New SqlCommand()
            Comando.Connection = Conexao
            Comando.CommandType = CommandType.Text
            Comando.CommandText = Sql
            Comando.Transaction = Transacao
            N = Comando.ExecuteScalar()
            Transacao.Commit()
        Catch ex As Exception
            Transacao.Rollback()
        Finally
            FechaConexao(Conexao)
            Transacao.Dispose()
        End Try
        Return N
    End Function

End Class

