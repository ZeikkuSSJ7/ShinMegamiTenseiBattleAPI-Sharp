using System;

namespace SMTBattle.Fight {
    public class Enemy {
        private string name;
        private int maxHP;
        private int attack;
        private int defense;
        private int xpBase;
        public Enemy(string name, int maxHP, int attack, int defense, int xpBase) {
            this.name = name;
            this.maxHP = maxHP;
            this.attack = attack;
            this.defense = defense;
            this.xpBase = xpBase;
        }
        public bool Fight(Player enemy) {
            Console.WriteLine(name + " attacks!");
            if (Program.ran.Next(100) + 1 > 5){
                int lifeLost = (int)((attack + Program.ran.Next(1))/(enemy.GetDefense()/2));
                Console.WriteLine(enemy.GetName() + " lost " + lifeLost + "HP!");
                enemy.SetCurrentHP(enemy.GetCurrentHP() - lifeLost);
            } else {
                Console.WriteLine(name  + "'s attack missed!");
            }
            return true;
        }
        /**
         * @return the defense
         */
        public int GetDefense() {
            return defense;
        }
        /**
         * @return the maxHP
         */
        public int GetMaxHP() {
            return maxHP;
        }
        /**
         * @return the name
         */
        public string GetName() {
            return name;
        }
        /**
         * @param maxHP the maxHP to set
         */
        public void SetMaxHP(int maxHP) {
            this.maxHP = maxHP;
        }
        /**
         * @return the xpBase
         */
        public int GetXpBase() {
            return xpBase;
        }
    }
}