<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyForm._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
   <link rel="stylesheet" type="text/css" href="form.css" />
    <script type="text/javascript" src="jquery-3.3.1.min.js"></script>
                            <script type="text/javascript">

                                $(document).ready(function () {
                                   
                                    if (window.isEdit) {


                                        $("#txtFirstName").val(window.firstName);
                                        $("#txtLastName").val(window.lastName);
                                        $("#slctTitle").val(window.title).change();
                                        $("#slctJobCategory").val(window.jobCategory).change();
                                        $("#slctGender").val(window.gender).change();
                                        $("#slctCampus").val(window.campus).change();
                                        $("#slctLanguage").val(window.language).change();
                                        $("#txtExpirationDate").val(window.expiriationDate);
                                        $("#HFID").val(window.id);
                                        $("#HFIsEdit").val(window.isEdit);
                                        if (window.RSL == "&nbsp;") {
                                            $("#slctRSL").val("Resource sharing libary").change();
                                        }
                                        else
                                            $("#slctRSL").val(window.RSL).change();
                                    }
                                    else {
                                        $("#HFID").val(window.rowID);
                                    }
                                    });
                                
                        
                    </script>
</head>
    
<body>
        <script type="text/javascript" src="jquery-3.3.1.min.js"></script>

    <form id="form" runat="server">
        <asp:HiddenField runat="server" id="HFID"/>
         <asp:HiddenField runat="server" id="HFIsEdit"/>
        <table>
            <caption>user information</caption>
            <tr>
                
                <td>
                    First name<span style="color: red">*</span>
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="txtTextBox" ID="txtFirstName"></asp:TextBox>

                </td>
                <td>
                    <label id="lblFNameError" class="error">Test</label></td>
            </tr>
            <tr>
                <td>
                    <label>Last name<span style="color: red">*</span></label>
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="txtTextBox" ID="txtLastName"></asp:TextBox>
                </td>
                <td>
                    <label id="lblLNameError" class="error"></label>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Title</label>
                </td>
                <td>
                    <asp:DropDownList runat="server" CssClass="txtTextBox" ID="slctTitle">
                        <asp:ListItem Selected="True"></asp:ListItem>
                        <asp:ListItem>Mr</asp:ListItem>
                        <asp:ListItem>Mrs</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Job category<span style="color: red">*</span></label>
                </td>
                <td>
                    <asp:DropDownList runat="server" CssClass="txtTextBox" ID="slctJobCategory">
                        <asp:ListItem Selected="True">Please select a value</asp:ListItem>
                        <asp:ListItem>Information Technology</asp:ListItem>
                        <asp:ListItem>Manufacturing</asp:ListItem>
                        <asp:ListItem>Education and Training</asp:ListItem>
                        <asp:ListItem> Accounting</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <label id="lblJobError" class="error"></label>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Gender<span style="color: red">*</span></label>
                </td>
                <td>
                    <asp:DropDownList runat="server" CssClass="txtTextBox" ID="slctGender">
                        <asp:ListItem Selected="True"></asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <label id="lblGenderError" class="error"></label>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Campus</label>
                </td>
                <td>
                    <asp:DropDownList runat="server" CssClass="txtTextBox" ID="slctCampus">
                        <asp:ListItem Selected="True"></asp:ListItem>
                        <asp:ListItem>Al-Zaytoonah</asp:ListItem>
                        <asp:ListItem>Al-Perta</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <label>Preferred language</label>
                </td>
                <td>
                    <asp:DropDownList runat="server" CssClass="txtTextBox" ID="slctLanguage">
                        <asp:ListItem Selected="True">English</asp:ListItem>
                        <asp:ListItem>Arabic</asp:ListItem>
                        <asp:ListItem>Spanish</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <label>Status Date</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCurrentDate" CssClass="txtTextBox" ReadOnly="true"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <label>Expriation Date</label>
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="txtTextBox" TextMode="Date" ID="txtExpirationDate"></asp:TextBox>
                </td>
                <td>
                    <label id="lblExprDateError" class="error"></label>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Resource sharing libary</label>
                </td>
                <td>
                    <asp:DropDownList runat="server" CssClass="txtTextBox" ID="slctRSL">
                        <asp:ListItem Selected="True">Resource sharing libary</asp:ListItem>
                        <asp:ListItem>Resource1</asp:ListItem>
                        <asp:ListItem>Resource2</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <label>Password</label>
                </td>
                <td>
                    <asp:TextBox runat="server" TextMode="Password" CssClass="txtTextBox" ID="txtPassword"></asp:TextBox>
                </td>
                <td>
                    <label id="lblPassError" class="error"></label>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Confirm Password</label>
                </td>
                <td>
                    <asp:TextBox CssClass="txtTextBox" TextMode="Password" ID="txtCnfmPassword" runat="server"></asp:TextBox>
                </td>
                <td>
                    <label id="lblCnfmPassError" class="error"></label>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Force password change on next log in</label>
                </td>
                <td>
                    <asp:CheckBox runat="server" ID="cbPassChange"></asp:CheckBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <label>Disable all log in restrictions</label>
                </td>
                <td>
                    <asp:CheckBox runat="server" ID="cbDisableLog"></asp:CheckBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button   runat="server" ID="btnSave"  Text="Save"
                        OnClick="btnSave_Click" Enabled="false" ></asp:Button>
                    </td>
                <td></td>
            </tr>
        </table>


    </form>
    <script type="text/javascript" language="javascript" src="form.js"></script>
</body>
</html>
