using System.Collections.Generic;
using Leopotam.EcsLite;

namespace Mitfart.LeoECSLite.UniLeo{
   public static class EcsWorldsLocator{
      private static readonly Dictionary<string, EcsWorld> Worlds = new();

      
      
      public static EcsWorld Get(string worldName) {
#if UNITY_EDITOR
         if (!Worlds.TryGetValue(worldName, out var world))
            throw new NoRegisteredWorldException(worldName);
         return world;
#else
         Worlds[worldName];
#endif
      }
      
      public static void Register(string worldName, EcsWorld world) {
         Worlds[worldName] = world;
      }



      public static void RegisterAllFrom(IEcsSystems systems) {
         foreach (var (name, world) in systems.GetAllNamedWorlds())
            Register(name, world);
      }
   }
}
