using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Puissance4
{
    [TestClass]
    public class UnitTest1
    {
        private Game puissance4;

        public UnitTest1()
        {
            puissance4 = new Game();
            Debug.WriteLine("Init");
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
            int colToken = 5;
            int player = 1;
            puissance4.DropToken(player, colToken);

            TestOnlyBottomOfColumnIsFilledForPlayer(colToken, player);
        }

        private void TestOnlyBottomOfColumnIsFilledForPlayer(int colToken, int player)
        {
            for (var row = 0; row < puissance4.Rows; row++)
            {
                for (var col = 0; col < puissance4.Columns; col++)
                {
                    if (row == 0 && col == colToken)
                    {
                        Assert.AreEqual(player, puissance4.Grille[row, col]);
                    }
                    else
                    {
                        Assert.AreEqual(0, puissance4.Grille[row, col]);
                    }
                }
            }
        }



        [TestMethod]
        public void When_A_Player2_Drops_A_Token_Goes_To_Bottom()
        {
            puissance4.DropToken(user:2, column:4);
            TestOnlyBottomOfColumnIsFilledForPlayer(4, 2);
        }
        [TestMethod]
        public void When_A_Player_Drops_A_Token_It_Stacks_Up()
        {
            const int column = 5;
            const int player = 1;

            puissance4.DropToken(player, column);
            puissance4.DropToken(player, column);

            Assert.AreEqual(player, puissance4.Grille[0, column]);
            Assert.AreEqual(player, puissance4.Grille[1, column]);
            Assert.AreEqual(0, puissance4.Grille[2, column]);
        }
    }
}
