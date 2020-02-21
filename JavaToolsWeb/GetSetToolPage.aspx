<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetSetToolPage.aspx.cs" Inherits="JavaWebTools.GetSetToolPage"  ValidateRequest="false"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="margin: 10px">
        <div>
            <p>在左框内粘贴标准的实体类（整个java文件内容，或者代码片段）。</p>
            <p>对于每个字段，需要有标准的注释：/** xxx  */，字段需要为私有</p>
        </div>
        <div style="padding: 10px">
            <asp:Panel ID="PanelTitle" runat="server" HorizontalAlign="Center">
            </asp:Panel>
        </div>
        <div>

            <asp:Panel ID="Panel1" runat="server" Height="600px" HorizontalAlign="Center">
                <asp:TextBox ID="tb_srcCode" runat="server" Width="48%" Height="100%" TextMode="MultiLine"></asp:TextBox>
                <%--<textarea style="width:50%;height:90%"></textarea>--%>
                <asp:TextBox ID="tb_tarCode" runat="server" Width="48%" Height="100%" TextMode="MultiLine"></asp:TextBox>
            </asp:Panel>

        </div>

        <div style="margin-top: 20px">
            <asp:Panel ID="PanelBtn" runat="server" HorizontalAlign="Center">
                <asp:Button runat="server" Text="转换代码片段=>" ID="btn_generateCode" OnClick="btn_generateCode_Click" />
            </asp:Panel>
        </div>

        <div style="margin: 10px;font-style:italic;">
            <div>
                ps:对于存在没有注释的字段，报错；<br/>
                对于存在大写开头、或者加了下划线的字段，报错；<br />
                对于在实体类里放了public 字段的，报错。（常量放实体类里也报错）<br />
                对于类内已经有get/set方法的，则容易识别为字段，此情况则请只复制字段的代码片段；
            </div>
        </div>
    </form>
</body>
</html>
