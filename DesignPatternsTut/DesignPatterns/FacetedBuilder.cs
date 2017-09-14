using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns
{
  public class Person
  {
    // address
    public string StreetAddress, Postcode, City;

    // employment
    public string CompanyName, Position;

    public int AnnualIncome;

    public override string ToString()
    {
      return $"{nameof( StreetAddress )}: {StreetAddress}, {nameof( Postcode )}: {Postcode}, {nameof( City )}: {City}, {nameof( CompanyName )}: {CompanyName}, {nameof( Position )}: {Position}, {nameof( AnnualIncome )}: {AnnualIncome}";
    }
  }

  //---------------------------------------------------------------------------

  public class PersonBuilder // facade
  {
    // reference
    protected Person Person = new Person();

    public PersonJobBuilder Works => new PersonJobBuilder( Person );
    public PersonAddressBuider Lives => new PersonAddressBuider( Person );

    public static implicit operator Person(PersonBuilder pb)
    {
      return pb.Person;
    }
  }

  //---------------------------------------------------------------------------

  public class PersonAddressBuider : PersonBuilder
  {
    public PersonAddressBuider( Person person )
    {
      this.Person = person;
    }

    public PersonAddressBuider At( string address )
    {
      Person.StreetAddress = address;
      return this;
    }

    public PersonAddressBuider WithPostCode( string postCode )
    {
      Person.Position = postCode;
      return this;
    }

    public PersonAddressBuider In( string city )
    {
      Person.City = city;
      return this;
    }
  }

  //---------------------------------------------------------------------------

  public class PersonJobBuilder : PersonBuilder
  {
    public PersonJobBuilder( Person person )
    {
      this.Person = person;
    }

    public PersonJobBuilder At( string companyName )
    {
      Person.CompanyName = companyName;
      return this;
    }

    public PersonJobBuilder AsA( string position )
    {
      Person.Position = position;
      return this;
    }

    public PersonJobBuilder Earning( int amount )
    {
      Person.AnnualIncome = amount;
      return this;
    }
  }

  //---------------------------------------------------------------------------
}
