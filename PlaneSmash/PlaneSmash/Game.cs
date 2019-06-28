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
            for (int i=0; i<Difficulty;i++)
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
        public void setHeight(int h) { Height = h; Player.setHeight(h); foreach (Enemy e in Enemies) { e.setHeight(h); } }
        public void setWidth(int w) { Width = w; Player.setWidth(w); foreach (Enemy e in Enemies) { e.setWidth(w); } }


        //Collisions Player
        public void CheckPlayerCollisions()
        {
            bool hit = false;
            foreach(Enemy e in Enemies)
            {
                foreach (Ammunition a in e.ammunitions)
                {
                    if (Player.PlayerHit(a)==true)
                    {
                        hit = true;
                        a.setShouldNotExist(true);
                    }
                }
            }
            if (hit == true)
            {
                Player.playerHealth();
            }
           
        }

        //Collisions Enemy
        public void CheckEnemiesCollisions()
        {

            foreach (Ammunition a in Player.ammunitions)
            {
                foreach(Enemy e in Enemies)
                {
                    if (e.EnemyHit(a) == true)
                    {
                        e.enemyHealth();
                        a.setShouldNotExist(true);
                    }

                    if (e.getHealth() == 0)
                    {
                        e.Draw = false;
                        e.Shoot = false;
                    }
            }

                for (int i = 0; i <= Enemies.Count - 1; i++)
                {
                    if (Enemies[i].Draw == false)
                    {
                        if (Enemies[i].ammunitions.Count < 1)
                        {
                            Enemies.RemoveAt(i);
                        }
                    }
                }
            }
       
        }
    }
}
