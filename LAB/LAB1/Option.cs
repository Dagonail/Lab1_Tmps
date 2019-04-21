
namespace LAB1
{
    class Option
    {
        private Option() { }

        public static Option Instance { get; } = new Option();
        public IChosen ChosenOption { get; } = new ChosenOption();
    }
}
