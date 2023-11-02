using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8pr_yanguzov.classes
{
    public class Enemy
    {
        public double Health { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Score { get; set; }
        public int Money { get; set; }
        public double Damage { get; set; }
        public string Img = "";

        public Enemy(string name, double health, int level, int score, int money, double damage)
        {
            Name = name;
            Health = health;
            Level = level;
            Score = score;
            Money = money;
            Damage = damage;
        }

        public Enemy(double Health, string Name, int Level, int Score, int Money, double Damage, string Img)
        {
            this.Health = Health;
            this.Name = Name;
            this.Level = Level;
            this.Score = Score;
            this.Money = Money;
            this.Damage = Damage;
            this.Img = Img;
        }

       

        public static List<object> CollHeroes()
        {

            List<object> list = new List<object>();
            list.Add(new HeavyWarrior(100, "Воин в тяжёлых доспехах", 20, 30, 72, 24, 20, "/8pr_yanguzov;component/img/HeavyWarrior.png"));
            list.Add(new LightWarrior(100, "Воин в лёгких доспехах", 13, 27, 50, 34, 20, "/8pr_yanguzov;component/img/lightWarrior.png"));
            return list;
        }
        public virtual double TakeDamage(double PlayerDamage)
        {
            return PlayerDamage;
        }
    }
}
