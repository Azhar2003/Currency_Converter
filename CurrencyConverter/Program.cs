using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class CurrencyConverter
{
    // API URL and Key
    private static readonly string apiKey = "79a1b8e564421a642786b2f7";
    private static readonly string apiUrl = "https://v6.exchangerate-api.com/v6/{0}/latest/{1}";

    static async Task Main(string[] args)
    {
        bool exitProgram = false;

        Console.WriteLine("Welcome to the Live Currency Converter!");

        // Loop until the user chooses to exit
        while (!exitProgram)
        {
            // Display menu options to the user
            Console.WriteLine("\nPlease choose an option:");
            Console.WriteLine("1. View list of supported currencies");
            Console.WriteLine("2. Convert currency");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice (1/2/3): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Display the list of supported currencies
                    await DisplaySupportedCurrencies();
                    break;

                case "2":
                    // Proceed with currency conversion
                    await ConvertCurrencyFlow();
                    break;

                case "3":
                    // Exit the application
                    exitProgram = true;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please select 1, 2, or 3.");
                    break;
            }

            Console.WriteLine(); // Add a line break for readability
        }

        Console.WriteLine("Thank you for using the Live Currency Converter! Goodbye.");
    }

    // Function to fetch and display supported currencies
    static async Task DisplaySupportedCurrencies()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                // Formulate the request URL (use USD or any valid base currency)
                string requestUrl = string.Format(apiUrl, apiKey, "USD");

                // Send a GET request to the API
                HttpResponseMessage response = await client.GetAsync(requestUrl);

                // Check if the response was successful
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Failed to retrieve exchange rates.");
                    return;
                }

                // Parse the JSON response
                string responseData = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(responseData);

                Console.WriteLine("\nSupported Currencies:");
                foreach (var currency in json["conversion_rates"])
                {
                    Console.WriteLine(currency.Path.Split('.').Last());  // Display the currency code
                }

                Console.WriteLine();  // Line break
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Function to guide the user through the currency conversion flow
    static async Task ConvertCurrencyFlow()
    {
        // Get user input for the base currency
        Console.Write("Enter the currency code to convert from (e.g., USD): ");
        string fromCurrency = Console.ReadLine().ToUpper();

        // Get user input for the target currency
        Console.Write("Enter the currency code to convert to (e.g., EUR): ");
        string toCurrency = Console.ReadLine().ToUpper();

        // Get user input for the amount to be converted
        Console.Write("Enter the amount to convert: ");
        decimal amount;
        if (!decimal.TryParse(Console.ReadLine(), out amount))
        {
            Console.WriteLine("Invalid amount. Please enter a valid number.");
            return; // Return to the main menu
        }

        // Fetch live exchange rate and perform conversion
        decimal convertedAmount = await ConvertCurrency(fromCurrency, toCurrency, amount);

        // Display the result
        if (convertedAmount != -1)
        {
            Console.WriteLine($"{amount} {fromCurrency} = {convertedAmount:F2} {toCurrency}");
        }
    }

    // Function to fetch live exchange rates and perform conversion
    static async Task<decimal> ConvertCurrency(string fromCurrency, string toCurrency, decimal amount)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                // Formulate the request URL
                string requestUrl = string.Format(apiUrl, apiKey, fromCurrency);

                // Send a GET request to the API
                HttpResponseMessage response = await client.GetAsync(requestUrl);

                // Check if the response was successful
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Failed to retrieve exchange rates.");
                    return -1;
                }

                // Parse the JSON response
                string responseData = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(responseData);

                // Check if the target currency is in the response
                if (json["conversion_rates"][toCurrency] == null)
                {
                    Console.WriteLine($"Currency {toCurrency} is not supported.");
                    return -1;
                }

                // Extract the exchange rate for the target currency
                decimal exchangeRate = json["conversion_rates"][toCurrency].Value<decimal>();

                // Perform the currency conversion
                decimal convertedAmount = amount * exchangeRate;

                return convertedAmount;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return -1;
        }
    }
}
