using Leopotam.EcsLite;

namespace Mitfart.LeoECSLite.UniLeo {
   public class ConvertSceneSys : IEcsPreInitSystem {
      public void PreInit(IEcsSystems systems) => EcsWorldsLocator.RegisterAllFrom(systems);
   }
}