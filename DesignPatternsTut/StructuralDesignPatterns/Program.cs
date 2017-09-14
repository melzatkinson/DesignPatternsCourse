using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using StructuralDesignPatterns.Exercises;
using Autofac;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;

namespace StructuralDesignPatterns
{
  // Adapter pattern

  //class Program
  //{
  //  private static readonly List<VectorObject> vectorObjects = new List<VectorObject>()
  //  {
  //    new VectorRectangle(1, 1, 10, 10),
  //    new VectorRectangle(3, 3, 6, 6)
  //  };

  //  public static void DrawPoint( Point p )
  //  {
  //    Console.Write( "." );
  //  }

  //  static void Main( string[] args )
  //  {
  //    //Draw();
  //    //Draw();

  //    Square square = new Square();
  //    square.Side = 5;

  //    IRectangle squareToRectangle = new SquareToRectangleAdapter(square);

  //    Console.WriteLine( ExtensionMethods.Area(squareToRectangle));
  //  }

  //  private static void Draw()
  //  {
  //    foreach (var vectorObject in vectorObjects)
  //    {
  //      foreach (var line in vectorObject)
  //      {
  //        var adapter = new LineToPointAdapter(line);
  //        foreach (var point in adapter)
  //        {
  //          DrawPoint(point);
  //        }
  //      }
  //    }
  //  }
  //}

  // Bridge pattern

  //class Program
  //{
  //  static void Main( string[] args )
  //  {
  //    IRenderer renderer = new RasterRenderer();
  //    IRenderer renderer2 = new VectorRenderer();
  //    var circle = new Circle( renderer2, 5 );
  //    circle.Draw();
  //    circle.Resize( 2 );
  //    circle.Draw();

  //    var cb = new ContainerBuilder();
  //    cb.RegisterType<VectorRenderer>().As<IRenderer>().SingleInstance();

  //    cb.Register( ( c, p ) => new Circle( c.Resolve<IRenderer>(), p.Positional<float>( 0 ) ) );

  //    using( var c = cb.Build() )
  //    {
  //      var circle = c.Resolve<Circle>( new PositionalParameter( 0, 5.0f ) );
  //      circle.Draw();
  //      circle.Resize( 2.0f );
  //      circle.Draw();
  //    }

  //    Console.WriteLine( new Triangle( new RasterRenderer() ).ToString() );
  //    Console.WriteLine(new VectorSquare());
  //    Console.WriteLine( new RasterSquare() );
  //  }
  //}

  // Composite pattern
  //class Program
  //{
  //  static void Main( string[] args )
  //  {
  //    var drawing = new GraphicObject() { Name = "My Drawing" };
  //    drawing.Children.Add( new Square() { Color = "Red" } );
  //    drawing.Children.Add( new Circle() { Color = "Yellow" } );

  //    var group = new GraphicObject();
  //    group.Children.Add( new Circle() { Color = "Blue" } );
  //    group.Children.Add( new Square() { Color = "Blue" } );
  //    drawing.Children.Add( group );

  //    Console.WriteLine( drawing );
  //  }
  //}

  // Composite pattern - neural networks.
  //class Program
  //{
  //  static void Main(string[] args)
  //  {
  //    var neuron1 = new Neuron();
  //    var neuron2 = new Neuron();

  //    neuron1.ConnectTo(neuron2);

  //    NeuronLayer layer1 = new NeuronLayer();
  //    NeuronLayer layer2 = new NeuronLayer();

  //    neuron1.ConnectTo(layer1);
  //    layer1.ConnectTo(layer2);
  //  }
  //}

  // Composite pattern exercise
  //class Program
  //{
  //  static void Main( string[] args )
  //  {
  //    ManyValues multipleValue = new ManyValues();
  //    multipleValue.Add( 3 );
  //    multipleValue.Add( 5 );

  //    SingleValue singleValue = new SingleValue();
  //    singleValue.Value = 2;

  //    Console.WriteLine( CompositeExtensionMethods.Sum( new List<IValueContainer> { multipleValue, singleValue } ));
  //  }
  //}

  // Decorator Pattern
  //class Program
  //{
  //  static void Main( string[] args )
  //  {
  //    //var cb = new CodeBuilder();
  //    //cb.AppendLine("class test")
  //    //  .AppendLine("{")
  //    //  .AppendLine("}");

  //    //Console.WriteLine(cb);

  //    //MyStringBuilder s = "Hello ";
  //    //s += "world";
  //    //Console.WriteLine(s);

  //    //var d = new Dragon();
  //    //d.Weight = 123;
  //    //d.Fly();
  //    //d.Crawl();

  //    //var square = new DecoratorSquare( 1.5f );
  //    //Console.WriteLine( square.AsString );

  //    //var redSquare = new ColouredShape( square, "red" );
  //    //Console.WriteLine( redSquare.AsString );

  //    //var redHalfTransparentSquare = new TransparentShape(redSquare, 0.5f);
  //    //Console.WriteLine(redHalfTransparentSquare.AsString);

  //    //var redSquare = new ColouredShape<DecoratorSquareStatic>("red");
  //    //Console.WriteLine(redSquare.AsString);

  //    //var circle = new TransparencyShape<ColouredShape<DecoratorCircleStatic>>(0.4f);
  //    //Console.WriteLine(circle.AsString);

  //    var dragon = new Dragon();
  //    Console.WriteLine(dragon.Fly());
  //    Console.WriteLine( dragon.Crawl() );
  //    dragon.Age = 5;
  //    Console.WriteLine( dragon.Fly() );
  //    Console.WriteLine( dragon.Crawl() );
  //    dragon.Age = 15;
  //    Console.WriteLine( dragon.Fly() );
  //    Console.WriteLine( dragon.Crawl() );
  //  }
  //}

  // Flyweight Pattern
  [TestFixture]
  class Program
  {
    public static void Main(string[] args)
    {
      
    }

    [Test]
    public void TestUser() // 1674386 // 1633758
    {
      var firstNames = Enumerable.Range( 0, 100 ).Select( _ => RandomString() );
      var lastNames = Enumerable.Range( 0, 100 ).Select( _ => RandomString() );

      var users = new List<User>();

      foreach (var firstName in firstNames )
      {
        foreach (var lastName in lastNames )
        {
          users.Add(new User($"{firstName} {lastName}"));
        }
      }

      ForceGC();

      dotMemory.Check(memory =>
      {
        Console.WriteLine(memory.SizeInBytes);
      });
    }

    [Test]
    public void TestUser2()
    {
      var firstNames = Enumerable.Range( 0, 100 ).Select( _ => RandomString() );
      var lastNames = Enumerable.Range( 0, 100 ).Select( _ => RandomString() );

      var users = new List<User2>();

      foreach( var firstName in firstNames )
      {
        foreach( var lastName in lastNames )
        {
          users.Add( new User2( $"{firstName} {lastName}" ) );
        }
      }

      ForceGC();

      dotMemory.Check( memory =>
      {
        Console.WriteLine( memory.SizeInBytes );
      } );
    }

    private void ForceGC()
    {
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
    }

    private string RandomString()
    {
      Random rand = new Random();
      return new string( 
        Enumerable.Range( 0, 10 )
        .Select( i => ( char )( 'a' + rand.Next( 26 ) ) )
        .ToArray() );
    }
  }
}
