using UnityEngine;

namespace Mitfart.LeoECSLite.UniLeo.LeoECSLite.UniLeo.Runtime{
   public abstract class ScrStruct<T> : ScriptableObject where T : struct{
      public T Value{ get; protected set; }
   }
}
