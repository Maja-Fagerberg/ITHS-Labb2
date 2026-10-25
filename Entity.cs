namespace Labb2;

class Entity : LevelElement
{
    public string? Name { get; private set; }
    public int HealthPoints { get; private set; }
    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }

    public Entity(int xPosition, int yPosition, char character, ConsoleColor color, string? name, int healthPoints, Dice attackDice, Dice defenceDice)
    : base(xPosition, yPosition, character, color)
    {
        Name = name;
        HealthPoints = healthPoints;
        AttackDice = attackDice;
        DefenceDice = defenceDice;
    }
    
    protected static LevelElement? Combat(Entity attacker, Entity defender) 
    {
        bool bothEntitiesAlive = true;
        LevelElement? whoDied = null;

        Console.WriteLine($"{attacker.Name} is attacking {defender.Name}!");

        while (bothEntitiesAlive)
        {
            int attackScore = attacker.AttackDice.Throw();
            int defenceScore = defender.DefenceDice.Throw();
            defender.HealthPoints -= TotalDamageDealt(attackScore, defenceScore);
            if (defender.HealthPoints <= 0) { whoDied = defender; bothEntitiesAlive = false; };

            attackScore = defender.AttackDice.Throw();
            defenceScore = attacker.AttackDice.Throw();
            attacker.HealthPoints -= TotalDamageDealt(attackScore, defenceScore);
            if (attacker.HealthPoints <= 0) { whoDied = attacker; bothEntitiesAlive = false; };
        }
        Console.Write($"{whoDied} died.");

        return whoDied;
    }

    private static int TotalDamageDealt(int attack, int defence)
    {
        int totalDamageDealt = attack - defence;
        return totalDamageDealt;
    }
}