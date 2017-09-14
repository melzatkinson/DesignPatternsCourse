using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPatterns.Exercises
{
  public class Bird
  {
    public int Age { get; set; }

    public string Fly()
    {
      return ( Age < 10 ) ? "flying" : "too old";
    }
  }

  public class Lizard
  {
    public int Age { get; set; }

    public string Crawl()
    {
      return ( Age > 1 ) ? "crawling" : "too young";
    }
  }

  public class Dragon // no need for interfaces
  {
    private Lizard lizzard = new Lizard();
    private Bird bird = new Bird();
    private int age;

    public int Age
    {
      get { return age; }
      set
      {
        age = value;
        lizzard.Age = value;
        bird.Age = value;
      }
    }

    public string Fly()
    {
      return bird.Fly();
    }

    public string Crawl()
    {
      return lizzard.Crawl();
    }
  }
}
