using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _1DV406_Labb1_4.Model;

namespace _1DV406_Labb1_4//Marco villegas
{
    public partial class Default : System.Web.UI.Page
    {
       
        
		private SecretNumber SecretNumber
		{
			get
			{
                if (Session["SecretNumber"] == null)// If satsen körs om sessionsobjekt SecretNumber är null 
				{

                    Session["SecretNumber"] = new SecretNumber();//Skapar nytt object och lägger den i sessionen SecretNumber

                    return Session["SecretNumber"] as SecretNumber; //Sparar sessionen i variabel för att kunna anropa objektet

				}
				else
				{
                    return Session["SecretNumber"] as SecretNumber; //Sparar sessionen i variabel för att kunna anropa objektet
				}
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
          
		}

		protected void SendButton_Click(object sender, EventArgs e)
		{
            if (IsValid) // If satsen körs om valideringarna inte hitat något fel
			{
				int choice = int.Parse(GuessTextBox.Text);// Omvandlar det inmatade talet till int
                Outcome answer = SecretNumber.MakeGuess(choice);//Tar med sig det in matade värdet in i funktionen MeakeGuess
                PlaceHolder1.Visible = true;// Visat placeholder1 på hemsidan 
                ShowGuessLabel.Text = string.Join(", ", SecretNumber.PreviousGuesses);// Visar numer som man gissat på 

                if (answer == Outcome.High)//Om siffran man gissat på, är för högt körs den här if satsen 
				{
                    ShowGuessLabel.Text += String.Format("<img src='Images/up16.png' /> För högt!");// visar bild och meddelande 
				}
                else if (answer == Outcome.Low)//Om siffran man gissat på, är för lågt körs den här if satsen 
				{
                    ShowGuessLabel.Text += String.Format("<img src='Images/down16.png' /> För lågt!");// visar bild och meddelande 
				}
                else if (answer == Outcome.Correct)//Om siffran man gissat på är rätt så körs den här if satsen 
				{
                    ShowResultLabel.Text = String.Format("<img src='Images/check1.png' /> Grattis! Du klarade det på {0} försök", SecretNumber.Count);// visar bild och text
                    GuessTextBox.Enabled = false;// tar bort GuessTextBox från websidan
                    SendButton.Enabled = false;// tar bort SendButton från websidan
                    PlaceHolder2.Visible = true;// Visat placeholder2 på websidan
                    PlaceHolder3.Visible = true;// Visat placeholder3 på websidan
				}
                else if (answer == Outcome.PreviousGuess)// Om man redan gissat på siffran man mattat in så körs den här if satsen  
				{
                    ShowGuessLabel.Text += String.Format("<img src='Images/alert16.png' /> redan gissat på talet"); // visar bild och meddelande 
				}
                else if (answer == Outcome.NoMoreGuesses)// Om du redan gissat 7 gånger körs den här if satsen  
				{
                    ShowResultLabel.Text = String.Format(" <img src='Images/close16.png' />inga gissningar kvar, hemliga talet var {0}", SecretNumber.Number);// visar bild och meddelande 
                    GuessTextBox.Enabled = false;// tar bort GuessTextBox från websidan
                    SendButton.Enabled = false;// tar bort SendButton från websidan
                    PlaceHolder2.Visible = true;// Visat placeholder2 på websidan
                    PlaceHolder3.Visible = true;// Visat placeholder2 på websidan
				}
			}
		}

		protected void NewSecretNoButton_Click(object sender, EventArgs e)
		{
            Session.Clear();// Rensar sessionen
            Response.Redirect("Default.aspx");//Startat den igen   
		}

        
    }
}