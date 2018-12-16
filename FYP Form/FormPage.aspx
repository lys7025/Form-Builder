<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormPage.aspx.cs" Inherits="FYP_Form.FormPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script>
		function show(id) {
			if (confirm("Are you sure?")) {
				window.location.replace("DeletePage.aspx?id="+id);
			} else {
				//nothing
			}
		}
	</script>

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
