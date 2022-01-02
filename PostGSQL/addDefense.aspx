<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addDefense.aspx.cs" Inherits="PostGSQL.addDefense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <h1>Add Defense</h1>

        <p>
            Thesis Serial Number:
            <asp:TextBox ID="ThesisSSN" runat="server" required ="true" type ="number"></asp:TextBox>
        </p>
        <p>
            Date:
            <asp:TextBox ID="dateDefense" runat="server" placeHolder ="dd/mm/yyyy"   autocomplete="off"  required ="true"></asp:TextBox>
               <!-- Bootstrap -->
    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
   
    <!-- Bootstrap -->
    <!-- Bootstrap DatePicker -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css"
        type="text/css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js"
        type="text/javascript"></script>
    <!-- Bootstrap DatePicker -->
    <script type="text/javascript">
        $(function () {
            $('[id*=dateDefense]').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                language: "tr"
            });
        });
    </script>
            
    
            
        </p>
        <p>
            location:
            <asp:TextBox ID="host" runat="server" required ="true"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" />
        </p>

    </form>
</body>
</html>
