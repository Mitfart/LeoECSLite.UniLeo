using Leopotam.EcsLite;
using Object = UnityEngine.Object;

namespace Mitfart.LeoECSLite.UniLeo {
  public class ConvertSceneSys : IEcsPreInitSystem {
    public void PreInit(IEcsSystems systems) {
      EcsWorldsLocator.Register(null, systems.GetWorld());
      EcsWorldsLocator.RegisterAllFrom(systems);
    }
  }
}
