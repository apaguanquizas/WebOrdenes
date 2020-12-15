<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmOrdenes.aspx.cs" Inherits="WebOrdenes.frmOrdenes" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">   
.modalBackground
    {
    background-color: black;
    filter: alpha(opacity = 30);
    opacity: 0.5;
    }
    .modalPopup
    {
    background-color: #FFFFFF;
    border-width: 3px;
    border-style: solid;
    border-color: black;
    padding-top: 10px;
    padding-left: 10px;
    width: 300px;
    height: 140px;
    }
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 67%;
        }
        .auto-style4 {
            height: 44px;
        }
        .auto-style5 {
            width: 4px;
        }
        .auto-style6 {
            width: 7px;
        }
        .auto-style8 {
            width: 62px;
            text-align: center;
        }
        .auto-style9 {
            width: 258px;
        }
        .auto-style10 {
            font-size: 12pt;
        }
        .auto-style11 {
            width: 89px;
            text-align: right;
        }
    </style>
    <table style="width: 100%">
        <tr>
            <td style="width: 4px">&nbsp;</td>
            <td>
                    <div style="height: 38px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="12pt" Text="Orden de Productos" style="text-decoration: underline"></asp:Label>
                        <asp:Label ID="lblPopupCliente" runat="server" Font-Size="7pt" ForeColor="White" Style="color: #000000"></asp:Label>
                        <ajaxToolkit:ModalPopupExtender ID="PopupCliente" runat="server" BackgroundCssClass="modalBackground" BehaviorID="PopupCliente" PopupControlID="pnlClientes" TargetControlID="lblPopupCliente">
                        </ajaxToolkit:ModalPopupExtender>
                        <asp:Label ID="lblpoupItems" runat="server" EnableTheming="True" Font-Size="7pt" ForeColor="White" Style="color: #000000"></asp:Label>
                        <ajaxToolkit:ModalPopupExtender ID="popupItem" runat="server" BackgroundCssClass="modalBackground" BehaviorID="popupItem" PopupControlID="pnlProductos" TargetControlID="lblpoupItems">
                        </ajaxToolkit:ModalPopupExtender>
                    </div>
                </td>
        </tr>
    </table>
    <table style="width: 743px">
        <tr>
            <td style="width: 4px">&nbsp;</td>
            <td colspan="2">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 132px">
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
                                <div style="text-align: right; width: 433px;">
                                    <asp:Label ID="lblAlertas" runat="server" Font-Bold="True" ForeColor="#FFCC00"></asp:Label>
                                </div>
                            </td>
                    </tr>
                </table>
            </td>
            <td style="width: 10px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 4px">&nbsp;</td>
            <td style="width: 359px">No. <asp:Label ID="lblNumeroPedido" runat="server" Font-Bold="True">0001</asp:Label>
                </td>
            <td style="width: 359px">&nbsp;</td>
            <td style="width: 10px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 4px">&nbsp;</td>
            <td style="width: 359px">
                    <asp:Label ID="Label5" runat="server" Text="Número de Identificación"></asp:Label>
                &nbsp;<asp:LinkButton ID="btnBuscarClientes" runat="server" ToolTip="Buscar Clientes" OnClick="btnBuscarClientes_Click">Ver</asp:LinkButton>
            </td>
            <td style="width: 359px">
                    <asp:Label ID="Label6" runat="server" Text="Nombres y Apellidos"></asp:Label>
                </td>
            <td style="width: 10px">
                <asp:Label ID="lblIDCliente" runat="server" Text="0" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 4px">&nbsp;</td>
            <td style="width: 359px">
                <div style="width: 359px">
                    <asp:TextBox ID="txtIdentificacion" runat="server" BackColor="#FFFFCC" EnableTheming="True" MaxLength="13" Width="300px" AutoPostBack="True" OnTextChanged="txtIdentificacion_TextChanged" onKeyPress="return soloNumeros(event)" placeholder="Digite el numero de Identificación"></asp:TextBox>
                </div>
            </td>
            <td style="width: 359px">
                <div style="width: 359px">
                    <asp:Label ID="lblNombres" runat="server" Font-Bold="True"></asp:Label>
                </div>
            </td>
            <td style="width: 10px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 4px; height: 20px">&nbsp;</td>
            <td style="width: 359px; height: 20px">
                    <asp:Label ID="Label7" runat="server" Text="Observacion de la Orden"></asp:Label>
                </td>
            <td style="width: 359px; height: 20px"></td>
            <td style="height: 20px; width: 10px"></td>
        </tr>
        <tr>
            <td style="height: 50px">
                <div style="width: 15px">
                </div>
            </td>
            <td colspan="2" style="height: 50px">
                <asp:TextBox ID="txtObservacion" runat="server" Height="44px" TextMode="MultiLine" ToolTip="Informaciómn adicional" Width="706px"></asp:TextBox>
            </td>
            <td style="height: 50px; width: 10px"></td>
        </tr>
        <tr>
            <td style="height: 20px">&nbsp;</td>
            <td colspan="2" style="height: 20px">
                <asp:LinkButton ID="btnAgregarProductos" runat="server" ToolTip="Seleccionar Productos" OnClick="btnAgregarProductos_Click">(+) Agregar Productos</asp:LinkButton>
            </td>
            <td style="height: 20px; width: 10px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 18px"></td>
            <td colspan="2" style="height: 18px">
                <asp:GridView ID="grwDetalle" runat="server" AutoGenerateColumns="False" Width="709px" DataKeyNames="Id_producto" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="auto-style8">
                                    <asp:LinkButton ID="btnEliminaGWDet" runat="server" OnClick="btnEliminaGWDet_Click">Eliminar</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Width="1px" />
                            <ItemStyle Width="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Producto">
                            <ItemTemplate>
                                <asp:Label ID="lblProductoGW" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                <asp:Label ID="lblIDPRO" runat="server" Font-Size="1pt" ForeColor="White" Height="1px" Text='<%# Eval("Id_producto") %>' Width="1px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cantidad">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCantidadGW" runat="server" onKeyPress="return numerosDecimales(event, this)" Text='<%# Eval("cantidad") %>' Width="100px" AutoPostBack="True" OnTextChanged="txtCantidadGW_TextChanged" ></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle Width="1px" />
                            <ItemStyle Width="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Precio">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPrecioGW" runat="server" onKeyPress="return numerosDecimales(event, this)" Text='<%# Eval("pvp") %>' Width="100px" OnTextChanged="txtPrecioGW_TextChanged"></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle Width="1px" />
                            <ItemStyle Width="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Costo">
                            <ItemTemplate>
                                <div style="width: 90px">
                                    <asp:Label ID="lblTotalGW" runat="server" Font-Bold="True" Text='<%# Eval("total") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <HeaderStyle Width="1px" HorizontalAlign="Right" />
                            <ItemStyle Width="1px" HorizontalAlign="Right" />
                        </asp:TemplateField>
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
            <td style="height: 18px; width: 10px"></td>
        </tr>
        <tr>
            <td style="width: 4px">&nbsp;</td>
            <td style="width: 359px">&nbsp;</td>
            <td style="width: 359px">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 130px">
                            <div style="text-align: right; " class="auto-style9">
                    <asp:Label ID="lbl" runat="server" Font-Bold="True" CssClass="auto-style10">TOTAL: </asp:Label>
                            </div>
                        </td>
                        <td class="text-center">
                            <div class="auto-style11">
                    <asp:Label ID="lblTotal" runat="server" Font-Bold="True" CssClass="auto-style10"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 10px">&nbsp;</td>
        </tr>
    </table>
    <asp:Panel ID="pnlProductos" runat="server" Height="250px" ScrollBars="Auto" Width="690px" BackColor="White">
        <table class="auto-style2">
            <tr>
                <td style="width: 4px; height: 28px"></td>
                <td style="height: 28px; width: 658px">
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="12pt" style="text-decoration: underline" Text="Productos"></asp:Label>
                </td>
                <td style="height: 28px">
                    <asp:ImageButton ID="btnSalir" runat="server" ImageUrl="~/Imagen/btnCancelarPnl.png" />
                </td>
            </tr>
            <tr>
                <td style="width: 4px; height: 28px">&nbsp;</td>
                <td style="height: 28px; width: 658px">
                    <div class="auto-style4">
                        <asp:TextBox ID="txtBuscarProductos" runat="server" BackColor="#FFFFCC" placeholder="Busqueda de Productos" Width="318px"></asp:TextBox>
                        <asp:LinkButton ID="btnBuscarProd" runat="server" OnClick="btnBuscarProd_Click">Buscar</asp:LinkButton>
                    </div>
                </td>
                <td style="height: 28px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 658px">
                    <asp:GridView ID="grwProductos" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_producto" ForeColor="#333333" GridLines="None" Width="658px">
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
                                                <asp:LinkButton ID="btnSeleccionarGWPr" runat="server" OnClick="btnSeleccionarGWPr_Click" >Seleccionar</asp:LinkButton>
                                            </td>
                                            <td>
                                                <div style="width: 14px">
                                                </div>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <HeaderStyle Width="1px" />
                                <ItemStyle Width="1px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Nombre" HeaderText="Producto">
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Precio" HeaderText="Precio">
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
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 658px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlClientes" runat="server" Height="250px" Width="690px" BackColor="White">
        <table class="auto-style1">
            <tr>
                <td style="width: 4px; height: 28px"></td>
                <td style="height: 28px; width: 658px">
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="12pt" Text="Clientes" style="text-decoration: underline"></asp:Label>
                </td>
                <td style="height: 28px">
                    <asp:ImageButton ID="btnSalirCli" runat="server" Height="16px" ImageUrl="~/Imagen/btnCancelarPnl.png" />
                </td>
            </tr>
            <tr>
                <td style="width: 4px; height: 28px">&nbsp;</td>
                <td style="height: 28px; width: 658px">
                    <div class="auto-style4">
                        <asp:TextBox ID="txtBuscar" runat="server" BackColor="#FFFFCC" Height="20px" placeholder="Busqueda de Clientes" style="margin-top: 32" Width="318px"></asp:TextBox>
                        <asp:LinkButton ID="btnBuscar" runat="server" OnClick="btnBuscar_Click">Buscar</asp:LinkButton>
                    </div>
                </td>
                <td style="height: 28px">&nbsp;</td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style5">
                    <div class="auto-style6">
                    </div>
                </td>
                <td>
                    <asp:GridView ID="grwClientes" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_cliente" ForeColor="#333333" GridLines="None" Width="658px">
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
                                                <asp:LinkButton ID="btnSleccionarGWCli" runat="server" OnClick="btnSleccionarGWCli_Click">Seleccionar</asp:LinkButton>
                                            </td>
                                            <td>
                                                <div style="width: 14px">
                                                </div>
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
        <br />
    </asp:Panel>
</asp:Content>
