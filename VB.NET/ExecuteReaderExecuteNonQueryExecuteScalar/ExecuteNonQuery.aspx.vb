Imports System.Data.SqlClient

Public Class ExecuteNonQuery
    Inherits System.Web.UI.Page

    'specify your connection string here..
    Public Shared strConn As String = "Data Source=datasource;Integrated Security=true;Initial Catalog=yourDB"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGridviewFileData()
        End If
    End Sub

    'button click event to get the scalar value
    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Using sqlConn As New SqlConnection(strConn)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "INSERT INTO SubjectDetails VALUES ('jQuery')"
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    'here execute scalar will get firsr row first column value
                    Dim retValue As Integer = sqlCmd.ExecuteNonQuery()
                    If retValue > 0 Then
                        lblReturnValue.Text = retValue & " record(s) inserted!"
                        'record(s) inserted so rebind fresh data
                        BindGridviewFileData()
                    Else
                        lblReturnValue.Text = "No record(s) inserted!"
                    End If
                    sqlConn.Close()
                End Using
            End Using
        Catch
        End Try
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