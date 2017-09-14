using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DesignPatternsTut.SolidDesignPrinciples
{
  public enum Relationship
  {
    Parent,
    Child,
    Sibling
  }

  //---------------------------------------------------------------------------

  public class Person
  {
    public string Name;
  }

  //---------------------------------------------------------------------------

  public interface IRelationshipBrowser
  {
    IEnumerable<Person> FindAllChildrenOf( string name );
  }

  //---------------------------------------------------------------------------

  // low-level
  public class Relationships : IRelationshipBrowser
  {
    private List<Tuple<Person, Relationship, Person>> relations = new List<Tuple<Person, Relationship, Person>>();

    //public List<Tuple<Person, Relationship, Person>> Relations => relations;

    public void AddParentAndChild( Person parent, Person child )
    {
      relations.Add( Tuple.Create( parent, Relationship.Parent, child ) );
      relations.Add( Tuple.Create( child, Relationship.Child, parent ) );
    }

    //---------------------------------------------------------------------------

    public IEnumerable<Person> FindAllChildrenOf( string name )
    {
      return relations.Where( x => x.Item1.Name == name &&
                                   x.Item2 == Relationship.Parent 
                                   ).Select( relation => relation.Item3 );
    }
  }

  //---------------------------------------------------------------------------
}
