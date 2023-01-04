using EcsExtensions.Pool;
using Leopotam.EcsLite;

namespace Mitfart.LeoECSLite.UniLeo.LeoECSLite.UniLeo.Runtime.Providers{
   public abstract class EcsScrProvider<T, TSrc> : BaseEcsProvider
      where T    : struct
      where TSrc : ScrStruct<T>{
      public TSrc scrValue;

      public override void Convert(int e, EcsWorld world){
         world.GetPool<T>().Set(e, scrValue.Value);

         Destroy(this);
      }
   }
}
