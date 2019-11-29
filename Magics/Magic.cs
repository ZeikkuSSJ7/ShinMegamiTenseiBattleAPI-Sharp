using SMTBattle.Fight;

namespace SMTBattle.Magics {
    public abstract class Magic {
        private string name;
        private int effect;
        private int mpCost;
        public Magic(string name, int effect, int mpCost) {
            this.name = name;
            this.effect = effect;
            this.mpCost = mpCost;
        }
        public abstract void Use(Player p, Enemy enemy);
        /**
         * @return the effect
         */
        public int GetEffect() {
            return effect;
        }
        /**
         * @return the name
         */
        public string GetName() {
            return name;
        }
        /**
         * @return the mpCost
         */
        public int GetMpCost() {
            return mpCost;
        }
    }
}