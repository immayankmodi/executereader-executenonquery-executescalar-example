﻿Imports System.Data.SqlClient

Public Class ExecuteReader
    Inherits System.Web.UI.Page

    'specify your connection string here..
    Public Shared strConn As String = "Data Source=datasource;Integrated Security=true;Initial Catalog=yourDB"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGridviewFileData()
        End If
    End Sub

    'bind subject details to gridview
    Private Sub BindGridviewFileData()
        Try
            Using sqlConn As New SqlConnection(strConn)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT * FROM SubjectDetails"
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                    gvSubjectDetails.DataSource = objDataReader
                    gvSubjectDetails.DataBind()
                    sqlConn.Close()
                End Using
            End Using
        Catch
        End Try
    End Sub

End Class