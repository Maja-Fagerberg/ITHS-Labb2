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
        Entity? whoDied = null;
        int newHp;

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
        }
        Console.SetCursorPosition(0,1);
        CombatInformationPrint(attacker, defender, attackScore, defenceScore, totalDamage);

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
        }
        Console.SetCursorPosition(0,2);
        CombatInformationPrint(defender, attacker, attackScore, defenceScore, totalDamage);

        Console.SetCursorPosition(0,3);

        return whoDied;
    }

    static int AttackResult(int attackscore, int defencescore)
    {
        int result = attackscore - defencescore;
        return result;
    }

    static void CombatInformationPrint(Entity attacker, Entity defender, int attackScore, int defenceScore, int totalDamage)
    {
        Console.Write(attacker.Name + " (atk: " + attacker.AttackDice + " => " + attackScore + ") attacked " + defender.Name + " (def: " + defender.DefenceDice + " => " + defenceScore +"), ");
        if (defender.HealthPoints <= 0) 
        {
            Console.Write("which led to " + defender.Name + " being defeated!! ");
            if (defender.HealthPoints < 0 && defender is Player)
            {
                Console.Write("(GAME OVER)           ");
            }
        }
        else
        {
            Console.Write(totalDamage switch
            {
                <= 0 => "however no damage was dealt to " + defender.Name + ".....                                       ",
                < 7 => "damaging " + defender.Name + " slightly.                                                      ",
                >= 7 => "dealing MASSIVE damage to " + defender.Name + "!!!                                            "
            });
        }
    }

    // public static void ClearDefeatedPrint()
    // {
    //     Console.SetCursorPosition(0,3);
    //     Console.Write("                                                        ");
    // }
}