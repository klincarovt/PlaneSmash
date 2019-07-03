using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSmash
{
    class GameOver
    {
        public int Height { get; set; }
        public int Width { get; set; }
    
        public GameOver(int h ,int w)
        {
            Height = h;
            Width = w;


        }
        public void DrawGameOver(Graphics g, int score)
        {

            g.DrawString("Game Over", new Font("Arial", 50, FontStyle.Bold),Brushes.Black, ((int)Width / 2)-200, (int)Height / 2-100);
            g.DrawString("Your score: "+score, new Font("Arial", 30, FontStyle.Bold), Brushes.Black, ((int)Width / 2)-150, ((int)Height / 2)+50);
        }
    }
}
