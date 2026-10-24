using Labb2;

Console.Clear();
Console.CursorVisible = false;

LevelData levelData = new();
Player player = levelData.Load("Level1.txt");
bool gameOn = true;

//ritar ut allt på mappen från början, flytta senare
foreach (var levelElement in levelData.Elements)
{
    levelElement.Draw();
    //if (levelElement is Enemy enemy)
    //  enemy.Update();
}
player.Draw();

while (gameOn)
{
    ConsoleKeyInfo movementKey = Console.ReadKey(); //Byt variabelnamn? stänger ju av spelet också

    if (movementKey.Key == ConsoleKey.Escape)
    {
        Console.Clear();
        gameOn = false;
    }
    player.Movement(movementKey, levelData);
    player.Draw();
}