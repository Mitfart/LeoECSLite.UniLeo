using Leopotam.EcsLite;

namespace Mitfart.Plugins.Mitfart.LeoECSLite.UniLeo.Convert.Providers {
  public abstract class EcsScrProvider<TComponent, TScrComponent> : BaseEcsProvider
    where TComponent : struct
    where TScrComponent : ScrComponent<TComponent> {
    public TScrComponent scrComponent;

    public override void Convert(int e, EcsWorld world) {
      EcsPool<TComponent> pool = world.GetPool<TComponent>();

      if (pool.Has(e))
        pool.Del(e);
      pool.Add(e) = scrComponent.GetComponent();

      Destroy(this);
    }
  }
}