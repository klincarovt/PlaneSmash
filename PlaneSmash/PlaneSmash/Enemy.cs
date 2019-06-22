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

        private static int Speed = 15;
        private int Health { get; set; }

        private static int Radius=70;
      
        private int Height { get; set; }
        private int Width { get; set; }
        private Image Avatar = Properties.Resources.enemyCopter;

        private int moveX { get; set; }
        private int moveY { get; set; }

        public Enemy()
        {
            Random random = new Random();
            Width = 600;
            Height = 500;

            moveY =  random.Next(0, 10);
            moveX =  random.Next(0, 10);

            
            Position = new Point(Width,random.Next(1,Height)); ;
  
        }
        
        public void enemyMove()
        {
            if (Position.X + Radius < Width/2) { moveX = -1 * moveX; }
            if (Position.Y  < 0) { moveY = -1 * moveY; }
            if (Position.X + Radius > Width) { moveX = -1 * moveX; }
            if (Position.Y + Radius > Height) { moveY = -1 * moveY; }
            

            Position = new Point((int)(Position.X + moveX), (int)(Position.Y + moveY));
        }

        public void enemyDraw(Graphics g)
        {
            g.DrawImage(Avatar,Position.X,Position.Y);
        }
        public void setHeight(int h) { Height = h; }
        public void setWidth(int w) { Width = w; }

    }
}
