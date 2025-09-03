
const string filePath = @"C:\Users\Carlos\Desktop\Teste_ler.json";

var data = File.ReadAllText(filePath);
Console.WriteLine(data);

// var data = File.ReadAllLines(filePath);
// foreach (var line in data)
// {
//     Console.WriteLine(line);
// }

// using var file = new StreamReader(filePath);

// string? line;
// while ((line = file.ReadLine()) != null)
//     Console.WriteLine(line);

// file.Close();