﻿<%@ Page Theme="pagina" Language="C#" MasterPageFile="~/principal.master" AutoEventWireup="true"
    CodeFile="fBusquedas.aspx.cs" Inherits="paginas_fBusquedas" Title="Consulting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 776px; background-color: Window" frame="border" 
                align="center">
                <tbody>
                    <tr>
                        <td style="width: 100px; height: 12px">
                            <table style="width: 764px">
                                <tbody>
                                    <tr>
                                        <td style="width: 9px; height: 10px">
                                        </td>
                                        <td style="height: 10px" colspan="2" rowspan="1">
                                        </td>
                                        <td style="height: 10px" colspan="1">
                                            <asp:Image ID="Image6" runat="server" ImageUrl="~/imagenes/nuevasImagenes/logo-top.png"
                                                Width="99px"  Height="72px"></asp:Image>
                                        </td>
                                        <td style="height: 10px" valign="baseline" colspan="2">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="text-align: left" colspan="2">
                                                            <asp:Label ID="Label20" runat="server" Font-Size="X-Small" Font-Names="Tahoma" 
                                                                Text="Busquedas Guardadas"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:DropDownList ID="DropDownList3" runat="server" Width="168px" Font-Size="X-Small"
                                                                Font-Names="Tahoma"  AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 2614px; text-align: right">
                                                            <asp:ImageButton ID="ImageButton15" OnClick="ImageButton15_Click" runat="server"
                                                                ImageUrl="~/imagenes/nuevasImagenes/icono-documento.png" >
                                                            </asp:ImageButton>
                                                        </td>
                                                        <td style="width: 100px">
                                                            <asp:Label ID="Label19" runat="server" Font-Size="X-Small" Font-Names="Tahoma" 
                                                                Text="Ejecutar"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td style="width: 100px; height: 10px">
                                        </td>
                                        <td style="width: 100px; height: 10px">
                                            <asp:ImageButton ID="ImageButton16" runat="server"  
                                                Height="60px" ImageUrl="~/imagenes/nuevasImagenes/buscar.png" 
                                                OnClick="ImageButton14_Click" Width="60px" />
                                        </td>
                                        <td style="width: 100px; height: 10px">
                                            <asp:ImageButton ID="ImageButton17" runat="server" 
                                                Height="60px" ImageUrl="~/imagenes/nuevasImagenes/listar.png" 
                                                OnClick="ImageButton13_Click" Width="60px" />
                                        </td>
                                        <td style="width: 100px; height: 10px">
                                            <asp:ImageButton ID="ImageButton18" runat="server"  
                                                Height="60px" ImageUrl="~/imagenes/nuevasImagenes/cancelar.png" 
                                                OnClick="ImageButton12_Click" Width="60px" />
                                        </td>
                                        <td style="width: 100px; height: 10px">
                                            <asp:ImageButton ID="ImageButtonVolver" runat="server" Height="60px" ImageUrl="~/imagenes/nuevasImagenes/atras.jpg" 
                                                OnClick="ImageButtonVolver_Click" Width="60px" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
            <table style="width: 780px; background-color: ghostwhite" frame="border" 
                align="center">
                <tbody>
                    <tr>
                        <td style="width: 100px">
                            <table style="width: 762px; border-collapse: collapse">
                                <tbody>
                                    <tr>
                                        <td style="width: 16px; height: 4px">
                                        </td>
                                        <td style="width: 100px; height: 4px">
                                        </td>
                                        <td style="width: 100px; height: 4px">
                                        </td>
                                        <td style="width: 9px; height: 4px">
                                        </td>
                                        <td style="width: 9px; height: 4px">
                                        </td>
                                        <td style="width: 9px; height: 4px">
                                        </td>
                                        <td style="width: 9px; height: 4px">
                                        </td>
                                        <td style="width: 9px; height: 4px">
                                        </td>
                                        <td style="width: 9px; height: 4px">
                                        </td>
                                        <td style="width: 9px; height: 4px">
                                        </td>
                                        <td style="width: 9px; height: 4px">
                                        </td>
                                        <td style="width: 9px; height: 4px">
                                        </td>
                                        <td style="width: 100px; height: 4px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 16px; height: 1px">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: #003366"
                                            colspan="2">
                                            <asp:Label ID="Label15" runat="server" Width="148px" ForeColor="White" Font-Size="8pt"
                                                Font-Names="Tahoma" Font-Bold="True"  Text="BUSQUEDA AVANZADA"></asp:Label>
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: #003366">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: #003366">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: #003366">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: #003366">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: #003366">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: #003366">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: #003366">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: #003366">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: #003366">
                                        </td>
                                        <td style="width: 100px; height: 1px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 16px; height: 1px">
                                        </td>
                                        <td style="width: 100px; border-collapse: collapse; height: 1px; background-color: white"
                                            colspan="2">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 3px; text-align: right">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/nuevasImagenes/icono-documento.png"
                                                                ></asp:Image>
                                                        </td>
                                                        <td style="width: 100px">
                                                            <asp:Label ID="Label11" runat="server" Width="160px" Font-Size="X-Small" Font-Names="Tahoma"
                                                                 Text="Seleccione el Tipo de Documento"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: white">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: white">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: white">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: white">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: white">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: white">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: white">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: white">
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: white">
                                        </td>
                                        <td style="width: 100px; height: 1px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 16px; height: 1px">
                                        </td>
                                        <td style="width: 100px; border-collapse: collapse; height: 1px; background-color: white;
                                            text-align: left" colspan="2">
                                            <asp:DropDownList ID="DropDownList1" runat="server" Width="176px" Font-Size="X-Small"
                                                Font-Names="Tahoma"  AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: white">
                                            <asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click" runat="server" ImageUrl="~/imagenes/ultima.jpg"
                                                Width="19px"  Height="17px"></asp:ImageButton>
                                        </td>
                                        <td style="text-align: left" valign="top" colspan="8" rowspan="5">
                                            <asp:Panel ID="Panel3" runat="server" Width="546px"  Height="120px"
                                                BorderWidth="2px" BorderStyle="Ridge" BorderColor="Gainsboro">
                                                <asp:GridView ID="filtrosGridView" runat="server"  OnSelectedIndexChanged="filtrosGridView_SelectedIndexChanged"
                                                    AutoGenerateColumns="False" ShowHeader="False" DataKeyNames="id" SkinID="filtros"
                                                    HorizontalAlign="Left">
                                                    <Columns>
                                                        <asp:CommandField SelectText="Quitar" ShowSelectButton="True"></asp:CommandField>
                                                        <asp:BoundField DataField="mostrar" HeaderText="Filtro"></asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                        <td style="width: 100px; height: 1px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 16px; height: 1px">
                                        </td>
                                        <td style="width: 100px; border-collapse: collapse; height: 1px; background-color: white;
                                            text-align: left" colspan="2">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 3px; text-align: right">
                                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/imagenes/nuevasImagenes/icono-documento.png"
                                                                ></asp:Image>
                                                        </td>
                                                        <td style="width: 100px">
                                                            <asp:Label ID="Label16" runat="server" Width="96px" Font-Size="X-Small" Font-Names="Tahoma"
                                                                Text="Seleccione el Indice"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: white">
                                        </td>
                                        <td style="width: 100px; height: 1px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 16px; height: 1px">
                                        </td>
                                        <td style="width: 100px; border-collapse: collapse; height: 1px; background-color: white"
                                            colspan="2">
                                            <asp:DropDownList ID="DDIndices" runat="server" Width="176px" Font-Size="X-Small"
                                                Font-Names="Tahoma" AutoPostBack="True" OnSelectedIndexChanged="DDIndices_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 9px; border-collapse: collapse; height: 1px; background-color: white">
                                        </td>
                                        <td style="width: 100px; height: 1px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 16px; height: 1px">
                                        </td>
                                        <td style="height: 1px; width: 100px; border-collapse: collapse; background-color: white;" 
                                            colspan="2">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 3px; text-align: right">
                                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/imagenes/nuevasImagenes/icono-documento.png"
                                                                ></asp:Image>
                                                        </td>
                                                        <td style="width: 100px">
                                                            <asp:Label ID="Label17" runat="server" Width="120px" Font-Size="X-Small" Font-Names="Tahoma"
                                                                Text="Personalice su Busqueda"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td style="width: 9px; height: 1px">
                                        </td>
                                        <td style="width: 100px; height: 1px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 16px; height: 1px">
                                        </td>
                                        <td style="height: 1px; text-align: left" colspan="2">
                                            <asp:DropDownList ID="DDReglas" runat="server" Width="176px" Font-Size="X-Small"
                                                Font-Names="Tahoma" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 9px; height: 1px">
                                        </td>
                                        <td style="width: 100px; height: 1px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 16px; height: 1px">
                                        </td>
                                        <td style="height: 1px; text-align: left" colspan="2">
                                            <asp:TextBox ID="TextBox1" runat="server" Width="168px" Font-Size="X-Small" Font-Names="Tahoma"
                                                ></asp:TextBox>
                                        </td>
                                        <td style="width: 9px; height: 1px">
                                        </td>
                                        <td style="height: 1px; background-color: #003366; text-align: left" colspan="8">
                                            <table style="width: 535px; border-collapse: collapse; background-color: #003366">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 350px; height: 1px">
                                                        </td>
                                                        <td style="height: 1px">
                                                            <asp:Image ID="Image3" runat="server" ImageUrl="~/imagenes/nuevasImagenes/flecha-menu.png"
                                                                ></asp:Image>
                                                        </td>
                                                        <td style="width: 47px; height: 1px; text-align: left" valign="middle">
                                                            <asp:Label ID="Label14" runat="server" Width="256px" ForeColor="White" Font-Size="X-Small"
                                                                Font-Names="Tahoma" Text="Escriba el nombre con el cual guardara su consulta"></asp:Label>
                                                        </td>
                                                        <td style="width: 85px; height: 1px">
                                                            <asp:TextBox ID="TextBox3" runat="server" Width="157px" Font-Size="X-Small" Font-Names="Tahoma"
                                                                ></asp:TextBox>
                                                        </td>
                                                        <td style="width: 284px; height: 1px; text-align: right">
                                                        </td>
                                                        <td style="width: 16px; height: 1px; text-align: right">
                                                            <asp:ImageButton ID="ImageButton11" OnClick="ImageButton11_Click" runat="server"
                                                                ImageUrl="~/imagenes/nuevasImagenes/icono-diskette.png" >
                                                            </asp:ImageButton>
                                                        </td>
                                                        <td style="width: 106px; height: 1px">
                                                        </td>
                                                        <td style="width: 11px; height: 1px" valign="middle">
                                                            <asp:Label ID="Label18" runat="server" ForeColor="White" Font-Size="X-Small" Font-Names="Tahoma"
                                                                Text="Guardar"></asp:Label>
                                                        </td>
                                                        <td style="width: 100px; height: 1px">
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td style="width: 100px; height: 1px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 16px; height: 1px">
                                        </td>
                                        <td style="height: 1px; text-align: left" colspan="2">
                                        </td>
                                        <td style="width: 9px; height: 1px">
                                        </td>
                                        <td style="width: 9px; height: 1px">
                                        </td>
                                        <td style="width: 9px; height: 1px">
                                        </td>
                                        <td style="width: 9px; height: 1px">
                                        </td>
                                        <td style="width: 9px; height: 1px">
                                        </td>
                                        <td style="width: 9px; height: 1px">
                                        </td>
                                        <td style="width: 9px; height: 1px">
                                        </td>
                                        <td style="width: 9px; height: 1px">
                                        </td>
                                        <td style="width: 9px; height: 1px">
                                        </td>
                                        <td style="width: 100px; height: 1px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 16px; height: 2px">
                                        </td>
                                        <td style="width: 100px; height: 2px">
                                        </td>
                                        <td style="width: 100px; height: 2px">
                                        </td>
                                        <td style="width: 9px; height: 2px">
                                        </td>
                                        <td style="width: 9px; height: 2px">
                                        </td>
                                        <td style="width: 9px; height: 2px">
                                        </td>
                                        <td style="width: 9px; height: 2px">
                                        </td>
                                        <td style="width: 9px; height: 2px">
                                        </td>
                                        <td style="width: 9px; height: 2px">
                                        </td>
                                        <td style="width: 9px; height: 2px">
                                        </td>
                                        <td style="width: 9px; height: 2px">
                                        </td>
                                        <td style="width: 9px; height: 2px">
                                        </td>
                                        <td style="width: 100px; height: 2px">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
            <table style="width: 780px; background-color: ghostwhite" frame="border" 
                align="center">
                <tbody>
                    <tr>
                        <td style="width: 100px">
                            <table style="width: 762px; background-color: ghostwhite" frame="border">
                                <tbody>
                                    <tr>
                                        <td style="width: 100px">
                                            <table style="border-collapse: collapse">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 633px">
                                                        </td>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 100px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 633px; border-collapse: collapse; background-color: whitesmoke"
                                                            colspan="1">
                                                        </td>
                                                        <td style="border-collapse: collapse; background-color: #003366; text-align: left"
                                                            colspan="3">
                                                            <asp:Label ID="Label10" runat="server" Width="171px" ForeColor="White" Font-Size="8pt"
                                                                Font-Names="Tahoma" Font-Bold="True" Text="RESULTADOS DE BUSQUEDA"></asp:Label>
                                                        </td>
                                                        <td style="border-collapse: collapse; background-color: #003366">
                                                        </td>
                                                        <td style="border-collapse: collapse; background-color: #003366">
                                                        </td>
                                                        <td style="border-collapse: collapse; background-color: #003366">
                                                        </td>
                                                        <td style="border-collapse: collapse; background-color: #003366">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 633px; border-collapse: collapse; background-color: whitesmoke"
                                                            colspan="1">
                                                        </td>
                                                        <td style="border-collapse: collapse; background-color: whitesmoke" colspan="7">
                                                            <asp:Panel ID="Panel4" runat="server" Width="730px"  Height="180px">
                                                                <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
                                                                    AutoGenerateColumns="False" DataKeyNames="IDExport,FileName" SkinID="LetraMuyChica"
                                                                    OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDataBound="GridView2_RowDataBound"
                                                                    PageSize="3" AllowPaging="True">
                                                                    <Columns>
                                                                        <asp:TemplateField ShowHeader="False">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagenes/pdf.jpg" 
                                                                                    CommandName="Select" OnClick="ImageButton1_Click1"></asp:ImageButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
<%--                                                                    <PagerTemplate>
                                                                        <table>
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 100px">
                                                                                        <table style="width: 295px">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td style="width: 32px; text-align: center">
                                                                                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/imagenes/nuevasImagenes/icono-campos-a-mostrar.png"
                                                                                                            ></asp:ImageButton>
                                                                                                    </td>
                                                                                                    <td style="width: 100px">
                                                                                                        <asp:Label ID="Label12" runat="server" Width="187px" Font-Size="Small" Font-Names="Tahoma"
                                                                                                            Text="Cantidad de registros a mostrar" ></asp:Label>
                                                                                                    </td>
                                                                                                    <td style="width: 100px; text-align: center">
                                                                                                        <asp:TextBox ID="TextBox6" runat="server" Width="37px" Font-Size="X-Small" Font-Names="Tahoma"
                                                                                                            ReadOnly="True" ></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td style="width: 100px">
                                                                                        &nbsp;&nbsp;&nbsp;
                                                                                    </td>
                                                                                    <td style="width: 100px">
                                                                                        <table style="width: 295px">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td style="width: 65px">
                                                                                                        <asp:ImageButton ID="ImageButton3" OnClick="ImageButton6_Click" runat="server" ImageUrl="~/imagenes/nuevasImagenes/icono-primero.png"
                                                                                                            CommandName="Page" CommandArgument="First" ToolTip="Prim. Pag">
                                                                                                        </asp:ImageButton>
                                                                                                    </td>
                                                                                                    <td style="width: 50px">
                                                                                                        <asp:ImageButton ID="ImageButton8" OnClick="ImageButton8_Click" runat="server" ImageUrl="~/imagenes/nuevasImagenes/icono-anterior.png"
                                                                                                            CommandName="Page" CommandArgument="Prev" ToolTip="Pág. anterior">
                                                                                                        </asp:ImageButton>
                                                                                                    </td>
                                                                                                    <td style="width: 71px; text-align: center">
                                                                                                        <asp:TextBox ID="TextBox5" runat="server" Width="37px" Font-Size="X-Small" Font-Names="Tahoma"
                                                                                                            ReadOnly="True" ></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td style="width: 31px; text-align: center">
                                                                                                        <asp:Label ID="Label13" runat="server" Font-Size="Small" Font-Names="Tahoma" Text="de"
                                                                                                            ></asp:Label>
                                                                                                    </td>
                                                                                                    <td style="width: 63px; text-align: center">
                                                                                                        <asp:TextBox ID="TextBox4" runat="server" Width="37px" Font-Size="X-Small" Font-Names="Tahoma"
                                                                                                            ReadOnly="True" ></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td style="width: 38px">
                                                                                                        <asp:ImageButton ID="ImageButton9" OnClick="ImageButton3_Click" runat="server" ImageUrl="~/imagenes/nuevasImagenes/icono-siguiente.png"
                                                                                                             CommandName="Page" CommandArgument="Next" ToolTip="Sig. página">
                                                                                                        </asp:ImageButton>
                                                                                                    </td>
                                                                                                    <td style="width: 100px">
                                                                                                        <asp:ImageButton ID="ImageButton10" OnClick="ImageButton4_Click" runat="server" ImageUrl="~/imagenes/nuevasImagenes/icono-ultimo.png"
                                                                                                            CommandName="Page" CommandArgument="Last" ToolTip="Últ. Pag">
                                                                                                        </asp:ImageButton>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </PagerTemplate>
--%>                                                                </asp:GridView>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <br />
                            <br />
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
