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
            {
                switch (LastGuessedNumber.Outcome)
                {
                    case Outcome.Initialize: return "Ingen gissning gjord";
                    case Outcome.Low: return "För lågt ";
                    case Outcome.High: return "För högt";
                    case Outcome.Right: return "Grattis, rätt gissat!";
                    case Outcome.NoMoreGuesses: return "Looser, slut på gissningar";
                    case Outcome.OldGuess: return "Ni har redan gissat på detta tal";

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }


        public string GuessedText
        {
            get
            {
                string countString = "";
                switch (Count)
                {
                    case 1: countString = "Första";
                        break;
                    case 2: countString = "Andra";
                        break;
                    case 3: countString = "Tredje";
                        break;
                    case 4: countString = "Fjärde";
                        break;
                    case 5: countString = "Femte";
                        break;
                    case 6: countString = "Sjätte";
                        break;
                    case 7: countString = "Sjunde";
                        break;
                }
                return String.Format("{0} gissningen", countString);
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
                if (Count < MaxNumberOfGuesses && LastGuessedNumber.Outcome != Outcome.Right)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
            //_guessedNumbers.Any = (n == number) - Kolla över detta igen! Lite rövigt just nu...
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
                return _number;
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
            //_lastGuessedNumber = new GuessedNumber() {Number = guess};
            if (CanMakeGuess)
            {
                if (guess < 1 || guess > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }
                foreach (var item in _guessedNumbers)

                    if (item.Number == guess)
                    {
                        return _lastGuessedNumber.Outcome = Outcome.OldGuess;
                    }

            }
            //Lågt, högt eller stämmer ska lämpligt värde av Outcome returneras. 
            //_lastGuessedNumber.Number = guess;
            _guessedNumbers.Add(_lastGuessedNumber);

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
            //Slut på gissningar!
            else
            {
                _lastGuessedNumber.Outcome = Outcome.NoMoreGuesses;
            }
            return _lastGuessedNumber.Outcome;

        }

        public SecretNumber()
        {
            _guessedNumbers = new List<GuessedNumber>();
            _lastGuessedNumber = new GuessedNumber();
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