namespace Minesweeper.Models
{
    public class GameBoardModel
    {
		// Board properties
		public int size { get; set; }
		public CellModel[,] grid { get; set; }
		// Percent of live cells of cells that will be live
		public double bombRatio { get; set; }

		public int totalCells { get; set; } = 0;

		// number of live cells
		public int liveCells { get; set; } = 0;
		public int nonLiveCells { get; set; } = 0;
		public bool firstClick { get; set; } = true;

		
        public double[] Difficulty
        {
            get { return new double[] { 0.15d, 0.20d, 0.23d }; }
            private set { }
        }


		//default constructor
		public GameBoardModel()
		{
			this.size = 0;
			this.bombRatio = 0;
			this.grid = new CellModel[0, 0];
		}
		// Contructor that takes in a size and creates the game board with the cells 
		public GameBoardModel(int size)
		{
			this.size = size;
			this.grid = new CellModel[size, size];
			for (int row = 0; row < size; row++)
			{
				for (int col = 0; col < size; col++)
				{
					grid[row, col] = new CellModel();
				}
			}
		}

		// Get diffuculty and size
		public GameBoardModel(int size, double bombRatio)
		{
			this.size = size;
			this.grid = new CellModel[size, size];
			this.bombRatio = bombRatio;
			this.totalCells = size * size;
			firstClick = true;
			for (int row = 0; row < size; row++)
			{
				for (int col = 0; col < size; col++)
				{
					grid[row, col] = new CellModel();
				}
			}
		}

		// Randomly initailize the grid with live bombs based on diffculty
		public void SetupLiveNeighbors()
		{
			// calculate live cells
			liveCells = (int)(bombRatio * totalCells);
			// calculate non live cells
			nonLiveCells = totalCells - liveCells;
			// Random fill the cells
			Random random = new Random();
			for (int i = 0; i < liveCells; i++)
			{
				int randomRow = random.Next(size);
				int randomColumn = random.Next(size);

				// Check if the cell is already live, and if not, set it as live
				if (!grid[randomRow, randomColumn].live)
				{
					grid[randomRow, randomColumn].live = true;
				}
				else
				{
					// If the cell is already live, try again with a different cell
					i--;
				}
			}
		}

		/* This calculates the number of live neightbors 
         * We create two arrays to get the neighbors of the cell and ask of they are live
         * If that neightbot is live it adds to the live nieghbors count
         * There are 8 neighbors to each cell becuase we count the corners and the sides
         * We also skip checking the neighbor if the neighbor is not part of the board. 
         */

		public void CalculateLiveNeighbors()
		{
			// These are the arrays that keep track of the neighbors. For example the -1,-1 would be the top left corner of the current cell we are checking.
			int[] dr = { -1, -1, -1, 0, 0, 1, 1, 1 };
			int[] dc = { -1, 0, 1, -1, 1, -1, 0, 1 };

			for (int row = 0; row < size; row++)
			{
				for (int col = 0; col < size; col++)
				{
					// Variable to keep track of neighbor live count
					int liveNeighborCount = 0;

					for (int i = 0; i < 8; i++)
					{
						// Using the arrays to save the temp of the neight we are checking
						int newRow = row + dr[i];
						int newCol = col + dc[i];

						if (newRow >= 0 && newRow < size && newCol >= 0 && newCol < size && grid[newRow, newCol].live)
						{
							// adds one to the neighbor count if the neightbor is set to live
							liveNeighborCount++;
						}
					}
					// Setting neightbor count to 9 if the cell is live
					if (grid[row, col].live)
					{
						grid[row, col].liveNeighbors = 9;
					}
					else
					{
						// set the temporary count to the cells object live neighbor count
						grid[row, col].liveNeighbors = liveNeighborCount;
					}
				}
			}
		}
		// This is for the flood fill 
		// This will flood to any neightbor that has no bombs touching it and if it does have a bomb as a niehtbor it will
		// not go past that but will show as visited.
		public void FloodFill(int row, int col)
		{
			// Define the eight possible moves (neighbors)
			int[] dx = { 1, -1, 0, 0, 1, 1, -1, -1 };
			int[] dy = { 0, 0, 1, -1, 1, -1, 1, -1 };

			// Mark the current cell as visited
			grid[row, col].visited = true;
			grid[row, col].flagged = false;
			grid[row, col].active = false;
            // Iterate through all eight possible neighbors
            for (int i = 0; i < 8; i++)
			{
				int newRow = row + dx[i];
				int newCol = col + dy[i];

				// Check if the neighbor is within the bounds of the grid
				if (newRow >= 0 && newRow < size && newCol >= 0 && newCol < size)
				{
					// Check the condition and recursively fill if met
					if (!grid[newRow, newCol].visited)
					{
						if (grid[newRow, newCol].liveNeighbors == 0)
						{
                            
                            FloodFill(newRow, newCol);
						}
						// We want the neighbors that have bombs as neightbors to show but we do not want to recusrivly call after that.
						else if (grid[newRow, newCol].live == false)
						{
							grid[newRow, newCol].visited = true;
                            grid[newRow, newCol].active = false;
                        }
					}
				}
			}

		}
	}
}
