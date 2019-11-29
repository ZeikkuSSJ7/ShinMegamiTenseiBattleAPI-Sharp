using System;
using SMTBattle.Magics;
using SMTBattle.Items;

namespace SMTBattle.Fight {
    public class Player{
        private string name;
        private int level;
        private int maxHP;
        private int currentHP;
        private int maxMP;
        private int currentMP;
        private int attack;
        private int defense;
        private int exp;
        private int expNeeded;
        private Magic[] magic;
        private Item[] items;
        private string[] invokes = {"Soul Slayer"};
        public Player(string name, int maxHP, int maxMP, Magic[] magic, Item[] items) {
            this.name = name;
            level = 1;
            this.maxHP = maxHP;
            currentHP = maxHP;
            this.maxMP = maxMP;
            currentMP = maxMP;
            attack = 4;
            defense = 2;
            exp = 0;
            expNeeded = 1000;
            this.magic = magic;
            this.items = items;
        }
        
    
	    public bool Fight(Enemy enemy) {
            Console.WriteLine(name + " attacks!");
            if (Program.ran.Next(100) + 1 > 5){
                int lifeLost = (int)((attack + Program.ran.Next(1))/(enemy.GetDefense()/2));
                Console.WriteLine("The enemy " + enemy.GetName() + " lost " + lifeLost + "HP!");
                enemy.SetMaxHP(enemy.GetMaxHP() - lifeLost);
            } else {
                Console.WriteLine(name  + "'s attack missed!");
            }
            return true;
        }

	    public bool Defend() {
            Console.WriteLine(name + " is defending");
            defense = defense * 2;
            return true;
        }

	    public bool Magic(Enemy e) {
            int pos = 1;
            foreach (Magic mag in magic) {
                Console.WriteLine(pos + ". " + mag.GetName() + " " + mag.GetMpCost() + "MP");
                pos++;
            }
            Console.WriteLine(pos + ". Exit");
            Console.WriteLine("Which magic do you want to use?");
            int selection = Int32.Parse(Console.ReadLine());
            if (selection == pos || selection < 0 || selection > magic.Length) {
                return false;
            }
            Magic magSelected = magic[selection - 1];
            if (magSelected.GetMpCost() > GetCurrentMP()) {
                Console.WriteLine("Not enough MP!");
                return false;
            }
            magSelected.Use(this, e);
            return true;
        }

	    public bool Item() {
            int pos = 1;
            foreach (Item item in items) {
                if (item.GetQuantity() > 0) {
                    Console.WriteLine(pos + ". " + item.GetName() + " Quantitiy: " + item.GetQuantity());
                    pos++;
                }
            }
            Console.WriteLine(pos + ". Exit");
            Console.WriteLine("Which item do you want to use?");
            int selection = Int32.Parse(Console.ReadLine());
            if (selection == pos || selection < 0 || selection > items.Length) {
                return false;
            }
            Item itemSelected = items[selection - 1];
            itemSelected.Use(this);
	    	return true;
        }

        public bool Invoke(Enemy e){
            int cont = 1;
            foreach (string s in invokes) {
                Console.WriteLine(cont +  ". " +  s);
                cont++;
            }
            Console.WriteLine(cont + ". Exit");
            Console.Write("Select invokation: ");
            switch (Console.ReadLine()) {
                case "1":
                    return soulSlayer(e);
                default:
                    return false;
            }
        }

	    private bool soulSlayer(Enemy e) {
            Console.WriteLine("Try Soul Slayer?");
            if (Console.ReadLine().ToLower().StartsWith("y")){
                int chance = Program.ran.Next(2) + 1;
                if (Program.ran.Next(4) * chance >= 3) {
                    Console.WriteLine(name + " awakened his Soul Slayer!");
                    Console.WriteLine(name + "'s Soul Slayer destroyed the enemy " + e.GetName() + "!");
                    e.SetMaxHP(0);
                } else
                    Console.WriteLine(name + " failed to awake his Soul Slayer...");
                return true;
            } else 
                return false;
        }

        public void GainXP(int xp) {
            int expGained = Program.ran.Next(xp) + 500;
            Console.WriteLine("You gained " + expGained + " experience points!");
            exp += expGained;
            if (exp > expNeeded) 
                levelUp();
        }
        private void levelUp() {
            Console.WriteLine("You leveled up!");
            level++;
            Console.WriteLine("Level: " + level);
            maxHP += 5;
            currentHP = maxHP;
            Console.WriteLine("HP: " + maxHP);
            maxMP++;
            maxMP++;
            currentMP = maxMP;
            Console.WriteLine("MP: " + maxMP);
            attack++;
            attack++;
            Console.WriteLine("Attack: " + attack);
            defense++;
            defense++;
            Console.WriteLine("Defense: " + defense);
            expNeeded += level * 100;
            Console.WriteLine("Experience needed for next level: " + expNeeded);
        }
        /**
         * @return the currentHP
         */
        public int GetCurrentHP() {
            return currentHP;
        }
        /**
         * @return the currentMP
         */
        public int GetCurrentMP() {
            return currentMP;
        }
        /**
         * @return the defense
         */
        public int GetDefense() {
            return defense;
        }
        /**
         * @return the name
         */
        public string GetName() {
            return name;
        }
        /**
         * @return the maxHP
         */
        public int GetMaxHP() {
            return maxHP;
        }
        /**
         * @return the maxMP
         */
        public int GetMaxMP() {
            return maxMP;
        }
        /**
         * @param currentHP the currentHP to set
         */
        public void SetCurrentHP(int currentHP) {
            this.currentHP = currentHP;
        }
        /**
         * @param currentMP the currentMP to set
         */
        public void SetCurrentMP(int currentMP) {
            this.currentMP = currentMP;
        }
        /**
         * @return the level
         */
        public int GetLevel() {
            return level;
        }
    }
}