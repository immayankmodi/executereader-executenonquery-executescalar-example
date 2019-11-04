using System;
using System.Data.SqlClient;

namespace ExecuteReaderExecuteNonQueryExecuteScalar {

    public partial class ExecuteScalar : System.Web.UI.Page {

        //specify your connection string here..
        public static string strConn = @"Data Source=datasource;Integrated Security=true;Initial Catalog=yourDB";

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
                BindGridviewFileData();
        }

        //button click event to get the scalar value
        protected void btnGetValue_Click(object sender, EventArgs e) {
            try {
                using (SqlConnection sqlConn = new SqlConnection(strConn)) {
                    using (SqlCommand sqlCmd = new SqlCommand()) {
                        sqlCmd.CommandText = "SELECT * FROM SubjectDetails";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        //here execute scalar will get firsr row first column value
                        lblScalarValue.Text = Convert.ToString(sqlCmd.ExecuteScalar());
                        if (string.IsNullOrEmpty(lblScalarValue.Text))
                            lblScalarValue.Text = "No record found!";
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