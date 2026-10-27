namespace Warship_1684
{
  public static class Globals
  {
    public static int MissileTransitFri = 0;
    public static int MissileTransitEne = 0;
    public static int Distance = 0;
    public static int Speed = 0;
    public static Ship PlayerShip  = new Ship();
    public static Boolean MainLoop = false;
    

    public static void DistanceVisual()
    {
      int displayDist = Distance / 2500000;
      string stringDist = string.Concat(Enumerable.Repeat("-", displayDist));
      Console.WriteLine(">" + stringDist + "<");
    }
  }
  public class Ship
  {
    protected int _structure = 1;
    protected int _armor = 1;
    protected int _acceleration = 1;
    protected int _heatDissipation = 1;
    protected int _heat = 0;
    protected Boolean _engine = true;
    protected Boolean _reactor = true;
    protected Boolean _radiator = true;
    protected Boolean _cic = true;
    protected Boolean _ammoFeed = true;
    protected GunType _gunType = GunType.Null;
    protected int _gunNumber = 1;
    protected int _missileNumber = 1;

    public void ChangeStats(String shipClass)
    {
      if (shipClass == "Destroyer")
      {
        _structure = 100;
        _armor = 1500;
        _acceleration = 1960;
        _heatDissipation = 14;
        _heat = 0;
        _engine = true;
        _reactor = true;
        _radiator = true;
        _cic = true;
        _ammoFeed = true;
        _gunType = GunType.Coilgun;
        _gunNumber = 5;
        _missileNumber = 2;
      }
    }
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
      _structure = _structure - damage;
      return _structure;
    }
    public int GetStructure()
    {
      return _structure;
    }
    public int GetArmor()
    {
      return _armor;
    }
    public int GetAcceleration()
    {
      int accel = 0;
      if (_engine == false)
      {
        accel =  _acceleration / 2;
      }
      else
      {
        accel = _acceleration;
      }
      if (_reactor == false)
      {
        accel = accel / 2;
      }
      return accel;
    }
    public int Shoot(int distance)
    {
      int shots = 0;
      int ammoMod = 1;
      if (_ammoFeed == false)
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
          float shotsPercent = (_gunNumber * (58 / ammoMod)) * hitPercent;
          shots = (int)shotsPercent;
        }
      }
      if (_reactor == false)
      {
        shots = shots / 2;
      }
      if (_cic == false)
      {
        shots = shots / 2;
      }
      return shots;
    }
    public int DissipateHeat()
    {
      int newHeat = 0;
      if (_radiator == false)
      {
        int newheatdis = _heatDissipation / 2;
        newHeat = _heat - newheatdis;
        if (newHeat < 0)
        {
          newHeat = 0;
        }
      }
      else
      {
        newHeat = _heat - _heatDissipation;
        if (newHeat < 0)
        {
          newHeat = 0;
        }
      }
      return newHeat;
    }
    public int FireMissile(int missileNum)
    {
      if (missileNum > _missileNumber)
      {
        missileNum = _missileNumber;
      }
      Globals.MissileTransitFri = Globals.MissileTransitFri + missileNum;
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
          Globals.PlayerShip.ChangeStats("Destroyer");
          Console.WriteLine("Your ship has been set to: Destroyer");
          Globals.Distance = 100000000;
          Console.WriteLine("Dev: Distance has been set to 100000 KM. Main game loop starting.");
          Globals.MainLoop = true;
        }
        else
        {
          Console.WriteLine("Invalid Choice");
          shipSelection = "Null";
        }
      }
      while (Globals.MainLoop == true)
      {
        Globals.DistanceVisual();
        string playSelection = "Null";
        playSelection = Console.ReadLine();
        if (playSelection == "exit")
        {
          Globals.MainLoop = false;
        }
        else if (playSelection == "Move+")
        {
          Globals.PlayerShip.GetAcceleration();
        }
      }
    }
  }
  public enum GunType 
  {
    Coilgun,
    Railgun,
    Ureb,
    Laser,
    Macron,
    Shredgun,
    Null
  }
}
