using System;

namespace MySpriteClass
{
    class Map
    {
        private int[,] map = new int[,]{
                    { 1, 1, 1, 1, 1, 1},
                    { 1, 0, 0, 0, 0, 1},
                    { 1, 0, 0, 0, 0, 1},
                    { 1, 0, 0, 0, 0, 1},
                    { 1, 0, 0, 0, 0, 1},
                    {1, 1, 1, 1, 1, 1 }
                                    };

        public int[,] getMap
        {
            get
            {
                return map;
            }
        }
    }
}
