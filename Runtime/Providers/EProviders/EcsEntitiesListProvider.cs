using System.Collections.Generic;
using System.Linq;
using EcsExtensions.Pool;
using Leopotam.EcsLite;
using UnityEngine;

namespace Mitfart.LeoECSLite.UniLeo.LeoECSLite.UniLeo.Runtime.Providers.EProviders{
   public abstract class EcsEntitiesListProvider<T, TProvider> : BaseEcsProvider
      where T : struct
      where TProvider : BaseEcsProvider{
      [field: SerializeField] public List<TProvider> Providers{ get; private set; }

      protected virtual void OnValidate(){
         Providers = Providers.ToHashSet().ToList();
      }

      public override void Convert(int e, EcsWorld world){
         T component = new();
         Init(ref component);

         foreach (TProvider provider in Providers) 
            Process(ref component, provider);

         world.GetPool<T>().Set(e, component);
         Destroy(this);
      }

      public abstract void Init   (ref T component);
      public abstract void Process(ref T component, TProvider provider);
   }
}
