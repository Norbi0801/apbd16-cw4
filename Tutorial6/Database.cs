using Tutorial6.Models;

namespace Tutorial6;

public static class Database
{
    public static List<Animal> Animals = new()
    {
        new Animal() { Id = 1, Name = "Rick" , Category = "Pies", Mass = 1.5 },
        new Animal() { Id = 2, Name = "Paul" , Category = "Kot", Mass = 2.5 },
        new Animal() { Id = 3, Name = "Richard" , Category = "Chomik", Mass = 0.5 }
    };
}