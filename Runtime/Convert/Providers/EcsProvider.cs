using Leopotam.EcsLite;

namespace Mitfart.LeoECSLite.UniLeo.Providers {
   public abstract class EcsProvider<TComponent> : BaseEcsProvider<TComponent> where TComponent : struct {
      public TComponent component;

      protected override void Add(EcsPool<TComponent> pool, int e, EcsWorld world) {
         if (pool.Has(e))
            pool.Del(e);

         pool.Add(e) = component;
      }
   }
}