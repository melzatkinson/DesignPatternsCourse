using System;
using System.Collections.Generic;

namespace DesignPatternsTut.SolidDesignPrinciples
{
  public enum Colour
  {
    Red, Green, Blue
  }

  public enum Size
  {
    Small, Medium, Large
  }

  //---------------------------------------------------------------------------

  public class Product
  {
    public string Name;
    public Colour Colour;
    public Size Size;

    //---------------------------------------------------------------------------

    public Product( string name, Colour colour, Size size )
    {
      Name = name;
      Colour = colour;
      Size = size;
    }
  }

  //---------------------------------------------------------------------------

  public class ProductFilter
  {
    public static IEnumerable<Product> FilterBySize( IEnumerable<Product> products, Size size )
    {
      foreach( var product in products )
        if( product.Size == size )
          yield return product;
    }

    //---------------------------------------------------------------------------

    public IEnumerable<Product> FilterByColour( IEnumerable<Product> products, Colour colour )
    {
      foreach( var product in products )
        if( product.Colour == colour )
          yield return product;
    }

    //---------------------------------------------------------------------------

    public IEnumerable<Product> FilterBySizeAndColour( IEnumerable<Product> products, Size size, Colour colour )
    {
      foreach( var product in products )
        if( product.Colour == colour && product.Size == size )
          yield return product;
    }
  }

  //---------------------------------------------------------------------------

  public interface ISpecification<T>
  {
    bool IsSatisfied( T t );
  }

  //---------------------------------------------------------------------------

  public interface IFilter<T>
  {
    IEnumerable<T> Filter( IEnumerable<T> items, ISpecification<T> specification );
  }

  //---------------------------------------------------------------------------

  public class AndSpecification<T> : ISpecification<T>
  {
    private ISpecification<T> first, second;

    public AndSpecification( ISpecification<T> first, ISpecification<T> second )
    {
      this.first = first;
      this.second = second;
    }

    public bool IsSatisfied( T t )
    {
      return first.IsSatisfied( t ) && second.IsSatisfied( t );
    }
  }

  //---------------------------------------------------------------------------

  public class ColourSpecification : ISpecification<Product>
  {
    private readonly Colour _colour;

    public ColourSpecification( Colour colour )
    {
      _colour = colour;
    }
    public bool IsSatisfied( Product t )
    {
      return _colour == t.Colour;
    }
  }

  //---------------------------------------------------------------------------

  public class SizeSpecification : ISpecification<Product>
  {
    private readonly Size _size;

    public SizeSpecification( Size size )
    {
      _size = size;
    }

    public bool IsSatisfied( Product t )
    {
      return t.Size == _size;
    }
  }

  //---------------------------------------------------------------------------

  public class ImprovedFilter : IFilter<Product>
  {
    public IEnumerable<Product> Filter( IEnumerable<Product> items, ISpecification<Product> specification )
    {
      foreach( var item in items )
        if( specification.IsSatisfied( item ) )
          yield return item;
    }
  }

  //---------------------------------------------------------------------------
}
