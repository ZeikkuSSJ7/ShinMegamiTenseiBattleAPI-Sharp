using SMTBattle.Fight;

namespace SMTBattle.Magics {
    public class Fire : Magic {
        public Fire() : base("Fire", 10, 5) {}
        public override void Use(Player p, Enemy enemy) {
            System.Console.WriteLine(p.GetName() + " used " + GetName() + "!");
            System.Console.WriteLine(enemy.GetName() + " lost " + GetEffect() + " HP!");
            enemy.SetMaxHP(enemy.GetMaxHP() - GetEffect());
            p.SetCurrentMP(p.GetCurrentMP() - GetMpCost());
        }
    }
}