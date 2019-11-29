using SMTBattle.Fight;

namespace SMTBattle.Items{
    public abstract class Item {
        private string name;
        private int quantity;
        private int effect;
        public Item(string name, int quantity, int effect) {
            this.name = name;
            this.effect = effect;
            this.quantity = quantity;
        }
        public abstract void Use(Player p);
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
         * @return the quantity
         */
        public int GetQuantity() {
            return quantity;
        }
    }
}