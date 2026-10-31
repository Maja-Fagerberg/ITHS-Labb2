using Labb2;

Console.Clear();
Console.CursorVisible = false;

LevelData levelData = new();
Player player = levelData.Load("Level1.txt");
bool gameOn = true;

while (gameOn)
{
    foreach (var levelElement in levelData.Elements)
    {
        if (LevelElement.IsInSightOfPlayer(levelElement, player)) 
        {
            levelElement.InSight = true;
            if (levelElement is Wall wall)
            {
                wall.IsDiscovered = true;
            }
        }
        else {levelElement.InSight =false;}
        levelElement.Draw();
    }

    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.Escape) {break;}

    gameOn = player.Turn(key, levelData, player);
    player.Draw();

    Enemy? killed = null;
    if (gameOn)
    {
        foreach (var levelElement in levelData.Elements)
        {
            if (levelElement is Enemy enemy)
            {
                if (enemy.HealthPoints > 0)
                {
                    if (enemy.InSight) {enemy.Draw();}
                    gameOn = enemy.Update(levelData, player);
                    if (enemy.InSight) {enemy.Draw();}
                }
                if (enemy.HealthPoints < 0)
                {
                    killed = enemy;
                }
            }
        }
    if (killed != null)
    {
        levelData.RemoveEnemyFromList(killed);
    }
    }
}