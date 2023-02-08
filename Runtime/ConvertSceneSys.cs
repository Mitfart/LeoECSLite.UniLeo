using Leopotam.EcsLite;
using Object = UnityEngine.Object;

namespace Mitfart.LeoECSLite.UniLeo {
  public class ConvertSceneSys : IEcsPreInitSystem {
    public void PreInit(IEcsSystems systems) {
      EcsWorldsLocator.Register(null, systems.GetWorld());
      EcsWorldsLocator.RegisterAllFrom(systems);
      
      foreach (var convertable in Object.FindObjectsOfType<ConvertToEntity>()) {
        var world = systems.GetWorld(convertable.WorldName);
        convertable.Convert(world);
      }
    }
  }
}
