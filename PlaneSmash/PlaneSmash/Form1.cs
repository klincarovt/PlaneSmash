using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaneSmash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            p = new Player();

            en = new Enemy(this.Height,this.Width);



            //Original timer
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 10;
            timer.Start();

            //Original timer is too fast for the shooting to look natural
            //So i made this slower timer so the shooting may look good and the player doesnt lose mobility smoothness
            shootTimer = new Timer();
            shootTimer.Tick += new EventHandler(shootTimer_Tick);
            shootTimer.Interval = 100;
            shootTimer.Start();

            //Player booleans to increase smoothness
            right = false;
            down = false;
            up = false;
            left = false;
            shoot = false;
            
        }
        Player p;
        Enemy en;
    
        //Timers
        private Timer timer;
        private Timer shootTimer;

        //Player move booleans
        private bool left;
        private bool right;
        private bool up;
        private bool down;
        private bool shoot;
        private void timer_Tick(object sender,EventArgs e)
        {
            Invalidate(true);
            p.setHeight(this.Height);
            p.setWidth(this.Width);

            en.setHeight(this.Height);
            en.setWidth(this.Width);



          
            en.moveAmmunition();

            
            p.moveAmmunition();

            if (left) p.moveLeft();
            if (right) p.moveRight();
            if (down) p.moveDown();
            if (up) p.moveUp();
           

        }
        private void shootTimer_Tick(object sender, EventArgs e)
        {

            if (shoot) p.Shoot();

            en.enemyShoot();
            en.enemyMove();



        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            p.DrawPlayer(e.Graphics);

            en.enemyDraw(e.Graphics);
          

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
