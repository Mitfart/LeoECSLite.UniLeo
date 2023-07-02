using System.Collections.Generic;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Extensions.String;

namespace Mitfart.LeoECSLite.UniLeo {
   public static class EcsWorldsLocator {
      private static readonly Dictionary<string, EcsWorld> _Worlds = new();



      public static EcsWorld Get(string worldName) {
         worldName = worldName.AsValidWorldName();

#if UNITY_EDITOR
         if (!_Worlds.ContainsKey(worldName))
            throw new NoRegisteredWorldException(worldName);
#endif

         return _Worlds[worldName];
      }

      public static void Register(string worldName, EcsWorld world) {
         if (string.IsNullOrWhiteSpace(worldName))
            worldName = string.Empty;

         _Worlds[worldName] = world;
      }



      public static void RegisterAllFrom(IEcsSystems systems) {
         Register(worldName: null, systems.GetWorld());

         foreach ((string name, EcsWorld world) in systems.GetAllNamedWorlds()) {
            Register(name, world);
         }
      }
   }
}