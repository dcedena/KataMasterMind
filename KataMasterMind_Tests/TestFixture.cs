using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using KataMasterMind_Model;
using NUnit.Framework;

namespace KataMasterMind_Tests
{
    [TestFixture]
    public class TestFixture1
    {
        /// <summary>
        /// ENUNCIADO: Misma lógica que => http://www.solveet.com/exercises/Kata-CodeBreaker/14
        /// </summary>

        [Test]
        public void Test_CrearElemento()
        {
            ColorElement e = new ColorElement(ColorElement.eColor.YELLOW);
            Assert.AreEqual(ColorElement.eColor.YELLOW.ToString(), e.Color.ToString());
            Assert.AreEqual(ColorElement.eColor.YELLOW, e.Color);

        }

        [Test]
        public void Test_CrearFilaDeElementos()
        {
            ColorElement e1 = new ColorElement(ColorElement.eColor.BLACK);
            ColorElement e2 = new ColorElement(ColorElement.eColor.GREEN);
            ColorElement e3 = new ColorElement(ColorElement.eColor.ORANGE);
            ColorElement e4 = new ColorElement(ColorElement.eColor.YELLOW);

            RowElements row = new RowElements();
            row.AddElement(e1);
            row.AddElement(e2);
            row.AddElement(e3);
            row.AddElement(e4);

            Assert.AreEqual(4, row.GetElements().Count);
        }

        [Test]
        public void Test_GenerarCodigoSecreto()
        {
            MasterMind mm = new MasterMind();

            mm.GenerateCodeSecret();
            Console.WriteLine(mm.GetCodeSecret().ToString());

            mm.GenerateCodeSecret();
            Console.WriteLine(mm.GetCodeSecret().ToString());

            mm.GenerateCodeSecret();
            Console.WriteLine(mm.GetCodeSecret().ToString());

            mm.GenerateCodeSecret();
            Console.WriteLine(mm.GetCodeSecret().ToString());

            mm.GenerateCodeSecret();
            Console.WriteLine(mm.GetCodeSecret().ToString());
        }

        [Test]
        public void Test_Comparar_01_AttemptWin_XXXX()
        {
            MasterMind mm = new MasterMind();
            mm.SetCodeSecret(RowsDefault.ROW_BRYW);
            string result = mm.GetResultAttempt(RowsDefault.ROW_BRYW);
            Assert.AreEqual(mm.GetResultWin(), result);
        }

        [Test]
        public void Test_Comparar_02_Xii()
        {
            MasterMind mm = new MasterMind();
            mm.SetCodeSecret(RowsDefault.ROW_BRYW);
            string result = mm.GetResultAttempt(RowsDefault.ROW_RYOW);
            Assert.AreEqual(MasterMind.OK_POS + MasterMind.OK_OPOS + MasterMind.OK_OPOS, result);
        }

        [Test]
        public void Test_Comparar_03_Xi()
        {
            MasterMind mm = new MasterMind();
            mm.SetCodeSecret(RowsDefault.ROW_BRYW);
            string result = mm.GetResultAttempt(RowsDefault.ROW_GROB);
            Assert.AreEqual(MasterMind.OK_POS + MasterMind.OK_OPOS, result);
        }

        [Test]
        public void Test_Comparar_04_ii()
        {
            MasterMind mm = new MasterMind();
            mm.SetCodeSecret(RowsDefault.ROW_BRYW);
            string result = mm.GetResultAttempt(RowsDefault.ROW_YWGO);
            Assert.AreEqual(MasterMind.OK_OPOS + MasterMind.OK_OPOS, result);
        }


        [Test]
        public void Test_DibujarTableroEmpty()
        {
            MasterMind mm = new MasterMind();
            mm.DrawBoard();
        }

        [Test]
        public void Test_ComprobarAciertos_Intento_01()
        {
            MasterMind mm = new MasterMind();
            mm.SetCodeSecret(RowsDefault.ROW_BRYW);
            mm.SetAttempt(RowsDefault.ROW_OGVL);
            mm.SetAttempt(RowsDefault.ROW_WVOY);
            mm.SetAttempt(RowsDefault.ROW_GROB);
            mm.SetAttempt(RowsDefault.ROW_OGVW);

            mm.DrawBoard();
        }

        [Test]
        public void Test_ComprobarAciertos_Intento_02_Win()
        {
            MasterMind mm = new MasterMind();
            mm.SetCodeSecret(RowsDefault.ROW_BRYW);
            mm.SetAttempt(RowsDefault.ROW_OGVL);
            mm.SetAttempt(RowsDefault.ROW_WVOY);
            mm.SetAttempt(RowsDefault.ROW_GROB);
            mm.SetAttempt(RowsDefault.ROW_BRYW);

            mm.DrawBoard();
        }

        [Test]
        public void Test_ComprobarAciertos_Intento_03_Lost()
        {
            MasterMind mm = new MasterMind();
            mm.SetCodeSecret(RowsDefault.ROW_BRYW);
            mm.SetAttempt(RowsDefault.ROW_OGVL);
            mm.SetAttempt(RowsDefault.ROW_WVOY);
            mm.SetAttempt(RowsDefault.ROW_RYOW);
            mm.SetAttempt(RowsDefault.ROW_GROB);
            mm.SetAttempt(RowsDefault.ROW_OGVW);

            mm.DrawBoard();
        }
    }
}
