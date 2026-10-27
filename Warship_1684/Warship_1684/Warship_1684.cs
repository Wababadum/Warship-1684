namespace ship_test
{
  public static class Globals
  {
    public static int MissileTransitFri = 0;
    public static int MissileTransitEne = 0;
    public static int Distance = 0;
    public static Ship PlayerShip = new Ship();
  }
  public class Ship
  {
    private int _structure = 100;
    private int _armor = 1500;
    private int _acceleration = 1960;
    private int _heatDissipation = 14;
    private int _heat = 0;
    private Boolean _engine =  true;
    private Boolean _reactor = true;
    private Boolean _radiator = true;
    private Boolean _cic = true;
    private Boolean _ammoFeed = true;
    private GunType _gunType = GunType.Coilgun;
    private int _gunNumber = 5;
    private int _missileNumber = 2;

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
          Globals.PlayerShip = new Ship();
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
