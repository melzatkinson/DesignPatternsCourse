using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPatterns.Exercises
{
  public abstract class Shape
  {
    protected IRenderer _renderer;

    public Shape( IRenderer renderer )
    {
      _renderer = renderer;
    }

    public override string ToString()
    {
      return $"Drawing {Name} as {_renderer.WhatToRenderAs}";
    }

    public string Name { get; set; }
  }

  public interface IRenderer
  {
    string WhatToRenderAs { get; }
  }

  public class VectorRenderer : IRenderer
  {
    public VectorRenderer()
    {
      WhatToRenderAs = "lines";
    }

    public string WhatToRenderAs { get; }
  }

  public class RasterRenderer : IRenderer
  {
    public RasterRenderer()
    {
      WhatToRenderAs = "pixels";
    }

    public string WhatToRenderAs { get; }
  }

  public class Triangle : Shape
  {
    public Triangle( IRenderer renderer ) : base( renderer )
    {
      Name = "Triangle";
    }
  }

  public class Square : Shape
  {
    public Square( IRenderer renderer ) : base( renderer )
    {
      Name = "Square";
    }
  }

  public class VectorSquare : Square
  {
    public VectorSquare() : base( new VectorRenderer() )
    {
    }
  }

  public class RasterSquare : Square
  {
    public RasterSquare() : base( new RasterRenderer() )
    {
    }
  }

  // imagine VectorTriangle and RasterTriangle are here too
}
