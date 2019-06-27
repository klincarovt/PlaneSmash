using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSmash
{
    class Enemy
    {
        private Point Position { get; set;}

        private static int Speed = 3;
        private int Health { get; set; }

        private static int Radius=70;
      
        private int Height { get; set; }
        private int Width { get; set; }
        private Image Avatar = Properties.Resources.enemyCopter;

        private int moveX { get; set; }
        private int moveY { get; set; }

        List<Ammunition> ammunitions;

        public Enemy(int h,int w)
        {

            Random random = new Random((int) DateTime.Now.Ticks);

            moveY =  random.Next(-Speed, Speed);
            moveX =  random.Next(-Speed, Speed);

            if(moveX==0 && moveY == 0) { moveX = 1;moveY = 1; }

            Height = h;
            Width = w;
            Health = 30;

            //System.Diagnostics.Debug.WriteLine(x + " " + y);
             
            Position = new Point(Width-150,random.Next(1,Height-Radius-50)); ;

            ammunitions = new List<Ammunition>();
  
        }
        
        public void enemyMove()
        {
            if (Position.X + Radius < Width/2) { moveX = -1 * moveX; }
            if (Position.Y  < 50) { moveY = -1 * moveY; }
            if (Position.X + Radius > Width) { moveX = -1 * moveX; }
            if (Position.Y + Radius > Height-50) { moveY = -1 * moveY; }
            

            Position = new Point((int)(Position.X + moveX), (int)(Position.Y + moveY));
        }

        public void enemyShoot()
        {
            ammunitions.Add(new Ammunition(new Point(Position.X,Position.Y+30)));
        }

        public void moveAmmunition()
        {
            foreach (Ammunition ammo in ammunitions)
            {
                ammo.enemyAmmoMove(Width);
            }
            for (int i = ammunitions.Count - 1; i > 0; i--)
            {
                if (ammunitions[i].getOutOfBound()) ammunitions.RemoveAt(i);
            }
        }

        public void enemyDraw(Graphics g)
        {
            g.DrawRectangle(Pens.Black,Position.X+10,Position.Y-5,Health,5);
            g.FillRectangle(Brushes.Red, Position.X+10, Position.Y - 5,Health,5);
            g.DrawImage(Avatar,Position.X,Position.Y);


            foreach (Ammunition a in ammunitions)
            {
                a.enemyAmmo(g);
            }
        }
        public void setHeight(int h) { Height = h; }
        public void setWidth(int w) { Width = w; }

        public void enemyHealth() { Health -= 1; }
        //Test
        public List<Ammunition> GetAmmunition()
        {
            return ammunitions;
        }
    }
}
