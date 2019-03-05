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
            //DataTable dt = dataProvider.GetDataTable();
            //foreach (DataColumn col in dt.Columns)
            //{
            //    if (col.ColumnName != "Record ID")
            //    {
            //        BoundField field = new BoundField();
            //        field.DataField = col.ColumnName;
            //        field.HeaderText = col.ColumnName;
            //        grdUsers.Columns.Add(field);
                    
            //    }
            //}
            //grdUsers.AutoGenerateColumns = false;
            grdUsers.DataSource = dataProvider.GetDataSet();
            grdUsers.DataBind();
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            
            DataTable dt = dataProvider.GetDataTable();
           
            var btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            DataRow dataRow = dt.Rows[row.RowIndex];
            string s = $"myWindow = window.open(\"Default.aspx\", \"List\", \"toolbar = no, location = no,status = no,menubar = no,scrollbars = yes,resizable = no, width = 700,height = 650,left = 430,top = 0\");" +
                $"myWindow.id=\"{dataRow[0].ToString()}\";" +
                $"myWindow.firstName= \"{dataRow[1].ToString()}\" ;" +
                $"myWindow.lastName= \"{dataRow[2].ToString()}\";" +
                $"myWindow.title =\"{ dataRow[3].ToString()}\";" +
                $"myWindow.jobCategory=\"{dataRow[4].ToString()}\";" +
                $"myWindow.gender=\"{dataRow[5].ToString()}\";" +
                $"myWindow.campus=\"{dataRow[6].ToString()}\";" +
                $"myWindow.language=\"{dataRow[7].ToString()}\";" +
                $"myWindow.isEdit=\"true\";" +
                $"myWindow.expiriationDate=\"{dataRow[9].ToString()}\";" +
                $"myWindow.RSL=\"{dataRow[10].ToString()}\";" ;
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            //Response.Redirect($"Default.aspx?isEdit=true" +
            //    $"&id={index}" +
            //    $"&firstName={row.Cells[1].Text}" +
            //    $"&lastName={row.Cells[2].Text}" +
            //    $"&title={row.Cells[3].Text}" +
            //    $"&jobCategory={row.Cells[4].Text}" +
            //    $"&gender={row.Cells[5].Text}" +
            //    $"&campus={row.Cells[6].Text}" +
            //    $"&language={row.Cells[7].Text}" +
            //    $"&currentDate={row.Cells[8].Text}" +
            //    $"&expiriationDate={row.Cells[9].Text}" +
            //    $"&RSL={row.Cells[10].Text}" +
            //    $"&password={row.Cells[11].Text}");
            

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int index = row.RowIndex;
            dataProvider.DeleteUser(index);
            Page.Response.Redirect(Page.Request.Url.ToString(), false);


        }

        protected void GridViewEvent(object sender, GridViewRowEventArgs e)
        {
            
            e.Row.Cells[1].Visible = false;
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