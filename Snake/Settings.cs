using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public enum Directions
    {
        Left,
        Right,
        Up,
        Down,
        None
    };

    public static class myExtensions
    {
        public static bool Between(this int me, int lower, int upper, bool inclusiveLower = true, bool inclusiveUpper = true)
        {
            int l = inclusiveLower ? lower - 1 : lower;
            int u = inclusiveUpper ? upper + 1 : upper;

            if (me > l && me < u) return true;
            return false;
        }
    }



    public class Settings
    {
        public static DataTable dt { get; set; }
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Bonus { get; set; }
        public static int HighScore { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static Directions direction { get; set; }
        public static int CurrentLives { get; set; }
        public static int CurrentLevel { get; set; }
        public static string DisplaySpeed { get; set; }
        public static List<Wall> LevelWalls { get; set; }

        public static string MediaPath {get;set;}

        public Settings()
        {
            dt = new DataTable();
            MediaPath = Directory.GetCurrentDirectory() + "\\";
            Width = 16;
            Height = 16;
            Speed = 10;
            Score = 0;
            Bonus = 500;
            SetHighScore();
            Points = 100;
            GameOver = false;
            direction = Directions.None;
            CurrentLives = 3;
            LevelWalls = new List<Wall>();
        }

        public static void SetLevel(int level, int canvasWidth, int canvasHeight)
        {
            if (level < 1) level = 1;
            if (level > 99) level = 99;

            CurrentLevel = level;
            Points = 100 + (level * 10); 
            //string fileText = File.ReadAllText("C:\\Users\\Screech\\source\\repos\\Snake\\Snake\\testlevel1.txt");
            //fileText = fileText.Replace("\n", "").Replace("\r", "");
            //int ttt = fileText.Length;
            //for (int y = 0; y < canvasHeight; y++)
            //{
            //    for (int x = 0; x < canvasWidth; x++)
            //    {                    
            //        if (fileText[(y*Height) + x] == '1')
            //        {
            //            LevelWalls.Add(new Wall(x, y, System.Drawing.Color.White));
            //        }      
            //        else if (fileText[(y*Height)+x] == '2')
            //        {
            //            LevelWalls.Add(new Wall(x, y, System.Drawing.Color.Green));
            //        }
            //    }
            //}

            switch (level)
            {
                case 1: Speed = 10; break;
                case 2: Speed = 15; break;
                case 3: Speed = 20; break;
                case 4: Speed = 25; break;
                case 5: Speed = 30; break;
                case 6: Speed = 40; break;
                case 7: Speed = 50; break;
                default: Speed = Speed + 15; break;
            }

            DisplaySpeed = Speed.ToString("00");
        }

        public static void SetHighScore()
        {
            if (File.Exists("C:\\Users\\Screech\\source\\repos\\Snake\\Snake\\HighScore.txt"))
            {
                string hs = File.ReadAllText("C:\\Users\\Screech\\source\\repos\\Snake\\Snake\\HighScore.txt");
                HighScore = Convert.ToInt32(hs);
            }
            else
            {
                HighScore = 0;
            }
        }

        public static void SaveHighScore()
        {
            File.WriteAllText("C:\\Users\\Screech\\source\\repos\\Snake\\Snake\\HighScore.txt", Settings.HighScore.ToString());
        }
    }
}
