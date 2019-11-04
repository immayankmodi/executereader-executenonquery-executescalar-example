Imports System.Data.SqlClient

Public Class ExecuteScalar
    Inherits System.Web.UI.Page

    'specify your connection string here..
    Public Shared strConn As String = "Data Source=datasource;Integrated Security=true;Initial Catalog=yourDB"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGridviewFileData()
        End If
    End Sub

    'button click event to get the scalar value
    Protected Sub btnGetValue_Click(ByVal sender As Object, ByVal e As EventArgs)
        Using sqlConn As New SqlConnection(strConn)
            Using sqlCmd As New SqlCommand()
                sqlCmd.CommandText = "SELECT * FROM SubjectDetails"
                sqlCmd.Connection = sqlConn
                sqlConn.Open()
                'here execute scalar will get firsr row first column value
                lblScalarValue.Text = Convert.ToString(sqlCmd.ExecuteScalar())
                If String.IsNullOrEmpty(lblScalarValue.Text) Then
                    lblScalarValue.Text = "No record found!"
                End If
                sqlConn.Close()
            End Using
        End Using
    End Sub

    'bind subject details to gridview
    Private Sub BindGridviewFileData()
        Try
            Using sqlConn As New SqlConnection(strConn)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT * FROM SubjectDetails"
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    gvSubjectDetails.DataSource = sqlCmd.ExecuteReader()
                    gvSubjectDetails.DataBind()
                    sqlConn.Close()
                End Using
            End Using
        Catch
        End Try
    End Sub

End Class