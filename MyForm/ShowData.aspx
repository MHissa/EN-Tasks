<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowData.aspx.cs" Inherits="MyForm.ShowData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <%--  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css"/>--%>

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
           <script src="//ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
    <!-- Latest compiled JavaScript -->


    <title></title>
  <%--  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />--%>

    <script>
        //window.onblur= function() {window.onfocus= function () {location.reload(true)}};
    </script>
    <style>
        .col{
            padding:3px !important;
        }
        *{font-family:Calibri;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="dialog" title="Add new user"  style="width: auto"></div>

        <asp:LinkButton runat="server"  OnClick="BtnOpen_Click" ID="btnOpen" Text="Add new user"> </asp:LinkButton>
        <asp:GridView  ID="grdUsers" runat="server" OnRowDataBound="GridViewEvent" CssClass="table-bordered" CellPadding="3">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>Edit/Delete</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button CssClass="btn-primary" ID="EditRow" Text="Edit" runat="server" OnClick="Edit_Click" />
                        <asp:Button ID="DeleteRow" CssClass="btn-danger" Text="Delete" runat="server" OnClick="Delete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </form>
    <script type="text/javascript"  src="form.js"></script>
</body>
</html>
