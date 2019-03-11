using MyForm.Models;
using System;
using System.Web.Services;
using System.Web.UI;

namespace MyForm
{
    public partial class _Default : System.Web.UI.Page
    {
        private readonly static DataProvider dataProvider = new DataProvider(DataProvider.ProviderType.XML);

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                txtCurrentDate.Text = DateTime.Now.ToString();
                
            }
        }
        [WebMethod]
        public static  void Update(UserInput userInput, bool isEdit)
        {
            if (userInput.RecordID != 0)
            {
                object[] updatedRowValues=new object[12];
                updatedRowValues[0] = userInput.RecordID;
                updatedRowValues[1] = userInput.FristName;
                updatedRowValues[2] = userInput.LastName;
                updatedRowValues[3] =userInput.Title ;
                updatedRowValues[4] = userInput.JobCategory;
                updatedRowValues[5] =userInput.Gender;
                updatedRowValues[6] =7 ;
                updatedRowValues[7] =8 ;
                updatedRowValues[8] = 9;
                updatedRowValues[9] = 10;
                updatedRowValues[10] =11 ;
                updatedRowValues[11] = 12;
                dataProvider.EditUser(1, updatedRowValues);

            }
            else
            {
                dataProvider.AddNewUser(userInput);
            }
        }

    }

}
