using UnityEngine;

namespace Mitfart.Plugins.Mitfart.LeoECSLite.UniLeo.Convert.Providers {
  public abstract class ScrComponent<TComponent> : ScriptableObject where TComponent : struct {
    [field: SerializeField] protected TComponent value;

    public virtual TComponent GetComponent() => value;
  }
}