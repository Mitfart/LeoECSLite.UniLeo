using Leopotam.EcsLite;
using Mitfart.Plugins.Mitfart.LeoECSLite.UniLeo.WorldsLocator;
using UnityEngine;

namespace Mitfart.Plugins.Mitfart.LeoECSLite.UniLeo.Convert {
  public class ConvertSceneSys : IEcsPreInitSystem {
    public void PreInit(IEcsSystems systems) {
      EcsWorldsLocator.Register(null, systems.GetWorld());
      EcsWorldsLocator.RegisterAllFrom(systems);

      foreach (ConvertToEntity convertable in Object.FindObjectsOfType<ConvertToEntity>()) {
        EcsWorld world = string.IsNullOrWhiteSpace(convertable.WorldName)
          ? systems.GetWorld()
          : systems.GetWorld(convertable.WorldName);
        convertable.Convert(world);
      }
    }
  }
}