<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAudio.aspx.cs" Inherits="MyUserAuthenticator.MyAudio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/WebFormsJs") %>
    </asp:PlaceHolder>
</head>
<body>

    <form id="form1" runat="server">
        <div>            
            <audio id="player1" runat="server" src="http://techslides.com/demos/samples/sample.mp3" type="audio/mp3" 
                    controls="controls" preload="none">
            </audio>

            <audio id="player2" runat="server" src="http://techslides.com/demos/samples/sample.mp3" type="audio/mp3" 
                controls="controls" preload="none">
            </audio>
        </div>
        <asp:Button ID="btnPlayAudio" runat="server" Text="Play"/>
        
    </form>
   
</body>
</html>
