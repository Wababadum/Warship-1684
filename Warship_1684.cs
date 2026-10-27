namespace ship_test
{
  public static class Globals
  {
    public static int missileTransitFri = 0;
    public static int missileTransitEne = 0;
    public static int distance = 0;
    public static Ship playerShip = new Ship();
  }
  public class Ship
  {
    private int structure = 100;
    private int armor = 1500;
    private int acceleration = 1960;
    private int heatDissipation = 14;
    private int heat = 0;
    private Boolean engine =  true;
    private Boolean reactor = true;
    private Boolean radiator = true;
    private Boolean cic = true;
    private Boolean ammoFeed = true;
    private GunType _gunType = GunType.Coilgun;
    private int gunNumber = 5;
    private int missileNumber = 2;

    public int Hit(int numRounds, string gun)
    {
      int damage = 0;
      if (gun == "Coilgun")
      {
        damage = numRounds * 3;
      }
      else if (gun == "Railgun")
      {
        damage = numRounds * 9;
      }
      else if (gun == "Ureb")
      {
        damage = numRounds * 27;
      }
      else if (gun == "Laser")
      {
        damage = numRounds * 5;
      }
      else if (gun == "Macron")
      {
        damage = numRounds * 21;
      }
      else if (gun == "Shredgun")
      {
        damage = numRounds * 13;
      }
      structure = structure - damage;
      return structure;
    }
    public int GetStructure()
    {
      return structure;
    }
    public int GetArmor()
    {
      return armor;
    }
    public int GetAcceleration()
    {
      int accel = 0;
      if (engine == false)
      {
        accel =  acceleration / 2;
      }
      else
      {
        accel = acceleration;
      }
      if (reactor == false)
      {
        accel = accel / 2;
      }
      return accel;
    }
    public int Shoot(int distance)
    {
      int shots = 0;
      int ammoMod = 1;
      if (ammoFeed == false)
      {
        ammoMod = 2;
      }
      if (_gunType == GunType.Coilgun)
      {
        if (distance > 35000)
        {
          shots = 0;
        }
        else if (distance <= 35000)
        {
          float x = distance / 70000;
          float hitPercent = 1 - x;
          float shotsPercent = (gunNumber * (58 / ammoMod)) * hitPercent;
          shots = (int)shotsPercent;
        }
      }
      if (reactor == false)
      {
        shots = shots / 2;
      }
      if (cic == false)
      {
        shots = shots / 2;
      }
      return shots;
    }
    public int DissipateHeat()
    {
      int newHeat = 0;
      if (radiator == false)
      {
        int newheatdis = heatDissipation / 2;
        newHeat = heat - newheatdis;
        if (newHeat < 0)
        {
          newHeat = 0;
        }
      }
      else
      {
        newHeat = heat - heatDissipation;
        if (newHeat < 0)
        {
          newHeat = 0;
        }
      }
      return newHeat;
    }
    public int FireMissile(int missileNum)
    {
      if (missileNum > missileNumber)
      {
        missileNum = missileNumber;
      }
      Globals.missileTransitFri = Globals.missileTransitFri + missileNum;
      return 0;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("|------------------------|");
      Console.WriteLine("|       Welcome to       |");
      Console.WriteLine("|      Warship 1684      |");
      Console.WriteLine("|------------------------|\n");
      string shipSelection = "Null";
      while (shipSelection == "Null")
      {
        Console.WriteLine("Please Select Your Ship Class:");
        shipSelection = Console.ReadLine();
        if (shipSelection == "Destroyer")
        {
          Globals.playerShip = new Ship();
          Console.WriteLine("Your ship has been set to: Destroyer");
        }
        else
        {
          Console.WriteLine("Invalid Choice");
          shipSelection = "Null";
        }
      }
    }
  }
  enum GunType 
  {
    Coilgun,
    Railgun,
    Ureb,
    Laser,
    Macron,
    Shredgun
  }
}
