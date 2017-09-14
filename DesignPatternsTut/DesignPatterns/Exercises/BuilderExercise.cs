using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns
{
  public class Field
  {
    public string Name, Type;

    public Field( string name, string type )
    {
      Name = name;
      Type = type;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      const string indent = "  ";
      sb.AppendLine( $"{indent}public {Type} {Name};" );

      return sb.ToString();
    }
  }

  public class CodeBuilder
  {
    private readonly List<Field> _fields = new List<Field>();
    private readonly string _className;

    public CodeBuilder( string className )
    {
      _className = className;
    }

    public CodeBuilder AddField( string name, string type )
    {
      var field = new Field( name, type );
      _fields.Add( field );

      return this;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      sb.AppendLine( $"public class {_className}" );
      sb.AppendLine( "{" );

      foreach( var field in _fields )
      {
        sb.Append( field );
      }

      sb.AppendLine( "}" );

      return sb.ToString();
    }
  }
}
