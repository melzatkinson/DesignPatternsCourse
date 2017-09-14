using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DesignPatterns.CreationalPatterns.Exercises
{
  [Serializable]
  public class Point
  {
    public int X, Y;

    public override string ToString()
    {
      return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
    }
  }

  [Serializable]
  public class Line
  {
    public Point Start, End;

    public Line DeepCopy()
    {
      using( var stream = new MemoryStream() )
      {
        var formatter = new BinaryFormatter();
        formatter.Serialize( stream, this );
        stream.Position = 0;
        return ( Line )formatter.Deserialize( stream );
      }

      //return new Line
      //{
      //  Start = new Point() { X = Start.X, Y = Start.Y },
      //  End = new Point() { X = End.X, Y = End.Y }
      //};
    }

    public override string ToString()
    {
      return $"{nameof(Start)}: {Start}, {nameof(End)}: {End}";
    }
  }
}
