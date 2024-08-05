namespace App;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"{Environment.NewLine}Bienvenido a la consola de Net Core, favor elija una opción");
        Menu.DisplayMainMenu();
    }
}
