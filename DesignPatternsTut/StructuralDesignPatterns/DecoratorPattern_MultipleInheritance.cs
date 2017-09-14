//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace StructuralDesignPatterns
//{
//  internal interface IBird
//  {
//    void Fly();
//    int Weight { get; set; }
//  }

//  class Bird : IBird
//  {
//    public int Weight { get; set; }


//    public void Fly()
//    {
//      Console.WriteLine( $"Flying with weight {Weight}" );
//    }
//  }

//  internal interface ILizzard
//  {
//    void Crawl();
//    int Weight { get; set; }
//  }

//  class Lizzard : ILizzard
//  {
//    internal int Age;

//    public int Weight { get; set; }

//    public void Crawl()
//    {
//      Console.WriteLine( $"Crawling with weight {Weight}" );
//    }
//  }

//  class Dragon : IBird, ILizzard
//  {
//    public void Crawl()
//    {
//      lizzard.Crawl();
//    }

//    public void Fly()
//    {
//      bird.Fly();
//    }

//    public int Weight
//    {
//      get { return _weight; }
//      set
//      {
//        _weight = value;
//        bird.Weight = value;
//        lizzard.Weight = value;
//      }
//    }

//    private Bird bird = new Bird();
//    private Lizzard lizzard = new Lizzard();
//    private int _weight;
//  }
//}
