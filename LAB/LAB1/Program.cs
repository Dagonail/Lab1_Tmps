using System;
using System.Collections.Generic;

namespace LAB1
{
    class Program
    {
        static void Main(string[] args)
        {
            var option = Option.Instance.ChosenOption;
            var mealFactory = option.GetMealFactory();
 
            var menuFactory = option.GetMenuFactory();


            var meal = new List<Meal>();

            var menu = new List<IMenu>();

            meal.Add(mealFactory.CreateMeal("1", Combination.Pie));
            meal.Add(mealFactory.CreateMeal("2", Combination.Kebab));
            meal.Add(mealFactory.CreateMeal("3", Combination.Barbeque));



            var menu1 = menuFactory.CreateMenu(Name.Menu1, meal[0]);
            var menu2 = menuFactory.CreateMenu(Name.Menu2 ,meal[1]);
            var menu3 = menuFactory.CreateMenu(Name.Menu3, meal[2]);

            menu.Add(menu1.Clone());
            menu.Add(menu2.Clone());
            menu.Add(menu3.Clone());
            

            Console.WriteLine("########MEALS########\n");
            foreach (var x in meal)
            {
                Console.WriteLine(x.ToString());
            };
            Console.WriteLine("########MENUS########\n");
            foreach (var x in menu)
            {
                Console.WriteLine("#########################");
                Console.WriteLine(x.ToString());
            };
           
            Console.ReadKey();

        }
    }
}
