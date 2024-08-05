class Menu
{

    public static async void DisplayMainMenu()
    {
        Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Menú Principal");
        Console.WriteLine("1. Agregar un cliente nuevo");
        Console.WriteLine($"2. Editar un cliente");
        Console.WriteLine($"3. Eliminar un cliente");
        Console.WriteLine($"4. Consultar un cliente por id");
        Console.WriteLine($"5. Listar clientes por ordenados por fecha de nacimiento descendente");
        Console.WriteLine($"6. Listar clientes por ordenados por id");
        Console.WriteLine($"7. Listar clientes por nombre de manera ascendente");
        Console.WriteLine($"8. Salir");

        Console.Write($"{Environment.NewLine}Opción Elegida: ");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Option.AddCustomer();
                DisplayMainMenu();
                break;
            case "2":
                Option.EditCustomer();
                DisplayMainMenu();
                break;
            case "3":
                Option.DeleteCustomer();
                DisplayMainMenu();
                break;
            case "4":
                Option.GetCustomer();
                DisplayMainMenu();
                break;
            case "5":
                Option.GetCustomersOrderByBirthDate();
                DisplayMainMenu();
                break;
            case "6":
                Option.GetCustomersOrderById();
                DisplayMainMenu();
                break;
            case "7":
                Option.GetCustomersOrderByName();
                DisplayMainMenu();
                break;
            case "8":
                Console.WriteLine($"{Environment.NewLine}Presione cualquier tecla para continuar...");
                Console.ReadKey(true);
                break;
            default:
                Console.WriteLine($"{Environment.NewLine}Opción Inválida");
                DisplayMainMenu();
                break;
        }
    }
}