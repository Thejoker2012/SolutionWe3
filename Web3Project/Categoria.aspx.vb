Public Class Categoria
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        'Captura os dados do formulário
        Dim categorias As New CategoriasTO
        categorias.NomeCategoria = txtNomeCategoria.Text
        categorias.Descricao = txtDescricao.Text

        'Enviar para a DAO'
        Dim dao As New CategoriasDAO
        Dim msg As String
        Dim MsgVazio As String

        If (txtNomeCategoria.Text And txtDescricao.Text = "") Then
            MsgVazio = "Preencha os Campos!"
        End If


        msg = dao.Adiciona(categorias)

        If msg = "OK" Then
            txtMsg.Visible = True
            txtMsg.Text = "Gravação com Sucesso!"

        Else
            txtMsg.Visible = True
            txtMsg.Text = msg
        End If

    End Sub

    Protected Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click

        txtNomeCategoria.Focus()
        txtMsg.Visible = False

    End Sub
End Class