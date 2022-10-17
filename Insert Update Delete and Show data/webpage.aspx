<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webpage.aspx.cs" Inherits="Insert_Update_Delete_and_Show_data.webpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>First Name</td>
                    <td><asp:TextBox ID="studentFirstName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Last Name</td>
                    <td><asp:TextBox ID="studentLastName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>CLass</td>
                    <td><asp:TextBox ID="studentClassName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td> Roll </td>
                    <td><asp:TextBox ID="studentRollNo" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Result</td>
                    <td><asp:TextBox ID="studentResult" runat="server"></asp:TextBox></td>
                </tr>
                <br />

                <tr>
                    <td colspan ="100" align="center">
                        <asp:Button ID="btnStudentInfoSave" runat="server" Text="Save" OnClick="btnStudentInfoSave_Click" />
                        <asp:Button ID="btnStudentInfoUpdate" runat="server" Text="Update" OnClick="btnStudentInfoUpdate_Click" />
                        <asp:Button ID="btnStudentInfoDelete" runat="server" Text="Delete" OnClick="btnStudentInfoDelete_Click" />
                        
                    </td>

                </tr>

                <tr>
                    <td>Insert Your Id For Update or Delete</td>
                    <td><asp:TextBox ID="UpdateDeleteTextBox" runat="server"></asp:TextBox></td>
                </tr>
            </table>
             <br />
                <asp:GridView ID="StudentInfoDisplayGrid" runat="server"></asp:GridView>
             <br />
            
            
            <table>
                 <tr>
                    <td>Insert Your Class to Show you CLass Information</td>
                    <td><asp:TextBox ID="classForShow" runat="server"></asp:TextBox></td>
                </tr>
              <br />
               <tr>
                    <td colspan ="100" align="center">
                       <asp:Button ID="btnStudentInfoShow" runat="server" Text="Show" OnClick="btnStudentInfoShow_Click"/>
                    </td>
                </tr>
            </table>
             <br />
                <asp:GridView ID="EachClassGrid" runat="server"></asp:GridView>

        </div>
    </form>
</body>
</html>
