namespace Labb2;

class Entity : LevelElement
{
    public string? Name { get; private set; }
    public int HealthPoints { get; private set; }
    public Dice AttackDice { get; private set; }
    public Dice DefenceDice { get; private set; }

    public Entity(int xPosition, int yPosition, char character, ConsoleColor color, string? name, int healthPoints, Dice attackDice, Dice defenceDice)
    : base(xPosition, yPosition, character, color)
    {
        Name = name;
        HealthPoints = healthPoints;
        AttackDice = attackDice;
        DefenceDice = defenceDice;
    }
    
    protected static Entity? Combat(Entity attacker, Entity defender) 
    {
        bool bothEntitiesAlive = true;
        Entity? whoDied = null;

        Console.SetCursorPosition(0,19);
        Console.WriteLine($"{attacker.Name} is attacking {defender.Name}!");

        while (bothEntitiesAlive)
        {
            int attackScore = attacker.AttackDice.Throw();
            int defenceScore = defender.DefenceDice.Throw();
            defender.HealthPoints -= attackScore - defenceScore;
            if (defender.HealthPoints <= 0) { whoDied = defender; bothEntitiesAlive = false; };

            attackScore = defender.AttackDice.Throw();
            defenceScore = attacker.AttackDice.Throw();
            attacker.HealthPoints -= attackScore - defenceScore;
            if (attacker.HealthPoints <= 0) { whoDied = attacker; bothEntitiesAlive = false; };
        }

        Console.SetCursorPosition(30,19);
        if (whoDied != null) {Console.Write($"{whoDied.Name} was defeated.");}

        return whoDied;
    }
}