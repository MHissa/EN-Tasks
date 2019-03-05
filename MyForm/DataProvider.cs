using MyForm.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Configuration;

namespace MyForm
{


    public class DataProvider
    {
        DataSet ds;
        DataTable dt;
        DataRow row;

        public enum ProviderType
        {
            XML,
            SQL

        }

        readonly ProviderType providerType;
        public DataProvider(ProviderType providerType)
        {
            this.providerType = providerType;
            switch (this.providerType)
            {
                case ProviderType.XML:
                    CreateDataTableFromXML();

                    break;

            }
        }
        public DataTable GetDataTable()
        {
            return ds.Tables[0];

        }
        public void CreateDataTableFromXML()
        {

            ds = new DataSet("Users");
            dt = ds.Tables.Add("UserInfo");

            DataColumn dcID = dt.Columns.Add("Record ID", typeof(int));
            DataColumn dcFName = dt.Columns.Add("First name");
            DataColumn dcLName = dt.Columns.Add("Last name");
            DataColumn dcTitle = dt.Columns.Add("Title");
            DataColumn dcJobCategory = dt.Columns.Add("Job category");
            DataColumn dcGender = dt.Columns.Add("Gender");
            DataColumn dcCampus = dt.Columns.Add("Campus");
            DataColumn dcLanguage = dt.Columns.Add("prefered language");
            DataColumn dcDate = dt.Columns.Add("Status date");
            DataColumn dcExprDate = dt.Columns.Add("Expriation date");
            DataColumn dcRSL = dt.Columns.Add("Resource sharing libary");
            DataColumn dcPass = dt.Columns.Add("Password");
            dt.PrimaryKey = new DataColumn[] { dcID };
            dcID.DataType = System.Type.GetType("System.Int32");
            LoadXML();

        }

        public void LoadXML()
        {
            try
            {
                ds.ReadXml(WebConfigurationManager.AppSettings["xml_path"], XmlReadMode.InferSchema);
            }
            catch (Exception)
            {

                throw;
            }



        }
        public void AddNewUser(UserInput userInput)
        {


            row = ds.Tables["UserInfo"].NewRow();
            row["First name"] = userInput.Fristname;
            row["Last name"] = userInput.LastName;
            row["Title"] = userInput.Title;
            row["Job category"] = userInput.JobCategory;
            row["Gender"] = userInput.Gender;
            row["Campus"] = userInput.Campus;
            row["Prefered language"] = userInput.PreferedLanguage;
            row["Status date"] = userInput.StatusDate;
            row["Expriation date"] = userInput.ExpriationDate;
            row["Resource sharing libary"] = userInput.RSL;
            row["Password"] = userInput.Password;
            row["Record ID"] = userInput.RecordID;
            ds.Tables["UserInfo"].Rows.Add(row);
            SaveXML();


        }
        public void SaveXML()
        {
            try
            {
                ds.WriteXml(WebConfigurationManager.AppSettings["xml_path"]);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet GetDataSet()
        {
            return ds;

        }



        public void EditUser(int pk, object[] updatedData)
        {
            DataRowCollection dRowC = dt.Rows;
            DataRow row=dRowC.Find(pk);

            int rowIndex=dt.Rows.IndexOf(row);
            ds.Tables["UserInfo"].Rows[rowIndex].ItemArray = updatedData;
            ds.AcceptChanges();
            SaveXML();
        }
        public void DeleteUser(int index)
        {
            ds.Tables["UserInfo"].Rows[index].Delete();
            ds.AcceptChanges();
            SaveXML();

        }
        public int GetLatestID()
        {
            if(dt.Rows.Count>0)
            {
               int id= Convert.ToInt32( dt.Rows[dt.Rows.Count - 1]["Record ID"]);
                return id;
            }
            else
            return 0;
        }
    }
}

