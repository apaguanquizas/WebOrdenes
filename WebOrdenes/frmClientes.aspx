<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmClientes.aspx.cs" Inherits="WebOrdenes.frmClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Validador.js"></script>
    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 48px">&nbsp;</td>
                <td>
                    <div style="height: 38px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="12pt" Text="Administración -Clientes" style="text-decoration: underline"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 48px">
                    &nbsp;</td>
                <td>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 4px">
                                <div style="width: 132px; height: 40px">
                                    <asp:Button ID="btnNuevo" runat="server" Height="30px" OnClick="btnNuevo_Click" Text="Nuevo" Width="127px" />
                                </div>
                            </td>
                            <td style="width: 147px">
                                <div style="width: 147px; height: 40px">
                                    <asp:Button ID="btnGuardar" runat="server" Height="30px" OnClick="btnGuardar_Click" Text="Guardar" Width="127px" OnClientClick="return confirm('¿Desea Continuar con el Proceso?');" />
                                </div>
                            </td>
                            <td>
                                <div style="text-align: right; width: 372px;">
                                    <asp:Label ID="lblAlertas" runat="server" Font-Bold="True" ForeColor="#FFCC00"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 48px">
                    <div style="width: 48px">
                    </div>
                </td>
                <td class="text-left">
                    <asp:Label ID="Label5" runat="server" Text="Número de Identificación"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 48px">&nbsp;</td>
                <td class="text-left">
                    <asp:TextBox ID="txtIdentificacion" runat="server" Width="150px" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 48px">&nbsp;</td>
                <td class="text-left">
                    <asp:Label ID="Label2" runat="server" Text="Nombres del Cliente"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 48px">&nbsp;</td>
                <td class="text-left">
                    <asp:TextBox ID="txtNombre" runat="server" Width="318px"></asp:TextBox>
                    <asp:Label ID="lblID" runat="server" Text="0" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 48px">&nbsp;</td>
                <td class="text-left">
                    <asp:Label ID="Label3" runat="server" Text="Apellidos del Cliente"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 48px">&nbsp;</td>
                <td class="text-left">
                    <asp:TextBox ID="txtApellido" runat="server" Width="318px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 48px">&nbsp;</td>
                <td class="text-left">
                    <hr />
                </td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 48px">&nbsp;</td>
                <td class="text-left">
                    <asp:TextBox ID="txtBuscar" runat="server" BackColor="#FFFFCC" Width="318px" placeholder="Busqueda de Clientes"></asp:TextBox>
                    <asp:LinkButton ID="btnBuscar" runat="server" OnClick="btnBuscar_Click">Buscar</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 48px">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 48px">&nbsp;</td>
                <td>
                    <asp:GridView ID="grwClientes" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_cliente" ForeColor="#333333" GridLines="None" Height="35px" Width="652px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table class="nav-justified">
                                        <tr>
                                            <td style="width: 14px">
                                                <div style="width: 14px">
                                                </div>
                                            </td>
                                            <td style="width: 37px">
                                                <asp:LinkButton ID="btnEditarGW" runat="server" OnClick="btnEditarGW_Click">Editar</asp:LinkButton>
                                            </td>
                                            <td>
                                                <div style="width: 14px">
                                                </div>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="btnEliminarGW" runat="server" OnClick="btnEliminarGW_Click" OnClientClick="return confirm('¿Desea Continuar con el Proceso?');">Eliminar</asp:LinkButton>
                                            </td>
                                            <td>
                                                <div style="width: 14px">
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <HeaderStyle Width="1px" />
                                <ItemStyle Width="1px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Identificacion" HeaderText="Identificación">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Apellidos" HeaderText="Apellidos">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </p>
</asp:Content>

