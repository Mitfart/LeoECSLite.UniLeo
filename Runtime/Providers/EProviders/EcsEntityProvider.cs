using EcsExtensions.Pool;
using Leopotam.EcsLite;

namespace Mitfart.LeoECSLite.UniLeo.LeoECSLite.UniLeo.Runtime.Providers.EProviders{
   public abstract class EcsEntityProvider<T, TProvider> : BaseEcsProvider
      where T : struct
      where TProvider : BaseEcsProvider{
      public TProvider provider;

      public override void Convert(int e, EcsWorld world){
         T component = new();
         Init(ref component);

         if (provider != null && provider.isActiveAndEnabled)
            Process(ref component, provider.GetComponent<ConvertToEntity>());

         world.GetPool<T>().Set(e) = component;
         Destroy(this);
      }


      public abstract void Init   (ref T component);
      public abstract void Process(ref T component, ConvertToEntity provider);
   }
}
