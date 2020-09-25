using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game_Of_Life.Models
{
    public class Game
    {
        public List<Cell> Cells { get; set; }

        public Game()
        {
            Cells = new List<Cell>();
        }

        public void AddCell(Point coords, bool alive = false)
        {
            if (Cells.Any(x => x.Coords == coords))
                return;

            var cell = new Cell()
            {
                Coords = coords,
                Alive = alive,
            };

            Cells.Add(cell);
        }

        public void UpdateCell(Point coords, bool alive)
        {
            var cell = Cells.FirstOrDefault(x => x.Coords == coords);
            if (cell == null)
                return;
            cell.Alive = alive;
        }

        public void ToogleCellAlive(Point coords)
        {
            var cell = Cells.FirstOrDefault(x => x.Coords == coords);
            if (cell == null)
                return;
            cell.Alive = !cell.Alive;
        }

        public List<Cell> Check()
        {
            var newCells = new List<Cell>();

            foreach(var c in Cells)
            {
                var shouldLive = c.ShouldBeAlive(this.Cells);
                var newCell = new Cell()
                {
                    Coords = c.Coords,
                    Alive = shouldLive,
                };
                newCells.Add(newCell);
            }

            this.Cells = newCells;

            return this.Cells;
        }

        public void SetCells(List<Cell> cells)
        {
            this.Cells = cells;
        }
    }
}
