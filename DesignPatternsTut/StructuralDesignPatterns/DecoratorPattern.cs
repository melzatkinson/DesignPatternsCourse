using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPatterns
{
  class CodeBuilder
  {
    private StringBuilder builder = new StringBuilder();

    public override string ToString()
    {
      return builder.ToString();
    }

    public void GetObjectData( SerializationInfo info, StreamingContext context )
    {
      ( ( ISerializable )builder ).GetObjectData( info, context );
    }

    public int EnsureCapacity( int capacity )
    {
      return builder.EnsureCapacity( capacity );
    }

    public string ToString( int startIndex, int length )
    {
      return builder.ToString( startIndex, length );
    }

    public CodeBuilder Clear()
    {
      //builder.Clear();
      return this;
    }

    public CodeBuilder Append( char value, int repeatCount )
    {
      builder.Append( value, repeatCount );
      return this;
    }

    public CodeBuilder Append( char[] value, int startIndex, int charCount )
    {
      builder.Append( value, startIndex, charCount );
      return this;
    }

    public CodeBuilder Append( string value )
    {
      builder.Append( value );
      return this;
    }

    public CodeBuilder Append( string value, int startIndex, int count )
    {
      builder.Append( value, startIndex, count );
      return this;
    }

    public CodeBuilder AppendLine()
    {
      builder.AppendLine();
      return this;
    }

    public CodeBuilder AppendLine( string value )
    {
      builder.AppendLine( value );
      return this;
    }

    public void CopyTo( int sourceIndex, char[] destination, int destinationIndex, int count )
    {
      builder.CopyTo( sourceIndex, destination, destinationIndex, count );
    }

    public CodeBuilder Insert( int index, string value, int count )
    {
      builder.Insert( index, value, count );
      return this;
    }

    public CodeBuilder Remove( int startIndex, int length )
    {
      builder.Remove( startIndex, length );
      return this;
    }

    public CodeBuilder Append( bool value )
    {
      builder.Append( value );
      return this;
    }

    public CodeBuilder Append( sbyte value )
    {
      builder.Append( value );
      return this;
    }

    public CodeBuilder Append( byte value )
    {
      builder.Append( value );
      return this;
    }

    public CodeBuilder Append( char value )
    {
      builder.Append( value );
      return this;
    }

    public CodeBuilder Append( short value )
    {
      builder.Append( value );
      return this;
    }

    public CodeBuilder Append( int value )
    {
      builder.Append( value );
      return this;
    }

    public CodeBuilder Append( long value )
    {
      builder.Append( value );
      return this;
    }

    public CodeBuilder Append( float value )
    {
      builder.Append( value );
      return this;
    }

    public CodeBuilder Append( double value )
    {
      builder.Append( value );
      return this;
    }

    public CodeBuilder Append( decimal value )
    {
      builder.Append( value );
      return this;
    }

    public CodeBuilder Append( ushort value )
    {
      builder.Append( value );
      return this;
    }

    public CodeBuilder Append( uint value )
    {
      builder.Append( value );
      return this;
    }

    public CodeBuilder Append( ulong value )
    {
      builder.Append( value );
      return this;
    }

    public CodeBuilder Append( object value )
    {
      builder.Append( value );
      return this;
    }

    public CodeBuilder Append( char[] value )
    {
      builder.Append( value );
      return this;
    }

    public CodeBuilder Insert( int index, string value )
    {
      builder.Insert( index, value );
      return this;
    }

    public CodeBuilder Insert( int index, bool value )
    {
      builder.Insert( index, value );
      return this;
    }

    public CodeBuilder Insert( int index, sbyte value )
    {
      builder.Insert( index, value );
      return this;
    }

    public CodeBuilder Insert( int index, byte value )
    {
      builder.Insert( index, value );
      return this;
    }

    public CodeBuilder Insert( int index, short value )
    {
      builder.Insert( index, value );
      return this;
    }

    public CodeBuilder Insert( int index, char value )
    {
      builder.Insert( index, value );
      return this;
    }

    public CodeBuilder Insert( int index, char[] value )
    {
      builder.Insert( index, value );
      return this;
    }

    public CodeBuilder Insert( int index, char[] value, int startIndex, int charCount )
    {
      builder.Insert( index, value, startIndex, charCount );
      return this;
    }

    public CodeBuilder Insert( int index, int value )
    {
      builder.Insert( index, value );
      return this;
    }

    public CodeBuilder Insert( int index, long value )
    {
      builder.Insert( index, value );
      return this;
    }

    public CodeBuilder Insert( int index, float value )
    {
      builder.Insert( index, value );
      return this;
    }

    public CodeBuilder Insert( int index, double value )
    {
      builder.Insert( index, value );
      return this;
    }

    public CodeBuilder Insert( int index, decimal value )
    {
      builder.Insert( index, value );
      return this;
    }

    public CodeBuilder Insert( int index, ushort value )
    {
      builder.Insert( index, value );
      return this;
    }

    public CodeBuilder Insert( int index, uint value )
    {
      builder.Insert( index, value );
      return this;
    }

    public CodeBuilder Insert( int index, ulong value )
    {
      builder.Insert( index, value );
      return this;
    }

    public CodeBuilder Insert( int index, object value )
    {
      builder.Insert( index, value );
      return this;
    }

    public CodeBuilder AppendFormat( string format, object arg0 )
    {
      builder.AppendFormat( format, arg0 );
      return this;
    }

    public CodeBuilder AppendFormat( string format, object arg0, object arg1 )
    {
      builder.AppendFormat( format, arg0, arg1 );
      return this;
    }

    public CodeBuilder AppendFormat( string format, object arg0, object arg1, object arg2 )
    {
      builder.AppendFormat( format, arg0, arg1, arg2 );
      return this;
    }

    public CodeBuilder AppendFormat( string format, params object[] args )
    {
      builder.AppendFormat( format, args );
      return this;
    }

    public CodeBuilder AppendFormat( IFormatProvider provider, string format, params object[] args )
    {
      builder.AppendFormat( provider, format, args );
      return this;
    }

    public CodeBuilder Replace( string oldValue, string newValue )
    {
      builder.Replace( oldValue, newValue );
      return this;
    }

    public bool Equals( CodeBuilder sb )
    {
      return builder.Equals( sb );
    }

    public CodeBuilder Replace( string oldValue, string newValue, int startIndex, int count )
    {
      builder.Replace( oldValue, newValue, startIndex, count );
      return this;
    }

    public CodeBuilder Replace( char oldChar, char newChar )
    {
      builder.Replace( oldChar, newChar );
      return this;
    }

    public CodeBuilder Replace( char oldChar, char newChar, int startIndex, int count )
    {
      builder.Replace( oldChar, newChar, startIndex, count );
      return this;
    }

    public int Capacity
    {
      get { return builder.Capacity; }
      set { builder.Capacity = value; }
    }

    public int MaxCapacity => builder.MaxCapacity;

    public int Length
    {
      get { return builder.Length; }
      set { builder.Length = value; }
    }

    public char this[ int index ]
    {
      get { return builder[ index ]; }
      set { builder[ index ] = value; }
    }
  }

  class MyStringBuilder
  {
    private StringBuilder builder = new StringBuilder();

    public static implicit operator MyStringBuilder( string s )
    {
      var msb = new MyStringBuilder();
      msb.builder.Append( s );
      return msb;
    }

    public static MyStringBuilder operator +( MyStringBuilder msb, string s )
    {
      msb.Append( s );
      return msb;
    }

    public override string ToString()
    {
      return builder.ToString();
    }

    public void GetObjectData( SerializationInfo info, StreamingContext context )
    {
      ( ( ISerializable )builder ).GetObjectData( info, context );
    }

    public int EnsureCapacity( int capacity )
    {
      return builder.EnsureCapacity( capacity );
    }

    public string ToString( int startIndex, int length )
    {
      return builder.ToString( startIndex, length );
    }

    public MyStringBuilder Clear()
    {
      //builder.Clear();
      return this;
    }

    public MyStringBuilder Append( char value, int repeatCount )
    {
      builder.Append( value, repeatCount );
      return this;
    }

    public MyStringBuilder Append( char[] value, int startIndex, int charCount )
    {
      builder.Append( value, startIndex, charCount );
      return this;
    }

    public MyStringBuilder Append( string value )
    {
      builder.Append( value );
      return this;
    }

    public MyStringBuilder Append( string value, int startIndex, int count )
    {
      builder.Append( value, startIndex, count );
      return this;
    }

    public MyStringBuilder AppendLine()
    {
      builder.AppendLine();
      return this;
    }

    public MyStringBuilder AppendLine( string value )
    {
      builder.AppendLine( value );
      return this;
    }

    public void CopyTo( int sourceIndex, char[] destination, int destinationIndex, int count )
    {
      builder.CopyTo( sourceIndex, destination, destinationIndex, count );
    }

    public MyStringBuilder Insert( int index, string value, int count )
    {
      builder.Insert( index, value, count );
      return this;
    }

    public MyStringBuilder Remove( int startIndex, int length )
    {
      builder.Remove( startIndex, length );
      return this;
    }

    public MyStringBuilder Append( bool value )
    {
      builder.Append( value );
      return this;
    }

    public MyStringBuilder Append( sbyte value )
    {
      builder.Append( value );
      return this;
    }

    public MyStringBuilder Append( byte value )
    {
      builder.Append( value );
      return this;
    }

    public MyStringBuilder Append( char value )
    {
      builder.Append( value );
      return this;
    }

    public MyStringBuilder Append( short value )
    {
      builder.Append( value );
      return this;
    }

    public MyStringBuilder Append( int value )
    {
      builder.Append( value );
      return this;
    }

    public MyStringBuilder Append( long value )
    {
      builder.Append( value );
      return this;
    }

    public MyStringBuilder Append( float value )
    {
      builder.Append( value );
      return this;
    }

    public MyStringBuilder Append( double value )
    {
      builder.Append( value );
      return this;
    }

    public MyStringBuilder Append( decimal value )
    {
      builder.Append( value );
      return this;
    }

    public MyStringBuilder Append( ushort value )
    {
      builder.Append( value );
      return this;
    }

    public MyStringBuilder Append( uint value )
    {
      builder.Append( value );
      return this;
    }

    public MyStringBuilder Append( ulong value )
    {
      builder.Append( value );
      return this;
    }

    public MyStringBuilder Append( object value )
    {
      builder.Append( value );
      return this;
    }

    public MyStringBuilder Append( char[] value )
    {
      builder.Append( value );
      return this;
    }

    public MyStringBuilder Insert( int index, string value )
    {
      builder.Insert( index, value );
      return this;
    }

    public MyStringBuilder Insert( int index, bool value )
    {
      builder.Insert( index, value );
      return this;
    }

    public MyStringBuilder Insert( int index, sbyte value )
    {
      builder.Insert( index, value );
      return this;
    }

    public MyStringBuilder Insert( int index, byte value )
    {
      builder.Insert( index, value );
      return this;
    }

    public MyStringBuilder Insert( int index, short value )
    {
      builder.Insert( index, value );
      return this;
    }

    public MyStringBuilder Insert( int index, char value )
    {
      builder.Insert( index, value );
      return this;
    }

    public MyStringBuilder Insert( int index, char[] value )
    {
      builder.Insert( index, value );
      return this;
    }

    public MyStringBuilder Insert( int index, char[] value, int startIndex, int charCount )
    {
      builder.Insert( index, value, startIndex, charCount );
      return this;
    }

    public MyStringBuilder Insert( int index, int value )
    {
      builder.Insert( index, value );
      return this;
    }

    public MyStringBuilder Insert( int index, long value )
    {
      builder.Insert( index, value );
      return this;
    }

    public MyStringBuilder Insert( int index, float value )
    {
      builder.Insert( index, value );
      return this;
    }

    public MyStringBuilder Insert( int index, double value )
    {
      builder.Insert( index, value );
      return this;
    }

    public MyStringBuilder Insert( int index, decimal value )
    {
      builder.Insert( index, value );
      return this;
    }

    public MyStringBuilder Insert( int index, ushort value )
    {
      builder.Insert( index, value );
      return this;
    }

    public MyStringBuilder Insert( int index, uint value )
    {
      builder.Insert( index, value );
      return this;
    }

    public MyStringBuilder Insert( int index, ulong value )
    {
      builder.Insert( index, value );
      return this;
    }

    public MyStringBuilder Insert( int index, object value )
    {
      builder.Insert( index, value );
      return this;
    }

    public MyStringBuilder AppendFormat( string format, object arg0 )
    {
      builder.AppendFormat( format, arg0 );
      return this;
    }

    public MyStringBuilder AppendFormat( string format, object arg0, object arg1 )
    {
      builder.AppendFormat( format, arg0, arg1 );
      return this;
    }

    public MyStringBuilder AppendFormat( string format, object arg0, object arg1, object arg2 )
    {
      builder.AppendFormat( format, arg0, arg1, arg2 );
      return this;
    }

    public MyStringBuilder AppendFormat( string format, params object[] args )
    {
      builder.AppendFormat( format, args );
      return this;
    }

    public MyStringBuilder AppendFormat( IFormatProvider provider, string format, params object[] args )
    {
      builder.AppendFormat( provider, format, args );
      return this;
    }

    public MyStringBuilder Replace( string oldValue, string newValue )
    {
      builder.Replace( oldValue, newValue );
      return this;
    }

    public bool Equals( MyStringBuilder sb )
    {
      return builder.Equals( sb );
    }

    public MyStringBuilder Replace( string oldValue, string newValue, int startIndex, int count )
    {
      builder.Replace( oldValue, newValue, startIndex, count );
      return this;
    }

    public MyStringBuilder Replace( char oldChar, char newChar )
    {
      builder.Replace( oldChar, newChar );
      return this;
    }

    public MyStringBuilder Replace( char oldChar, char newChar, int startIndex, int count )
    {
      builder.Replace( oldChar, newChar, startIndex, count );
      return this;
    }

    public int Capacity
    {
      get { return builder.Capacity; }
      set { builder.Capacity = value; }
    }

    public int MaxCapacity => builder.MaxCapacity;

    public int Length
    {
      get { return builder.Length; }
      set { builder.Length = value; }
    }

    public char this[ int index ]
    {
      get { return builder[ index ]; }
      set { builder[ index ] = value; }
    }
  }
}
