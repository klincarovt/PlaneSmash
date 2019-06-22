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
        private static int travelSpeed = 10;
        private Boolean outOfBound { get; set; }
        public Ammunition(Point p)
        {
            ammoPosition = p;
            ammoImage= Properties.Resources.ammo;
            outOfBound = false;
        }

        public void ammoMove(int Width) {
            if (ammoPosition.X > Width) outOfBound = true;
            ammoPosition = new Point(ammoPosition.X + travelSpeed, ammoPosition.Y);
        }
        public void drawAmmo(Graphics g)
        {
            g.DrawImage(ammoImage, ammoPosition);
        }
        public bool getOutOfBound() { return outOfBound; }

    }
}
