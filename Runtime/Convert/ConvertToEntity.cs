using Leopotam.EcsLite;
using Mitfart.Plugins.Mitfart.LeoECSLite.UniLeo.WorldsLocator;
using UnityEngine;

namespace Mitfart.Plugins.Mitfart.LeoECSLite.UniLeo.Convert {
  [DisallowMultipleComponent]
  public class ConvertToEntity : MonoBehaviour {
    [field: SerializeField] public string WorldName { get; private set; }

    public EcsWorld        World        { get; private set; }
    public EcsPackedEntity PackedEntity { get; private set; }
    public bool            IsConverted  { get; private set; }



    protected virtual void Start() => Convert();



    protected virtual void OnValidate() {
      if (string.IsNullOrWhiteSpace(WorldName))
        WorldName = string.Empty;
    }

    public virtual EcsPackedEntity Convert() => Convert(EcsWorldsLocator.Get(WorldName));

    public virtual EcsPackedEntity Convert(EcsWorld world) {
      if (IsConverted)
        return PackedEntity;

      World = world;

      int entity = World.NewEntity();
      foreach (IConvertToEntity provider in GetComponents<IConvertToEntity>())
        provider.Convert(entity, World);

      IsConverted  = true;
      PackedEntity = World.PackEntity(entity);
      return PackedEntity;
    }



    public bool TryGetEntity(out int e) => PackedEntity.Unpack(World, out e);
  }
}