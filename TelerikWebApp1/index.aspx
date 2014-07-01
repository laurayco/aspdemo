<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="TelerikWebApp1.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <script type="text/javascript">
        //Put your JavaScript code here.
    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <div class="content_area">
        <div class="modal_content">
            <div>
                <label for="Bandwidth">Pump-Up Quantity:</label>
                <telerik:RadNumericTextBox
                    runat="server"
                    ShowSpinButtons="true"
                    DataType="Int"
                    Type="Number"
                    ID="Bandwidth"
                 ></telerik:RadNumericTextBox>
            </div>
            <div>
                <label for="Latency">Catchup Effort:</label>
                <telerik:RadNumericTextBox
                    runat="server"
                    ShowSpinButtons="true"
                    DataType="Int"
                    Type="Number"
                    ID="Latency"
                 ></telerik:RadNumericTextBox>
            </div>
            <div>
                <label for="Redirects">Degrees of Freedom:</label>
                <telerik:RadNumericTextBox
                    runat="server"
                    ShowSpinButtons="true"
                    DataType="Int"
                    Type="Number"
                    ID="Redirects"
                 ></telerik:RadNumericTextBox>
            </div>
            <div>
                <asp:Button ID="CalculateButton" runat="server" Text="Calculate" />
            </div>
        </div>

        <div class="modal_content">
            <h1>Results:</h1>
            <table>
                <thead>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
