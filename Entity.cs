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
        int newHp;

        while (bothEntitiesAlive)
        {
            int attackScore = attacker.AttackDice.Throw();
            int defenceScore = defender.DefenceDice.Throw();
            int totalDamage = AttackResult(attackScore, defenceScore);
            if (totalDamage > 0)
            {    
                newHp = defender.HealthPoints - totalDamage;
                defender.HealthPoints = newHp;
            } 
            if (defender.HealthPoints <= 0) 
            { 
                whoDied = defender; 
                bothEntitiesAlive = false; 
                break;
            }
            Console.SetCursorPosition(0,2);
            CombatInformationPrint(attacker,defender,attackScore,defenceScore);

            attackScore = defender.AttackDice.Throw();
            defenceScore = attacker.DefenceDice.Throw();
            totalDamage = AttackResult(attackScore, defenceScore);
            if (totalDamage > 0)
            {    
                newHp = attacker.HealthPoints - totalDamage;
                attacker.HealthPoints = newHp;
            } 
            if (attacker.HealthPoints <= 0) 
            { 
                whoDied = attacker; 
                bothEntitiesAlive = false; 
                break;
            }
            Console.SetCursorPosition(0,2);
            CombatInformationPrint(defender,attacker,attackScore,defenceScore);
        }

        Console.SetCursorPosition(0,1);
        if (whoDied != null) {Console.Write($"{whoDied.Name} was defeated.");}

        return whoDied;
    }

    static int AttackResult(int attackscore, int defencescore)
    {
        int result = attackscore - defencescore;
        return result;
    }

    static void CombatInformationPrint(Entity attacker, Entity defender, int attackScore, int defenceScore)
    {
        Console.Write("the " + attacker.Name + "(atk: " + attacker.AttackDice + " => " + attackScore + ") attacked " + defender.Name + " (def: " + defender.DefenceDice + " => " + defenceScore +").       ");
    }
}