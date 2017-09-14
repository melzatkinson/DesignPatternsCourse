using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPatterns
{
  public interface IShape
  {
    string AsString { get; }
  }

  class DecoratorCircle : IShape
  {
    private float radius;

    public DecoratorCircle( float radius )
    {
      this.radius = radius;
    }

    public void Resize( float factor )
    {
      radius *= factor;
    }

    public string AsString => $"A circle with radius {radius}";
  }

  class DecoratorSquare : IShape
  {
    private float side;

    public DecoratorSquare( float side )
    {
      this.side = side;
    }

    public string AsString => $"A square with side {side}";
  }

  class ColouredShape : IShape
  {
    private IShape shape;
    private string colour;

    public ColouredShape( IShape shape, string colour )
    {
      this.shape = shape;
      this.colour = colour;
    }

    public string AsString => $"{shape.AsString} has the colour {colour}";
  }

  class TransparentShape : IShape
  {
    private IShape shape;
    private float transparency;

    public TransparentShape( IShape shape, float transparency )
    {
      this.shape = shape;
      this.transparency = transparency;
    }

    public string AsString => $"{shape.AsString} has {transparency * 100.0}% transparency.";
  }
}
