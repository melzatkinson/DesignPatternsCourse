using System;

namespace StructuralDesignPatterns
{
  //class ColouredShape<T> : T  //CRTP

  public abstract class Shape
  {
    public abstract string AsString { get; }
  }

  class DecoratorCircleStatic : Shape
  {
    private float radius;

    public DecoratorCircleStatic() : this( 0.0f )
    {
      
    }

    public DecoratorCircleStatic( float radius )
    {
      this.radius = radius;
    }

    public void Resize( float factor )
    {
      radius *= factor;
    }

    public override string AsString => $"A circle with radius {radius}";
  }

  class DecoratorSquareStatic : Shape
  {
    private float side;

    public DecoratorSquareStatic() : this( 0.0f )
    {
      
    }

    public DecoratorSquareStatic( float side )
    {
      this.side = side;
    }

    public override string AsString => $"A square with side {side}";
  }

  class ColouredShapeStatic : Shape
  {
    private Shape shape;
    private string colour;

    public ColouredShapeStatic( Shape shape, string colour )
    {
      this.shape = shape;
      this.colour = colour;
    }

    public override string AsString => $"{shape.AsString} has the colour {colour}";
  }

  class TransparentShapeStatic : Shape
  {
    private Shape shape;
    private float transparency;

    public TransparentShapeStatic( Shape shape, float transparency )
    {
      this.shape = shape;
      this.transparency = transparency;
    }

    public override string AsString => $"{shape.AsString} has {transparency * 100.0}% transparency.";
  }

  class ColouredShape<T> : Shape where T : Shape, new()
  {
    private string colour;
    private T shape = new T();

    public ColouredShape() : this( "black" )
    {
    }

    public ColouredShape( string colour )
    {
      this.colour = colour;
    }

    public override string AsString => $"{shape.AsString} has the colour {colour}";
  }

  class TransparencyShape<T> : Shape where T : Shape, new()
  {
    private float transparency;
    private T shape = new T();

    public TransparencyShape() : this( 0.0f )
    {
      
    }
    public TransparencyShape(float transparency)
    {
      this.transparency = transparency;
    }

    public override string AsString => $"{shape.AsString} has {transparency * 100}% transparency";
  }
}
