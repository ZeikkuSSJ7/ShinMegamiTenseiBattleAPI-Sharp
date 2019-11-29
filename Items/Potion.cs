using SMTBattle.Fight;

namespace SMTBattle.Items {
    public class Potion : Item {
        public Potion() : base("Potion", 5, 50) { }
        public override void Use(Player p) {
            System.Console.WriteLine(p.GetName() + " used " + GetName() + "!");
            System.Console.WriteLine(p.GetName() + " recovered " + GetEffect() + "HP!");
            p.SetCurrentHP(p.GetCurrentHP() + GetEffect());
        }
    }
}