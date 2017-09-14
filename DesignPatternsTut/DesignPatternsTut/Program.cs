using System;
using System.Diagnostics;
using System.Linq;
using DesignPatterns;
using DesignPatternsTut.SolidDesignPrinciples;

namespace DesignPatternsTut
{
  // Open Closed Principle
  class Program
  {
    static void Main( string[] args )
    {
      var item1 = new Product( "Item1", Colour.Green, Size.Small );
      var item2 = new Product( "Item2", Colour.Green, Size.Large );
      var item3 = new Product( "Item3", Colour.Blue, Size.Large );

      Product[] products = { item1, item2, item3 };

      var filter = new ProductFilter();
      Console.WriteLine( "Green products (old):" );
      foreach( var product in filter.FilterByColour( products, Colour.Green ) )
      {
        Console.WriteLine( $" - {product.Name} is green" );
      }

      var improvedFilter = new ImprovedFilter();
      Console.WriteLine( "Green products (new):" );

      foreach( var product in improvedFilter.Filter( products, new ColourSpecification( Colour.Green ) ) )
      {
        Console.WriteLine( $"{product.Name} is green" );
      }

      Console.WriteLine( "Large blue items" );

      foreach( var product in improvedFilter.Filter( products, new AndSpecification<Product>( new ColourSpecification( Colour.Blue ),
                                                                                            new SizeSpecification( Size.Large ) ) ) )
      {
        Console.WriteLine( $"{product.Name} is large and blue" );
      }
    }
  }

  //---------------------------------------------------------------------------

  // Single Responsibility Principle
  //class Program
  //{
  //  static void Main( string[] args )
  //  {
  //    var journal = new Journal();
  //    journal.AddEntry( "It is hot today." );
  //    journal.AddEntry( "It is cold today." );

  //    var persistence = new Persistence();
  //    var filename = @"c:\temp\jounal.txt";
  //    persistence.SaveToFile( journal, filename );
  //    Process.Start( filename );
  //    Console.WriteLine( journal.ToString() );
  //  }
  //}

  //---------------------------------------------------------------------------

  // Liskov Substition principle.
  //class Program
  //{
  //  public static int Area( Rectangle r ) => r.Width * r.Height;

  //  static void Main( string[] args )
  //  {
  //    var rectangle = new Rectangle( 2, 3 );
  //    Console.WriteLine( $"{rectangle} has area {Area( rectangle )}" );

  //    Rectangle square = new Square();
  //    square.Width = 4;
  //    Console.WriteLine( $"{square} has area {Area( square )}" );
  //  }
  //}

  //---------------------------------------------------------------------------

  // Dependency Inversion Principle
  //class Research
  //{
  //public Research( Relationships relationships )
  //{
  //  var relations = relationships.Relations;
  //  foreach( var relation in relations.Where( x => x.Item1.Name == "John" &&
  //                                            x.Item2 == Relationship.Parent ) )
  //  {
  //    Console.WriteLine( $"John has a child called {relation.Item3.Name}" );
  //  }
  //}

  //---------------------------------------------------------------------------

  //public Research( IRelationshipBrowser browser )
  //{
  //  foreach( var person in browser.FindAllChildrenOf( "John" ) )
  //  {
  //    Console.WriteLine( $"John has a child called {person.Name}" );
  //  }
  //}

  //---------------------------------------------------------------------------

  //static void Main( string[] args )
  //{
  //  var parent = new Person { Name = "John" };
  //  var child1 = new Person { Name = "Chris" };
  //  var child2 = new Person { Name = "Mary" };

  //  var relationships = new Relationships();
  //  relationships.AddParentAndChild( parent, child1 );
  //  relationships.AddParentAndChild( parent, child2 );

  //  new Research( relationships );
  //}

  //---------------------------------------------------------------------------
  //}
}
