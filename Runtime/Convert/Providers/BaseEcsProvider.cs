using Leopotam.EcsLite;
using UnityEngine;

namespace Mitfart.LeoECSLite.UniLeo.Providers {
   [RequireComponent(typeof(ConvertToEntity))]
   public abstract class BaseEcsProvider<TComponent> : MonoBehaviour, IEcsProvider where TComponent : struct {
      public void Convert(int e, EcsWorld world) {
         EcsPool<TComponent> pool = world.GetPool<TComponent>();

         Add(pool, e, world);

         Destroy(this);
      }

      protected abstract void Add(EcsPool<TComponent> pool, int e, EcsWorld world);
   }
}