using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns
{
  //public enum CoordinateSystem
  //{
  //  Cartesian,
  //  Polar
  //}

  public class Point
  {
    private double x, y;

    // Factory method
    public static Point NewCartesianPoint( double x, double y )
    {
      return NewPolarPoint( x, y );
    }

    public static Point NewPolarPoint( double rho, double theta )
    {
      return new Point( rho * Math.Cos( theta ), rho * Math.Sin( theta ) );
    }

    private Point( double x, double y )
    {
      this.x = x;
      this.y = y;
    }

    public override string ToString()
    {
      return $"{nameof( x )}: {x}, {nameof( y )}: {y}";
    }

    //public Point( double a, double b,
    //  CoordinateSystem system = CoordinateSystem.Cartesian )
    //{
    //  switch (system)
    //  {
    //    case CoordinateSystem.Cartesian:
    //      x = a;
    //      y = b;
    //      break;
    //    case CoordinateSystem.Polar:
    //      x = a * Math.Cos( b );
    //      y = a * Math.Sin( b );
    //      break;
    //    default:
    //      throw new ArgumentOutOfRangeException(nameof(system), system, null);
    //  }
    //}
  }
}
