namespace Labb2;

class Entity : LevelElement
{
    public string? Name { get; protected set; }
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

        while (bothEntitiesAlive)
        {
            int attackScore = attacker.AttackDice.Throw();
            int defenceScore = defender.DefenceDice.Throw();
            int newHp = defender.HealthPoints - AttackResult(attackScore, defenceScore);
            defender.HealthPoints = newHp;
            if (defender.HealthPoints <= 0) 
            { 
                whoDied = defender; 
                bothEntitiesAlive = false; 
                break;
            }
            Console.SetCursorPosition(0,2);
            CombatInformationPrint(attacker,defender);

            attackScore = defender.AttackDice.Throw();
            defenceScore = attacker.DefenceDice.Throw();
            newHp = attacker.HealthPoints - AttackResult(attackScore, defenceScore);
            attacker.HealthPoints = newHp;
            if (attacker.HealthPoints <= 0) 
            { 
                whoDied = attacker; 
                bothEntitiesAlive = false; 
                break;
            }
            Console.SetCursorPosition(0,3);
            CombatInformationPrint(defender,attacker);
        }

        Console.SetCursorPosition(0,1);
        if (whoDied != null) {Console.Write($"{whoDied.Name} was defeated.");}

        return whoDied;
    }

    static int AttackResult(int attackscore, int defencescore)
    {
        int result = attackscore - defencescore;

        if (result >= 0) {return result;}
        else {return 0;}
    }

    static void CombatInformationPrint(Entity attacker, Entity defender)
    {
        Console.Write("The " + attacker.Name + "(ATK: " + attacker.AttackDice + ") attacked " + defender.Name + " (DEF: " + defender.DefenceDice + ").       ");

    }
}