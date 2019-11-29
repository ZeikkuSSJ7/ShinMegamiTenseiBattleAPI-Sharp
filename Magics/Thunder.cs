using SMTBattle.Fight;

namespace SMTBattle.Magics {
    public class Thunder : Magic  {
        public Thunder() : base("Thunder", 20, 10) {}
        public override void Use(Player p, Enemy enemy) {
            System.Console.WriteLine(p.GetName() + " used " + GetName() + "!");
            System.Console.WriteLine(enemy.GetName() + " lost " + GetEffect() + " HP!");
            enemy.SetMaxHP(enemy.GetMaxHP() - GetEffect());
            p.SetCurrentMP(p.GetCurrentMP() - GetMpCost());
        }
    }
}