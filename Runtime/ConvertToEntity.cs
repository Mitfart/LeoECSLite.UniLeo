using Leopotam.EcsLite;
using UnityEngine;

namespace Mitfart.LeoECSLite.UniLeo{
  [DisallowMultipleComponent]
  public class ConvertToEntity : MonoBehaviour{
    [field: SerializeField] public string WorldName { get; private set; }
      
    public EcsWorld        World        { get; private set; }
    public EcsPackedEntity PackedEntity { get; private set; }
    public bool            IsConverted  { get; private set; }

      

    private void Start() {
      Convert();
    }



    public EcsPackedEntity Convert() => Convert(EcsWorldsLocator.Get(WorldName));
      
    public EcsPackedEntity Convert(EcsWorld world) {
      if (IsConverted) return PackedEntity;

      World = world;
         
      var entity = World.NewEntity();
      foreach (var provider in GetComponents<IConvertToEntity>()) 
        provider.Convert(entity, World);

      IsConverted  = true;
      PackedEntity = World.PackEntity(entity);
      return PackedEntity;
    }
      
      
      
    public bool TryGetEntity(out int e) {
      return PackedEntity.Unpack(World, out e);
    }



    private void OnValidate() {
      if (string.IsNullOrWhiteSpace(WorldName)) 
        WorldName = string.Empty;
    }
  }
}
