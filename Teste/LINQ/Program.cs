List<string> Nomes = new List<string>()
{
    "João", "Maria", "Pedro", "Ana", "Lucas", "Julia", "Gabriel", "Mariana", "Bruno", "Beatriz",
        "Rafael", "Isabela", "Daniel", "Livia", "Gustavo", "Larissa", "Thiago", "Sofia", "Felipe", "Camila",
        "Artur", "Carolina", "Leonardo", "Fernanda", "Rodrigo", "Amanda", "André", "Gabriela", "Vitor", "Helena",
        "Eduardo", "Patrícia", "Guilherme", "Paula", "Henrique", "Luiza", "Caio", "Tatiane", "Marcelo", "Bianca",
        "Vinicius", "Letícia", "Diego", "Elisa", "Ricardo", "Nicole", "Alexandre", "Valéria", "Fábio", "Juliana"
};

List<string> NomeFiltrado = Nomes.Where(nome => nome.Length <= 5).ToList();

Console.WriteLine("Nomes com 5 ou menos caracteres:");
foreach (var nome in NomeFiltrado)
{
    Console.WriteLine(nome);
}