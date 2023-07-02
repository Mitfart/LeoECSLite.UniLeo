using Leopotam.EcsLite;
using UnityEngine;

namespace Mitfart.LeoECSLite.UniLeo.Providers {
   [RequireComponent(typeof(ConvertToEntity))]
   public abstract class BaseEcsProvider : MonoBehaviour, IEcsProvider {
      public abstract void Convert(int e, EcsWorld world);
   }
   
   public abstract class BaseEcsProvider<TComponent> : BaseEcsProvider where TComponent : struct {
      public override void Convert(int e, EcsWorld world) {
         EcsPool<TComponent> pool = world.GetPool<TComponent>();

         Add(pool, e, world);

         Destroy(this);
      }

      protected abstract void Add(EcsPool<TComponent> pool, int e, EcsWorld world);
   }
}