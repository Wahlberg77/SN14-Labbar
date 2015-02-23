using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gissa_Talet_MVC_A_Labb_7.Models
{
    public enum Outcome
    {
        Undefined,
        Low,
        High,
        Right,
        NoMoreGuesses,
        OldGuess,
        Initialize,
    };

    public class SecretNumber
    {
        public string _OutcomeMessage(Outcome outcome)
        {
            string message = "";

            switch (outcome)
            {
                case Outcome.Right:
                    return String.Format("Grattis, du klarade det på {0}!", GuessedText);
                case Outcome.OldGuess:
                    return String.Format("Du har redan gissat på {0}, välj ett annat tal!", LastGuessedNumber.Number);
                case Outcome.High:
                    message = String.Format("{0} är för högt.", LastGuessedNumber.Number);
                    break;
                case Outcome.Low:
                    message = String.Format("{0} är för lågt.", LastGuessedNumber.Number);
                    break;
            }
            if (!CanMakeGuess)
            {
                message = String.Format("{0} Inga fler gissningar, det hemliga talet var {1}", message, Number);
            }

            return message;
        }


        public string GuessedText
        {
            get
            {
                string countString = "";
                switch (Count)
                {
                    case 1: countString = "Första gissningen";
                        break;
                    case 2: countString = "Andra gissningen";
                        break;
                    case 3: countString = "Tredje gissningen";
                        break;
                    case 4: countString = "Fjärde gissningen";
                        break;
                    case 5: countString = "Femte gissningen";
                        break;
                    case 6: countString = "Sjätte gissningen";
                        break;
                    case 7: countString = "Sjunde gissningen";
                        break;
                }
                return String.Format("{0}", countString);
            }
        }


        //Fält
        private List<GuessedNumber> _guessedNumbers;

        private GuessedNumber _lastGuessedNumber;

        private int? _number;

        public const int MaxNumberOfGuesses = 7;

        //Egenskaper

        public bool CanMakeGuess
        {
            get
            {
                return Count < MaxNumberOfGuesses;
            }
        }

        public int Count
        {
            get
            {
                return _guessedNumbers.Count;
            }
        }

        public IList<GuessedNumber> GuessedNumbers
        {

            get
            {
                {
                    return _guessedNumbers.AsReadOnly();
                }
            }
        }

        public GuessedNumber LastGuessedNumber
        {
            get
            {
                return _lastGuessedNumber;
            }
        }

        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                else
                {
                    return _number;
                }
            }
            private set
            {
                _number = value;
            }
        }

        // Metoder
        public void Initialize()
        {
            _lastGuessedNumber.Outcome = Outcome.Initialize;
            _guessedNumbers.Clear();
            Random myRandom = new Random();
            _number = myRandom.Next(1, 101);
        }

        // guess utanför 1 och 100 ArgumentExc kastas.
        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            _lastGuessedNumber = new GuessedNumber { Number = guess };

            if (CanMakeGuess)
            {
                if (_guessedNumbers.Any(n => n.Number == guess))
                {
                    _lastGuessedNumber.Outcome = Outcome.OldGuess;
                }
                else
                {
                    if (guess > _number)
                    {
                        _lastGuessedNumber.Outcome = Outcome.High;
                    }

                    else if (guess < _number)
                    {
                        _lastGuessedNumber.Outcome = Outcome.Low;
                    }

                    else if (guess == _number)
                    {
                        _lastGuessedNumber.Outcome = Outcome.Right;
                    }

                    _guessedNumbers.Add(_lastGuessedNumber);
                }
            }
        

            if (!CanMakeGuess && LastGuessedNumber.Outcome != Outcome.Right)
            {
                _lastGuessedNumber.Outcome = Outcome.NoMoreGuesses;
            }
            return _lastGuessedNumber.Outcome;

        }

        public SecretNumber()
        {
            _guessedNumbers = new List<GuessedNumber>();
            Initialize();
        }
    }

    public struct GuessedNumber
    {
        //Innerhåller det gissade värdet. 
        public int? Number;

        //Innerhåller utfallet av gissningen.
        public Outcome Outcome;

    }

}