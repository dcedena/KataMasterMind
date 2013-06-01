using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataMasterMind_Model
{
    public class RowElements
    {
        public readonly static string BEGIN_LINE = "[ ";
        public readonly static string END_LINE = " ]";
        public readonly static string SEPARATOR_LINE = " | ";

        private List<ColorElement> _listElements = new List<ColorElement>();
        public string Result = "";
        public bool SetQuestion = false;

        public RowElements()
        {
            this._listElements = new List<ColorElement>();
        }

        public RowElements(List<ColorElement> listElements)
            : this()
        {
            this._listElements = listElements;
        }

        public RowElements AddElement(ColorElement newElement)
        {
            this._listElements.Add(newElement);
            return this;
        }

        public List<ColorElement> GetElements()
        {
            return this._listElements;
        }

        public bool ContainsElement(ColorElement element)
        {
            bool result = false;
            if(element is ColorElement)
            {
                ColorElement ce = (ColorElement) element;
                foreach (ColorElement elem in _listElements)
                {
                    if (elem.Color == ce.Color)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            if ((_listElements != null) && (_listElements.Count > 0))
            {
                if (SetQuestion)
                {
                    List<string> sq = new List<string>();
                    for (int i = 0; i < _listElements.Count;i++ )
                        sq.Add("?".ToString().PadRight(ColorElement.NumCharsPerElement, ColorElement.CharPadRight));

                    result = BEGIN_LINE + string.Join(SEPARATOR_LINE, sq) + END_LINE;
                }
                else
                    result = BEGIN_LINE + string.Join(SEPARATOR_LINE, _listElements) + END_LINE;
            }
            return result;
        }
    }
}
