using System;
using System.ComponentModel;
using System.Text;
using System.Threading;
using DesignPatterns.CreationalPatterns;
using DesignPatterns.CreationalPatterns.Exercises;
using Point = DesignPatterns.CreationalPatterns.Exercises.Point;

namespace DesignPatterns
{
  // Builder
  //class Program
  //{
  //  static void Main( string[] args )
  //  {
  //    var hello = "hello";
  //    var sb = new StringBuilder();
  //    sb.Append( "<p>" );
  //    sb.Append( hello );
  //    sb.Append( "</p>" );
  //    Console.WriteLine( sb );

  //    var words = new[] { "hello", "world" };
  //    sb.Clear();

  //    sb.Append( "<ul>" );

  //    foreach( var word in words )
  //    {
  //      sb.AppendFormat( "<li>{0}</li>", word );
  //    }

  //    sb.Append( "</ul>" );
  //    Console.WriteLine( sb );

  //    var builder = new HtmlBuilder( "ul" );
  //    builder.AddChild( "li", "hello" ).AddChild( "li", "world" );

  //    Console.WriteLine( builder.ToString() );
  //  }
  //}

  //---------------------------------------------------------------------------

  // Faceted builder
  //class Program
  //{
  //  static void Main( string[] args )
  //  {
  //    var pb = new PersonBuilder();
  //    Person person = pb
  //      .Lives.At( "123 road" )
  //            .In( "A large city" )
  //            .WithPostCode( "An obscure one" )
  //      .Works.At( "companyA" )
  //            .AsA( "Programmer" )
  //            .Earning( 10000000 );

  //    Console.WriteLine( person );
  //  }
  //}

  //---------------------------------------------------------------------------

  // Coding exercise
  //class Program
  //{
  //  static void Main( string[] args )
  //  {
  //    var cb = new CodeBuilder( "Person" ).AddField( "Name", "string" ).AddField( "Age", "int" );

  //    Console.WriteLine( cb.ToString() );
  //  }
  //}

  //---------------------------------------------------------------------------

  // Factories
  //class Program
  //{
  //  static void Main( string[] args )
  //  {
  //    // Factory method
  //    var point1 = Point.NewPolarPoint( 1.0, Math.PI / 2 );
  //    Console.WriteLine( point1 );

  //    // Factory pattern
  //    var point2 = Point1.Factory.NewPolarPoint( 1.0, Math.PI / 2 );
  //    Console.WriteLine( point2 );

  //    // Abstract factory.
  //    var machine = new HotDrinkMachine();
  //    //var drink = machine.MakeDrink( HotDrinkMachine.AvailableDrink.Tea, 2 );
  //    //drink.Consume();

  //    var drink = machine.MakeDrink();
  //    drink.Consume();
  //  }
  //}

  // Exercise
  //class Program
  //{
  //  static void Main( string[] args )
  //  {
  //    var pf = new PersonFactory();
  //    var p1 = pf.CreatePerson( "A" );
  //    var p2 = pf.CreatePerson( "B" );

  //    Console.WriteLine( $"{p1.Id}: {p1.Name}" );
  //    Console.WriteLine( $"{p2.Id}: {p2.Name}" );
  //  }
  //}

  // Prototype
  // Xml serialization needs default constructors for each type.
  // Binary serialization needs each type to be serializable, i.e. [Serializable]
  //class Program
  //{
  //  static void Main( string[] args )
  //  {
  //    var p1 = new PersonPrototype( new[] { "nameA", "surnameA" },
  //                                  new Address( "street1", 1234 ) );

  //    // Copy constructor
  //    var p2 = new PersonPrototype( p1 );
  //    p2.Address.HouseNumber = 1;
  //    p2.Names = new[] { "nameB", "surnameB" };

  //    // Prototype interface
  //    var p3 = p2.DeepCopyXml();
  //    p3.Address.StreetName = "New Street";
  //    p3.Names[0] = "nameC";

  //    Console.WriteLine( p1 );
  //    Console.WriteLine( p2 );
  //    Console.WriteLine( p3 );
  //  }
  //}

  // Prototype exercise
  //class Program
  //{
  //  static void Main( string[] args )
  //  {
  //    var p1 = new Point
  //    {
  //      X = 100,
  //      Y = 100
  //    };

  //    var p2 = new Point
  //    {
  //      X = 200,
  //      Y = 200
  //    };

  //    var p3 = new Point
  //    {
  //      X = 300,
  //      Y = 400
  //    };

  //    var line1 = new Line
  //    {
  //      Start = p1,
  //      End = p2
  //    };

  //    var line2 = line1.DeepCopy();
  //    line2.End = p3;

  //    Console.WriteLine( line1 );
  //    Console.WriteLine( line2 );
  //  }
  //}

    // Singleton
  class Program
  {
    static void Main( string[] args )
    {
      //var db = SingletonDatabase.Instance;
      //var city = "Tokyo";
      //Console.WriteLine($"City {city} has population {db.GetPopulation(city)}" );

      //Console.WriteLine(db);

      var ceo = new Ceo();
      ceo.Name = "Name1234";
      ceo.Age = 55;

      var ceo2 = new Ceo();
      Console.WriteLine( ceo2 );

      Func<object> createSingleton = CreateSingleton;
      Func<object> createNonSingleton = CreateNotSingleton;

      Console.WriteLine( $"Is singleton? {SingletonTester.IsSingleton( createSingleton )}" );
      Console.WriteLine( $"Is singleton? {SingletonTester.IsSingleton( createNonSingleton )}" );
    }

    static Singleton CreateSingleton()
    {
      return Singleton.Instance;
    }

    static NotSingleton CreateNotSingleton()
    {
      NotSingleton notSingleton = new NotSingleton();
     
      return notSingleton;
    }
  }
}
