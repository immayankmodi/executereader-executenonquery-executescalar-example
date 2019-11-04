using System;
using System.Data.SqlClient;

namespace ExecuteReaderExecuteNonQueryExecuteScalar {

    public partial class ExecuteNonQuery : System.Web.UI.Page {

        //specify your connection string here..
        public static string strConn = @"Data Source=datasource;Integrated Security=true;Initial Catalog=yourDB";

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
                BindGridviewFileData();
        }

        //button click event to get the scalar value
        protected void btnInsert_Click(object sender, EventArgs e) {
            try {
                using (SqlConnection sqlConn = new SqlConnection(strConn)) {
                    using (SqlCommand sqlCmd = new SqlCommand()) {
                        sqlCmd.CommandText = "INSERT INTO SubjectDetails VALUES ('jQuery')";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        //here execute scalar will get firsr row first column value
                        int retValue = sqlCmd.ExecuteNonQuery();
                        if (retValue > 0) {
                            lblReturnValue.Text = retValue + " record(s) inserted!";
                            //record(s) inserted so rebind fresh data
                            BindGridviewFileData();
                        } else {
                            lblReturnValue.Text = "No record(s) inserted!";
                        }
                        sqlConn.Close();
                    }
                }
            } catch { }
        }

        //bind subject details to gridview
        private void BindGridviewFileData() {
            try {
                using (SqlConnection sqlConn = new SqlConnection(strConn)) {
                    using (SqlCommand sqlCmd = new SqlCommand()) {
                        sqlCmd.CommandText = "SELECT * FROM SubjectDetails";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        gvSubjectDetails.DataSource = sqlCmd.ExecuteReader();
                        gvSubjectDetails.DataBind();
                        sqlConn.Close();
                    }
                }
            } catch { }
        }
    }
}