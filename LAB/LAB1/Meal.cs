

namespace LAB1
{
  
        public enum Vegetables
        {
            Carrot, Potatoe, Brocolli, Onion, Cabbage, EggPlant, None
        }

        public enum Fruits
        {
            Apple, Banana, Peach, Strawberries, None
        }

        public enum Spices
        {
            Salt, Sugar, Piper, None
        }

        public enum Method
        {
            Fresh, Grilled, Baked, Rolled, None
        }

        public enum Meat
        {
            Chicken, Sheep, Rabbit, Beef, Pork, None
        }
        public enum Combination
        {
            Kebab, Barbeque, Pie
        }
        public class Meal
        {
            public string Name { get; }
            public Vegetables Vegetables { get; set; }
            public Fruits Fruits { get; set; }
            public Meat Meat { get; set; }
            public Spices Spices { get; set; }
            public Method Method { get; set; }
            public Combination Combination { get; set; }

            public Meal(string name) { Name = name; }

            public override string ToString()
            {
                return string.Format("\nName: {0}\nMethod: {1}\nType:{2}\nVegetables: {3}\nFruits: {4}\n" +
                                    "Meat: {5}\nSpices: {6}\n",
                                Name, Method,Combination, Vegetables, Fruits, Meat, Spices);
            }
        }

    public interface IMealBuilder
    {
        void BuildVegetables(Vegetables vveg);
        void BuildFruits(Fruits vfrut);
        void BuildMeat(Meat vmeat);
        void BuildSpices(Spices vspice);
        void BuildMethod(Method vmethod);
        void BuildCombination(Combination vcom);
        Meal BuildMeal();

    }
    public class MealBuilder : IMealBuilder
    {
        private Meal meal;
        public MealBuilder(string name) => meal = new Meal(name);

        public void BuildVegetables(Vegetables vveg) => meal.Vegetables = vveg;
        public void BuildFruits(Fruits vfrut) => meal.Fruits = vfrut;
        public void BuildMeat(Meat vmeat) => meal.Meat = vmeat;
        public void BuildSpices(Spices vspice) => meal.Spices = vspice;
        public void BuildMethod(Method vmethod) => meal.Method = vmethod;
        public void BuildCombination(Combination vcom) => meal.Combination = vcom;
        public Meal BuildMeal() => meal;


    }

    public class ConcreteMealBuilder
    {
        public void Pie(IMealBuilder pie)
        {

            pie.BuildVegetables(Vegetables.None);
            pie.BuildFruits(Fruits.Apple);
            pie.BuildMeat(Meat.None);
            pie.BuildSpices(Spices.Sugar);
            pie.BuildMethod(Method.Baked);
            pie.BuildCombination(Combination.Pie);

        }
        public void Kebab(IMealBuilder kebab)
        {

            kebab.BuildVegetables(Vegetables.Potatoe);
            kebab.BuildFruits(Fruits.None);
            kebab.BuildMeat(Meat.Chicken);
            kebab.BuildSpices(Spices.Piper);
            kebab.BuildMethod(Method.Rolled);
            kebab.BuildCombination(Combination.Kebab);

        }
        public void Barbeque(IMealBuilder barbeque)
        {

            barbeque.BuildVegetables(Vegetables.Brocolli);
            barbeque.BuildFruits(Fruits.None);
            barbeque.BuildMeat(Meat.Pork);
            barbeque.BuildSpices(Spices.Piper);
            barbeque.BuildMethod(Method.Grilled);
            barbeque.BuildCombination(Combination.Barbeque);

        }

    }
   

   

}




