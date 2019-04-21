
namespace LAB1
{
  
        public interface IMealFactory
        {
            Meal CreateMeal(string name, Combination combination);
        }

        public class MealFactory : IMealFactory
        {
            public Meal CreateMeal(string name, Combination combination)
            {
            IMealBuilder builder = new MealBuilder(name);
            switch (combination)
            {
                    case Combination.Pie:
                        ConcreteMealBuilder pie = new ConcreteMealBuilder();
                        pie.Pie(builder);
                        return builder.BuildMeal();
                    case Combination.Kebab:
                        ConcreteMealBuilder kebab = new ConcreteMealBuilder();
                        kebab.Kebab(builder);
                        return builder.BuildMeal();
                    case Combination.Barbeque:
                        ConcreteMealBuilder barbeque = new ConcreteMealBuilder();
                        barbeque.Barbeque(builder);
                        return builder.BuildMeal();

            }
            return null;
            }
        }
    
}
