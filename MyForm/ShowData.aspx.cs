using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;

namespace MyForm
{
    public partial class ShowData : System.Web.UI.Page
    {
        DataProvider dataProvider = new DataProvider(DataProvider.ProviderType.XML);
        protected void Page_Load(object sender, EventArgs e)
        {

            


            if (!IsPostBack)
            {
                FillDataToGridView();
            }
        

        }
        public void FillDataToGridView()
        {
            grdUsers.DataSource = dataProvider.GetDataSet();
            grdUsers.DataBind();
        }

            

        protected void Delete_Click(object sender, EventArgs e)
            {
            var btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int index = row.RowIndex;
            dataProvider.DeleteUser(index);
            Page.Response.Redirect(Page.Request.Url.ToString(), false);


        }

 

        protected void BtnOpen_Click(object sender, EventArgs e)
        {
            int newID = dataProvider.GetLatestID() + 1;
            string s = $"myNewWindow = window.open(\"Default.aspx\", \"List\", \"toolbar = no, location = no,status = no,menubar = no,scrollbars = yes,resizable = no, width = 700,height = 650,left = 430,top = 0\");" +
                $"myNewWindow.rowID=\"{newID}\";";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }
    }
}