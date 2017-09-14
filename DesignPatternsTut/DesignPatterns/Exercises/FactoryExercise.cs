namespace DesignPatterns.CreationalPatterns.Exercises
{
  public class Person
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }

  public class PersonFactory
  {
    private int _id;

    public Person CreatePerson( string name )
    {
      var person = new Person { Name = name, Id = _id };
      ++_id;
      return person;
    }
  }
}
