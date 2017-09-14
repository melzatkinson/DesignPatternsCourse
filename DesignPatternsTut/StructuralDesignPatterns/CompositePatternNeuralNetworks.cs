using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPatterns
{
  static class ExtensionMethods
  {
    public static void ConnectTo( this IEnumerable<Neuron> self, IEnumerable<Neuron> other )
    {
      if( ReferenceEquals( self, other ) ) return;

      foreach( var from in self )
      {
        foreach( var to in other )
        {
          from.Out.Add( to );
          to.In.Add( from );
        }
      }
    }
  }

  class Neuron : IEnumerable<Neuron>
  {
    public float value;
    public List<Neuron> In, Out;

    public IEnumerator<Neuron> GetEnumerator()
    {
      yield return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }

  class NeuronLayer : Collection<Neuron>
  {
    
  }
}
