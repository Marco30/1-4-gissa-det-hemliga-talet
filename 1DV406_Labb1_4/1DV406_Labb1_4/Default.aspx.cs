using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _1DV406_Labb1_4.Model;

namespace _1DV406_Labb1_4
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
			if (IsValid) 
			{
				int choice = int.Parse(GuessTextBox.Text);
				Outcome answer = SecretNumber.MakeGuess(choice);
				PlaceHolder1.Visible = true;
				ShowGuessLabel.Text = string.Join(", ", SecretNumber.PreviousGuesses);
				
				if (answer == Outcome.High)
				{
					ShowGuessLabel.Text += String.Format("<img src='Images/up16.png' /> För högt!");
				}
				else if (answer == Outcome.Low)
				{
					ShowGuessLabel.Text += String.Format("<img src='Images/down16.png' /> För lågt!");
				}
				else if (answer == Outcome.Correct)
				{
					ShowResultLabel.Text = String.Format("<img src='Images/check1.png' /> Grattis! Du klarade det på {0} försök", SecretNumber.Count);
					GuessTextBox.Enabled = false;
					SendButton.Enabled = false;
					PlaceHolder2.Visible = true;
					PlaceHolder3.Visible = true;
				}
				else if (answer == Outcome.PreviousGuess)
				{
					ShowGuessLabel.Text += String.Format("<img src='Images/alert16.png' /> Du har redan gissat på talet");
				}
				else if (answer == Outcome.NoMoreGuesses)
				{
					ShowResultLabel.Text = String.Format(" <img src='Images/close16.png' /> Du har inga gissningar kvar. Det hemliga talet var {0}", SecretNumber.Number);
					GuessTextBox.Enabled = false;
					SendButton.Enabled = false;
					PlaceHolder2.Visible = true;
					PlaceHolder3.Visible = true;
				}
			}
		}

		protected void NewSecretNoButton_Click(object sender, EventArgs e)
		{
			Session.Clear();
			Response.Redirect("Default.aspx");
		}

        
    }
}