using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.Exercises
{
  public class SingletonTester
  {
    public static bool IsSingleton( Func<object> func )
    {
      object object1 = func.Invoke();
      object object2 = func.Invoke();

      return object1 == object2;

      // Answer
      //var obj1 = func();
      //var obj2 = func();
      //return ReferenceEquals( obj1, obj2 );
    }
  }

  public class Singleton
  {
    private static Lazy<Singleton> instance = new Lazy<Singleton>( () => new Singleton() );
    public static Singleton Instance => instance.Value;
  }

  public class NotSingleton
  {
    public NotSingleton()
    {
    }
  }
}
