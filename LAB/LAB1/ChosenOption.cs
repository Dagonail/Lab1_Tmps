
namespace LAB1
{
  
        public interface IChosen
        {
            IMealFactory GetMealFactory();
            IMenuFactory GetMenuFactory();
        }

        public class ChosenOption : IChosen
        {
            public IMealFactory GetMealFactory() => new MealFactory();

            public IMenuFactory GetMenuFactory() => new MenuFactory();

            
         }

    
}
