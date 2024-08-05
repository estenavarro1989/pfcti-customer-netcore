using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Reflection;

class Api
{
    private static string baseUrl = "http://localhost:5244/api/customers";
    public static bool AddCustomer(Customer customer)
    {
        string url = baseUrl;
        try
        {
            HttpClient client = new HttpClient();
            var jsonContent = JsonSerializer.Serialize(customer);
            HttpResponseMessage response = client.PostAsync(url, new StringContent(jsonContent, Encoding.UTF8, "application/json")).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            if (result.Contains("errors") && result.Contains("type"))
            {
                Console.WriteLine($"{Environment.NewLine}");
                var getResponse = System.Text.Json.JsonSerializer.Deserialize<ValidationError>(result);
                foreach (KeyValuePair<string, string[]> entry in getResponse.errors)
                {
                    Console.WriteLine(entry.Value[0]);
                }
                return false;
            }
            if (result.Contains("errors") && !result.Contains("type"))
            {
                Console.WriteLine($"{Environment.NewLine}");
                var getResponse = System.Text.Json.JsonSerializer.Deserialize<RuntimeError>(result);
                foreach (string error in getResponse.errors)
                {
                    Console.WriteLine(error);
                }
                return false;
            }
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public static bool EditCustomer(string id, Customer customer)
    {
        string url = baseUrl + "/" + id;
        try
        {
            HttpClient client = new HttpClient();
            var jsonContent = JsonSerializer.Serialize(customer);
            HttpResponseMessage response = client.PutAsync(url, new StringContent(jsonContent, Encoding.UTF8, "application/json")).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            if (result.Contains("errors") && result.Contains("type"))
            {
                Console.WriteLine($"{Environment.NewLine}");
                var getResponse = System.Text.Json.JsonSerializer.Deserialize<ValidationError>(result);
                foreach (KeyValuePair<string, string[]> entry in getResponse.errors)
                {
                    Console.WriteLine(entry.Value[0]);
                }
                return false;
            }
            if (result.Contains("errors") && !result.Contains("type"))
            {
                Console.WriteLine($"{Environment.NewLine}");
                var getResponse = System.Text.Json.JsonSerializer.Deserialize<RuntimeError>(result);
                foreach (string error in getResponse.errors)
                {
                    Console.WriteLine(error);
                }
                return false;
            }
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public static bool DeleteCustomer(string id)
    {
        string url = baseUrl + "/" + id;
        try
        {
            HttpClient client = new HttpClient();
            var res = client.DeleteAsync(url);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public static List<Customer> GetCustomersList(string orderParam)
    {
        string url = baseUrl + "/" + orderParam;
        try
        {
            HttpClient client = new HttpClient();
            var res = client.GetAsync(url).Result;
            if (res.IsSuccessStatusCode)
            {
                var responseContent = res.Content.ReadAsStringAsync().Result;
                var getResponse = System.Text.Json.JsonSerializer.Deserialize<List<Customer>>(responseContent);

                return getResponse;
            }
            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public static Customer GetCustomerById(string id)
    {
        string url = baseUrl + "/" + id;
        try
        {
            HttpClient client = new HttpClient();
            var res = client.GetAsync(url).Result;
            if (res.IsSuccessStatusCode)
            {
                var responseContent = res.Content.ReadAsStringAsync().Result;
                var getResponse = System.Text.Json.JsonSerializer.Deserialize<Customer>(responseContent);
                return getResponse;
            }
            else
            {
                if (res == null) throw new Exception("El cliente no existe");
                return null;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}