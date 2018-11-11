using System;
namespace Roulette
{
    /// <summary>
    /// Roulette spin event arguments, such as number and color after the spin.
    /// </summary>
    public class RouletteSpinEventArgs : EventArgs
    {
        readonly int number;
        readonly Colors color;

        public Colors Color
        {
            get
            {
                return color;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
        }

        public RouletteSpinEventArgs(int num, Colors col)
        {
            number = num;
            color = col;
        }
    }
}
