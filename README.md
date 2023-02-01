# UltimateValidator 🧪
## 1. [Download](https://github.com/diego-hartmann/UltimateValidator/raw/main/bin/Debug/UltimateValidator.dll) the .dll
- C# library to easy validate common data through static boolean methods.

## 2. Import the namespace
```cs
using UltimateValidator;
```

## 3. Call the IsValid struct.
![image](https://user-images.githubusercontent.com/122852487/215940790-dbb964dd-d307-4143-8df5-4d9807eff481.png)
The IsValid struct holds the static methods to validade their parameters.
- Call any of these methods passing the parameters. 
```cs
bool isValidEmail = IsValid.Email("email@adress.com");
bool isValidCPF = IsValid.CPF("000.000.000-00");
bool isValidDate = IsValid.Date("01/01/2000");
// and so on...
```