using System.Security.Cryptography;

namespace Warship_1684
{
  public static class Globals
  {
    public static int MissileTransitFri = 0;
    public static int MissileTransitEne = 0;
    public static int TruDist = Math.Abs(Distance);
    public static int Distance = 0;
    public static int Speed = 0;
    public static Ship PlayerShip  = new Ship();
    public static Boolean MainLoop = false;
    public static int EnemyShipHealth = 10000;
    public static void DistanceVisual()
    {
      int displayDist = TruDist / 2500000;
      string stringDist = string.Concat(Enumerable.Repeat("-", displayDist));
      Console.WriteLine(">" + stringDist + "<");
    }
    public static void EnemyHit(int numRounds, string gun)
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
      EnemyShipHealth = EnemyShipHealth - damage;
    }
    public static void DistanceChange()
    {
      Distance += Speed;
    }
    public static void MissileResolve()
    {
      if (MissileTransitFri != 0)
      {
        int damage = MissileTransitFri * 230;
        EnemyShipHealth = EnemyShipHealth - damage; // NEEDS MORE FIXING TO MAKE FUNCTIONAL
        MissileTransitFri = 0;
      }
    }
  }
  public class Ship
  {
    protected int _structure = 1;
    protected int _armor = 1;
    protected int _acceleration = 1;
    protected int _heatDissipation = 1;
    protected int _heat = 0;
    protected bool _engine = true;
    protected bool _reactor = true;
    protected bool _radiator = true;
    protected bool _cic = true;
    protected bool _ammoFeed = true;
    protected GunType _gunType = GunType.Null;
    protected int _gunNumber = 1;
    protected int _missileNumber = 1;
    public void ChangeStats(string shipClass)
    {
      if (shipClass == "Destroyer")
      {
        _structure = 100;
        _armor = 1500;
        _acceleration = 5880;
        _heatDissipation = 14;
        _heat = 0;
        _engine = true;
        _reactor = true;
        _radiator = true;
        _cic = true;
        _ammoFeed = true;
        _gunType = GunType.Railgun;
        _gunNumber = 3;
        _missileNumber = 2;
      }
      else if (shipClass == "Corvette")
      {
        _structure = 85;
        _armor = 1000;
        _acceleration = 5880;
        _heatDissipation = 9;
        _heat = 0;
        _engine = true;
        _reactor = true;
        _radiator = true;
        _cic = true;
        _ammoFeed = true;
        _gunType = GunType.Coilgun;
        _gunNumber = 3;
        _missileNumber = 0;
      }
      else if (shipClass == "Cruiser")
      {
        _structure = 350;
        _armor = 4000;
        _acceleration = 7290;
        _heatDissipation = 23;
        _heat = 0;
        _engine = true;
        _reactor = true;
        _radiator = true;
        _cic = true;
        _ammoFeed = true;
        _gunType = GunType.Ureb;
        _gunNumber = 8;
        _missileNumber = 12;
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
        if (distance > 35000000) // 35,000 KM
        {
          shots = 0;
        }
        else if (distance <= 35000000)
        {
          float x = distance / 70000000; // 70,000 KM
          float hitPercent = 1 - x;
          float shotsPercent = (_gunNumber * (58 / ammoMod)) * hitPercent;
          shots = (int)shotsPercent;
        }
        _heat += _gunNumber * 2;
      }
      else if (_gunType == GunType.Railgun)
      {
        if (distance > 50000000) // 50,000 KM
        {
          shots = 0;
        }
        else if (distance <= 50000000)
        {
          float x = distance / 100000000; // 100,000 KM
          float hitPercent = 1 - x;
          float shotsPercent = (_gunNumber * (10 / ammoMod)) * hitPercent;
          shots = (int)shotsPercent;
        }
        _heat += _gunNumber * 3;
      }
      else if (_gunType == GunType.Ureb)
      {
        if (distance > 1000000000) // 1,000,000 KM
        {
          shots = 0;
        }
        else if (distance <= 800000000) // 800,000 KM
        {
          float x = distance / 1200000000; // 1,200,000 KM
          float hitPercent = 1 - x;
          float shotsPercent = (_gunNumber * (10 / ammoMod)) * hitPercent;
          shots = (int)shotsPercent;
        }
        _heat += _gunNumber * 3;
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
    public void DissipateHeat()
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
      _heat = newHeat;
    }
    public void FireMissile(int missileNum)
    {
      if (missileNum > _missileNumber)
      {
        missileNum = _missileNumber;
      }
      Globals.MissileTransitFri = Globals.MissileTransitFri + missileNum;
      _heat = _heat + missileNum;
    }
    public string GetGun()
    {
      string gun = "Null";
      if (_gunType == GunType.Coilgun)
      {
        gun = "Coilgun";
      }
      else if (_gunType == GunType.Railgun)
      {
        gun = "Railgun";
      }
      else if (_gunType == GunType.Ureb)
      {
        gun = "Ureb";
      }
      return gun;
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
          Console.WriteLine($"Your ship has been set to: {shipSelection}");
          Globals.Distance = 50000000;
          Console.WriteLine("Dev: Distance has been set to 50000 KM or 50000000 meters. Main game loop starting.");
          Globals.MainLoop = true;
        }
        else if (shipSelection == "Corvette")
        {
          Globals.PlayerShip.ChangeStats("Corvette");
          Console.WriteLine($"Your ship has been set to: {shipSelection}");
          Globals.Distance = 50000000;
          Console.WriteLine("Dev: Distance has been set to 50000 KM or 50000000 meters. Main game loop starting.");
          Globals.MainLoop = true;
        }
        else if (shipSelection == "Cruiser")
        {
          Globals.PlayerShip.ChangeStats("Cruiser");
          Console.WriteLine($"Your ship has been set to: {shipSelection}");
          Globals.Distance = 50000000;
          Console.WriteLine("Dev: Distance has been set to 50000 KM or 50000000 meters. Main game loop starting.");
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
        Globals.TruDist = Math.Abs(Globals.Distance);
        Console.WriteLine(Globals.TruDist);
        Globals.DistanceVisual();
        string playSelection = "Null";
        playSelection = Console.ReadLine();
        if (playSelection == "exit")
        {
          Globals.MainLoop = false;
        }
        else if (playSelection == "Move+")
        {
          int moveVal = Globals.PlayerShip.GetAcceleration();
          Globals.Speed += moveVal;
        }
        else if (playSelection == "Move-")
        {
          int moveVal = Globals.PlayerShip.GetAcceleration();
          Globals.Speed -= moveVal;
        }
        else if (playSelection == "Fire")
        {
          int shotsToEnemy = Globals.PlayerShip.Shoot(Globals.TruDist);
          Globals.EnemyHit(shotsToEnemy, Globals.PlayerShip.GetGun());
          Console.WriteLine("Enemy health is: " + Globals.EnemyShipHealth);
        }
        else if (playSelection == "Missile")
        {
          Console.WriteLine("Number of Missiles to be fired: ");
          string missileAmount = Console.ReadLine();
          int missileAmountInt = int.Parse(missileAmount);
          Globals.MissileTransitFri = missileAmountInt;
          Globals.PlayerShip.FireMissile(missileAmountInt);
          Console.WriteLine($"Number of Missiles fired: {Globals.MissileTransitFri}");
          Console.WriteLine(Globals.EnemyShipHealth);
        }
        Globals.MissileResolve();
        Globals.DistanceChange();
        Globals.PlayerShip.DissipateHeat();
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