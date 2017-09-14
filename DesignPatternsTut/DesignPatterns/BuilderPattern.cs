using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns
{
  public class HtmlElement
  {
    public string Name, Text;
    public List<HtmlElement> Elements = new List<HtmlElement>();
    private const int indentSize = 2;

    public HtmlElement()
    {

    }

    public HtmlElement( string name, string text )
    {
      Name = name;
      Text = text;
    }

    private string ToStringImpl( int indent )
    {
      var sb = new StringBuilder();
      var i = new string( ' ', indentSize * indent );
      sb.AppendLine( $"{i}<{Name}>" );

      if( !string.IsNullOrWhiteSpace( Text ) )
      {
        sb.Append( ' ', indentSize * ( indent + 1 ) );
        sb.AppendLine( Text );
      }

      foreach( var e in Elements )
      {
        sb.Append( e.ToStringImpl( indent + 1 ) );
      }

      sb.AppendLine( $"{i}</{Name}>" );

      return sb.ToString();
    }

    public override string ToString()
    {
      return ToStringImpl( 0 );
    }
  }

  public class HtmlBuilder
  {
    private HtmlElement _root = new HtmlElement();
    private readonly string _rootName;

    public HtmlBuilder( string rootName )
    {
      _root.Name = rootName;
      _rootName = rootName;
    }

    //public void AddChild( string childName, string childText )
    //{
    //  var e = new HtmlElement( childName, childText );
    //  _root.Elements.Add( e );
    //}

    // Fluent builder
    public HtmlBuilder AddChild( string childName, string childText )
    {
      var e = new HtmlElement( childName, childText );
      _root.Elements.Add( e );

      return this;
    }

    public override string ToString()
    {
      return _root.ToString();
    }

    public void Clear()
    {
      _root = new HtmlElement { Name = _rootName };
    }
  }
}
