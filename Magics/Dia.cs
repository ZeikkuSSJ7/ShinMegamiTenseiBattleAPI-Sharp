using SMTBattle.Fight;

namespace SMTBattle.Magics {
    public class Dia : Magic {
        public Dia() : base("Dia", 50, 5) {}
        public override void Use(Player p, Enemy enemy) {
            System.Console.WriteLine(p.GetName() + " used " + base.GetName() + "!");
            System.Console.WriteLine(p.GetName() + " recovered " + GetEffect() + " HP!");
            p.SetCurrentHP(p.GetCurrentHP() + GetEffect());
            p.SetCurrentMP(p.GetCurrentMP() - GetMpCost());
        }
    }
}