using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSmash
{
    class Ammunition
    {
        private Point ammoPosition { get; set; }
        private Image ammoImage;
        private Image ammoImageReversed;
        private static int playerTravelSpeed = 10;
        private static int enemyTravelSpeed = 5;
        private Boolean outOfBound { get; set; }
        public Ammunition(Point p)
        {
            ammoPosition = p;
            ammoImage= Properties.Resources.ammo;
            ammoImageReversed= Properties.Resources.ammoReversed;
      
            outOfBound = false;
        }

        public void playerAmmoMove(int Width) {
            if (ammoPosition.X > Width) outOfBound = true;
            ammoPosition = new Point(ammoPosition.X + playerTravelSpeed, ammoPosition.Y);
        }

       
        public void enemyAmmoMove(int Width)
        {
            if (ammoPosition.X > Width) outOfBound = true;
            ammoPosition = new Point(ammoPosition.X - enemyTravelSpeed, ammoPosition.Y);
        }
        
        public void enemyAmmo(Graphics g)
        {
            g.DrawImage(ammoImageReversed, ammoPosition);
        }
        public void drawAmmo(Graphics g)
        {
            g.DrawImage(ammoImage, ammoPosition);
        }
        public bool getOutOfBound() { return outOfBound; }

        //Test
        public Point getPosition() { return ammoPosition; }
    }
}
