using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace KataMasterMind_Model
{
    public class MasterMind
    {
        public const string OK_POS = "X";  // Acierto en misma posición
        public const string OK_OPOS = "i"; // Acierto en otra posición

        /// <summary>
        /// Nº elementos por fila.
        /// </summary>
        public readonly int NumElementPerRow = 4;
        /// <summary>
        /// Nº máximo de intentos.
        /// </summary>
        public readonly int NumMaxAttempts = 5;

        private List<RowElements> _listAttempts = null;

        private RowElements _rowCodeSecret = null;

        public MasterMind()
        {
            this._listAttempts = new List<RowElements>();
        }

        public MasterMind(int numElementPerRow, int numMaxAttempts) : this()
        {
            this.NumElementPerRow = numElementPerRow;
            this.NumMaxAttempts = numMaxAttempts;
        }

        public void GenerateCodeSecret()
        {
            this._rowCodeSecret = new RowElements();
            while (this._rowCodeSecret.GetElements().Count < this.NumElementPerRow)
            {
                ColorElement c = ColorElement.GetElementRandom();
                if(!this._rowCodeSecret.ContainsElement(c))
                    this._rowCodeSecret.AddElement(c);
            }
        }

        public RowElements GetCodeSecret()
        {
            return _rowCodeSecret;
        }

        public void SetCodeSecret(RowElements newRowElements)
        {
            _rowCodeSecret = newRowElements;
        }

        public void SetAttempt(RowElements rowElements)
        {
            ValidateRowElements(rowElements);

            rowElements.Result = GetResultAttempt(rowElements);
            _listAttempts.Add(rowElements);
        }

        private void ValidateRowElements(RowElements rowElements)
        {
            if (rowElements.GetElements().Count != this.NumElementPerRow)
                throw new ArgumentException("El objeto no tiene " + this.NumElementPerRow + " elementos.");

            if (_listAttempts.Count == NumMaxAttempts)
                throw new WarningException("La lista tiene el máximo de intentos (" + NumMaxAttempts + ").");
        }

        /// <summary>
        /// Obtiene una cadena indicando con una 'X' cada acierto de color y posición, y con un '*' cada acierto en otra posición.
        /// </summary>
        /// <param name="rowElements"></param>
        /// <returns></returns>
        public string GetResultAttempt(RowElements rowElements)
        {
            string result = "";

            // Comprobar coincidencia en misma posición.
            result += GetStringResultEqualPosition(rowElements);

            // Comprobar coincidencia en distinta posición.
            result += GetStringResultDistinctPosition(rowElements);

            return result;
        }

        private string GetStringResultEqualPosition(RowElements rowElements)
        {
            string result = "";
            ColorElement cp; // Parameter
            ColorElement cs; // Secret

            for (int i = 0; i < rowElements.GetElements().Count; i++)
            {
                cp = rowElements.GetElements()[i]; // Parameter
                cs = _rowCodeSecret.GetElements()[i]; // Secret

                if (cp.Equals(cs))
                {
                    // Si hay coincidencia de posición.
                    result += OK_POS;
                }
            }
            return result;
        }

        private string GetStringResultDistinctPosition(RowElements rowElements)
        {
            string result = "";
            ColorElement cp; // Parameter
            ColorElement cs; // Secret

            for (int i = 0; i < rowElements.GetElements().Count; i++)
            {
                for (int j = 0; j < _rowCodeSecret.GetElements().Count; j++)
                {
                    if (i != j)
                    {
                        cs = _rowCodeSecret.GetElements()[i]; // Secret
                        cp = rowElements.GetElements()[j]; // Parameter
                        if (cs.Equals(cp))
                        {
                            // Si hay coincidencia en otra posición posición.
                            result += OK_OPOS;
                        }
                    }
                }
            }
            return result;
        }

        public void DrawBoard()
        {
            DrawBoard(false);
        }

        public void DrawBoard(bool drawCodeSecret)
        {
            //DrawHeader(drawCodeSecret);

            DrawHeaderWinOrLost(drawCodeSecret);

            DrawBody();

            DrawFooter();
        }
        
        private void DrawHeader(bool drawCodeSecret)
        {
            if (drawCodeSecret)
            {
                DrawCodeSecret();
                DrawLine();
            }
            else
            {
                if ((_listAttempts.Count > 0) &&
                    ((!IsResultWin(_listAttempts[_listAttempts.Count - 1].Result))) || (IsResultLost()))
                {
                    DrawRowElementsEmpty(true);
                    DrawLine();
                }
            }
        }

        private void DrawHeaderWinOrLost(bool drawCodeSecret)
        {
            if (_listAttempts.Count > 0)
            {
                if (IsResultWin(_listAttempts[_listAttempts.Count - 1].Result))
                {
                    DrawCodeSecret();
                    DrawLine(" => YOU WIN!!");
                }
                else if (IsResultLost())
                {
                    DrawCodeSecret();
                    DrawLine(" => YOU LOST!!");
                }
                else
                {
                    DrawRowElementsEmpty(true);
                    DrawLine();
                }
            }
        }

        private void DrawBody()
        {
            for (int i = NumMaxAttempts; i > 0; i--)
            {
                if (i > this._listAttempts.Count)
                {
                    DrawRowElementsEmpty(false);
                }
                else
                {
                    for (int j = _listAttempts.Count; j > 0; j--)
                    {
                        RowElements row = _listAttempts[j - 1];
                        DrawRowElements(row, true);
                    }
                    break;
                }
            }
        }

        private void DrawFooter()
        {
            DrawLine();
        }

        private void DrawCodeSecret()
        {
            DrawRowElements(_rowCodeSecret);
        }

        private void DrawRowElements(RowElements row)
        {
            DrawRowElements(row, false);
        }

        private void DrawRowElements(RowElements row, bool drawResult)
        {
            string strDraw = row.ToString();

            if (drawResult)
                strDraw += " => " + row.Result;

            Console.WriteLine(strDraw);
        }

        private bool IsResultWin(string result)
        {
            return (result == GetResultWin());
        }

        public string GetResultWin()
        {
            string strAux = "";
            for (int i = 0; i < NumElementPerRow; i++)
                strAux += OK_POS;

            return strAux;
        }
        
        private bool IsResultLost()
        {
            return (this._listAttempts.Count == this.NumMaxAttempts);
        }

        private void DrawLine()
        {
            DrawLine("");
        }

        private void DrawLine(string strResult)
        {
            int count = RowElements.BEGIN_LINE.Length + (NumElementPerRow * ColorElement.NumCharsPerElement) +
                ((NumElementPerRow-1) * RowElements.SEPARATOR_LINE.Length) + RowElements.END_LINE.Length;

            string strAux = "".PadRight(count, '-');

            if (strResult != "")
                strAux += strResult;

            Console.WriteLine(strAux);
        }

        //private void DrawRowElementsEmpty()
        //{
        //    DrawRowElementsEmpty(false);
        //}

        private void DrawRowElementsEmpty(bool withQuestion)
        {
            RowElements row = new RowElements();
            row.SetQuestion = withQuestion;
            for (int i = 0; i < this.NumElementPerRow;i++)
                row.AddElement(new ColorElement(ColorElement.eColor._EMPTY));
            Console.WriteLine(row.ToString());
        }
    }
}
