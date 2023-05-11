using ChessBoardModel;

namespace ChessBoardGUIApp
{
    public partial class Form1 : Form
    {

        static Board myBoard = new Board(8);

        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];

        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }

        private void populateGrid()
        {
            int buttonSize = panel1.Width / myBoard.Size;
            panel1.Height = panel1.Width;

            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j] = new Button();

                    btnGrid[i, j].Height = buttonSize;
                    btnGrid[i, j].Width = buttonSize;

                    btnGrid[i, j].Click += Grid_Button_Click;

                    panel1.Controls.Add(btnGrid[i, j]);

                    btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);

                    btnGrid[i, j].Tag = new Point(i, j);
                }
            }
        }

        private void Grid_Button_Click(object? sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;
            int x = location.X;
            int y = location.Y;

            Cell currentCell = myBoard.theGrid[x, y];


            myBoard.MarkNextLegalMoves(currentCell, comboBox1.Text);

            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].Text = "";
                    btnGrid[i, j].BackColor = Color.White;

                    if (myBoard.theGrid[i, j].LegalNextMove)
                    {
                        btnGrid[i, j].Text = "Legal";
                        btnGrid[i, j].BackColor = Color.LightGreen;

                    }
                    else if (myBoard.theGrid[i, j].CurrentlyOccupied)
                    {
                        btnGrid[i, j].Text = comboBox1.Text;
                        btnGrid[i, j].BackColor = Color.LightSkyBlue;
                    }
                }
            }

        }
    }
}