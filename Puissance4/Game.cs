using System;
using System.Linq;

namespace Puissance4
{
    internal class Game
    {
        private int lastUser;

        public int[,] Grille { get; set; }
        public Game()
        {
            Rows = 6;
            Columns = 7;
            Grille = new int[6, 7];
            this.Winner = 0;
        }

        public int Rows { get; internal set; }
        public int Columns { get; internal set; }
        public int Winner { get; private set; }

        internal void DropToken(int user, int column)
        {
            CheckNotSamePlayer(user);
            for (int rowIndex = 0; rowIndex < this.Rows; rowIndex++)
            {
                if (Grille[rowIndex, column] == 0)
                {
                    Grille[rowIndex, column] = user;
                    SetLastPlayer(user);
                    break;
                }
            }

            if (IsWinHorizontal())
            {
                this.Winner = 1;
            }
        }

        private bool IsWinHorizontal()
        {
            return Enumerable.Range(0, 4).All(column => Grille[0, column] == 1);
        }
 

        private void SetLastPlayer(int user)
        {
            lastUser = user;
        }

        private void CheckNotSamePlayer(int user)
        {
            if (user == lastUser)
            {
                throw new InvalidOperationException("A player can't play twice");
            }
        }
    }
}