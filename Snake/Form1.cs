using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private List<Circle> snake = new List<Circle>();
        private Circle food = new Circle();
        public Form1()
        {
            InitializeComponent();
            //Default Settings
            new GameSettings();

            //Set game speed at start timer
            gameTimer.Interval = 1000 / GameSettings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            //Start new game
            StartGame();
        }

        private void StartGame()
        {
            lblGameOver.Visible = false;
            new GameSettings();

            //create new player object
            snake.Clear();
            Circle head = new Circle { X = 10, Y = 5 };
            snake.Add(head);

            lblScoreValue.Text = GameSettings.Score.ToString();
            GenerateFood();
        }

        //Place random food in game
        private void GenerateFood()
        {
            int maxXPos = pbCanvas.Size.Width / GameSettings.Width;
            int maxYPos = pbCanvas.Size.Height / GameSettings.Height;

            Random randomFood = new Random();
            food = new Circle();
            food.X = randomFood.Next(0, maxXPos);
            food.Y = randomFood.Next(0, maxYPos);
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            //Check if Game Over
            if(GameSettings.Gameover)
            {
                //Check if enter key is pressed
                if(KeyboardInput.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                if(KeyboardInput.KeyPressed(Keys.Right) && GameSettings.Directions != Direction.Left)
                {
                    GameSettings.Directions = Direction.Right;
                }
                else if (KeyboardInput.KeyPressed(Keys.Left) && GameSettings.Directions != Direction.Right)
                {
                    GameSettings.Directions = Direction.Left;
                }
                else if (KeyboardInput.KeyPressed(Keys.Up) && GameSettings.Directions != Direction.Down)
                {
                    GameSettings.Directions = Direction.Up;
                }
                else if (KeyboardInput.KeyPressed(Keys.Down) && GameSettings.Directions != Direction.Up)
                {
                    GameSettings.Directions = Direction.Down;
                }
                MovePlayer();
            }

            pbCanvas.Invalidate();
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            //check if game is not over
            if (!GameSettings.Gameover)
            {
                //Set color of snake
                Brush snakeColor;

                //Define Snake
                for (int i=0; i< snake.Count; i++)
                {
                    if(i==0)
                    {
                        snakeColor = Brushes.Black; //head
                    }
                    else
                    {
                        snakeColor = Brushes.Green; //body
                    }

                    //Draw Snake
                    canvas.FillEllipse(snakeColor,
                        new Rectangle(snake[i].X * GameSettings.Width,
                                      snake[i].Y * GameSettings.Height,
                                      GameSettings.Width, GameSettings.Height));

                    //Draw food
                    canvas.FillEllipse(Brushes.Red,
                        new Rectangle(food.X * GameSettings.Width,
                                      food.Y * GameSettings.Height, GameSettings.Width, GameSettings.Height));
                }
            }
            else
            {
                string gameOver = "Game over \nYour final score is: " + GameSettings.Score + "\nPress Enter to try again";
                lblGameOver.Text = gameOver;
                lblGameOver.Visible = true;
            }
        }

        private void MovePlayer()
        {
            for(int i= snake.Count -1; i>=0; i--)
            {
                //Move head
                if(i == 0)
                {
                    switch (GameSettings.Directions)
                    {
                        case Direction.Right:
                            snake[i].X++;
                            break;
                        case Direction.Left:
                            snake[i].X--;
                            break;
                        case Direction.Up:
                            snake[i].Y--;
                            break;
                        case Direction.Down:
                            snake[i].Y++;break;
                    }

                    //Get max X and Y pos
                    int maxXPos = pbCanvas.Size.Width / GameSettings.Width;
                    int maxYPos = pbCanvas.Size.Height / GameSettings.Height;

                    // Detect collision with game borders
                    if(snake[i].X < 0 || snake[i].Y < 0 || snake[i].X >= maxXPos || snake[i].Y >=maxYPos)
                    {
                        RestInPeace();
                    }

                    //Detect collision with body
                    for (int j=1; j<snake.Count; j++)
                    {
                        if(snake[i].X == snake[j].X && snake[i].Y == snake[j].Y)
                        {
                            RestInPeace();
                        }
                    }

                    //Detect collision with food
                    if (snake[0].X == food.X && snake[0].Y == food.Y)
                    {
                        EatThatShit();
                    }
                }
                else
                {
                    //Move body
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            KeyboardInput.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            KeyboardInput.ChangeState(e.KeyCode, false);
        }

        private void EatThatShit()
        {
            //add circle to body when player eats food
            Circle circle = new Circle
            {
                X = snake[snake.Count - 1].X,
                Y = snake[snake.Count - 1].Y
            };
            snake.Add(circle);

            //update score
            GameSettings.Score += GameSettings.Points;
            lblScoreValue.Text = GameSettings.Score.ToString();

            GenerateFood();
        }

        private void RestInPeace()
        {
            GameSettings.Gameover = true;
        }
    }
}
