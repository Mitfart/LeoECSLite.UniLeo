using System.Collections.Generic;
using Leopotam.EcsLite;

namespace Mitfart.LeoECSLite.UniLeo{
   public static class EcsWorldsLocator{
      private static readonly Dictionary<string, EcsWorld> Worlds = new();

      
      
      public static EcsWorld Get(string worldName) {
#if UNITY_EDITOR
         if (string.IsNullOrWhiteSpace(worldName)) 
            worldName = string.Empty;
         
         if (!Worlds.TryGetValue(worldName, out var world)) 
            throw new NoRegisteredWorldException(worldName);
         
         return world;
#else
         return Worlds[worldName];
#endif
      }
      
      public static void Register(string worldName, EcsWorld world) {
         if (string.IsNullOrWhiteSpace(worldName)) 
            worldName = string.Empty;
         
         Worlds[worldName] = world;
      }



      public static void RegisterAllFrom(IEcsSystems systems) {
         foreach (var (name, world) in systems.GetAllNamedWorlds())
            Register(name, world);
      }
   }
}
