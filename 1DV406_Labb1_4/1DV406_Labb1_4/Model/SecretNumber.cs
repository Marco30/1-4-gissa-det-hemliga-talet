using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace _1DV406_Labb1_4.Model// Marco villegas
{
    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess };
    public class SecretNumber
    {
       
        private int _number;//privat inte
        private List<int> _previousGuesses;//privat lista
        public const int MaxNumberOfGuesses = 7;// Antal gissningar 

        public SecretNumber()  //Konstruktor
        {
            _previousGuesses = new List<int>(MaxNumberOfGuesses);//Till delar listan 7 platser 
            Initialize();
        }
        public void Initialize()// Initierar klassens medlemmar
        {
            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
            Random randomNumber = new Random();
            _number = randomNumber.Next(1, 101);
        }


        public bool CanMakeGuess
        {
            get
            {
                

                // Ger ett värde som indikerar om en gissning kan göras eller inte
                if(_previousGuesses.Count == MaxNumberOfGuesses || Outcome.PreviousGuess == Outcome.NoMoreGuesses) 
                {
                    return false;
                }
                else
                {
                    return true;
                }


            }
        }

       
        public int Count
        {
            get { return _previousGuesses.Count; } // Ger antalet gjorda gissningar 
        }



        public int? Number    // Sätter det hemliga talet
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                return _number;
            }
        }


        public Outcome Outcome { get; private set; } // Ger resultat av den senast utförda gissningen


        public ReadOnlyCollection<int> PreviousGuesses// Ger referens till en samling innehållande gjorda gissningar
        {
            get { return _previousGuesses.AsReadOnly(); }
        }


        public Outcome MakeGuess(int guess) // Returnerar värde på det gissade talet
        {
            if (guess < 1 || guess > 100)// Om gissningen är mindre 1 och större än 100 så kastas felhantering  
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Count > MaxNumberOfGuesses)//om man gjort mer än 7 gissningar så kastas felhantering  
            {
                throw new ApplicationException();
            }

            if (Count == MaxNumberOfGuesses)// om man exakt gjort 7 gissningar så visas inga mer gissningar 
            {
                return Outcome.NoMoreGuesses;
            }

            if (PreviousGuesses.Contains(guess))// If satsen körs om man gjort en gissning som man gjort tidigare 
            {
                return Outcome.PreviousGuess;
            }
            _previousGuesses.Add(guess);// Läger till gissning 

            if (guess > _number)//Om siffran man gissat på, är för högt körs den här if satsen 
            {
                return Outcome.High;
            }
            else if (guess < _number)// //Om siffran man gissat på, är för lågt körs den här if satsen 
            {
                return Outcome.Low;
            }
            else//Om siffran man gissat på är rätt så körs den här satsen 
            {
                return Outcome.Correct;
            }
        }


     

    }
}