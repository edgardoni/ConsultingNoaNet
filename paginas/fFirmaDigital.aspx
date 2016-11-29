<%@ Page Title="" Language="C#" MasterPageFile="~/principal.master" AutoEventWireup="true"
    CodeFile="fFirmaDigital.aspx.cs" Inherits="paginas_fFirmaDigital" %>

    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
  <%-- <script language ="javascript" type ="text/javascript" >

       var bPreguntar = true;

       window.onbeforeunload = preguntarAntesDeSalir;

       function preguntarAntesDeSalir() {
           if (bPreguntar)
               return "¿Esta seguro que desea salir de la pagina actual?";
                              
       }

   </script>--%>

   <script language="javascript" type="text/javascript">
       var xmlHttp;


       function ExecuteCall(url) {
           try {
               xmlHttp = GetXmlHttpObject(CallbackMethod);
               SendXmlHttpRequest(xmlHttp, url);
           }
           catch (e) { }
       }


       function CallbackMethod() {
           try {
               if (xmlHttp.readyState == 4 ||
                    xmlHttp.readyState == 'complete') {
                   var response = xmlHttp.responseText;
                   if (response.length > 0) {
                       //update page -- no need to do while closing the browser
                       //alert(response)
                   }
               }
           }
           catch (e) { }
       }


       function SendXmlHttpRequest(xmlhttp, url) {
           xmlhttp.open('GET', url, false);
           xmlhttp.send(null);
       }


       function GetXmlHttpObject(handler) {
           var objXmlHttp = null;
           if (!window.XMLHttpRequest) {
               // Microsoft
               objXmlHttp = GetMSXmlHttp();
               if (objXmlHttp != null) {
                   objXmlHttp.onreadystatechange = handler;
               }
           }
           else {
               // Mozilla | Netscape | Safari
               objXmlHttp = new XMLHttpRequest();
               if (objXmlHttp != null) {
                   objXmlHttp.onload = handler;
                   objXmlHttp.onerror = handler;
               }
           }
           return objXmlHttp;
       }


       function GetMSXmlHttp() {
           var xmlHttp = null;
           var clsids = ["Msxml2.XMLHTTP.6.0",
                  "Msxml2.XMLHTTP.4.0",
                  "Msxml2.XMLHTTP.3.0"];
           for (var i = 0; i < clsids.length && xmlHttp == null; i++) {
               xmlHttp = CreateXmlHttp(clsids[i]);
           }
           return xmlHttp;
       }


       function CreateXmlHttp(clsid) {
           var xmlHttp = null;
           try {
               xmlHttp = new ActiveXObject(clsid);
               lastclsid = clsid;
               return xmlHttp;
           }
           catch (e) { }
       }
       window.onbeforeunload = onwindowclosing;
       function onwindowclosing() {
           ExecuteCall("ExeOnClose.aspx");

       }
    </script>


    <table style="width: 100%">
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="vertical-align: top; text-align: center">
                <asp:ImageButton ID="ImageButtonVolver" runat="server" Height="30px" ImageUrl="~/imagenes/nuevasImagenes/atras.jpg"
                    Width="30px" onclick="ImageButtonVolver_Click" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="vertical-align: top; text-align: center">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Timer ID="Timer1" runat="server" Interval="300000" ontick="Timer1_Tick">
                </asp:Timer>
            </td>
        </tr>
    </table>
</asp:Content>
