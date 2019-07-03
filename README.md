# PlaneSmash

Трајче Клинчаров 163212, Емилија Мечкарова - 161055, Наталија Маркоска- 161077.

-Идејата за апликацијата која што ја изработивме ја добивме од играта Apache Overkill.

-Линк до играта: https://www.miniclip.com/games/apache-overkill/en/ 

-Целта на играта е што подолго да останеш во живот и што повеќе се убијат противници.

*Играта е составена од 3 Windows Forms форми.
Првата форма (MenuForm) се состои од логото на играта и од три копчиња. Првото копче означува не води кон главната форма на играта, т.е старт на играта. Второто копче е копчето за инструкции,а третото за излез од играта.

![alt_text]

*Втората форма се добива при клик на копчето за инстуркции. Таа форма ни го прикажува начинот на кој може да се игра играта.
![alt_text] 

*Додека пак третата форма, е всушност формата во која се почнува со играта. 
Правила на оваа игра е прежувањето на еден хеликоптер кој е постојано нападнат од противници. Со убивање на противници остваруваат поени. Противниците се појавуваат на одредено време и напаѓаат. Крајот на играта е кога играчот ќе биде убиен.

![alt_text] 




-За играње на играта се користат стрелките за лево, десно, горе и долу, со кои се движи играчот(хеликоптерот), додека пак за пукање се користи копчето Z, при што се пука по еден проектил. 



-За изработка на играта имплементирани се класи за муницијата, позадината на играта, противникот, играчот, текот на играта и крајот на играта. Секоја од класите е имплементирана според барањата за играта. 
*Како пример ќе ја издовиме класата за противникот(Enemy) . Во неа се чуваат информации за противникот, неговата позицијата при појавувањето, брзината на движење и патеката на движење на противниците. Во истата класа имплеменитрани се и методи за пукањето (enemyShoot) и патеката на движење на муницијата(moveAmmunition) испукана од притивниците.


    class Enemy
    {
        private Point Position { get; set;}

        private static int Speed = 3;
        private int Health { get; set; }

        private static int Radius=45;
      
        private int Height { get; set; }
        private int Width { get; set; }
        private Image Avatar = Properties.Resources.enemyCopterpng;

        private int moveX { get; set; }
        private int moveY { get; set; }

        public bool Shoot { get; set; }
        public bool Draw { get; set; }

        public List<Ammunition> ammunitions;

        public Enemy(int h,int w)
        {

            Random random = new Random((int) DateTime.Now.Ticks);

            moveY =  random.Next(-Speed, Speed);
            moveX =  random.Next(-Speed, Speed);

            if(moveX==0 && moveY == 0) { moveX = 1;moveY = 1; }

            Height = h;
            Width = w;
            Health = 30;

            //System.Diagnostics.Debug.WriteLine(x + " " + y);
             
            Position = new Point(Width-150,random.Next(50+Radius,Height-Radius-150)); ;

            ammunitions = new List<Ammunition>();

            Shoot = true;
            Draw = true;
  
        }
        
        public void enemyMove()
        {
            if (Position.X + Radius < Width/2) { moveX = -1 * moveX; }
            if (Position.Y  < 100) { moveY = -1 * moveY; }
            if (Position.X + Radius > Width) { moveX = -1 * moveX; }
            if (Position.Y + Radius > Height-150) { moveY = -1 * moveY; }

            if (Draw == true)
            {
                Position = new Point((int)(Position.X + moveX), (int)(Position.Y + moveY));
            }
            else
            {
                Position = new Point(2000, 2000);
            }

        }

        public void enemyShoot()
        {
            if (Shoot == true)
            ammunitions.Add(new Ammunition(new Point(Position.X,Position.Y+30)));
        }

        public void moveAmmunition()
        {
            foreach (Ammunition ammo in ammunitions)
            {
                ammo.enemyAmmoMove(Width);
            }
            for (int i = ammunitions.Count - 1; i > 0; i--)
            {
                if (ammunitions[i].getShouldNotExist()==true) ammunitions.RemoveAt(i); 

            }
        }

        public void enemyDraw(Graphics g)
        {
            if (Draw == true)
            {
                g.DrawRectangle(Pens.Black, Position.X + 10, Position.Y - 5, Health, 5);
                g.FillRectangle(Brushes.Red, Position.X + 10, Position.Y - 5, Health, 5);
                g.DrawImage(Avatar, Position.X, Position.Y);
            }
           
            foreach (Ammunition a in ammunitions)
            {
                a.enemyAmmo(g);
            }
        }
        public void setHeight(int h) { Height = h; }
        public void setWidth(int w) { Width = w; }

        public void enemyHealth() { Health -= 10; }

        public int getHealth() { return Health; }

        public bool EnemyHit(Ammunition a)
        {
            float d = (Position.X - a.getPosition().X) * (Position.X - a.getPosition().X) + (Position.Y - a.getPosition().Y) * (Position.Y - a.getPosition().Y);
            return d <= Radius * Radius;
        }
    }







