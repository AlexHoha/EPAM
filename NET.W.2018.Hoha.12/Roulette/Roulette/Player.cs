using System;
namespace Roulette
{
    /// <summary>
    /// Player contains his current chosen number and/or color and the name of the player.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The number allows values only from 0-36 range.
        /// </summary>
        int number;

        Colors color;

        string name;

        public Colors Color
        {
            get
            {
                return color;
            }

            set
            {
                if (Enum.IsDefined(typeof(Colors),value))
                {
                    color = value;
                }
            }
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                if(value >= 0 && value <=36)
                {
                    number = value;
                }
            }
        }

        public string Name 
        {   get
            {
                return name;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the Player class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="num">Number.</param>
        /// <param name="col">Col.</param>
        public Player(string name = "default", int num = -1, Colors col = Colors.Undefined)
        {
            Name = name;
            Number = num;
            Color = col;
        }

        /// <summary>
        /// Display message. 
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void PlayerMsgOnNum(object sender, RouletteSpinEventArgs e)
        {
            if(e.Number == Number)
            {
                Console.WriteLine($"GOTCHA! {Name} got the number!");
            }
        }

        /// <summary>
        /// Display message.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void PlayerMsgOnCol(object sender, RouletteSpinEventArgs e)
        {
            if(e.Color == Color)
            {
                Console.WriteLine($"GOTCHA! {Name} got the color!");
            }
        }

        /// <summary>
        /// Start "listening" SpecNumEventHandler from Roulette class.
        /// </summary>
        /// <param name="roulette">Roulette.</param>
        public void RegisterOnNum(Roulette roulette)
        {
            roulette.OnSpecNumber += PlayerMsgOnNum;
        }

        /// <summary>
        /// Start "listening" SpecColEventHandler from Roulette class.
        /// </summary>
        /// <param name="roulette">Roulette.</param>
        public void RegisterOnColor(Roulette roulette)
        {
            roulette.OnSpecColor += PlayerMsgOnCol;
        }
    }
}
