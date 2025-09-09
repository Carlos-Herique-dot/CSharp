
const string filePath = @"winequality-white.csv";

var data = File.ReadAllText(filePath);
Console.WriteLine(data);

// var data = File.ReadAllLines(filePath);
// foreach (var line in data.Where(l => l.Contains("7")))
// {
//     Console.WriteLine(line);
// }

// using var file = new StreamReader(filePath);

// string? line;
// while ((line = file.ReadLine()) != null)
//     Console.WriteLine(line);

// file.Close();