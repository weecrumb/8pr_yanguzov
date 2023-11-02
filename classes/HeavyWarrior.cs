using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8pr_yanguzov.classes
{
    public class HeavyWarrior : Enemy
    {
        public double Armor { get; set; }
        public string Src { get; set; }
        public double Health { get; set; }
        public HeavyWarrior(double health, string name, int level, int score, int money, double damage, int armor, string src)
            : base(health, name, level, score, money, damage, src)
        {
            this.Health = health;
            this.Src = src;
            this.Armor = armor;
        }
        public override double TakeDamage(double PlayerDamage)
        {
            return PlayerDamage /= Armor / 5;
        }
    }
}
