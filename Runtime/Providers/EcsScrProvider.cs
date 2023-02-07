using Leopotam.EcsLite;

namespace Mitfart.LeoECSLite.UniLeo.Providers{
   public abstract class EcsScrProvider<TComponent, TScrComponent> : BaseEcsProvider
      where TComponent    : struct
      where TScrComponent : ScrComponent<TComponent>{
      public TScrComponent scrValue;

      public override void Convert(int e, EcsWorld world){
         EcsPool<TComponent> pool = world.GetPool<TComponent>();
         
         if (pool.Has(e)) pool.Del(e);
         pool.Add(e) = scrValue.Value;

         Destroy(this);
      }
   }
}
