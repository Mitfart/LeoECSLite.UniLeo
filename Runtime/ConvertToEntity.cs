using Leopotam.EcsLite;
using UnityEngine;

namespace Mitfart.LeoECSLite.UniLeo{
   [DisallowMultipleComponent]
   public class ConvertToEntity : MonoBehaviour{
      public string worldName;
      
      public EcsWorld        World       { get; private set; }
      public EcsPackedEntity PackedEntity{ get; private set; }
      public bool            IsConverted { get; private set; }

      

      private void Start() {
         Convert(EcsWorldsLocator.Get(worldName));
      }

      
      
      public EcsPackedEntity Convert(EcsWorld world){
         World = world;
         Convert();
         return PackedEntity;
      }
      
      private void Convert(){
         if (IsConverted) return;

         var entity = World.NewEntity();
         foreach (var provider in GetComponents<IConvertToEntity>()) 
            provider.Convert(entity, World);

         IsConverted  = true;
         PackedEntity = World.PackEntity(entity);
      }
      
      
      
      public bool TryGetEntity(out int e){
         return PackedEntity.Unpack(World, out e);
      }
   }
}
