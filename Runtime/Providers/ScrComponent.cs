using UnityEngine;

namespace Mitfart.LeoECSLite.UniLeo.Providers{
   public abstract class ScrComponent<TComponent> : ScriptableObject where TComponent : struct {
      [field: SerializeField] protected TComponent value;

      public virtual TComponent GetComponent() => value;
   }
}
