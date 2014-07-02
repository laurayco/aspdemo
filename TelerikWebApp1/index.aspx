<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="TelerikWebApp1.Index" %>
<%@ Import Namespace="System.Data" %>

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

<script runat="server">
</script>

    <script type="text/javascript">
        //Put your JavaScript code here.
    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <div class="content_area">
        <div class="modal_content">
            <div>
                <label for="Redirects">Pump-Up Threshold:</label>
                <telerik:RadNumericTextBox
                    runat="server"
                    ShowSpinButtons="true"
                    DataType="Float"
                    Type="Number"
                    ID="HiSales"
                    Value="0.5"
                 ></telerik:RadNumericTextBox>
            </div>
            <div>
                <label for="Bandwidth">Pump-Up Quantity:</label>
                <telerik:RadNumericTextBox
                    runat="server"
                    ShowSpinButtons="true"
                    DataType="Int"
                    Type="Number"
                    ID="Bandwidth"
                    Value="1"
                 ></telerik:RadNumericTextBox>
            </div>
            <div>
                <label for="Latency">Catch-Up Stock Quantity:</label>
                <telerik:RadNumericTextBox
                    runat="server"
                    ShowSpinButtons="true"
                    DataType="Int"
                    Type="Number"
                    ID="Latency"
                    Value="1"
                 ></telerik:RadNumericTextBox>
            </div>
            <div>
                <label for="Redirects">Minimum Stock:</label>
                <telerik:RadNumericTextBox
                    runat="server"
                    ShowSpinButtons="true"
                    DataType="Int"
                    Type="Number"
                    ID="Redirects"
                    Value="1"
                 ></telerik:RadNumericTextBox>
            </div>
            <div>
                <asp:Button ID="CalculateButton" runat="server" Text="Calculate" OnClick="OnCalculateClick" />
            </div>
        </div>

        <div class="modal_content">
            <telerik:RadGrid runat="server" ID="datagrid" AllowPaging="True" AllowSorting="True" DataMember="DefaultView" DataSourceID="DataSource">
                <MasterTableView DataMember="DefaultView" DataSourceID="DataSource">
                </MasterTableView>
            </telerik:RadGrid>
            <asp:SqlDataSource ID="DataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MookstrDBConnectionString %>"></asp:SqlDataSource>
        </div>
    </div>
    </form>
</body>
</html>
