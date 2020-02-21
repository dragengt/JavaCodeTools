<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetSetToolPage.aspx.cs" Inherits="JavaWebTools.GetSetToolPage" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="margin: 10px" action="#">
        <div>
            <p>
                解决问题：
                <br />
                1、@Data 生成的get/set 没有注释，要看字段还得点进去看。<br />
                2、@Data  生成的get,在对字段查看被哪个地方引用的时候，会无法直接查看Call Hierarchy。<br />
            </p>
            <p>
                <b>工具使用：</b>
                在左框内粘贴标准的实体类（整个java文件内容，或者代码片段）。<br />
                对于每个字段，需要有标准的注释：/** xxx  */，字段需要为私有
            </p>
        </div>
        <div style="padding: 10px; align-content: flex-end">
            <asp:Panel ID="PanelTitle" runat="server" HorizontalAlign="Center">
                作者信息：<asp:TextBox ID="tb_authorText" runat="server"></asp:TextBox>
            </asp:Panel>
        </div>
        <div>

            <asp:Panel ID="Panel1" runat="server" Height="600px" HorizontalAlign="Center">
                <asp:TextBox ID="tb_srcCode" runat="server" Width="48%" Height="600px" TextMode="MultiLine"></asp:TextBox>
                <%--<textarea style="width:50%;height:90%"></textarea>--%>
                <asp:TextBox ID="tb_tarCode" runat="server" Width="48%" Height="600px" TextMode="MultiLine"></asp:TextBox>
            </asp:Panel>

        </div>

        <div style="margin-top: 20px">
            <asp:Panel ID="PanelBtn" runat="server" HorizontalAlign="Center">
                <asp:Button runat="server" Text="转换代码片段=>" ID="btn_generateCode" OnClick="btn_generateCode_Click" OnClientClick="setUserName();return true;" />
            </asp:Panel>
        </div>

        <div style="margin: 10px; font-style: italic;">
            <div>
                ps:对于存在没有注释的字段，报错；<br />
                对于存在大写开头、或者加了下划线的字段，报错；<br />
                对于在实体类里放了public 字段的，报错。（常量放实体类里也报错）<br />
                对于类内已经有get/set方法的，则容易识别为字段，此情况则请只复制字段的代码片段；<br />
            </div>

        </div>


        <div style="margin: 10px;">
            <p>其他工具：（手动复制以下目录路径，非浏览器打开）</p>
            <h4>exe版java的getter、setter工具</h4> <br /> <i>\\wss01kf\DOC\document\持续的技术分享\17 java工具</i>
            <h4>Nuget版本浏览和批量替换工具</h4> <br /> <i>\\wss01kf\DOC\document\持续的技术分享\18 C#自制工具</i>
        </div>
    </form>
    <footer style="text-align: right">
        <p>风险计量开发室：231356</p>
    </footer>

    <script>
        var C_AuthorInfoKEY = "authorInfo";
        var userName = localStorage.getItem(C_AuthorInfoKEY);
        
        if (userName != "") {
            console.log("get user name:" + userName);
            document.getElementById("<%=tb_authorText.ClientID%>").value = userName;
        }

        function setUserName() {
            var val = document.getElementById("<%=tb_authorText.ClientID%>").value;
            
            localStorage.setItem(C_AuthorInfoKEY, val);
            console.log("set author name:"+val);
        }
    </script>
</body>
</html>
