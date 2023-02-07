using Leopotam.EcsLite;
using Object = UnityEngine.Object;

namespace Mitfart.LeoECSLite.UniLeo {
  public class ConvertSceneSys : IEcsPreInitSystem {
    public void PreInit(IEcsSystems systems) {
      EcsWorldsLocator.RegisterAllFrom(systems);
      
      foreach (var convertable in Object.FindObjectsOfType<ConvertToEntity>()) {
        var world = systems.GetWorld(convertable.worldName);
        convertable.Convert(world);
      }
    }
  }
}
