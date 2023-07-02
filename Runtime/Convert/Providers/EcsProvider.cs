using Leopotam.EcsLite;

namespace Mitfart.Plugins.Mitfart.LeoECSLite.UniLeo.Convert.Providers {
  public abstract class EcsProvider<TComponent> : BaseEcsProvider where TComponent : struct {
    public TComponent component;

    public override void Convert(int e, EcsWorld world) {
      EcsPool<TComponent> pool = world.GetPool<TComponent>();

      if (pool.Has(e))
        pool.Del(e);
      pool.Add(e) = component;

      Destroy(this);
    }
  }
}