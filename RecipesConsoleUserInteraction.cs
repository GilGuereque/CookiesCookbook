namespace CookieCookbook.RecipesUserInteraction
{
    public interface IRecipesUserInteraction
    {
        void ShowMessage(string message);
        void Exit();
    }
    
    public class RecipesConsoleUserInteraction : IRecipesUserInteraction
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        
        public void Exit()
        {
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }
    }
}
