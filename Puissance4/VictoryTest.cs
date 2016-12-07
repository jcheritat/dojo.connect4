using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4
{
    [TestClass]
    public class VictoryTest
    {
        private Game puissance4;

        public VictoryTest()
        {
            puissance4 = new Game();
        }

        [TestMethod]
        public void When_Debut_Pas_De_Winner()
        {
            Assert.AreEqual(0, puissance4.Winner);
        }

        [TestMethod]
        public void When_Joue_Horizontal_Joueur_Gagne()
        {
            var joueur1 = 1;
            var joueur2 = 2;
            puissance4.DropToken(joueur1, 0);
            puissance4.DropToken(joueur2, 0);
            puissance4.DropToken(joueur1, 1);
            puissance4.DropToken(joueur2, 1);
            puissance4.DropToken(joueur1, 2);
            puissance4.DropToken(joueur2, 2);
            puissance4.DropToken(joueur1, 3);
            Assert.AreEqual(joueur1, puissance4.Winner);
        }

        [TestMethod]
        public void When_Play_For_First_Time_No_Winner()
        {
            var joueur1 = 1;
            puissance4.DropToken(joueur1, 0);

            Assert.AreEqual(0, puissance4.Winner);
        }


    }
}
