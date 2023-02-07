using UnityEngine;

namespace Mitfart.LeoECSLite.UniLeo.Providers{
   public abstract class ScrComponent<TComponent> : ScriptableObject where TComponent : struct{
      [field: SerializeField] public TComponent Value { get; protected set; }
   }
}
