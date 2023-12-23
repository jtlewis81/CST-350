namespace Minesweeper.Models
{
    public class GameBoardModel
    {
        // Board properties
        public int Size { get; set; }
        public CellModel[,] Grid { get; set; }
        // Percent of Live cells of cells that will be Live
        public double BombRatio { get; set; }

        public int TotalCells { get; set; } = 0;

        // number of Live cells
        public int LiveCells { get; set; } = 0;
        public int NonLiveCells { get; set; } = 0;
        public bool FirstClick { get; set; } = true;

        public double[] Difficulty
        {
            get { return new double[] { 0.15d, 0.20d, 0.23d }; }
            private set { }
        }

        //default constructor
        public GameBoardModel()
        {
            this.Size = 0;
            this.BombRatio = 0;
            this.Grid = new CellModel[0, 0];
        }

        // Constructor that takes in a Size and Difficulty,
        // then creates the game board with the cells
        public GameBoardModel(int size, double bombRatio)
        {
            this.Size = size;
            this.Grid = new CellModel[size, size];
            this.BombRatio = bombRatio;
            this.TotalCells = size * size;
            FirstClick = true;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Grid[row, col] = new CellModel();
                }
            }
        }
    }
}
