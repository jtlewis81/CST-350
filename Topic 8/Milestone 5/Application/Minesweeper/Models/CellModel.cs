namespace Minesweeper.Models
{
    public class CellModel
    {
        // Cell properties 
        public int Row { get; set; } = -1;
        public int Column { get; set; } = -1;
        public bool Visited { get; set; } = false;
        public bool Live { get; set; } = false;
        public int LiveNeighbors { get; set; } = 0;
        public bool Flagged { get; set; } = false;

        //Default constructor
        public CellModel() { }
        public CellModel(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
        // Contructor that set up all the values
        public CellModel(int row, int column, bool visited, bool live, int liveNeighbors)
        {
            this.Row = row;
            this.Column = column;
            this.Visited = visited;
            this.Live = live;
            this.LiveNeighbors = liveNeighbors;
        }
    }
}
