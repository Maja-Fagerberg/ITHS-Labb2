using Labb2;

Console.Clear();
Console.CursorVisible = false;

LevelData levelData = new();
Player player = levelData.Load("Level1.txt");
bool gameOn = true;
player.Draw();

while (gameOn)
{
    foreach (var levelElement in levelData.Elements)
    {
        if (LevelElement.IsInSight(levelElement, player)) {levelElement.Draw();}
    }
    player.Draw();
    ConsoleKeyInfo key = Console.ReadKey();

    if (key.Key == ConsoleKey.Escape)
    {
        break;
    }

    gameOn = player.Movement(key, levelData, player);
    player.Draw();
    if (!gameOn)
    {
        break;
    }

    Enemy? killed = null;
    foreach (var levelElement in levelData.Elements)
    {
        if (levelElement is Enemy enemy)
        {
            if (LevelElement.IsInSight(enemy, player)) {enemy.Draw();}
            gameOn = enemy.Update(levelData, player);
            if (LevelElement.IsInSight(enemy, player)) {enemy.Draw();}
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