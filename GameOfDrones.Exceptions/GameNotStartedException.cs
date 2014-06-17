using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Exceptions
{
  /// <summary>
  /// Exception type for the Game Not Started Exception.
  /// </summary>
  [Serializable]
  public class GameNotStartedException : Exception
  {
    public GameNotStartedException() 
    { 
    }
    
    public GameNotStartedException(string message) : base(message) 
    {
    }
    
    public GameNotStartedException(string message, Exception inner) 
      : base(message, inner) 
    { 
    }
    
    protected GameNotStartedException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context)
      : base(info, context) 
    { 
    }
  }
}
