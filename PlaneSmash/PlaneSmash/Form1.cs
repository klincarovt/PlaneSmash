using System;
using System.Drawing;
using System.Windows.Forms;

namespace PlaneSmash
{
    public partial class Form1 : Form
    {

        Game Game;

        //Player move booleans
        private bool left;
        private bool right;
        private bool up;
        private bool down;
        private bool shoot;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            Game = new Game(this.Height, this.Width);

            //Player booleans
            right = false;
            down = false;
            up = false;
            left = false;
            shoot = false;


            //Game Start
            Game.CreateEnemies(1);


            //Player timer
            PlayerTimer = new Timer();
            PlayerTimer.Tick += new EventHandler(PlayerTimer_Tick);
            PlayerTimer.Interval = 1;
            PlayerTimer.Start();
            // Due to players shoot speed and waste of ammo we needed to slow down the shooting process
            PlayerShootTimer = new Timer();
            PlayerShootTimer.Tick += new EventHandler(PlayerShootTimer_Tick);
            PlayerShootTimer.Interval = 100;
            PlayerShootTimer.Start();

            //Creating enemies
            CreateEnemiesTimer = new Timer();
            CreateEnemiesTimer.Tick += new EventHandler(CreateEnemiesTimer_Tick);
            CreateEnemiesTimer.Interval = 5000;
            CreateEnemiesTimer.Start();

            //Enemies Shooting
            EnemyShootTimer = new Timer();
            EnemyShootTimer.Tick += new EventHandler(EnemyShootTimer_Tick);
            EnemyShootTimer.Interval = 2000;
            EnemyShootTimer.Start();


            Background = new Timer();
            Background.Tick += new EventHandler(Background_Tick);
            Background.Interval = 700;
            Background.Start();

        }
        //Timers
        private Timer PlayerTimer;
        private Timer PlayerShootTimer;
        private Timer CreateEnemiesTimer;
        private Timer EnemyShootTimer;
        private Timer Background;

        private int Difficulty = 3;


        private void Background_Tick(object sender,EventArgs e)
        {
            Game.AddBackgroundObject();
        }
        private void PlayerTimer_Tick(object sender, EventArgs e)
        {
            Invalidate(true);
            //Player
            Game.MovePlayer(left, right, up, down);
            Game.MovePlayerAmmunition();

            //Enemy
            Game.MoveEnemies();
            Game.MoveEnemyAmmunition();

            Game.setHeight(this.Height);
            Game.setWidth(this.Width);

            Game.MoveBackground();

        }
        private void PlayerShootTimer_Tick(object sender, EventArgs e) { Game.PlayerShoot(shoot); Game.CheckPlayerCollisions(); Game.CheckEnemiesCollisions(); }

        private void CreateEnemiesTimer_Tick(object sender, EventArgs e) { Game.CreateEnemies(Difficulty); Difficulty++; }
        private void EnemyShootTimer_Tick(object sende, EventArgs e) { Game.ShootEnemies(); }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            if (!Game.GameOverStatus)
            {
                e.Graphics.Clear(Color.SkyBlue);
                //Player
                Game.DrawPlayer(e.Graphics);

                //Enemies
                Game.DrawEnemies(e.Graphics);

                Game.DrawBackground(e.Graphics);
            }
            else
            {
                e.Graphics.Clear(Color.Red);
                Game.DrawGameOver(e.Graphics);
                PlayerTimer.Stop();
                PlayerShootTimer.Stop();
                CreateEnemiesTimer.Stop();
                EnemyShootTimer.Stop();
                Background.Stop();

            }   
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { right = true; }
            if (e.KeyCode == Keys.Left) { left = true; }
            if (e.KeyCode == Keys.Up) { up = true; }
            if (e.KeyCode == Keys.Down) { down = true; }
            if (e.KeyCode == Keys.Z) { shoot = true; }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Right) { right = false; }
            if (e.KeyCode == Keys.Left) { left = false; }
            if (e.KeyCode == Keys.Up) { up = false; }
            if (e.KeyCode == Keys.Down) { down = false; }
            if (e.KeyCode == Keys.Z) { shoot = false; }

        }
    }
}
