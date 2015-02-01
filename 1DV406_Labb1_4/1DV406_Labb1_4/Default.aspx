<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_1DV406_Labb1_4.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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

				<!-- Skickaknapp-->
				<asp:Button ID="SendButton" runat="server" Text="Skicka gissning" OnClick="SendButton_Click" />

			</div>

			<!-- Presentation av gissningar-->
			<asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
				<p>
					<asp:Label ID="ShowGuessLabel" runat="server" Text=""></asp:Label>
				</p>
			</asp:PlaceHolder>

			<!-- Presentation av resultat-->
			<asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
				<p>
					<asp:Label ID="ShowResultLabel" runat="server" Text=""></asp:Label>
				</p>
			</asp:PlaceHolder>

			<!-- Knapp som ska generera nytt hemligt nummer-->
			<asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible="false">
				<p>
					<asp:Button ID="NewSecretNoButton" runat="server" Text="Slumpa nytt hemligt tal" OnClick="NewSecretNoButton_Click" />
				</p>
			</asp:PlaceHolder>

			<!-- Valideringsfelmeddelanden-->
			<p>
				<asp:ValidationSummary ID="ValidationSummary1" runat="server"
					HeaderText="fel inträffade! Korrigera felet och gör ett nytt försök." />
			</p>
		</div>
    
    </div>
    </form>
</body>
</html>
