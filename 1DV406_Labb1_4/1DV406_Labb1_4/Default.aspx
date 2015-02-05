<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_1DV406_Labb1_4.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Marco - Labb 1.4</title>

    <link rel="stylesheet" href="Style.css" media="screen">

    <script src="Script.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>

        <div id="inramning">

              <!-- text-->
			<h1>
				<asp:Label ID="TitleLabel" runat="server" Text="Gissa det hemliga talet"></asp:Label>
			</h1>

			<div id="Textruta">

			
           <!-- text-->
				<asp:Label ID="GuessLabel" runat="server" Text="Ange ett tal mellan 1 och 100:"></asp:Label>

                	<!--Textinputruta - för gissningar-->
				<asp:TextBox ID="GuessTextBox" runat="server" Width="35"></asp:TextBox>

				<!-- Validering: Kontrollerar om textboxsen är tom-->
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="GuessTextBox" 
                    ErrorMessage="Ett tal måste anges" Display="None"></asp:RequiredFieldValidator>

				 <!-- Validering: Kontrollerar om det in matade värdet är ett värde mellan 1-100-->
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="GuessTextBox" Type="Integer"
					ErrorMessage="Ange ett tal mellan 1 och 100" MaximumValue="100" MinimumValue="1" Display="None"></asp:RangeValidator>

                <div id="knap1">
				<!-- Skickaknapp-->
				<asp:Button ID="SendButton" runat="server" Text="Skicka gissning" OnClick="SendButton_Click" />
                </div>
			</div>

            <div id="Gissningar">

			<!-- Presentation av gissningar-->
			<asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
				<p>
					<asp:Label ID="ShowGuessLabel" runat="server" Text=""></asp:Label>
				</p>
			</asp:PlaceHolder>

                </div>

            <div id="resultat">

			<!-- Presentation av resultat-->
			<asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
				<p>
					<asp:Label ID="ShowResultLabel" runat="server" Text=""></asp:Label>
				</p>
			</asp:PlaceHolder>

                </div>

            <div id="knap2">

			<!-- Knapp som ska generera nytt hemligt nummer-->
			<asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible="false">
				<p>
					<asp:Button ID="NewSecretNoButton" runat="server" Text="Slumpa nytt hemligt tal" OnClick="NewSecretNoButton_Click" CausesValidation="False" />
				</p>
			</asp:PlaceHolder>

                 </div>

            <div id="Felmeddelanden">
			<!-- Valideringsfelmeddelanden-->
			<p>
				<asp:ValidationSummary ID="ValidationSummary1" runat="server"
					HeaderText="fel inträffade! Korrigera felet och gör ett nytt försök." />
			</p>
                </div>
		</div>
    
    </div>
    </form>
</body>
</html>
