using EcsExtensions.Pool;
using Leopotam.EcsLite;

namespace Mitfart.LeoECSLite.UniLeo.LeoECSLite.UniLeo.Runtime.Providers{
   public abstract class EcsProvider<T> : BaseEcsProvider where T : struct{
      public T component;

      public override void Convert(int e, EcsWorld world){
         world.GetPool<T>().Set(e, component);
         Destroy(this);
      }
   }
}
