using System;

namespace DesignPatterns.CreationalPatterns
{
  //public enum CoordinateSystem
  //{
  //  Cartesian,
  //  Polar
  //}

  public class Point1
  {
    private double x, y;

    private Point1( double x, double y )
    {
      this.x = x;
      this.y = y;
    }

    public override string ToString()
    {
      return $"{nameof( x )}: {x}, {nameof( y )}: {y}";
    }

    public static class Factory
    {
      public static Point1 NewCartesianPoint( double x, double y )
      {
        return new Point1( x, y );
      }

      public static Point1 NewPolarPoint( double rho, double theta )
      {
        return new Point1( rho * Math.Cos( theta ), rho * Math.Sin( theta ) );
      }
    }
  }
}
