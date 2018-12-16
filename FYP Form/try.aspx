<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="try.aspx.cs" Inherits="FYP_Form._try" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

    
   <script>
//function allowDrop(ev) {
//    ev.preventDefault();
//}

//function drag(ev) {
//    ev.dataTransfer.setData("text", ev.target.id);
//}

//function drop(ev) {
//    ev.preventDefault();
//    var data = ev.dataTransfer.getData("text");
//    ev.target.appendChild(document.getElementById(data));

//       }

  $(function () {

    $("#div1").draggable({
        helper: "clone",
        cursor: 'move'
    });
    $("#container").droppable({
        drop: function (event, ui) {
            var $canvas = $(this);
            if (!ui.draggable.hasClass('canvas-element')) {
                var $canvasElement = ui.draggable.clone();
                $canvasElement.addClass('canvas-element');
                $canvasElement.draggable({
                    containment: '#container'
                });
                $canvas.append($canvasElement);
                $canvasElement.css({
                    left: (ui.position.left),
                    top: (ui.position.top),
                    position: 'absolute'
                });
            }
        }
    });

});






</script>

    

 <style type ="text/css">

  #div1 {
     width: 300px;
     height: 500px;
     float:left;
     border:0px
     
 }
     #container {
         width: 800px;
         height: 1000px;
         background: #dbdddd;
         margin-left: 300px;
     }

     #container > div {
         
         width:100px;
         height: 100px;
         padding: 10px;
     }

     

    
 </style>

    <style>
        .padding {
            padding:.5em;
        }
    </style>

   
 
    <div id="div1" ondrop="drop(event)" ondragover="allowDrop(event)">
        <asp:Button ID="Label1" runat="server" Text="Tools Box" Height="50px" Width="252" BackColor="#0033CC" ForeColor="White"></asp:Button>
        <br />
        <asp:Button ID="Label2" runat="server" Text="Standard V" Height="40px" Width="252px" BackColor="Black" BorderColor="Black" ForeColor="White"></asp:Button>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Single Line Text" Height="40px" Width="140px" BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)" UseSubmitBehavior="false" OnClick="Button1_Click"/>
        <asp:Button ID="Button2" runat="server" Text="Multline Text" Height="40px" Width="112px" BackColor="#666666" ForeColor="White" draggable="true"
ondragstart="drag(event)"    />
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
       <h2>Your Form</h2>
 <div id="container" class="ui-widget-content" >

     <div id="form_com">
         
         <asp:PlaceHolder ID="PlaceHolder1"  runat="server"  ></asp:PlaceHolder>
         
         
     </div>



 </div>


    <asp:Button ID="addButton" runat="server" Text="add text box" />



    

</asp:Content>
