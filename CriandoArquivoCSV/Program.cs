
var heroes = new List<Hero>
{
    new("Bruce Wayne", "9999-9999", DateTime.Now.AddYears(-32)),
    new("Clark Kent", "8888-8888", DateTime.Now.AddYears(-35)),
    new("Diana Prince", "7777-7777", DateTime.Now.AddYears(-28)),
    new("Barry Allen", "6666-6666", DateTime.Now.AddYears(-30)),
};

var data = heroes.Select(hero => (string)hero);
File.WriteAllLines("heroes.csv", data);

public class Hero
{
    public Hero(string nome, string phone, DateTime birthDate)
    {
        Nome = nome;
        Phone = phone;
        BirthDate = birthDate;
    }
    public string Nome { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }

    public static implicit operator string(Hero hero)
    => $"{hero.Nome}, {hero.Phone}, {hero.BirthDate.ToString("yyyy-MM-dd")}";

}

public static class StringExtension
{
    public static DateTime ToDateTime(this string value)
    {
        var data = value.Split("-");
        return new DateTime(
            int.Parse(data[0]),
            int.Parse(data[1]),
            int.Parse(data[2]));
    }
}

