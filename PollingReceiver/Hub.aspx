<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hub.aspx.cs" Inherits="PollingReceiver.Hub" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
            <asp:Label ID="lblLastHit" runat="server" Text=""></asp:Label>
            <asp:Label ID="txtSent" runat="server" Text=""></asp:Label>
            <%--<h3>Send Alerts to Shaun?</h3>
                    <asp:CheckBox ID="chkAlertShaun" OnCheckedChanged="cbToggle_CheckedChanged" AutoPostBack="true" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </form>
</body>
</html>
