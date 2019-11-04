<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExecuteReader.aspx.cs"
    Inherits="ExecuteReaderExecuteNonQueryExecuteScalar.ExecuteReader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AspnetO.com | ExecuteReader Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td colspan="3">
                        <h4>SqlCommand ExecuteReader in ado.net example
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="gvSubjectDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="SubjectID">
                            <HeaderStyle Font-Bold="true" BackColor="#ff6600" BorderColor="#f5f5f5" ForeColor="White"
                                Height="30" />
                            <Columns>
                                <asp:BoundField DataField="SubjectID" HeaderText="Subject Id" ItemStyle-Width="150px" />
                                <asp:BoundField DataField="SubjectName" HeaderText="Subject Name" ItemStyle-Width="200px" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
