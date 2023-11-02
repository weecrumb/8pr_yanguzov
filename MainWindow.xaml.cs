using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _8pr_yanguzov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public classes.PersonalInfo Player = new classes.PersonalInfo("crumb", 300, 10, 1, 0, 0, 20);
        public List<classes.PersonalInfo> Enemies = new List<classes.PersonalInfo>();
        public List<object> Warrior = classes.Enemy.CollHeroes();

        private int random;

        public MainWindow()
        {
            InitializeComponent();
            UserInfoPlayer();

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            // настройки для таймера
            dispatcherTimer.Tick += AttackPlayer;
            // задём интервал с которым выполняется таймер
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            // запуск таймера
            dispatcherTimer.Start();
            // вызываем метод выбора случайного противника
            SelectEnemy();
        }
        public classes.PersonalInfo Enemy;
        public classes.Enemy Warriors;

        public void UserInfoPlayer()
        {
            // если lvl перса > чем 100* lvl перса
            if (Player.Score > 100 * Player.Level)
            {
                Player.Level++;
                Player.Score = 0;
                Player.Health += 50;
                Player.Damage += 5;
                Player.Armor++;
            }
            playerHealth.Content = "Жизненные показатели: " + Player.Health;
            playerArmor.Content = "Броня: " + Player.Armor;
            playerLevel.Content = "Уровень: " + Player.Level;
            playerScore.Content = "Опыт: " + Player.Score;
            playerMoney.Content = "Монеты: " + Player.Money;
        }

        public void EnemyInfo()
        {

            object f = Warrior[new Random().Next(0, Warrior.Count)];
            classes.Enemy enemyInfo = f as classes.Enemy;
            enemyHealth.Content = "Здоровье: " + Warriors.Health;
            enemyLevel.Content = "Уровень: " + Warriors.Level;
            enemyName.Content = "Имя: " + Warriors.Score;
            if (enemyInfo is classes.HeavyWarrior)
            {
                classes.HeavyWarrior heavyInfo = enemyInfo as classes.HeavyWarrior;
                enemyArmor.Content = "Броня: " + heavyInfo.Armor;
            }
            if (enemyInfo is classes.LightWarrior)
            {
                classes.LightWarrior lightData = enemyInfo as classes.LightWarrior;
                enemyArmor.Content = "Броня: " + lightData.Armor;
            }
        }

        public void SelectEnemy()
        {
            // выб случ индекс противника
            this.random = new Random().Next(0, Warrior.Count);
            object ObjWarrior = Warrior[random];
            classes.Enemy enemyInfo = ObjWarrior as classes.Enemy;
            // создаём экземпляр с данными противника
            Warriors = new classes.Enemy(
                enemyInfo.Name,
                enemyInfo.Health,
                enemyInfo.Level,
                enemyInfo.Score,
                enemyInfo.Money,
                enemyInfo.Damage);
            enemyHealth.Content = "Жизненные показатели: " + Math.Round(Warriors.Health);
            enemyLevel.Content = "Уровень: " + Warriors.Level;
            enemyName.Content = "Имя: " + Warriors.Name;

            if (enemyInfo is classes.HeavyWarrior)
            {
                classes.HeavyWarrior heavyInfo = enemyInfo as classes.HeavyWarrior;
                enemyArmor.Content = "Броня: " + heavyInfo.Armor;
                enemyImg.Source = new BitmapImage(new Uri(heavyInfo.Src, UriKind.Relative));
            }
            if (enemyInfo is classes.LightWarrior)
            {
                classes.LightWarrior lightInfo = enemyInfo as classes.LightWarrior;
                enemyArmor.Content = "Броня: " + lightInfo.Armor;
                enemyImg.Source = new BitmapImage(new Uri(lightInfo.Src, UriKind.Relative));
            }
        }

        private void AttackPlayer(object sender, EventArgs e)
        {
            // наноси урон в процентном соотношении имеющейся броне
            object f = Warrior[random];
            classes.Enemy infoEnemy = f as classes.Enemy;
            Player.Health -= Convert.ToInt32(Warriors.Damage * 100f / (100f - Player.Armor));
            //обновляем характеристики перса
            UserInfoPlayer();
            // добавляем метод окончания игры
            GameOver();
        }

        private void AttackEnemy(object sender, MouseButtonEventArgs e)
        {
            object infoEnemy = Warrior[random];
            classes.Enemy enemyInfo = infoEnemy as classes.Enemy;
            if (enemyInfo is classes.HeavyWarrior)
            {
                classes.HeavyWarrior heavyInfo = enemyInfo as classes.HeavyWarrior;
                Warriors.Health -= Convert.ToInt32(enemyInfo.TakeDamage(Player.Damage));
                enemyArmor.Content = "Броня: " + heavyInfo.Armor;
            }
            if (enemyInfo is classes.LightWarrior)
            {
                classes.LightWarrior lightInfo = enemyInfo as classes.LightWarrior;
                Warriors.Health -= Convert.ToDouble(enemyInfo.TakeDamage(Player.Damage));
                enemyArmor.Content = "Броня: " + lightInfo.Armor;
            }
            if (Warriors.Health <= 0)
            {
                Player.Score += Warriors.Score;
                Player.Money += Warriors.Money;
                UserInfoPlayer();
                SelectEnemy();
            }
            else
            {
                // обновляем UI перса
                enemyHealth.Content = "Жизненные показатели: " + Math.Round(Warriors.Health);
                enemyLevel.Content = "Уровень: " + Warriors.Level;
                enemyName.Content = "Имя: " + Warriors.Name;
            }
            GameOver();
        }

        public void GameOver()
        {
            if (Player.Health <= 0)
            {
                playerHealth.Content = "Жизненные показатели: 0";
                MessageBox.Show("Game over");

                Player.Health = 300;
                Player.Armor = 10;
                Player.Level = 1;
                Player.Score = 0;
                Player.Money = 0;
                Player.Damage = 20;

                UserInfoPlayer();
                SelectEnemy();
            }
        }
    }
}
