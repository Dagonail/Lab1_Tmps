

namespace LAB1
{
     public interface IMenuFactory
        {
            IMenu CreateMenu(Name name, Meal meal);
        }

        class MenuFactory : IMenuFactory
        {
            public IMenu CreateMenu(Name name, Meal meal) => new Menu(name, meal);
             
        }
    
}
