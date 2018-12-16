<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test2.aspx.cs" Inherits="FYP_Form.Test2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Content/Form/custom.css" rel="stylesheet">
    <link href="Content/Form/bootstrap.min.css" rel="stylesheet">
    <link href="Content/Form/bootstrap-responsive.min.css" rel="stylesheet">
    <script data-main="Scripts/FormBuilder/main-built.js" src="Scripts/FormBuilder/require.js" ></script>
          
    <div id="div1" ondrop="drop(event)" ondragover="allowDrop(event)">
        <asp:Button ID="Label1" runat="server" Text="Tools Box" Height="50px" Width="252" BackColor="#0033CC" ForeColor="White"></asp:Button>
        <br />
        <asp:Button ID="Label2" runat="server" Text="Standard V" Height="40px" Width="252px" BackColor="Black" BorderColor="Black" ForeColor="White"></asp:Button>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Single Line Text" Height="40px" Width="140px" BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"/>
        <asp:Button ID="Button2" runat="server" Text="Multline Text" Height="40px" Width="112px" BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"/>
        <br />
        <asp:Button ID="Button3" runat="server" Text="CheckBox" Height="40px" Width="140px"  BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"/>
        <asp:Button ID="Button4" runat="server" Text="Radio Button" Height="40px" Width="112px"  BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"/>
        <br />
        <asp:Button ID="Button5" runat="server" Text="dropdownlist" Height="40px" Width="140px"  BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"/>
        <asp:Button ID="Button6" runat="server" Text="Email" Height="40px" Width="112px"  BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"/>
        <br />
        <asp:Button ID="Button7" runat="server" Text="Phone" Height="40px" Width="140px"  BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"/>
        <asp:Button ID="Button8" runat="server" Text="Date" Height="40px" Width="112px"  BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"/>
        <br />
        <asp:Button ID="Button9" runat="server" Text="Number" Height="40px" Width="140px"  BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"/>
        <asp:Button ID="Button10" runat="server" Text="label" Height="40px" Width="112px"  BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"/>
        <br />
        <asp:Button ID="Button11" runat="server" Text="Address" Height="40px" Width="140px" BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"/>
        <asp:Button ID="Button12" runat="server" Text="Image" Height="40px" Width="112px" BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"/>
        <br />
        <asp:Button ID="Button13" runat="server" Text="Star rating" Height="40px" Width="140px" BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"/>
        <asp:Button ID="Button14" runat="server" Text="signature" Height="40px" Width="112px" BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"/>
        <br />
        <asp:Button ID="Button15" runat="server" Text="Heading" Height="40px" Width="140px" BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"/>
        <asp:Button ID="Button16" runat="server" Text="Paragraph" Height="40px" Width="112px" BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"/>

        </div>    
    
     
    
    
    <div class="span6">
          <div class="clearfix">
            <h2>Your Form</h2>
            <hr>
            <div id="build">
              <form id="target" class="form-horizontal">
              </form>
            </div>
          </div>
        </div>






</asp:Content>
