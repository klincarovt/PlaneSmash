﻿using System;
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
        public Player()
        {
            Position = new Point(50, 50);
            Avatar = Properties.Resources.helicopterPhoto;
            ammunitions = new List<Ammunition>();
            Health = 50;
            ammoLeft = 500;
           
        }

        public void moveLeft(){     if(!(Position.X  < 0))      Position = new Point(Position.X-Speed, Position.Y);}
        public void moveRight(){    if(!(Position.X + Radius * 3 > Width))      Position = new Point(Position.X+Speed, Position.Y);}
        public void moveUp(){       if(!(Position.Y < 0))     Position = new Point(Position.X , Position.Y-Speed);}
        public void moveDown(){     if(!(Position.Y+Radius * 2 > Height))        Position = new Point(Position.X, Position.Y+Speed);}
        public void Shoot() {   if(ammoLeft>0) ammunitions.Add( new Ammunition ( new Point(Position.X+Radius,Position.Y+Radius) ) ); playerAmmo(); }
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

            g.DrawString("Health bar",SystemFonts.IconTitleFont, Brushes.Black, 10, 5);
        
            g.DrawRectangle(Pens.Black, 10, 20, 100, 15);
            g.FillRectangle(Brushes.Green, 10, 20, Health, 15);

            Font font;
            font = new Font(SystemFonts.DefaultFont,FontStyle.Regular);
           

            g.DrawString("Ammo status", SystemFonts.IconTitleFont, Brushes.Black, 5, Height-100);
            g.DrawRectangle(Pens.Black, 5, Height-80, 500, 15);
            g.FillRectangle(Brushes.Red, 5, Height-80, ammoLeft, 15);



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
    }
}