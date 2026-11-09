namespace Csharp_grid;
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine(Global.location);
            Console.WriteLine("Choose direction of movement");
            Global.playInput = Console.ReadLine();
            switch(Global.playInput)
            {
                case "w":
                    if (Global.ValidPos(Global.x, Global.y, "w") == true)
                    {
                        Global.y += 1;
                        Global.location = Global.CombineLimit(Global.x, Global.y);
                    }
                    else
                    {
                        Console.WriteLine("Invalid direction");
                    }
                    break;
                case "a":
                    if (Global.ValidPos(Global.x, Global.y, "a") == true)
                    {
                        Global.x -= 1;
                        Global.location = Global.CombineLimit(Global.x, Global.y);
                    }
                    else
                    {
                        Console.WriteLine("Invalid direction");
                    }
                    break;
                case "s":
                    if (Global.ValidPos(Global.x, Global.y, "s") == true)
                    {
                        Global.y -= 1;
                        Global.location = Global.CombineLimit(Global.x, Global.y);
                    }
                    else
                    {
                        Console.WriteLine("Invalid direction");
                    }
                    break;
                case "d":
                    if (Global.ValidPos(Global.x, Global.y, "d") == true)
                    {
                        Global.x += 1;
                        Global.location = Global.CombineLimit(Global.x, Global.y);
                    }
                    else
                    {
                        Console.WriteLine("Invalid direction");
                    }
                    break;
            }
        }
    }
}
public static class Global
{
    public static string location = "0 0";
    public static int x = 0;
    public static int y = 0;
    public static string playInput = "Null";
    public static int mapSizeLimit = 10;
    /// <summary>
    /// Checks if future position is valid
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    public static bool ValidPos(int x, int y, string direction)
    {
        // is just the ValidPos script from the og grid_test script
        int Nx = x;
        int Ny = y;
        switch(direction)
        {
            case "w":
                Ny += 1;
                break;
            case "a":
                Nx -= 1;
                break;
            case "s":
                Ny -= 1;
                break;
            case "d":
                Nx += 1;
                break;
        }
        string temp_Loc = $"{Nx} {Ny}";
        List<string> Walls = new List<string> {"0 2", "1 2", "2 2", "3 2", "-1 2", "-2 2", "-3 2"};
        bool valid = Walls.Contains(temp_Loc);
        return valid;
    }
    /// <summary>
    /// Updates the player position with respect to the map size limit
    /// </summary>
    /// <param name="fx"></param>
    /// <param name="fy"></param>
    public static string CombineLimit(int fx, int fy)
    {
        // CombineLimit from og
        if (fx > mapSizeLimit)
        {
            Global.x = mapSizeLimit;
        }
        if (-fx < -mapSizeLimit)
        {
            Global.x = -mapSizeLimit;
        }
        if (fy > mapSizeLimit)
        {
            Global.y = mapSizeLimit;
            
        }
        if (-fy < -mapSizeLimit)
        {
            Global.y = -mapSizeLimit;
            string new_Loc = $"{Global.x} {Global.y}";
            return new_Loc;
        }
    }
    public static bool CombatLoop(string location)
    {
        // general combat loop. will contain all needed code in a while == true loop
    }
}
public static class Player
{
    public static int playHealth = 45;
}
