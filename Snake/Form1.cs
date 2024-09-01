using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private List<Food> Food = new List<Food>();
        private List<Wall> Walls = new List<Wall>();

        private Utility.MusicPlayer musicPlayer;
        private Utility.SoundPlayer soundPlayer;

        private Random rnd; 

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            rnd = new Random();

            lblMusicCredit1.Text = "\"Galactic Rap\" Kevin MacLeod (incompetech.com)\r\nLicensed under Creative Commons: By Attribution 4.0 License\r\nhttp://creativecommons.org/licenses/by/4.0/\r\n\r\n" +
                "\"Late Night Radio\" Kevin MacLeod (incompetech.com)\r\nLicensed under Creative Commons: By Attribution 4.0 License\r\nhttp://creativecommons.org/licenses/by/4.0/";

            musicPlayer = new Utility.MusicPlayer(new WaveOut());
            soundPlayer = new Utility.SoundPlayer(new WaveOut());

            musicPlayer.PlayMusic(Settings.MediaPath + "Late Night Radio.mp3");

            new Settings(); // linking the Settings Class to this Form

            dspCanvasHeightP.Text = pbCanvas.Height.ToString() + "px";
            dspCanvasWidthP.Text = pbCanvas.Width.ToString() + "px";

            dspCanvasHeightU.Text = (pbCanvas.Height / Settings.Height).ToString();
            dspCanvasWidthU.Text = (pbCanvas.Width / Settings.Width).ToString();

            gameTimer.Interval = 1000 / Settings.Speed; // Changing the game time to settings speed
            gameTimer.Tick += updateSreen; // linking a updateScreen function to the timer
            gameTimer.Start(); // starting the timer
            startGame(); // running the start game function
        }

        /// <summary>
        /// the key down event will trigger the change state from the Input class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyIsDown(object sender, KeyEventArgs e) => Input.changeState(e.KeyCode, true);

        /// <summary>
        /// the key up event will trigger the change state from the Input class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyIsUp(object sender, KeyEventArgs e) => Input.changeState(e.KeyCode, false);

        private void updateGraphics(object sender, PaintEventArgs e)
        {
            // this is where we will see the snake and its parts moving
            Graphics canvas = e.Graphics; // create a new graphics class called canvas
            if (Settings.GameOver == false)
            {
                // if the game is not over then we do the following

                Brush snakeColour; // create a new brush called snake colour

                // run a loop to check the snake parts
                for (int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0)
                    {
                        // colour the head of the snake white
                        snakeColour = Brushes.YellowGreen;
                    }
                    else
                    {
                        // the rest of the body can be green
                        snakeColour = Brushes.Green;
                    }

                    //draw snake body and head
                    if (i == 0)
                    {
                        canvas.FillEllipse(snakeColour,
                                            new Rectangle(
                                                Snake[i].X * Settings.Width,
                                                Snake[i].Y * Settings.Height,
                                                Settings.Width, Settings.Height
                                                ));
                    }
                    else
                    {
                        canvas.FillRectangle(snakeColour, new Rectangle(Snake[i].X * Settings.Width,
                            Snake[i].Y * Settings.Height,
                            Settings.Width, Settings.Height));
                    }
                }

                // draw walls
                int rowWidth = (pbCanvas.MaximumSize.Width / Settings.Width);
                int colHeight = (pbCanvas.MaximumSize.Height / Settings.Height);

                foreach (Wall wall in Walls)
                {
                    if (wall.Color == Color.White)
                    {

                        canvas.FillRectangle(Brushes.White,
                            new Rectangle(
                                wall.X * Settings.Width,
                                wall.Y * Settings.Height,
                                Settings.Width, Settings.Height));
                    }
                    else
                    {
                        canvas.FillRectangle(Brushes.Green,
                            new Rectangle(
                                wall.X * Settings.Width,
                                wall.Y * Settings.Height,
                                Settings.Width, Settings.Height));
                    }

                }

                // draw food
                foreach (Food food in Food.Where(x => !x.isEaten))
                { 
                    canvas.FillEllipse(Brushes.Red,
                                        new Rectangle(
                                            food.X * Settings.Width,
                                            food.Y * Settings.Height,
                                            Settings.Width, Settings.Height
                                            ));
                }
            }
            else
            {
                // this part will run when the game is over
                // it will show the game over text and make the label 3 visible on the screen
                lblGameOverMessage.Text = "GAME OVER\n\nPRESS [ENTER] TO PLAY";
                lblGameOverMessage.Visible = true;
            }
        }

        private void startGame()
        {
            // this is the start game function
            lblGameOverMessage.Visible = false; 

            Settings.SetLevel(1, (pbCanvas.Width/Settings.Width), (pbCanvas.Height/Settings.Height));
            Settings.GameOver = false;
            Settings.Score = 0;
            dspScore.Text = Settings.Score.ToString("00000");
            dspScore.ForeColor = Color.Black;
            Settings.CurrentLives = 5;
            dspLevel.Text = Settings.CurrentLevel.ToString("00");
            dspSpeed.Text = Settings.DisplaySpeed;
            Settings.SetHighScore();
            dspHighScore.Text = Settings.HighScore.ToString("00000");

            dspLives.Text = "";
            for (int i = 0; i < Settings.CurrentLives; i++)
            {
                dspLives.Text += '\u2764';
            }

            dspHighScore.ForeColor = Color.Black;

            Snake.Clear(); // clear all snake parts
            Circle head = new Circle { X = 0, Y = 0 }; // create a new head for the snake
            Snake.Add(head); // add the gead to the snake array
            lblGameOverMessage.Text = Settings.Score.ToString("00000"); // show the score to the label 2
            
            generateFood(Settings.CurrentLevel); // run the generate food function
            generateWalls(Settings.CurrentLevel);
        }

        private void resetField(bool resetSnake = true)
        {
            if (resetSnake)
            {
                Snake.Clear();
                Circle head = new Circle { X = 10, Y = 5 };
                Snake.Add(head);
            }
           
            Settings.direction = Directions.None;
        }

        private void loseLife()
        {
            int currentLives = dspLives.Text.Length;
            currentLives--;            
            if (currentLives < 1) die();

            dspLives.Text = "";
            for (int i = 0; i < currentLives; i++)
            {
                dspLives.Text += '\u2764';
            }
            
            soundPlayer.PlaySoundFX(Settings.MediaPath + "Death.mp3");
           
            resetField();
        }

        private void movePlayer()
        {
            // the main loop for the snake head and parts
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                // if the snake head is active 
                if (i == 0)
                {
                    // move rest of the body according to which way the head is moving
                    switch (Settings.direction)
                    {
                        case Directions.Right:
                            Snake[i].X++;
                            break;
                        case Directions.Left:
                            Snake[i].X--;
                            break;
                        case Directions.Up:
                            Snake[i].Y--;
                            break;
                        case Directions.Down:
                            Snake[i].Y++;
                            break;
                        case Directions.None: break;
                    }

                    // restrict the snake from leaving the canvas
                    int maxXpos = pbCanvas.Size.Width / Settings.Width;
                    int maxYpos = pbCanvas.Size.Height / Settings.Height;
                    if (
                        Snake[i].X < 0 || Snake[i].Y < 0 ||
                        Snake[i].X > maxXpos || Snake[i].Y > maxYpos
                        )
                    {
                        // end the game is snake either reaches edge of the canvas
                        loseLife();
                    }

                    if (Walls.Any(x => x.X == Snake[i].X && x.Y == Snake[i].Y)) loseLife();

                    // detect collision with the body
                    // this loop will check if the snake had an collision with other body parts
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y) loseLife();
                    }

                    // detect collision between snake head and food
                    for (int f = 0; f < Food.Count; f++)
                    {
                        if (Snake[0].X == Food[f].X && Snake[0].Y == Food[f].Y
                            && !Food[f].isEaten) eat(f);
                    }
                }
                else
                {
                    // if there are no collisions then we continue moving the snake and its parts
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        private void generateWalls(int currentLevel)
        {
            int maxXpos = pbCanvas.Size.Width / Settings.Width;
            // create a maximum X position int with half the size of the play area
            int maxYpos = pbCanvas.Size.Height / Settings.Height;
            // create a maximum Y position int with half the size of the play area

            rnd = new Random();
            int totalWalls = currentLevel + rnd.Next(0,currentLevel);
            int priorFood = Walls.Count;                       

            Walls = new List<Wall>();
            for (int i = 0; i < (2 * currentLevel+1); i++)
            {
                int posX = 0;
                int posY = 0;
                int len = 0;
                bool isHorizontal = true;

                do
                {
                    
                    posX = rnd.Next(1, maxXpos);
                    posY = rnd.Next(1, maxYpos);
                    len = rnd.Next(1, 6);
                    isHorizontal = rnd.Next(0,2) == 0 ? true : false;

                } while (isConflict(posX, posY, len, isHorizontal));
                
                for (int v = 0; v < len; v++)
                {
                    if (isHorizontal)
                    {
                        Walls.Add(new Wall(posX + v, posY, Color.White));
                    }
                    else
                    {
                        Walls.Add(new Wall(posX, posY + v, Color.White));
                    }
                }                
            }
        }

        private void generateFood(int currentLevel)
        {
            int maxXpos = pbCanvas.Size.Width / Settings.Width;
            // create a maximum X position int with half the size of the play area
            int maxYpos = pbCanvas.Size.Height / Settings.Height;
            // create a maximum Y position int with half the size of the play area

            int totalFood = 5;
            int priorFood = Food.Count;

            if (currentLevel < 11) totalFood = currentLevel;
            if (currentLevel.Between(11, 20)) totalFood = (currentLevel * 2 - priorFood);
            if (currentLevel.Between(21, 35)) totalFood = (currentLevel * 2 - (priorFood / 2));
            if (currentLevel.Between(36, 75)) totalFood = 99;

            Food = new List<Food>();
            for (int i = 0; i < (2 * currentLevel); i++)
            {
                int posX = 0;
                int posY = 0;

                do
                {
                    posX = rnd.Next(0, maxXpos);
                    posY = rnd.Next(0, maxYpos);
                } while (isConflict(posX, posY));

                Food.Add(new Food { X = rnd.Next(0, maxXpos), Y = rnd.Next(0, maxYpos), isEaten = false });
            }
        }

        private bool isConflict(int X, int Y, int length = 0, bool isHorizontal = true)
        {
            if (Food.Any(x => x.X == X && x.Y == Y && !x.isEaten)) return true;
            if (Snake.Any(x => x.X == X && x.Y == Y)) return true;            
            if (Walls.Any(x => x.X == X && x.Y == Y)) return true;

            if (isHorizontal && length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    if (isConflict(X + i, Y)) return true;
                }
            }

            if (!isHorizontal && length > 0)
            {
                for (int i =0; i < length; i++)
                {
                    if (isConflict(X, Y + i)) return true;
                }
            }

            return false;
        }

        private void eat(int foodIndex)
        {
            // add a part to body
            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };

            // sound effect
            soundPlayer.PlaySoundFX(Settings.MediaPath + "wacka.mp3");

            Snake.Add(body); // add the part to the snakes array
            Settings.Score += Settings.Points; // increase the score for the game
            if (Settings.Score > Settings.HighScore)
            {
                Settings.HighScore = Settings.Score;
                dspHighScore.Text = Settings.HighScore.ToString("00000");
                dspScore.ForeColor = Color.Green;
                dspHighScore.ForeColor = Color.Green;
            }
            dspScore.Text = Settings.Score.ToString("00000"); // show the score on the label 2

            Food[foodIndex].isEaten = true;
            if (!Food.Any(x => !x.isEaten))
            {
                soundPlayer.PlaySoundFX(Settings.MediaPath + "Coins2.mp3");
                Settings.SetLevel(Settings.CurrentLevel + 1, (pbCanvas.Width / Settings.Width), (pbCanvas.Height / Settings.Height));
                
                generateFood(Settings.CurrentLevel);
                generateWalls(Settings.CurrentLevel);
            }
                    
        }

        private void die()
        {
            Settings.SaveHighScore();            
            Settings.GameOver = true;
        }

        private void updateSreen(object sender, EventArgs e)
        {
            // this is the Timers update screen function. 
            // each tick will run this function
            if (Settings.GameOver == true)
            {
                // if the game over is true and player presses enter
                // we run the start game function
                if (Input.KeyPress(Keys.Enter))
                {
                    startGame();
                }
            }
            else
            {
                //if the game is not over then the following commands will be executed
                // below the actions will probe the keys being presse by the player
                // and move the accordingly
                               

                if (Input.KeyPress(Keys.Right) && Settings.direction != Directions.Left)
                {
                    Settings.direction = Directions.Right;
                }
                else if (Input.KeyPress(Keys.Left) && Settings.direction != Directions.Right)
                {
                    Settings.direction = Directions.Left;
                }
                else if (Input.KeyPress(Keys.Up) && Settings.direction != Directions.Down)
                {
                    Settings.direction = Directions.Up;
                }
                else if (Input.KeyPress(Keys.Down) && Settings.direction != Directions.Up)
                {
                    Settings.direction = Directions.Down;
                }

                movePlayer(); // run move player function
                
            }
            dspLevel.Text = Settings.CurrentLevel.ToString("00");
            dspSpeed.Text = Settings.DisplaySpeed;
            pbCanvas.Invalidate(); // refresh the picture box and update the graphics on it
        }
       
        private void buildLevel(int level)
        {           
            Settings.SetLevel(level, (pbCanvas.Width / Settings.Width), (pbCanvas.Height / Settings.Height));            
        }
    }
}
