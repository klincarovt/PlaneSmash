using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSmash
{
    public class Player
    {
        private Point Position { get; set; }
        private int Height { get; set; }
        private int Width { get; set; }
        private Image Avatar { get; set; }
        private static int Speed = 10;
        private static int Radius = 50;

        private List<Ammunition> ammunitions;
        public Player()
        {
            Position = new Point(50, 50);
            Avatar = Properties.Resources.helicopterPhoto;
            ammunitions = new List<Ammunition>();
           
        }

        public void moveLeft(){     if(!(Position.X  < 0))      Position = new Point(Position.X-Speed, Position.Y);}
        public void moveRight(){    if(!(Position.X + Radius * 3 > Width))      Position = new Point(Position.X+Speed, Position.Y);}
        public void moveUp(){       if(!(Position.Y < 0))     Position = new Point(Position.X , Position.Y-Speed);}
        public void moveDown(){     if(!(Position.Y+Radius * 2 > Height))        Position = new Point(Position.X, Position.Y+Speed);}
        public void Shoot() { ammunitions.Add(new Ammunition(new Point(Position.X+Radius,Position.Y+Radius)));}
        public void moveAmmunition() {
            foreach (Ammunition ammo in ammunitions) {
                ammo.ammoMove(Width);
            }
            for (int i = ammunitions.Count-1; i > 0; i--)
            {
                if (ammunitions[i].getOutOfBound()) ammunitions.RemoveAt(i);
            }
        }

        public void DrawPlayer(Graphics g)
        {
            g.DrawImageUnscaled(Avatar, Position);
            foreach(Ammunition a in ammunitions)
            {
                a.drawAmmo(g);
            }

           
        }

        public void setHeight(int h) { Height = h; }
        public void setWidth(int w) { Width = w; }
    }
}
