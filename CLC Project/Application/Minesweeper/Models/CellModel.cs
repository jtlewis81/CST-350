namespace Minesweeper.Models
{
    public class CellModel
    {
		// Cell properties 
		public int row { get; set; } = -1;
		public int column { get; set; } = -1;
		public bool visited { get; set; } = false;
		public bool live { get; set; } = false;
		public int liveNeighbors { get; set; } = 0;
		public bool flagged { get; set; } = false;

		public bool active { get; set; } = true;

		//Default constructor

		public CellModel()
		{
			this.row = -1;
			this.column = -1;
			this.visited = false;
			this.live = false;
			this.liveNeighbors = 0;
			this.flagged = false;
			this.active = true;

		}
		// Contructor that set up all the values
		public CellModel(int row, int column, bool visited, bool live, int liveNeighbors)
		{
			this.row = row;
			this.column = column;
			this.visited = visited;
			this.live = live;
			this.liveNeighbors = liveNeighbors;
		}
	}
}
