var myWindow;
var today;
var error_fName=false;
var error_lName=false;
var error_gender=false;
var error_job=false;
var error_exprDate=false;
var error_password=false;
var error_cnfmPassword=false;
var regexOnlyChar = /^[a-zA-Z]+$/;
var regexDate =/^([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))/;
$(document).ready(function () {
     today = new Date();
});
$("#lblFNameError").hide();
$("#lblLNameError").hide();
$("#lblGenderError").hide();
$("#lblExprDateError").hide();
$("#lblPassError").hide();
$("#lblCnfmPassError").hide();
$("#txtFirstName").focusout(function
    (){
        check_fName();
    });
$("#txtLastName").focusout(function
    (){
        check_lName();
    });
$("#slctJobCategory").focusout(function(){
        check_job();
    });
$("#slctGender").focusout(function(){
        check_gender();
    });
    $("#txtExpirationDate").change(function()
    {
        
        check_expriationDate();
    });
    $("#txtPassword").focusout(function()
    {
        check_pass();
    });
    $("#txtCnfmPassword").focusout(function()
    {
        check_cnfmPass();
});
$("#txtFirstName,#txtLastName,#slctJobCategory,#txtPassword,#slctGender,#txtExpirationDate,#txtCnfmPassword").change(function ()
{
    debugger;
        check_fName();
        check_lName();
        check_job();
        check_gender();
        check_expriationDate();
        check_pass();
        check_cnfmPass();
       
        if ((error_password || error_cnfmPassword || error_exprDate || error_fName || error_lName || error_gender || error_job)) {
            return false;
        }
        else {
            $("#btnSave").prop("disabled", false);
            
        }
        
    });
function check_fName()
{
    
    var fName=$("#txtFirstName").val();
    if(fName =="")
    {
        $("#lblFNameError").html("First Name cant be empty");
        $("#lblFNameError").show();
        error_fName=true;
        return false;
    }
    if(!regexOnlyChar.test(fName))
    {
        $("#lblFNameError").html("First Name should have only letters ");
        $("#lblFNameError").show();
        error_fName=true;
        return  ;
    }
    error_fName=false;
    $("#lblFNameError").hide();
}
function check_lName()
{
    
            var lName=$("#txtLastName").val();
            if(lName =="")
            {
                $("#lblLNameError").html("Last Name cant be empty");
                $("#lblLNameError").show();
                error_lName=true;
                return ;
            }
            if(!regexOnlyChar.test(lName))
            {
                $("#lblLNameError").html("Last Name should have only letters ");
                $("#lblLNameError").show();
                error_lName=true;
                return ;
            }
            error_lName=false;
            $("#lblLNameError").hide();
}
function check_job()
    {
        
        if($("#slctJobCategory").val()=="Please select a value")
        {
            $("#lblJobError").html("please select your job");
            $("#lblJobError").show();
            error_job=true;
            return ;
        }
        $("#lblJobError").hide();
        error_job=false;
    }
    function check_gender()
    {
        if($("#slctGender").val()=="")
        {
            $("#lblGenderError").html("please select your gender");
            $("#lblGenderError").show();
            error_job=true;
            return ;
        }
        $("#lblGenderError").hide();
        error_job=false;
    }
function check_expriationDate() {
    debugger;
    var exprDate = $("#txtExpirationDate").val();
    if (!regexDate.test(exprDate)) {
        $("#lblExprDateError").html("please enter valid date ");
        $("#lblExprDateError").show();
        error_fName = true;
        return;
    }
    var expr_date = new Date($("#txtExpirationDate").val());
        if (today > expr_date) {
            $("#lblExprDateError").html("Expiration date should be greater than today");
            $("#lblExprDateError").show();
            error_exprDate = true;
            return;
        }
        $("#lblExprDateError").hide();
        error_exprDate = false;
    }

    
    function check_pass() {

        var regexPass = /(?=.*?[0-9])(?=.*?[A-Za-z])(?=.*[^0-9A-Za-z]).+/;
        var pass_length = $("#txtPassword").val().length;
        var pass = $("#txtPassword").val();
        if (pass_length < 6 || pass == "") {
            $("#lblPassError").html("Password too short (at least 6 char)")
            $("#lblPassError").show()
            error_password = true;
            return;
        }
        if (!regexPass.test(pass)) {
            $("#lblPassError").html("should contain at least (letter,number,special char)")
            $("#lblPassError").show()
            error_password = true;
            return;
        }
        $("#lblPassError").hide()
        error_password = false;
    }
    function check_cnfmPass() {

        if (($("#txtPassword").val() != $("#txtCnfmPassword").val()) && !error_password) {
            $("#lblCnfmPassError").html("Password doesnt match");
            $("#lblCnfmPassError").show();
            error_cnfmPassword = true;
            return;
        }
        $("#lblCnfmPassError").hide()
        error_cnfmPassword = false;
    }
