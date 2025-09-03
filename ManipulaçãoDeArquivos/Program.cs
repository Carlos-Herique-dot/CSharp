const string filePath = @"C:\Users\Carlos\Desktop\test.txt";

File.Delete(filePath);
// using var file = File.CreateText(filePath);
// file.WriteLine("Hello, World! 1");

// file.Close();

// string conteudo = File.ReadAllText(filePath);
// Console.WriteLine(conteudo);

// try
// {
//     using var file = File.AppendText(filePath);
//     file.WriteLine("Hello, World!");
//     Console.WriteLine("Texto adicionado com sucesso.");
//     file.Close();
// }
// catch (Exception ex)
// {
//     Console.WriteLine($"Ocorreu um erro: {ex.Message}");
//     throw;
// }