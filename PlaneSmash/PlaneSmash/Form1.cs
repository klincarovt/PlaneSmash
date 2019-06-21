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
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 30;
            timer.Start();
            
        }
        Player p;
        private Timer timer;

        private void timer_Tick(object sender,EventArgs e)
        {
            Invalidate(true);
            p.setHeight(this.Height);
            p.setWidth(this.Width);
            p.moveAmmunition();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            p.DrawPlayer(e.Graphics);
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { p.moveRight(); }
            if (e.KeyCode == Keys.Left) { p.moveLeft(); }
            if (e.KeyCode == Keys.Up) { p.moveUp(); }
            if (e.KeyCode == Keys.Down) { p.moveDown(); }
            if (e.KeyCode == Keys.Z) { p.Shoot(); }
        }
    }
}
