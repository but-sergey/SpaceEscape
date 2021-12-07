using System;
using System.Collections.Generic;

namespace RollABall
{
    internal sealed class MapController : IController
    {
        public MapCell[,] Map { get; private set; }
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public int GoodBonuses { get; private set; }
        public int BadBonuses { get; private set; }

        private System.Random rand = new System.Random();

        public void GenerateMap(LevelData level)
        {
            this.Rows = level.Rows;
            this.Cols = level.Cols;
            this.GoodBonuses = level.GoodBonuses;
            this.BadBonuses = level.BadBonuses;

            Map = (MapCell[,])Array.CreateInstance(typeof(MapCell), new int[] { Rows, Cols });

            ClearMap();
            RemoveWall();
            GenerateBonuses(GoodBonuses, BonusTypes.Good);
            GenerateBonuses(BadBonuses, BonusTypes.Bad);
        }

        private void ClearMap()
        {
            for (var i = 0; i < Map.GetLength(0); i++)
            {
                for (var j = 0; j < Map.GetLength(1); j++)
                {
                    if ((i % 2 != 0 && j % 2 != 0) && (i < Rows - 1))
                    {
                        Map[i, j].Value = 0;
                    }
                    else
                    {
                        Map[i, j].Value = -1;
                    }
                    Map[i, j].Row = i;
                    Map[i, j].Col = j;
                    Map[i, j].Visited = false;
                }
            }
        }

        private void RemoveWall()
        {
            MapCell current = Map[1, 1];
            current.Visited = true;

            Stack<MapCell> stack = new Stack<MapCell>();

            do
            {
                List<MapCell> cells = new List<MapCell>();

                int row = current.Row;
                int col = current.Col;

                if (row - 1 > 0 && !Map[row - 2, col].Visited) cells.Add(Map[row - 2, col]);
                if (col - 1 > 0 && !Map[row, col - 2].Visited) cells.Add(Map[row, col - 2]);

                if (row < Rows - 3 && !Map[row + 2, col].Visited) cells.Add(Map[row + 2, col]);
                if (col < Cols - 3 && !Map[row, col + 2].Visited) cells.Add(Map[row, col + 2]);

                if (cells.Count > 0)
                {
                    MapCell selected = cells[rand.Next(cells.Count)];
                    RemoveCurrentWall(current, selected);

                    selected.Visited = true;
                    Map[selected.Row, selected.Col].Visited = true;
                    stack.Push(selected);
                    current = selected;
                }
                else
                {
                    current = stack.Pop();
                }

            } while (stack.Count > 0);
        }

        private void RemoveCurrentWall(MapCell current, MapCell selected)
        {
            if (current.Row == selected.Row)
            {
                if (current.Col > selected.Col)
                {
                    Map[current.Row, current.Col - 1].Value = 0;
                }
                else
                {
                    Map[selected.Row, selected.Col - 1].Value = 0;
                }
            }
            else
            {
                if (current.Row > selected.Row)
                {
                    Map[current.Row - 1, current.Col].Value = 0;
                }
                else
                {
                    Map[selected.Row - 1, selected.Col].Value = 0;
                }
            }
        }

        private void GenerateBonuses(int count, BonusTypes type)
        {
            for (var i = 0; i < count; i++)
            {
                var x = rand.Next(Map.GetLength(0));
                var y = rand.Next(Map.GetLength(1));

                if (Map[x, y].Value == 0)
                {
                    Map[x, y].Value = (int)type;
                    continue;
                }
                else
                {
                    var saved_x = x;
                    var saved_y = y;
                    do
                    {
                        y++;
                        if (y >= Map.GetLength(1))
                        {
                            y = 0;
                            x++;
                            if (x >= Map.GetLength(1))
                            {
                                x = 0;
                            }
                        }
                    } while ((Map[x, y].Value != 0) || ((x == saved_x) && (y == saved_y)));

                    if (Map[x, y].Value == 0)
                    {
                        Map[x, y].Value = (int)type;
                    }
                }
            }
        }
    }
}
