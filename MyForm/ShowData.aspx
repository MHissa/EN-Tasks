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
    <script src="jquery-3.3.1.min.js"></script>

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
        <asp:GridView  ID="grdUsers" runat="server" CssClass="table-bordered" CellPadding="3">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>Edit/Delete</HeaderTemplate>
                    <ItemTemplate>
                        <input type="button" class="myButton" id="EditRow" value="Edit"  />
                        <asp:Button ID="DeleteRow" CssClass="btn-danger" Text="Delete" runat="server" OnClick="Delete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <script type="text/javascript">
            $(document).ready(function () {
                
                $('#grdUsers tr').each(function() {
                    $("#grdUsers tbody td:nth-child(2), #grdUsers tbody th:nth-child(2)").hide();
                });

            
            });
            $(".myButton").click(function () {
                     myWindow = window.open('Default.aspx',' List',' toolbar = no, location = no,status = no,menubar = no,scrollbars = yes,resizable = no, width = 700,height = 650,left = 430,top = 0'); 
                myWindow.id=$(this).closest('tr').find("td").eq(1).text();
                myWindow.firstName =$(this).closest('tr').find("td").eq(2).text() ;
                myWindow.lastName = $(this).closest('tr').find("td").eq(3).text();
                myWindow.title = $(this).closest('tr').find("td").eq(4).text();
                myWindow.jobCategory = $(this).closest('tr').find("td").eq(5).text();
                myWindow.gender = $(this).closest('tr').find("td").eq(6).text();
                myWindow.campus = $(this).closest('tr').find("td").eq(7).text();
                myWindow.language = $(this).closest('tr').find("td").eq(8).text();
                myWindow.isEdit = true;
                myWindow.currentDate = $(this).closest('tr').find("td").eq(9).text();
                myWindow.expiriationDate = $(this).closest('tr').find("td").eq(10).text();
                return false;
                debugger;
                });
          
        </script>
    </form>
    <script type="text/javascript"  src="form.js"></script>
</body>
</html>
