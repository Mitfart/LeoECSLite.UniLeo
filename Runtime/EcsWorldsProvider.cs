using System.Collections.Generic;
using Leopotam.EcsLite;

namespace Mitfart.LeoECSLite.UniLeo.LeoECSLite.UniLeo.Runtime{
   public static class EcsWorldsProvider{
      private static readonly Dictionary<string, EcsWorld> Worlds = new();

      public static bool TryGetWorld(string worldName, out EcsWorld world){
         return Worlds.TryGetValue(worldName, out world);
      }
      public static void RegisterWorld(string worldName, EcsWorld world){
         Worlds[worldName] = world;
      }
   }
}
