using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace KataMasterMind_Model
{
    public class ColorElement
    {
        public readonly static int NumCharsPerElement = 7;
        public static readonly char CharPadRight = ' ';

        public enum eColor
        {
            _EMPTY = 0,
            RED = 1,
            YELLOW = 2,
            ORANGE = 3,
            GREEN = 4,
            VIOLET = 5,
            BLACK = 6,
            WHITE = 7,
            LIME = 8
        }

        public eColor Color;

        public ColorElement()
        {

        }

        public ColorElement(eColor color) : this()
        {
            this.Color = color;
        }

        public static ColorElement GetElementRandom()
        {
            Thread.Sleep(DateTime.Now.Millisecond/75); // 75 porque no?

            int seed = int.Parse(DateTime.Now.Millisecond.ToString());
            int randomNumber = new Random(seed).Next(1, Enum.GetNames(typeof (eColor)).Length);
            return new ColorElement((eColor) Enum.GetValues(typeof (eColor)).GetValue(randomNumber));
        }
     
        public bool EqualsElement(ColorElement color)
        {
            return (this.Color == color.Color);
        }  

        public override string ToString()
        {
            string result = "".ToString().PadRight(NumCharsPerElement, CharPadRight);
            if (this.Color != eColor._EMPTY)
                result = this.Color.ToString().PadRight(NumCharsPerElement, CharPadRight);
            return result;
        }

    }
}
