using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns
{
  public interface IHotDrink
  {
    void Consume();
  }

  internal class Tea : IHotDrink
  {
    public void Consume()
    {
      Console.WriteLine( "Drink Tea" );
    }
  }

  internal class Coffee : IHotDrink
  {
    public void Consume()
    {
      Console.WriteLine( "Drink Coffee" );
    }
  }

  public interface IHotDrinkFactory
  {
    IHotDrink Prepare( int amount );
  }

  internal class TeaFactory : IHotDrinkFactory
  {
    public IHotDrink Prepare( int amount )
    {
      Console.WriteLine( $"Prepare with {amount} spoons of tea." );
      return new Tea();
    }
  }

  internal class CoffeeFactory : IHotDrinkFactory
  {
    public IHotDrink Prepare( int amount )
    {
      Console.WriteLine( $"Prepare with {amount} spoons of coffee." );
      return new Coffee();
    }
  }

  public class HotDrinkMachine
  {
    // Violates Open Closed principle
    //  public enum AvailableDrink
    //  {
    //    Coffee, Tea
    //  }

    //  private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

    //  public HotDrinkMachine()
    //  {
    //    foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
    //    {
    //      var factory = (IHotDrinkFactory) Activator.CreateInstance(
    //        Type.GetType("DesignPatterns.CreationalPatterns." + Enum.GetName(typeof(AvailableDrink), drink ) + "Factory" ));

    //      factories.Add(drink, factory);
    //    }
    //  }

    //  public IHotDrink MakeDrink( AvailableDrink drink, int amount )
    //  {
    //    return factories[drink].Prepare(amount);
    //  }

    private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();

    public HotDrinkMachine()
    {
      foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
      {
        if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
        {
          factories.Add(Tuple.Create(t.Name.Replace("Factory", string.Empty),
            (IHotDrinkFactory) Activator.CreateInstance(t)));
        }
      }
    }

    public IHotDrink MakeDrink()
    {
      Console.WriteLine( "Available drinks:" );

      for( var index = 0; index < factories.Count; index++ )
      {
        var tuple = factories[ index ];
        Console.WriteLine( $"{index}: {tuple.Item1}" );
      }

      while( true )
      {
        string s;
        int chosenIndex;

        if( ( s = Console.ReadLine() ) != null &&
              int.TryParse( s, out chosenIndex ) &&
              chosenIndex >= 0 &&
              chosenIndex < factories.Count )
        {
          Console.WriteLine( "Specify amount: " );
          s = Console.ReadLine();

          int chosenAmount;
          if( s != null &&
              int.TryParse( s, out chosenAmount ) &&
              chosenAmount > 0 )
          {
            return factories[ chosenIndex ].Item2.Prepare( chosenAmount );
          }
        }

        Console.WriteLine( "Incorrect. Retry." );
      }
    }
  }
}
