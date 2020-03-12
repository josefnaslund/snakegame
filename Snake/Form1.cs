/*
 * Snake game by Josef Näslund
 * Programmed in C# Using Windows Forms
 * Version 0.1 (2020-03-11)
 * 
 */

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
        // ===================
        // data
        // ===================

        // size of building blocks should be a factor of picturebox height and width
        private int block_size = 50;


        // keep track of growing the snake after eating
        bool ate_food = false;

        // exit flag
        bool exit_flag = true;

        // Direcions of snake
        private int dirX = 1; // move right 
        private int dirY = 0;

        // only one (correct) move per tick allowed, else moves are stored in next_ (see below)
        bool not_moved = true;

        // store next directions if user enters quickly
        private bool next_move = false;
        private int next_dirX;
        private int next_dirY;

        // snake components from tail to head at start;
        private int[,] snakeC = new int[3, 2] { { 2, 0 }, { 2, 1 }, { 2, 2 } };

        // Timer
        Timer timer;

        // Count time, updates every tick
        int time = 0;

        // Starting position
        private char[,] gameArr;


        private void gameArrSetup()
        {

            // create new array
            gameArr = new char[pictureBox1.Height / block_size, pictureBox1.Width / block_size];
            //  Console.WriteLine("Length of gameArr: " + gameArr.Length);
            //  Console.WriteLine("GetLength gameArr: " + gameArr.GetLength(0));
            //  Console.WriteLine("GetLength gameArr: " + gameArr.GetLength(1));

            // fill array with 'x'
            for (int i = 0; i != gameArr.GetLength(0); ++i)
            {
                for (int j = 0; j != gameArr.GetLength(1); ++j)
                {
                    // Console.WriteLine("i: " + i + " j: " + j);
                    gameArr[i, j] = 'x';
                }
            }

            // insert starting position
            gameArr[2, 0] = 't';
            gameArr[2, 1] = 'b';
            gameArr[2, 2] = 'h';

            // insert food
            gameArr[gameArr.GetLength(0) - 2, gameArr.GetLength(1) - 2] = 'f';



        }

        private void snakeMove()
        {
            // remove tail from game board
            if (!ate_food)
                gameArr[snakeC[0, 0], snakeC[0, 1]] = 'x';

            // set new tail to game board
            gameArr[snakeC[1, 0], snakeC[1, 1]] = 't';

            // old head becomes body on game board
            gameArr[snakeC[snakeC.GetLength(0) - 1, 0], snakeC[snakeC.GetLength(0) - 1, 1]] = 'b';

            // remove old tail from array
            if (!ate_food)
            {
                for (int i = 0; i != snakeC.GetLength(0) - 1; ++i)
                {
                    snakeC[i, 0] = snakeC[i + 1, 0];
                    snakeC[i, 1] = snakeC[i + 1, 1];
                }
            }

            else
            {
                int[,] new_snakeC = new int[snakeC.GetLength(0) + 1, snakeC.GetLength(1) + 1];
                for (int i = 0; i != snakeC.GetLength(0); ++i)
                {
                    for (int j = 0; j != 2; ++j)
                    {
                        new_snakeC[i, j] = snakeC[i, j];
                    }
                }
                snakeC = new_snakeC;
                ate_food = false;

                new_food();
            }

            // new head is in direction of last head
            int[] new_head = new int[] { snakeC[snakeC.GetLength(0) - 2, 0] + dirY, snakeC[snakeC.GetLength(0) - 2, 1] + dirX };


            // test for valid moves before trying to insert new head
            if (new_head[0] >= 0 && new_head[0] < gameArr.GetLength(0) && new_head[1] >= 0 && new_head[1] < gameArr.GetLength(1))
            {

                // test for food
                if (gameArr[new_head[0], new_head[1]] == 'f')
                {
                    // Console.WriteLine("Ate food");
                    ate_food = true;
                }


                // test for crash into oneself
                else if (gameArr[new_head[0], new_head[1]] == 't' || gameArr[new_head[0], new_head[1]] == 'b')
                {
                    exit_flag = false;

                    timer.Stop();

                    // MessageBox.Show();
                    label_start.Text = "You crashed into yourself. Game over.";
                    label_start.Visible = true;

                    // gameArrSetup();
                    snakeC = new int[3, 2] { { 2, 0 }, { 2, 1 }, { 2, 2 } };

                    dirX = 1;
                    dirY = 0;
                    // time = 0;
                    // label_Time.Text = "0";
                    label_restart.Visible = true;


                }

                if (exit_flag)
                {
                    // insert new head in snake components (snakeC)
                    snakeC[snakeC.GetLength(0) - 1, 0] = new_head[0];
                    snakeC[snakeC.GetLength(0) - 1, 1] = new_head[1];

                    // set new head on board
                    gameArr[snakeC[snakeC.GetLength(0) - 1, 0], snakeC[snakeC.GetLength(0) - 1, 1]] = 'h';
                }

            }

            // snake tries to go outside of game world
            else if (exit_flag)
            {
                exit_flag = false;
                label_start.Text = "You crashed into the wall. Game over.";
                label_start.Visible = true;

                // gameArrSetup();
                snakeC = new int[3, 2] { { 2, 0 }, { 2, 1 }, { 2, 2 } };

                dirX = 1;
                dirY = 0;
                // time = 0;
                // label_Time.Text = "0";
                label_restart.Visible = true;

                timer.Stop();
            }

            if (next_move)
            {
                next_move = false;
                dirX = next_dirX;
                dirY = next_dirY;
            }
        }

        private void new_food()
        {
            bool found_x = false;

            // see if any empty space is available in game board
            foreach (var arr in gameArr)
            {
                foreach (var letter in gameArr)
                {
                    if (letter == 'x')
                    {
                        found_x = true;
                        break;

                    }
                    if (found_x)
                        break;
                }
            }

            if (!found_x)
            {
                MessageBox.Show("Congratulations! You are the master of snake!!!!");
                MessageBox.Show("Remember to print screen! Congratulations! You are the master of snake!!!!");
            }
            else
            {
                Random rnd = new Random();
                bool not_found_empty_random = true;
                while (not_found_empty_random)
                {

                    int r1 = rnd.Next(0, gameArr.GetLength(0));
                    int r2 = rnd.Next(0, gameArr.GetLength(1));
                    if (gameArr[r1, r2] == 'x')
                    {
                        not_found_empty_random = false;
                        gameArr[r1, r2] = 'f';
                    }



                }


            }

        }

        public Form1()
        {
            InitializeComponent();

            gameArrSetup();
            timer = new Timer();
            timer.Interval = 125;
            // timer.Start();
            timer.Tick += Timer_Tick;
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.FillRectangle(Brushes.Black, 0, 0, pictureBox1.Width, pictureBox1.Height);

            // top row
            graphics.FillRectangle(Brushes.DarkGoldenrod, 0, 0, pictureBox1.Width, 2);

            // bottom row
            graphics.FillRectangle(Brushes.DarkGoldenrod, 0, pictureBox1.Height - 2, pictureBox1.Width, 2);

            // left
            graphics.FillRectangle(Brushes.DarkGoldenrod, 0, 0, 2, pictureBox1.Height);

            // right 
            graphics.FillRectangle(Brushes.DarkGoldenrod, pictureBox1.Width - 2, 0, 2, pictureBox1.Height);

            pictureBox1.BackgroundImage = bitmap;

            for (int i = 0; i != gameArr.GetLength(0); ++i)
            {
                for (int j = 0; j != gameArr.GetLength(1); ++j)
                {
                    // Snake head
                    if (gameArr[i, j] == 'h')
                    {
                        graphics.FillEllipse(Brushes.Green, j * block_size, i * block_size, block_size, block_size);
                    }

                    // Snake body
                    else if (gameArr[i, j] == 'b')
                    {
                        graphics.FillEllipse(Brushes.LightGreen, j * block_size, i * block_size, block_size, block_size);
                    }

                    // Tail
                    else if (gameArr[i, j] == 't')
                    {
                        graphics.FillEllipse(Brushes.Turquoise, j * block_size, i * block_size, block_size, block_size);
                    }

                    // Food
                    else if (gameArr[i, j] == 'f')
                    {
                        graphics.FillEllipse(Brushes.Red, j * block_size, i * block_size, (block_size), block_size);
                    }
                }
            }

            var pos1 = this.PointToScreen(label_start.Location);
            pos1 = pictureBox1.PointToClient(pos1);
            label_start.Parent = pictureBox1;
            // label_start.Location = pos1;
            label_start.BackColor = Color.Transparent;

            label_restart.Parent = pictureBox1;
            // label_restart.Location = pos1;
            label_restart.BackColor = Color.Transparent;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (exit_flag)
            {
                not_moved = true;

                ++time;
                if (time % 2 == 0)
                {
                    label_Time.Text = (time / 8).ToString();

                }

                label_Snake_Size.Text = (snakeC.GetLength(0)).ToString();

                Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics graphics = Graphics.FromImage(bitmap);

                graphics.FillRectangle(Brushes.Black, 0, 0, pictureBox1.Width, pictureBox1.Height);

                // top row
                graphics.FillRectangle(Brushes.DarkGoldenrod, 0, 0, pictureBox1.Width, 2);

                // bottom row
                graphics.FillRectangle(Brushes.DarkGoldenrod, 0, pictureBox1.Height - 2, pictureBox1.Width, 2);
                
                // left
                graphics.FillRectangle(Brushes.DarkGoldenrod, 0, 0, 2, pictureBox1.Height);
                
                // right 
                graphics.FillRectangle(Brushes.DarkGoldenrod, pictureBox1.Width - 2, 0, 2, pictureBox1.Height);

                pictureBox1.BackgroundImage = bitmap;

                snakeMove();

                for (int i = 0; i != gameArr.GetLength(0); ++i)
                {
                    for (int j = 0; j != gameArr.GetLength(1); ++j)
                    {
                        // Snake head
                        if (gameArr[i, j] == 'h')
                        {
                            graphics.FillEllipse(Brushes.Green, j * block_size, i * block_size, block_size, block_size);
                        }

                        // Snake body
                        else if (gameArr[i, j] == 'b')
                        {
                            graphics.FillEllipse(Brushes.LightGreen, j * block_size, i * block_size, block_size, block_size);
                        }

                        // Tail
                        else if (gameArr[i, j] == 't')
                        {
                            graphics.FillEllipse(Brushes.Turquoise, j * block_size, i * block_size, block_size, block_size);
                        }

                        // Food
                        else if (gameArr[i, j] == 'f')
                        {
                            graphics.FillEllipse(Brushes.Red, j * block_size, i * block_size, (block_size), block_size);
                        }
                    }
                }
            }
        }

        // Key press
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // make move Down
            if ((e.KeyCode == Keys.J || e.KeyCode == Keys.S || e.KeyCode == Keys.Down) && dirY == 0 && not_moved)
            {
                // Console.WriteLine("Down (" + dirX + "," + dirY + ")");
                dirX = 0;
                dirY = 1;
                not_moved = false;
            }

            // store move Down
            else if ((e.KeyCode == Keys.J || e.KeyCode == Keys.S || e.KeyCode == Keys.Down) && dirY == 0 && !not_moved)
            {
                // Console.WriteLine("Down (" + dirX + "," + dirY + ")");
                next_move = true;
                next_dirX = 0;
                next_dirY = 1;
                not_moved = false;
            }

            // make move Up
            else if ((e.KeyCode == Keys.K || e.KeyCode == Keys.W || e.KeyCode == Keys.Up) && dirY == 0 && not_moved)
            {
                // Console.WriteLine("Up (" + dirX + "," + dirY + ")");
                dirX = 0;
                dirY = -1;
                not_moved = false;
            }

            // store move Up
            else if ((e.KeyCode == Keys.K || e.KeyCode == Keys.W || e.KeyCode == Keys.Up) && dirY == 0 && !not_moved)
            {
                // Console.WriteLine("Up (" + dirX + "," + dirY + ")");
                next_move = true;
                next_dirX = 0;
                next_dirY = -1;
                not_moved = false;
            }

            // make move Left
            else if ((e.KeyCode == Keys.H || e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && dirX == 0 && not_moved)
            {
                // Console.WriteLine("Left (" + dirX + "," + dirY + ")");
                dirX = -1;
                dirY = 0;
                not_moved = false;
            }

            // store move Left
            else if ((e.KeyCode == Keys.H || e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && dirX == 0 && not_moved)
            {
                // Console.WriteLine("Left (" + dirX + "," + dirY + ")");
                next_move = true;
                next_dirX = -1;
                next_dirY = 0;
                not_moved = false;
            }

            // make move Right
            else if ((e.KeyCode == Keys.L || e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && dirX == 0 && not_moved)
            {
                // Console.WriteLine("Right (" + dirX + "," + dirY + ")");
                dirX = 1;
                dirY = 0;
                not_moved = false;
            }

            // store move Right
            else if ((e.KeyCode == Keys.L || e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && dirX == 0 && !not_moved)
            {
                // Console.WriteLine("Right (" + dirX + "," + dirY + ")");
                next_move = true;
                next_dirX = 1;
                next_dirY = 0;
                not_moved = false;
            }

            // Start game on enter
            else if (e.KeyCode == Keys.Enter && label_restart.Visible)
            {
                restart();
            }
        }

        private void restart()
        {

            time = 0;
            label_Time.Text = "0";
            gameArrSetup();
            timer.Start();

            exit_flag = true;

            label_restart.Visible = false;
            label_start.Visible = false;

            dirX = 1;
            dirY = 0;


        }
    }
}
