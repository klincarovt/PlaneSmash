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
        private static int Speed = 5;
        private static int Radius = 50;
       
        private int Health { get; set; }
        private int ammoLeft { get; set; }

        private List<Ammunition> ammunitions;
        public Player(int Height,int Width)
        {
            Position = new Point(50, 50);
            Avatar = Properties.Resources.helicopterPhoto;
            ammunitions = new List<Ammunition>();
            Health = 100;
            ammoLeft = 300;
            this.Height = Height;
            this.Width = Width;
           
        }

        public void moveLeft(){     if(!(Position.X  < 0))      Position = new Point(Position.X-Speed, Position.Y);}
        public void moveRight(){    if(!(Position.X + Radius * 3 > Width))      Position = new Point(Position.X+Speed, Position.Y);}
        public void moveUp(){       if(!(Position.Y < 50))     Position = new Point(Position.X , Position.Y-Speed);}
        public void moveDown(){     if(!(Position.Y+Radius * 2 > Height-50))        Position = new Point(Position.X, Position.Y+Speed);}
        public void Shoot() {   if(ammoLeft>0) ammunitions.Add( new Ammunition ( new Point(Position.X+Radius,Position.Y+Radius) ) ); playerAmmo(); }
        public void moveAmmunition() {
            foreach (Ammunition ammo in ammunitions) {
                ammo.playerAmmoMove(Width);
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

            g.DrawString("Health bar",SystemFonts.IconTitleFont, Brushes.Black, 1, 1);
        
            g.DrawRectangle(Pens.Black, 1, 20, 100, 15);
            g.FillRectangle(Brushes.Green, 1, 20, Health, 15);

            Font font;
            font = new Font(SystemFonts.DefaultFont,FontStyle.Regular);
           

            g.DrawString("Ammo status", SystemFonts.IconTitleFont, Brushes.Black, 5, Height-80);
            g.DrawRectangle(Pens.Black, 1, Height-60, 300, 15);
            g.FillRectangle(Brushes.Red, 1, Height-60, ammoLeft, 15);



        }

        public void playerAmmo()
        {
            ammoLeft -= 1;
        }
        public void playerHealth()
        {
            Health -= 10;
        }
        public void setHeight(int h) { Height = h; }
        public void setWidth(int w) { Width = w; }

        //Collision
        public bool isHit(Point p)
        {
            float d = (Position.X - p.X) * (Position.X - p.X) + (Position.Y - p.Y) * (Position.Y - p.Y);
            return d <= Radius * Radius;
        }
    }
}
