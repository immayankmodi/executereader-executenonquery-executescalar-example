using System;
using System.Data.SqlClient;

namespace ExecuteReaderExecuteNonQueryExecuteScalar {

    public partial class ExecuteReader : System.Web.UI.Page {

        //specify your connection string here..
        public static string strConn = @"Data Source=datasource;Integrated Security=true;Initial Catalog=yourDB";

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
                BindGridviewFileData();
        }

        //bind subject details to gridview
        private void BindGridviewFileData() {
            try {
                using (SqlConnection sqlConn = new SqlConnection(strConn)) {
                    using (SqlCommand sqlCmd = new SqlCommand()) {
                        sqlCmd.CommandText = "SELECT * FROM SubjectDetails";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        SqlDataReader objDataReader = sqlCmd.ExecuteReader();
                        gvSubjectDetails.DataSource = objDataReader;
                        gvSubjectDetails.DataBind();
                        sqlConn.Close();
                    }
                }
            } catch { }
        }
    }
}