﻿namespace GeminiChess
{
    class MatrixIndex
    {
        private int x;
        private int y;

        public MatrixIndex(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

    }
}
