using System;
using SMTBattle.Items;
using SMTBattle.Magics;

namespace SMTBattle.Fight{
    class Program{
        public static Random ran = new Random();
        static Player player;
        static Enemy enemy;
        public static void Initialize(){
            Magic[] magic = {new Fire(), new Thunder()};
            Item[] items = {new Potion()};
            player = new Player(Console.ReadLine(), 40, 20, magic, items);
            enemy = new Enemy("Zombie", 40, 2, 2, 250);
        }
        static void Main(string[] args){
            Initialize();
            bool endTurn = false;
            while (true && player.GetCurrentHP() > 0){
                endTurn = false;
                while (!endTurn) {
                Console.WriteLine($"HP: {player.GetCurrentHP()}/{player.GetMaxHP()} MP: {player.GetCurrentMP()}/{player.GetMaxMP()} \nEnemy HP: {enemy.GetMaxHP()} \nWhat will {player.GetName()} do? \n1) Fight 2) Item 3) Magic 4) Defend 5) Invoke");
                    switch ("1") {
                        case "1":
                            endTurn = player.Fight(enemy);
                            break;
                        case "2":
                            endTurn = player.Item();
                            break;
                        case "3":
                            endTurn = player.Magic(enemy);                    
                            break;
                        case "4":
                            endTurn = player.Defend();                    
                            break;
                        case "5":
                            endTurn = player.Invoke(enemy);
                            break;
                        default:
                            Console.WriteLine("poops");
                            break;
                    }
                }
                if (enemy.GetMaxHP() <= 0){
                    player.GainXP(enemy.GetXpBase());
                    if (player.GetLevel() < 10) {
                        enemy = new Enemy("Zombie", 40, 2, 2, 250);
                    } else if (player.GetLevel() < 20) {
                        enemy = new Enemy("Wolf", 100, 15, 10, 750);
                    } else if (player.GetLevel() < 10000) {
                        enemy = new Enemy("Jack Frost", 150, 30, 40, 7000);
                    } else {
                        Console.WriteLine("You completed the game!");
                        break;
                    }
                } else {
                    enemy.Fight(player);
                }
                if (player.GetCurrentHP() > player.GetMaxHP()) {
                    player.SetCurrentHP(player.GetMaxHP());
                }
            }
            Console.WriteLine("Game over!");

        }
    }
}
