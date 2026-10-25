using Labb2;

Console.Clear();
Console.CursorVisible = false;

LevelData levelData = new();
Player player = levelData.Load("Level1.txt");
bool gameOn = true;

//ritar ut allt på mappen från början, flytta senare
foreach (var levelElement in levelData.Elements)
{
    // if (levelElement is not Enemy enemy)
    // {
    // levelElement.Draw();
    // }

    levelElement.Draw();
}
player.Draw();

while (gameOn)
{
    player.Draw();
    ConsoleKeyInfo key = Console.ReadKey(); //Byt variabelnamn? stänger ju av spelet också

    if (key.Key == ConsoleKey.Escape)
    {
        Console.Clear();
        gameOn = false;
        return;
    }
    gameOn = player.Movement(key, levelData, player);
    player.Draw();

    Enemy? killed = null;
    foreach (var levelElement in levelData.Elements)
    {
        if (levelElement is Enemy enemy)
        {
            enemy.Draw();
            gameOn = enemy.Update(levelData, player);
            enemy.Draw();
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

    //Hitta enemyWhoDied och ta bort efter loopen istl
    //levelData.RemoveEnemyFromList(enemyWhoDied);

}