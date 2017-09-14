using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Autofac;
using NUnit.Framework;

namespace DesignPatterns.CreationalPatterns
{
  public interface IDatabase
  {
    int GetPopulation( string name );
  }

  public class SingletonDatabase : IDatabase
  {
    private Dictionary<string, int> _capitals = new Dictionary<string, int>();

    // This is done regardless of whether it is required.
    //private static readonly SingletonDatabase instance = new SingletonDatabase();

    private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>( () => new SingletonDatabase() );
    public static SingletonDatabase Instance => instance.Value;

    private static int instanceCount;
    public static int Count => instanceCount;

    private SingletonDatabase()
    {
      instanceCount++;

      Console.WriteLine( "Initialising database" );

      var index = 0;
      var capital = "";

      //var file = Path.Combine( new FileInfo( typeof( IDatabase ).Assembly.Location ).DirectoryName, "CreationalPatterns/capitals.txt" );
      var file = @"C:\Users\melissaa\Documents\Visual Studio 2015\Projects\DesignPatternsTut\DesignPatterns\CreationalPatterns\capitals.txt";

      foreach( var line in File.ReadAllLines( file ) )
      {
        if( index == 0 )
        {
          capital = line.Trim();
          ++index;
        }
        else
        {
          _capitals.Add( capital, int.Parse( line.Trim() ) );
          index = 0;
        }
      }
    }

    public int GetPopulation( string name )
    {
      return _capitals[ name ];
    }

    public override string ToString()
    {
      string s = "";
      foreach( var capital in _capitals )
      {
        s += $"{capital.Key}: {capital.Value}\n";
      }

      return s;
    }
  }

  public class OrdinaryDatabase
  {
    private Dictionary<string, int> _capitals = new Dictionary<string, int>();

    private OrdinaryDatabase()
    {
      Console.WriteLine( "Initialising database" );

      var index = 0;
      var capital = "";

      //var file = Path.Combine( new FileInfo( typeof( IDatabase ).Assembly.Location ).DirectoryName, "CreationalPatterns/capitals.txt" );
      var file = @"C:\Users\melissaa\Documents\Visual Studio 2015\Projects\DesignPatternsTut\DesignPatterns\CreationalPatterns\capitals.txt";

      foreach( var line in File.ReadAllLines( file ) )
      {
        if( index == 0 )
        {
          capital = line.Trim();
          ++index;
        }
        else
        {
          _capitals.Add( capital, int.Parse( line.Trim() ) );
          index = 0;
        }
      }
    }

    public int GetPopulation( string name )
    {
      return _capitals[ name ];
    }

    public override string ToString()
    {
      string s = "";
      foreach( var capital in _capitals )
      {
        s += $"{capital.Key}: {capital.Value}\n";
      }

      return s;
    }
  }

  public class SingletonRecordFinder
  {
    public int GetTotalPopulation( IEnumerable<string> names )
    {
      int result = 0;

      foreach( var name in names )
        result += SingletonDatabase.Instance.GetPopulation( name );

      return result;
    }
  }

  public class ConfigurableRecordFinder
  {
    private IDatabase _database;

    public ConfigurableRecordFinder( IDatabase database )
    {
      if( database == null )
      {
        throw new ArgumentNullException( paramName: nameof( database ) );
      }
      _database = database;
    }

    public int GetTotalPopulation( IEnumerable<string> names )
    {
      int result = 0;

      foreach( var name in names )
        result += _database.GetPopulation( name );

      return result;
    }
  }

  public class DummyDatabase : IDatabase
  {
    public int GetPopulation( string name )
    {
      return new Dictionary<string, int>()
      {
        [ "a" ] = 1,
        [ "b" ] = 2,
        [ "c" ] = 3
      }[ name ];
    }
  }

  public class Ceo
  {
    private static string _name;
    private static int _age;

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public int Age
    {
      get { return _age; }
      set { _age = value; }
      }

    public override string ToString()
    {
      return $"{nameof( Name )}: {Name}, {nameof( Age )}: {Age}";
    }
  }


  [TestFixture]
  public class SingletonTests
  {
    [Test]
    public void IsSingletonTest()
    {
      var db1 = SingletonDatabase.Instance;
      var db2 = SingletonDatabase.Instance;

      Assert.That( db1, Is.SameAs( db2 ) );
      Assert.That( SingletonDatabase.Count, Is.EqualTo( 1 ) );
    }

    [Test]
    public void SingletonTotalPopulationTest()
    {
      var rf = new SingletonRecordFinder();
      var names = new[] { "Seoul", "Mexico City" };
      int tp = rf.GetTotalPopulation( names );
      Assert.That( tp, Is.EqualTo( 17500000 + 17400000 ) );
    }

    [Test]
    public void ConfigurablePopulationTest()
    {
      var rf = new ConfigurableRecordFinder( new DummyDatabase() );
      var names = new[] { "a", "c" };
      int tp = rf.GetTotalPopulation( names );
      Assert.That( tp, Is.EqualTo( 4 ) );
    }

    [Test]
    public void DependencyInjectionPopulationTest()
    {
      var cb = new ContainerBuilder();
      cb.RegisterType<OrdinaryDatabase>().As<IDatabase>().SingleInstance();
      cb.RegisterType<ConfigurableRecordFinder>();

      using( var c = cb.Build() )
      {
        var rf = c.Resolve<ConfigurableRecordFinder>();
      }
    }
  }
}
