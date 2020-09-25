using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game_Of_Life.Models
{
    public class Cell
    {
        public bool Alive { get; set; }
        public Point Coords { get; set; }

        public int AliveAround(List<Cell> cells)
        {
            var around = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {

                    if (i == 0 && j == 0)
                        continue;

                    var cell = cells
                        .FirstOrDefault(x => x.Coords.X == this.Coords.X + i && x.Coords.Y == this.Coords.Y + j);
                    if (cell == null)
                        continue;

                    if (cell.Alive)
                        around++;
                }
            }

            return around;
        }
    

        public bool ShouldBeAlive(List<Cell> cells)
        {
            var alive = this.AliveAround(cells);

            if (this.Alive && (alive >= 2 && alive <= 3))
                return true;

            if (!this.Alive && alive == 3)
                return true;

            if (this.Alive && alive > 3)
                return false;

            return false;


        }
    }
}
