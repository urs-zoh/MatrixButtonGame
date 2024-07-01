<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MatrixButtonGame.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Button Matrix Game</title>
    <style>
        .matrixButton {
            width: 50px;
            height: 50px;
            font-size: 20px;
            margin: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btn3x3" runat="server" Text="3x3" OnClick="btnSize_Click" />
            <asp:Button ID="btn4x4" runat="server" Text="4x4" OnClick="btnSize_Click" />
            <asp:Button ID="btn5x5" runat="server" Text="5x5" OnClick="btnSize_Click" />
        </div>
        <div>
            <asp:Label ID="lblScore" runat="server" Text="Score: 0"></asp:Label>
        </div>
        <div id="matrixContainer" runat="server"></div>
    </form>
</body>
</html>
