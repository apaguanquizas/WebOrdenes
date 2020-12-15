<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmOrdenConsulta.aspx.cs" Inherits="WebOrdenes.frmOrdenConsulta" %>
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
 </style>
    <script src="Validador.js"></script>
    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 4px">&nbsp;</td>
                <td>
                    <div style="height: 38px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="12pt" Text="Ordenes - Consulta y Creación" style="text-decoration: underline"></asp:Label>
                        <asp:Label ID="lblpoupItems" runat="server" EnableTheming="True" Font-Size="7pt" ForeColor="White" Style="color: #000000"></asp:Label>
                        <ajaxToolkit:ModalPopupExtender ID="popupItem" runat="server" BackgroundCssClass="modalBackground" BehaviorID="popupItem" PopupControlID="pnlProductos" TargetControlID="lblpoupItems">
                        </ajaxToolkit:ModalPopupExtender>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 4px">
                    &nbsp;</td>
                <td>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 4px">
                                <div style="width: 132px; height: 40px">
                                    <asp:Button ID="btnNuevo" runat="server" Height="30px" OnClick="btnNuevo_Click" Text="Nuevo" Width="127px" />
                                </div>
                            </td>
                            <td style="width: 290px">
                                <div style="width: 147px; height: 40px">
                                </div>
                            </td>
                            <td>
                                <div style="text-align: right">
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 4px">&nbsp;</td>
                <td class="text-left">
                    <div style="height: 32px">
                    <asp:TextBox ID="txtBuscar" runat="server" BackColor="#FFFFCC" Width="318px" placeholder="Busqueda de Productos"></asp:TextBox>
                    <asp:LinkButton ID="btnBuscar" runat="server" OnClick="btnBuscar_Click">Buscar</asp:LinkButton>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 4px">&nbsp;</td>
                <td>
                    <asp:GridView ID="grwOrdenes" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id_orden" ForeColor="#333333" GridLines="None" Height="35px" Width="1009px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
<asp:BoundField DataField="fecha_orden" HeaderText="Fecha">
</asp:BoundField>
                            <asp:BoundField DataField="Identificacion" HeaderText="Identificacion" />
                            <asp:BoundField DataField="nombres" HeaderText="Cliente" />
                            <asp:BoundField DataField="numero_orden" HeaderText="No.Orden">
                            <FooterStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="observacion_orden" HeaderText="Observacion">
                            </asp:BoundField>
                            <asp:BoundField DataField="total_orden" HeaderText="Total">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnVerDetalle" runat="server" OnClick="btnVerDetalle_Click">Ver Detalle</asp:LinkButton>
                                </ItemTemplate>
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
            </tr>
        </table>
    </p>
    <p>
    <asp:Panel ID="pnlProductos" runat="server" Height="250px" ScrollBars="Auto" Width="690px" BackColor="White">
        <table class="auto-style2">
            <tr>
                <td style="width: 4px; height: 28px"></td>
                <td style="height: 28px; width: 658px">
                    <div style="height: 34px">
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="12pt" style="text-decoration: underline" Text="Detalle de la Orden"></asp:Label>
                    </div>
                </td>
                <td style="height: 28px">
                    <asp:ImageButton ID="btnSalir" runat="server" ImageUrl="~/Imagen/btnCancelarPnl.png" />
                </td>
            </tr>
            <tr>
                <td style="width: 4px">&nbsp;</td>
                <td style="width: 658px">
                    <asp:GridView ID="grwProductos" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id_detorden" ForeColor="#333333" GridLines="None" Width="658px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="producto" HeaderText="Producto">
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cantidad_detorden" HeaderText="Cantidad">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Precio" DataField="precio_detorden" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="costo" HeaderText="Costo" />
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
    </p>
</asp:Content>