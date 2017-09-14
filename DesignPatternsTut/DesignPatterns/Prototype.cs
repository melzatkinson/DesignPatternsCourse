using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesignPatterns.CreationalPatterns
{
  //public interface IPrototype<T>
  //{
  //  T DeepCopy();
  //}

  public static class ExtensionMethods
  {
    public static T DeepCopy<T>( this T self )
    {
      var stream = new MemoryStream();
      var formatter = new BinaryFormatter();
      formatter.Serialize( stream, self );
      stream.Seek( 0, SeekOrigin.Begin );
      object copy = formatter.Deserialize( stream );
      stream.Close();
      return ( T )copy;
    }

    public static T DeepCopyXml<T>( this T self )
    {
      using( var ms = new MemoryStream() )
      {
        var stream = new XmlSerializer( typeof( T ) );
        stream.Serialize( ms, self );
        ms.Position = 0;
        return ( T )stream.Deserialize( ms );
      }
    }
  }

  //[Serializable]
  public class PersonPrototype /*: ICloneable*/ 
                               /*: IPrototype<PersonPrototype>*/
  {
    public string[] Names;
    public Address Address;

    public PersonPrototype( string[] names, Address address )
    {
      Names = names;
      Address = address;
    }

    public PersonPrototype( PersonPrototype person )
    {
      Names = ( string[] )person.Names.Clone();
      Address = new Address( person.Address );
    }

    public PersonPrototype()
    {
      
    }

    //public PersonPrototype DeepCopy()
    //{
    //  return new PersonPrototype( ( string[] )Names.Clone(), Address.DeepCopy() );
    //}

    public override string ToString()
    {
      return $"{nameof( Names )}: {string.Join( " ", Names )}, {nameof( Address )}: {Address}";
    }

    //public object Clone()
    //{
    //  return new PersonPrototype( ( string[] )Names.Clone(), ( Address )Address.Clone() );
    //}
  }

  //[Serializable]
  public class Address /*: ICloneable*/ 
                       /*: IPrototype<Address>*/
  {
    public string StreetName;
    public int HouseNumber;

    public Address( string streetName, int houseNumber )
    {
      StreetName = streetName;
      HouseNumber = houseNumber;
    }

    public Address()
    {
      
    }

    public Address( Address address )
    {
      StreetName = address.StreetName;
      HouseNumber = address.HouseNumber;
    }

    //public Address DeepCopy()
    //{
    //  return new Address( StreetName, HouseNumber );
    //}

    public override string ToString()
    {
      return $"{nameof( StreetName )}: {StreetName}, {nameof( HouseNumber )}: {HouseNumber}";
    }

    //public object Clone()
    //{
    //  return new Address( StreetName, HouseNumber );
    //}
  }
}
