using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSmash
{
    class Game
    {
        private Player Player { get; set; }
        List<Enemy> Enemies { get; set; }

        private int Height { get; set; }
        private int Width { get; set; }
        
        public Game(int height, int width)
        {
            Height = height;
            Width = width;
            Player = new Player(Height,Width);
            Enemies = new List<Enemy>();
        }


        //Enemies
        public void CreateEnemies(int Difficulty) {
            for (int i=Difficulty; i>=0;i--)
            {
                Enemies.Add(new Enemy(Height, Width));
            }
        }
        public void DrawEnemies(Graphics g) {
            foreach(Enemy enemy in Enemies)
            {
                enemy.enemyDraw(g);
            }
        }
        public void MoveEnemies() {
            foreach(Enemy e in Enemies)
            {
                e.enemyMove();
            }
        }
        public void ShootEnemies()
        {
            foreach(Enemy e in Enemies)
            {
                e.enemyShoot();
            }
        }
        public void MoveEnemyAmmunition()
        {
            foreach(Enemy e in Enemies) { e.moveAmmunition(); }
        }

        //Player
        public void DrawPlayer(Graphics g) { Player.DrawPlayer(g);}
        public void MovePlayer(bool left, bool right, bool up, bool down) {
            if (left) Player.moveLeft();
            if (right) Player.moveRight();
            if (down) Player.moveDown();
            if (up) Player.moveUp();
        }
        public void PlayerShoot(bool shoot) {if (shoot) Player.Shoot();}
        public void MovePlayerAmmunition()
        {
            Player.moveAmmunition();
        }

        //Height  or Width changes
        public void setHeight(int h) { Height = h; }
        public void setWidth(int w) { Width = w; }


        //Collisions Player
        public void CheckPlayerCollisions()
        {
            
        }
    }
}
