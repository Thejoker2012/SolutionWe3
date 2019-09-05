<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Categoria.aspx.vb" Inherits="Web3Project.Categoria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 242px;
        }
        .auto-style2 {
            width: 420px;
        }
        .auto-style3 {
            width: 92%;
        }
    </style>
</head>
<body style="width: 651px; height: 119px">
    <form id="form1" runat="server">
        <div>
            <table class="auto-style3">
                <tr>
                    <td class="auto-style1">Nome da Categoria:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtNomeCategoria" runat="server" Width="402px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Descrição:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtDescricao" runat="server" Width="402px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Width="122px" />
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="btnLimpar" runat="server" Text="Limpar" Width="122px" />
                    </td>
                </tr>
            </table>
        </div>
        <div>

            <asp:TextBox ID="txtMsg" runat="server" BackColor="#FFFF66" Font-Bold="True" ForeColor="#0066FF" Height="44px" TextMode="MultiLine" Visible="False" Width="100%"></asp:TextBox>

        </div>
    </form>
</body>
</html>
