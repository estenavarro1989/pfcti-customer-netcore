using Newtonsoft.Json.Linq;
class Option
{
    public static void AddCustomer()
    {
        try
        {
            Console.Write($"Id del Cliente: ");
            Customer customer = new Customer();
            customer.id = Console.ReadLine();
            Console.Write($"Nombre del Cliente: ");
            customer.firstName = Console.ReadLine();
            Console.Write($"Apellido del Cliente: ");
            customer.lastName = Console.ReadLine();
            Console.Write($"Teléfono del Cliente (+50688888888): ");
            customer.phone = Console.ReadLine();
            Console.Write($"Fecha de Nacimiento del Cliente (1990-01-01): ");
            try
            {
                customer.birthDate = DateTime.Parse(Console.ReadLine());
            }
            catch (System.Exception)
            {
                Console.Write($"{Environment.NewLine}Error: Formato de fecha incorrecto");
                return;
            }

            var success = Api.AddCustomer(customer);
            if (success) Console.Write($"{Environment.NewLine}Cliente agregado con éxito");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            throw;
        }

    }

    public static void EditCustomer()
    {
        try
        {
            Console.Write($"Id del Cliente que desea editar: ");
            string id = Console.ReadLine();
            Customer customer = new Customer();
            customer.id = id;
            Console.Write($"Nombre del Cliente: ");
            customer.firstName = Console.ReadLine();
            Console.Write($"Apellido del Cliente: ");
            customer.lastName = Console.ReadLine();
            Console.Write($"Teléfono del Cliente (+50688888888): ");
            customer.phone = Console.ReadLine();
            Console.Write($"Fecha de Nacimiento del Cliente(1990-01-01): ");
            try
            {
                customer.birthDate = DateTime.Parse(Console.ReadLine());
            }
            catch (System.Exception)
            {
                Console.Write($"{Environment.NewLine}Formato de fecha incorrecto");
                return;
            }
            
            var success = Api.EditCustomer(id, customer);
            if (success) Console.Write($"{Environment.NewLine}Cliente editado con éxito");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            throw;
        }

    }

    public static void DeleteCustomer()
    {
        Console.Write($"{Environment.NewLine}Digite el id del cliente: ");
        var id = Console.ReadLine();

        try
        {
            var success = Api.DeleteCustomer(id);

            if (success) Console.Write($"{Environment.NewLine}Cliente eliminado con éxito");
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public static void GetCustomersOrderById()
    {
        List<Customer> customers = Api.GetCustomersList("id");

        try
        {
            for (var i = 0; i < customers.Count; i++)
            {
                Console.WriteLine("");
                JObject parsed = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(customers[i]));

                foreach (var pair in parsed)
                {
                    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                }
            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public static void GetCustomersOrderByName()
    {
        List<Customer> customers = Api.GetCustomersList("name");

        try
        {
            for (var i = 0; i < customers.Count; i++)
            {
                Console.WriteLine("");
                JObject parsed = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(customers[i]));

                foreach (var pair in parsed)
                {
                    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                }
            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public static void GetCustomersOrderByBirthDate()
    {
        List<Customer> customers = Api.GetCustomersList("birthDate");

        try
        {
            for (var i = 0; i < customers.Count; i++)
            {
                Console.WriteLine("");
                JObject parsed = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(customers[i]));

                foreach (var pair in parsed)
                {
                    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                }
            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public static void GetCustomer()
    {
        Console.Write($"{Environment.NewLine}Digite el id del cliente: ");
        var option = Console.ReadLine();

        try
        {
            Customer customer = Api.GetCustomerById(option);

            Console.WriteLine("");
            JObject parsed = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(customer));

            foreach (var pair in parsed)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}