using Leopotam.EcsLite;

namespace Mitfart.LeoECSLite.UniLeo.Providers {
   public abstract class EcsScrProvider<TComponent, TScrComponent> : BaseEcsProvider<TComponent>
      where TComponent : struct
      where TScrComponent : ScrComponent<TComponent> {
      public TScrComponent scrComponent;

      protected override void Add(EcsPool<TComponent> pool, int e, EcsWorld world) {
         if (pool.Has(e))
            pool.Del(e);

         pool.Add(e) = scrComponent.Get();
      }
   }
}