using MyForm.Models;
using System;
using System.Web.UI;

namespace MyForm
{
    public partial class _Default : System.Web.UI.Page
    {
        private readonly DataProvider dataProvider = new DataProvider(DataProvider.ProviderType.XML);
        bool isEdit ;
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {


            //isEdit = Convert.ToBoolean(Request.QueryString["isEdit"]);
            //id = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                txtCurrentDate.Text = DateTime.Now.ToString();
                //if (isEdit)
                //{
                //    var firstName = Request.QueryString["firstName"];
                //    var lastName = Request.QueryString["lastName"];
                //    var title = Request.QueryString["title"].ToString();
                //    var jobCategory = Request.QueryString["jobCategory"];
                //    var gender = Request.QueryString["gender"];
                //    var campus = Request.QueryString["campus"];
                //    var language = Request.QueryString["language"];
                //    var currentDate = Request.QueryString["currentDate"];
                //    var expiriationDate = Request.QueryString["expiriationDate"];
                //    var RSL = Request.QueryString["RSL"];
                //    var password = Request.QueryString["password"];
                //    // hidden for id

                //    txtFirstName.Text = firstName;
                //    txtLastName.Text = lastName;
                //    slctTitle.ClearSelection();
                //    slctTitle.Items.FindByText(title).Selected = true;
                //    slctJobCategory.ClearSelection();
                //    slctJobCategory.Items.FindByText(jobCategory).Selected = true;
                //    slctGender.ClearSelection();
                //    slctGender.Items.FindByText(gender).Selected = true;
                //    slctCampus.ClearSelection();
                //    slctCampus.Items.FindByText(campus).Selected = true;
                //    slctLanguage.ClearSelection();
                //    slctLanguage.Items.FindByText(language).Selected = true;
                //    txtCurrentDate.Text = currentDate;
                //    txtExpirationDate.Text = expiriationDate; ;
                //    slctRSL.ClearSelection();
                //    if(RSL=="")
                //    {
                //        slctRSL.SelectedIndex = 0;
                //    }
                //    else
                //    {
                //        slctRSL.Items.FindByText(RSL).Selected = true;
                //    }
                    
                    
                //}
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(HFID.Value);
            if(HFIsEdit.Value!="")
            isEdit = Convert.ToBoolean(HFIsEdit.Value);
            if (isEdit)
            {
                object[] updatedRowValues=new object[12];
                updatedRowValues[0] = Convert.ToInt32(HFID.Value);
                updatedRowValues[1] = txtFirstName.Text;
                updatedRowValues[2] = txtLastName.Text;
                updatedRowValues[3] = slctTitle.SelectedItem.Text;
                updatedRowValues[4] = slctJobCategory.SelectedItem.Text;
                updatedRowValues[5] = slctGender.SelectedItem.Text;
                updatedRowValues[6] = slctCampus.SelectedItem.Text;
                updatedRowValues[7] = slctLanguage.SelectedItem.Text;
                updatedRowValues[8] = txtCurrentDate.Text;
                updatedRowValues[9] = txtExpirationDate.Text;
                updatedRowValues[10] = slctRSL.SelectedItem.Text;
                updatedRowValues[11] = txtPassword.Text;
                dataProvider.EditUser(id, updatedRowValues);
                string x = "<script type='text/javascript'>" +
                "var parentUrl = window.opener.location.href;window.opener.location.href=parentUrl;self.close();</script>";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", x, false);
            }
            else
            {

                UserInput userInput = new UserInput
                {
                    RecordID= Convert.ToInt32(HFID.Value),
                Fristname = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Title = slctTitle.SelectedItem.Text,
                    JobCategory = slctJobCategory.SelectedItem.Text,
                    Gender = slctGender.SelectedItem.Text,
                    Campus = slctCampus.SelectedItem.Text,
                    PreferedLanguage = slctLanguage.SelectedItem.Text,
                    StatusDate = txtCurrentDate.Text,
                    ExpriationDate = txtExpirationDate.Text,
                    Password = txtPassword.Text
                };

                if (slctRSL.SelectedIndex == 0)
                {
                    userInput.RSL = "";
                }
                else
                    userInput.RSL = slctRSL.SelectedItem.Text;

                dataProvider.AddNewUser(userInput);
                string x = "<script type='text/javascript'>" +
                "var parentUrl = window.opener.location.href;window.opener.location.href=parentUrl;self.close();</script>";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", x, false);
                //txtFirstName.Text = "";
                //txtLastName.Text = "";
                //slctTitle.SelectedIndex = 0;
                //slctJobCategory.SelectedIndex = 0;
                //slctGender.SelectedIndex = 0;
                //slctCampus.SelectedIndex = 0;
                //slctLanguage.SelectedIndex = 0;
                //txtCurrentDate.Text= DateTime.Now.ToString();
                //txtExpirationDate.Text = "mm/dd/yyyy";
                //slctRSL.SelectedIndex = 0;
            }
        }

    }

}
