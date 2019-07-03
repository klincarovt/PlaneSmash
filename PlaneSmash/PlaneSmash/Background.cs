using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSmash
{
    class Background
    {
        public Point CloudPosition { get; set; }
        public Point BuildingPosition { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }

        public Image Cloud;
        public Image Building;

        public bool RemoveFlag { get; set; }

        public Background(int w,int h)
        {
            Height = h;
            Width = w;

            CloudPosition = new Point(Width, 30);
            BuildingPosition = new Point(Width, Height-200);

            Cloud = Properties.Resources.Cloud;
            Building = Properties.Resources.Tree;

            RemoveFlag = false;
        }


        public void DrawBackground(Graphics g)
        {
            g.DrawImage(Cloud, CloudPosition);
            g.DrawImage(Building, BuildingPosition);
        }

        public void MoveBackground()
        {
            if(CloudPosition.X+400 < 0 || BuildingPosition.X+400 < 0)
            {
                RemoveFlag = true;
            }
            CloudPosition = new Point(CloudPosition.X - 10,CloudPosition.Y);
            BuildingPosition = new Point(BuildingPosition.X - 10, BuildingPosition.Y);

        }
    }
    
}
