# Number to Full Text Converter Library

The NumberToTextConverter library provides a simple and convenient way to convert numeric values into their corresponding full text representation.

## Installation

To use the NumberToTextConverter library, follow these steps:

1. Download the latest release of the library from the [GitHub repository](https://github.com/your-username/number-to-full-text-converter-lib).
2. Add the `NumberToTextConverter.cs` file to your project.

## Usage

To convert a number to its full text representation, follow these steps:

1. Import the `NumberToTextConverter` namespace in your code file:

```csharp
using NumberToTextConverter;
using NumberToTextConverter.Enums;
```

2. Call the `TextConverter.WriteLong` method and pass the number you want to convert as an argument:

```csharp
var text_to_write = TextConverter.WriteLong(123456789.12, LanguageEnum.En);
Console.WriteLine(text_to_write); // Output: "hundred and twenty and three millions and four hundred and fifty and six thousand and seven hundred and eighty and nine dollars and twelve cents"
```
The `WriteLong` method returns a string containing the full text representation of the input number.

## Example

Here's an example of how to use the NumberToTextConverter library:

```csharp
using NumberToTextConverter;
using NumberToTextConverter.Enums;

var text_to_write = TextConverter.WriteLong(123456789.12, LanguageEnum.En);

Console.WriteLine(text_to_write); // Output: "forty and two dollars"
```

That's it! You have successfully used the NumberToTextConverter library to convert a number to its full text representation.
