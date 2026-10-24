namespace Labb2;

class Entity : LevelElement
{
    public int HealthPoints { get; private set; }
    
    // public Dice AttackDice { get; set; } // Ska attack och defencedice in i konstruktorn tro?
    // public Dice DefenceDice { get; set; }

    public Entity(int xPosition, int yPosition, char character, ConsoleColor color, int healthPoints)
    : base(xPosition, yPosition, character, color)
    {
        HealthPoints = healthPoints;
    }
    
    //combat attacker plyer metod()
    //combat attacker enemy metod() overloading gör klar
    static void Combat(Player attacker, Enemy defender)
    {
        Console.WriteLine($"Player{attacker} is attacking Enemy{defender}!");
    }
    static void Combat(Enemy attacker, Player defender)
    {
        Console.WriteLine($"Enemy{defender} is attacking Player{attacker}!");
    }
}