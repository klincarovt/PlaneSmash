using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSmash
{
    class Game
    {
        private Player Player { get; set; }
        List<Enemy> Enemies { get; set; }
        
        public Game()
        {
            Player = new Player();
            Enemies = new List<Enemy>();
        }

        public void spawnEnemy() { }
        public void drawEnemies() { }
        public void moveEnemies() { }

        public void drawPlayer() { }
        public void movePlayer() { }

    }
}
