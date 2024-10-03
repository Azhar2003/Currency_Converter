# Currency_Converter

### Description:
The Currency Converter application is a console-based C# program that allows users to convert between different currencies using live exchange rates. The application fetches real-time data from an external API and supports a wide range of global currencies. Users can:
- View the list of supported currencies.
- Convert amounts between two currencies.
- Continuously convert currencies until they choose to exit the program.

### Features:
- **Live Exchange Rates**: Fetches live rates from an exchange rate API.
- **Multiple Currencies**: Supports conversion between a wide range of currencies.
- **Interactive Menu**: Users can choose to view supported currencies or proceed with conversions.
- **Input Validation**: Ensures valid input for currency codes and amounts.
- **Continuous Use**: Allows users to convert multiple times without restarting the program.

---

## Installation:

### Prerequisites:
1. **.NET SDK**: Ensure the .NET SDK is installed on your machine. You can download it [here](https://dotnet.microsoft.com/download).
2. **API Key**: You need an API key from a currency exchange rate provider (e.g., [ExchangeRate-API](https://www.exchangerate-api.com/)).

### Steps to Install:
1. **Clone or Download the Project**:
   - Clone the repository or download the source files.
   - Open the project in your IDE (e.g., Visual Studio).

2. **API Configuration**:
   - Obtain an API key from the exchange rate provider.
   - In the `CurrencyConverter.cs` file, replace `your_api_key` with your actual API key in the following line:

   ```csharp
   private static readonly string apiKey = "your_api_key";
   ```

3. **Build the Project**:
   - In Visual Studio, open the solution file (`CurrencyConverter.sln`).
   - Build the project by navigating to `Build > Build Solution` or pressing `Ctrl + Shift + B`.

---

## Usage:

### Running the Application:
1. **Run the Program**:
   - To start the program, press `Ctrl + F5` in Visual Studio, or run it via the command line:
     ```bash
     dotnet run
     ```

2. **Main Menu**:
   - After launching the program, you will be presented with the following options:
     1. View the list of supported currencies.
     2. Convert between currencies.
     3. Exit the application.

3. **Conversion**:
   - If you choose to convert a currency, you will be prompted to:
     - Enter the base currency code (e.g., USD).
     - Enter the target currency code (e.g., EUR).
     - Enter the amount to be converted.
   - The program will fetch the live rate, perform the conversion, and display the result.

4. **Exit**:
   - You can choose to exit the program at any time by selecting the `Exit` option.

---

## Example:

```
Welcome to the Live Currency Converter!

Please choose an option:
1. View list of supported currencies
2. Convert currency
3. Exit
Enter your choice (1/2/3): 1

Supported Currencies:
USD
EUR
GBP
ZAR
JPY
INR
... 

Please choose an option:
1. View list of supported currencies
2. Convert currency
3. Exit
Enter your choice (1/2/3): 2
Enter the currency code to convert from (e.g., USD): USD
Enter the currency code to convert to (e.g., GBP): GBP
Enter the amount to convert: 100
100 USD = 75.00 GBP

Do you want to convert another currency? (yes/no): no
```

---

## Dependencies:
- **.NET SDK**: For building and running the application.
- **Newtonsoft.Json**: A popular JSON framework for .NET used to parse API responses.

You can install Newtonsoft.Json via NuGet:
```bash
dotnet add package Newtonsoft.Json
```

---

## API Information:
The application uses an external currency exchange rate API (e.g., [ExchangeRate-API](https://www.exchangerate-api.com/)) to get live exchange rates. You need to sign up for an API key and insert it into the code.

---

## Future Enhancements:
- Add graphical user interface (GUI) to improve user experience.
- Implement caching of exchange rates to reduce API calls.
- Handle errors more gracefully with detailed user messages.

---

## License:
This project is licensed under the MIT License. See the LICENSE file for details.

---

## Author:
Developed by [Azhar Anath].

For any questions or suggestions, feel free to contact me at [azhar.anath@gmail.com].

---
