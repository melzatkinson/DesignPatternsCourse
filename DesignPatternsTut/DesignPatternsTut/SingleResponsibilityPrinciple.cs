using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;

namespace DesignPatternsTut.SolidDesignPrinciples
{
  public class Journal
  {
    private readonly List<string> entries = new List<string>();
    private static int count = 0;

    //---------------------------------------------------------------------------

    public int AddEntry( string text )
    {
      entries.Add( $"{++count}: {text}" );
      return count;
    }

    //---------------------------------------------------------------------------

    public void RemoveEntry( int index )
    {
      entries.RemoveAt( index );
    }

    //---------------------------------------------------------------------------

    public override string ToString()
    {
      return string.Join( Environment.NewLine, entries );
    }

    //---------------------------------------------------------------------------

    //public void Save( string filename )
    //{
    //  File.WriteAllText( filename, entries.ToString() );
    //}

    ////---------------------------------------------------------------------------

    //public static Journal Load( string filename )
    //{
    //  return new Journal();
    //}

    ////---------------------------------------------------------------------------

    //public void Load(Uri uri)
    //{

    //}

    ////---------------------------------------------------------------------------
  }

  public class Persistence
  {
    public void SaveToFile( Journal journal, string filename, bool overwrite = false )
    {
      if( overwrite || !File.Exists( filename ) )
        File.WriteAllText( filename, journal.ToString() );
    }

    //---------------------------------------------------------------------------

    public static Journal Load( string filename )
    {
      return new Journal();
    }

    //---------------------------------------------------------------------------

    public void Load( Uri uri )
    {

    }

    //--------------------------------------------------------------------------- 
  }
}
