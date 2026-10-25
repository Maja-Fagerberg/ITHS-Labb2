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
    ConsoleKeyInfo movementKey = Console.ReadKey(); //Byt variabelnamn? stänger ju av spelet också

    if (movementKey.Key == ConsoleKey.Escape)
    {
        Console.Clear();
        gameOn = false;
        return;
    }
    player.Movement(movementKey, levelData);
    player.Draw();
    
    foreach (var levelElement in levelData.Elements)
    {
        if (levelElement is Enemy enemy)
        {
            enemy.Draw();
            enemy.Update(levelData, player);
            enemy.Draw();
        }
    }

}