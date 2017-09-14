using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPatterns
{
  class User
  {
    private string fullName;

    public User( string fullName )
    {
      this.fullName = fullName;
    }
  }

  public class User2
  {
    private static List<string> strings = new List<string>();
    private List<int> names = new List<int>();

    public User2( string fullName )
    {
      var splitStrings = fullName.Split( ' ' );
      foreach( var s in splitStrings )
      {
        names.Add( GetOrAdd( s ) );
      }
    }

    public string FullName => string.Join( " ", names.Select( i => strings[ i ] ) );

    int GetOrAdd( string s )
    {
      int index = strings.IndexOf( s );
      if( index != -1 ) return index;

      strings.Add( s );
      return strings.Count - 1;
    }
  }
}
