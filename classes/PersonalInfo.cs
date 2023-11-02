using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8pr_yanguzov.classes
{
    public class PersonalInfo
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Level { get; set; }
        public int Score { get; set; }
        public int Money { get; set; }
        public double Damage { get; set; }

        public PersonalInfo(string Name, int Health, int Armor, int Level, int Score, int Money, double Damage)
        {
            this.Name = Name;
            this.Health = Health;
            this.Armor = Armor;
            this.Level = Level;
            this.Score = Score;
            this.Money = Money;
            this.Damage = Damage;
        }



    }
}
