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
        LinkedList<Enemy> Enemies { get; set; }

        private int Height { get; set; }
        private int Width { get; set; }

        List<Background> backgrounds;

        public int score { get; set; }
        public bool GameOverStatus;

        private GameOver gameOver;
        public Game(int height, int width)
        {
            Height = height;
            Width = width;
            Player = new Player(Height, Width);
            Enemies = new LinkedList<Enemy>();
            backgrounds = new List<Background>();
            gameOver = new GameOver(height, width);
            GameOverStatus = false;
            score = 0;
        }

        //Game Over
        public void DrawGameOver(Graphics g)
        {
            gameOver.DrawGameOver(g,score);
        }

        //Background
        public void AddBackgroundObject()
        {
            backgrounds.Add(new Background(Width, Height));
        }
        public void DrawBackground(Graphics g)
        {
            foreach(Background b in backgrounds)
            {
                b.DrawBackground(g);
            }
        }

        public void MoveBackground()
        {
            foreach (Background b in backgrounds) b.MoveBackground();
            for (int i = backgrounds.Count - 1; i >= 0; i--)
            {
                if (backgrounds[i].RemoveFlag == true)
                {
                    backgrounds.RemoveAt(i);
                }
            }
        }

      
        //Enemies
        public void CreateEnemies(int Difficulty) {
            for (int i=0; i<Difficulty;i++)
            {
                Enemies.AddLast(new Enemy(Height, Width));
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

            if (Player.Dead == true) GameOverStatus = true;
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
                        System.Diagnostics.Debug.WriteLine("Deleting enemy");
                    }

                    if (e.getHealth() == 0)
                    {
                        e.Draw = false;
                        e.Shoot = false;
                    }
            }
                if (Enemies.Count > 1) {
                    foreach(Enemy e in Enemies.ToList()) 
                    {
                        if (e.Draw == false) Enemies.Remove(e);
                    }
                }
                //for (int i = 0; i <= Enemies.Count - 1; i++)
                //{
                //  if (Enemies[i].Draw == false)
                //{
                //  if (Enemies[i].ammunitions.Count < 1)
                //{
                //  Enemies.Remove(i);
                //score = score + 1;
                //}
                //}
                //}
            }
       
        }
    }
}
