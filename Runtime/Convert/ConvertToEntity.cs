using Leopotam.EcsLite;
using UnityEngine;

namespace Mitfart.LeoECSLite.UniLeo.LeoECSLite.UniLeo.Runtime{
   [DisallowMultipleComponent]
   public class ConvertToEntity : MonoBehaviour{
      public string worldName;
      
      public EcsWorld        World       { get; private set; }
      public EcsPackedEntity PackedEntity{ get; private set; }
      public bool            IsConverted { get; private set; }


      void Start(){
         if (EcsWorldsProvider.TryGetWorld(worldName, out EcsWorld world)){
            World = world;
            Convert();
         } else
            Debug.LogError($"Can't find World nameof: {worldName}! \n (Each world should be register by: {nameof(EcsWorldsProvider.RegisterWorld)}!)"); 
      }

      public EcsPackedEntity Convert(EcsWorld world){
         World = world;
         Convert();
         return PackedEntity;
      }
      private void Convert(){
         if (IsConverted) return;

         int entity = World.NewEntity();
         foreach (IConvertToEntity provider in GetComponents<IConvertToEntity>()) provider.Convert(entity, World);

         IsConverted  = true;
         PackedEntity = World.PackEntity(entity);
      }
      
      public bool TryGetEntity(out int e){
         return PackedEntity.Unpack(World, out e);
      }
   }
}
