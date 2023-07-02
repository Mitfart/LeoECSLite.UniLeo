using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Extensions.String;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Mitfart.LeoECSLite.UniLeo {
   [DisallowMultipleComponent]
   public class ConvertToEntity : MonoBehaviour {
      [field: SerializeField] public string WorldName { get; private set; }

      public bool                     IsConverted     { get; private set; }
      public int                      Entity          { get; private set; }
      public EcsWorld                 World           { get; private set; }
      public EcsPackedEntity          Packed          { get; private set; }
      public EcsPackedEntityWithWorld PackedWithWorld { get; private set; }



      protected virtual void Start() => Convert();



      public virtual ConvertToEntity Convert() => Convert(EcsWorldsLocator.Get(WorldName.AsValidWorldName()));

      public virtual ConvertToEntity Convert(EcsWorld world) {
         if (IsConverted)
            return this;

         World           = world;
         Entity          = World.NewEntity();
         Packed          = World.PackEntity(Entity);
         PackedWithWorld = World.PackEntityWithWorld(Entity);
         IsConverted     = true;

         AddComponents();
         return this;
      }



      private void AddComponents() {
         foreach (IEcsProvider provider in GetComponents<IEcsProvider>())
            provider.Convert(Entity, World);
      }
   }
}