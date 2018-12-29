<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLogout.Master" AutoEventWireup="true" CodeBehind="FormPage.aspx.cs" Inherits="FYP_Form.FormPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        //function show(id,title) {
        //    if (confirm("Are you sure want to delete " + title + " ?")) {
        //        window.location.replace("DeletePage.aspx?id=" + id);
        //    } else {
        //        //nothing
        //    }
        //}
    </script>

    <style type="text/css">
        table {
            width: 400px;
        }

        th {
            text-align: left;
        }

        table, th, td {
            border: 1px solid #000;
            border-collapse: collapse;
        }

        th, td {
            padding: 10px;
        }
    </style>

    <h2>Form Page</h2>

    <p>
        <a href='Create'>Create New</a>
    </p>

    <br />
    <asp:PlaceHolder ID="phTable" runat="server"></asp:PlaceHolder>
    <asp:Table ID="Table1" runat="server"
        CellPadding="10"
        GridLines="Both">
        <%--<asp:TableRow>
        <asp:TableHeaderCell >
            Title
       </asp:TableHeaderCell>
<%--        <th>
            Staff ID
        </th>--%>

        <%--<asp:TableHeaderCell>
            Version
       </asp:TableHeaderCell>
        <asp:TableHeaderCell>
            Status
        </asp:TableHeaderCell>
 
    </asp:TableRow>--%>


        <%--    <% foreach (var item in Model) %>--%>
        <%--<asp:TableRow>--%>
        <%--<asp:TableCell>
  <%--              <%= item.title %>--%>
        <%--Registration Form
           </asp:TableCell>--%>
        <%--            <td>
                <%= item.staffID %>
            </td>--%>
        <%--           <td>
               <%= item.dateGenerated %>
            </td>--%>
        <%--           <asp:TableCell>--%>
        <%--                <%= item.Version %>--%>

        <%--</asp:TableCell>
            <asp:TableCell>
   <%--             <%= item.Status %>--%>

        <%--</asp:TableCell>
        <asp:TableCell>
            <a href='EditForm'>Edit</a> |
            <a href='ViewForm'>View</a> |
            <a href='DeleteForm'>Delete</a> |        
        </asp:TableCell>--%>
        <%--</asp:TableRow>--%>
    </asp:Table>



</asp:Content>
