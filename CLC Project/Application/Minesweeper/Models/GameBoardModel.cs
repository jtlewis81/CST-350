namespace Minesweeper.Models
{
    public class GameBoardModel
    {
        public int Size { get; set; }
        public CellModel[,] Grid { get; set; }
        public double[] Difficulty
        {
            get { return new double[] { 0.15d, 0.20d, 0.23d }; }
            private set { }
        }

        // Constructor initializes a grid of cells, assigning their row and col property values. 
        public GameBoardModel(int size)
        {
            Size = size;
            Grid = new CellModel[size, size];
            for (int a = 0; a < size; a++)
            {
                for (int b = 0; b < size; b++)
                {
                    CellModel cell = new CellModel();
                    Grid[a, b] = cell;
                    Grid[a, b].Row = a;
                    Grid[a, b].Col = b;
                }
            }
        }
    }
}
