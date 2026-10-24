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
        levelElement.Draw();
    }
    player.Draw();
    ConsoleKeyInfo movementKey = Console.ReadKey();
    Console.Write(" ");
    switch (movementKey.Key)
    {
        case ConsoleKey.UpArrow:
            if (levelData.Elements.Any(e => e.XPosition == player.XPosition 
                && e.YPosition == player.YPosition-1 
                && (e.Character == 'r' || e.Character == 's')))
            {
                Console.WriteLine("COMBAT!!");
            }

            if (!levelData.Elements.Any(e => e.XPosition == player.XPosition && e.YPosition == player.YPosition-1))
            { 
                player.YPosition--; 
            }

            foreach (var element in levelData.Elements)
            {
                if (element is Enemy enemy)
                {
                    enemy.Update();
                }
            }
            break;

        case ConsoleKey.DownArrow:
            if (levelData.Elements.Any(e => e.XPosition == player.XPosition 
                && e.YPosition == player.YPosition+1 
                && (e.Character == 'r' || e.Character == 's')))
            {
                Console.WriteLine("COMBAT!!");
            }

            if (!levelData.Elements.Any(e => e.XPosition == player.XPosition && e.YPosition == player.YPosition+1))
            { 
                player.YPosition++; 
            }

            foreach (var element in levelData.Elements)
            {
                if (element is Enemy enemy)
                {
                    enemy.Update();
                }
            }
            break;

        case ConsoleKey.LeftArrow:
            if (levelData.Elements.Any(e => e.XPosition == player.XPosition-1 
                && e.YPosition == player.YPosition 
                && (e.Character == 'r' || e.Character == 's')))
            {
                Console.WriteLine("COMBAT!!");
            }
            
            if (!levelData.Elements.Any(e => e.XPosition == player.XPosition-1 && e.YPosition == player.YPosition))
            { player.XPosition--; }

            foreach (var element in levelData.Elements)
            {
                if (element is Enemy enemy)
                {
                    enemy.Update();
                }
            }

            break;

        case ConsoleKey.RightArrow:
            if (levelData.Elements.Any(e => e.XPosition == player.XPosition+1 
                && e.YPosition == player.YPosition 
                && (e.Character == 'r' || e.Character == 's')))
            {
                Console.WriteLine("COMBAT!!");
            }
            
            if (!levelData.Elements.Any(e => e.XPosition == player.XPosition+1 && e.YPosition == player.YPosition))
            { 
                player.XPosition++; 
            }

            foreach (var element in levelData.Elements)
            {
                if (element is Enemy enemy)
                {
                    enemy.Update();
                }
            }
            break;

        //Hur gör man så texten inte skrivs ut mitt i banan, fixa
        case ConsoleKey.Escape:
            Console.WriteLine("Are you sure you want to quit? \n ENTER to quit, alternatively BACKSPACE to keep playing."); //Varför Skriver den inte ut första bokstavevn? 
            // NÅgot att göra med console readlkey?
            ConsoleKeyInfo quitOrNotKey = Console.ReadKey(true);

            gameOn = quitOrNotKey.Key switch
            {
                ConsoleKey.Enter => false,
                ConsoleKey.Backspace => true,
                _ => gameOn
            };

            //Kolla fix för nullable readlien, antingen ! eller annat
            // int choice = int.Parse(Console.ReadLine()!);
            // gameOn = choice != 1;
            break;
    }
}