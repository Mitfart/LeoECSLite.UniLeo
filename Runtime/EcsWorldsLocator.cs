using System.Collections.Generic;
using Leopotam.EcsLite;

namespace Mitfart.LeoECSLite.UniLeo{
   public static class EcsWorldsLocator{
      private static readonly Dictionary<string, EcsWorld> Worlds = new();

      
      
      public static EcsWorld Get(string worldName) {
         if (string.IsNullOrWhiteSpace(worldName)) 
            worldName = string.Empty;
         
#if UNITY_EDITOR
         if (!Worlds.TryGetValue(worldName, out EcsWorld world)) 
            throw new NoRegisteredWorldException(worldName);

         return world;
#endif
         return Worlds[worldName];
      }
      
      public static void Register(string worldName, EcsWorld world) {
         if (string.IsNullOrWhiteSpace(worldName)) 
            worldName = string.Empty;
         
         Worlds[worldName] = world;
      }



      public static void RegisterAllFrom(IEcsSystems systems) {
         foreach ((string name, EcsWorld world) in systems.GetAllNamedWorlds())
            Register(name, world);
      }
   }
}
