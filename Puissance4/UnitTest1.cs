using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Puissance4
{
    [TestClass]
    public class UnitTest1
    {
        private Game puissance4;

        public UnitTest1()
        {
            puissance4 = new Game();
        }

        [TestMethod]
        public void When_A_Game_Is_Created_Grid_Is_Empty()
        {
            Assert.AreEqual(6, puissance4.Rows);
            Assert.AreEqual(7, puissance4.Columns);

            for (var row = 0; row < 6; row++)
            {
                for (var col = 0; col < 7; col++)
                {
                    Assert.AreEqual(0, puissance4.Grille[row, col]);
                }
            }
        }
        [TestMethod]
        public void When_A_Player_Drops_A_Token_Goes_To_Bottom()
        {
            puissance4.DropToken(1, 5);

            Assert.AreEqual(1, puissance4.Grille[0, 5]);
            Assert.AreEqual(0, puissance4.Grille[0, 4]);
        }

        [TestMethod]
        public void When_A_Player2_Drops_A_Token_Goes_To_Bottom()
        {
            puissance4.DropToken(2, 4);
            Assert.AreEqual(2, puissance4.Grille[0, 4]);
        }
    }
}
