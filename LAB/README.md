# Tehnici și Mecanisme de Proiectare Software

Лабораторная №1

*Подготовил - Кушнир Влад, группа TI-164*

*Целью данной лабораторной работы было имплементировать 5 порождающих шабловнов*

Были выбраны 5 шаблонов: 
1. Одиночка (Singleton)
Это порождающий паттерн проектирования, который гарантирует, что у класса есть только один экземпляр, и предоставляет к нему глобальную точку доступа.

Структура шаблона одиночка
![Структура шаблона одиночка](https://refactoring.guru/images/patterns/diagrams/singleton/structure-ru-2x.png )



2. Фабричный метод (Factory Method)

Это порождающий паттерн проектирования, который определяет общий интерфейс для создания объектов в суперклассе, позволяя подклассам изменять тип создаваемых объектов.

Паттерн Фабричный метод предлагает создавать объекты не напрямую, используя оператор new, а через вызов особого фабричного метода. Объекты всё равно будут создаваться при помощи  new, но делать это будет фабричный метод.

![Image of Factory Method](https://refactoring.guru/images/patterns/cards/factory-method-mini-2x.png)



3. Абстрактная фабрика (Abstract Factory)

Это порождающий паттерн проектирования, который позволяет создавать семейства связанных объектов, не привязываясь к конкретным классам создаваемых объектов.

![Image of Abstract Factory](https://refactoring.guru/images/patterns/cards/abstract-factory-mini-2x.png)


4. Строитель (Builder)

Это порождающий паттерн проектирования, который позволяет создавать сложные объекты пошагово. Строитель даёт возможность использовать один и тот же код строительства для получения разных представлений объектов.

![Image of Builder](https://refactoring.guru/images/patterns/diagrams/builder/solution1-2x.png)

Строитель позволяет создавать сложные объекты пошагово. Промежуточный результат всегда остаётся защищён.

5. Проторип (Prototype)

Это порождающий паттерн проектирования, который позволяет копировать объекты, не вдаваясь в подробности их реализации. Ниже приведен пример структуры шаблона прототип

![Image of Prototype](https://refactoring.guru/images/patterns/diagrams/prototype/structure-2x.png)

Применение:

**Singleton** связан с **AbstractFactory** через класс [Option](https://github.com/Dagonail/Lab1_Tmps/blob/master/LAB/LAB1/Option.cs), который дает одну опцию за раз.
```
namespace LAB1
{
    class Option
    {
        private Option() { }

        public static Option Instance { get; } = new Option();
        public IChosen ChosenOption { get; } = new ChosenOption();
    }
}
```
Согласно теории: ровно один экземпляр класса и доступен для клиентов из хорошо известной точки доступа. Таким образом, он создает свой собственный уникальный экземпляр, который представляет выбор клиента для еды и меню.

Этот выбор - класс [ChosenOption](https://github.com/Dagonail/Lab1_Tmps/blob/master/LAB/LAB1/ChosenOption.cs), который представляет **Abstract Factory**.
```

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
```
Создает ссылку на **MealFactory** и **MenuFactory** через интерфейсы. , Теоретически: обеспечивает интерфейс для создания семейств или связанных или зависимых объектов без указания их конкретных классов.

Далее у нас есть **Factory** паттерн с 3 фабриками.
 1. Класс **[MealFactory](https://github.com/Secoranda/TMPS/blob/master/LAB1/LAB1/LAB1/MealFactory.cs)**
  использует интерфейс и инструкцию switch с параметром из **Builder classes**.
 Таким образом, связаны **Factory** и **Builder** паттерны.
 
       1.1. Шаблон **Builder** использовался для создания классов **[Meal](https://github.com/Dagonail/Lab1_Tmps/blob/master/LAB/LAB1/Meal.cs)**. 
       **Builder** больше похож на интерфейс, сам продукт создан **ConcreteBuilder**.
       
 2.  **[MenuFactory](https://github.com/Dagonail/Lab1_Tmps/blob/master/LAB/LAB1/MealFactory.cs)** связана с классом **Prototype**.
 ```
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
 ```
 Меню представляет собой комбинацию между едой. Поэтому, чтобы избежать создания одинаковых объектов, используется метод clone () через шаблон **Prototype**.

Результат работы программы:
![Image of program](https://github.com/Dagonail/Lab1_Tmps/blob/master/LAB/Screens/%D0%91%D0%B5%D0%B7%D1%8B%D0%BC%D1%8F%D0%BD%D0%BD%D1%8B%D0%B9.png)
![Image of program](https://github.com/Dagonail/Lab1_Tmps/blob/master/LAB/Screens/%D0%91%D0%B5%D0%B7%D1%8B%D0%BC%D1%8F%D0%BD%D0%BD%D1%8B%D0%B92.png)

Вывод :
 В ходе данной лабораторной работы мы изучили и реализовали порождающие паттерны, они нам упрощают и структурируют код.
