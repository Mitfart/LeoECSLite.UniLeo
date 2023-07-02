using System;

namespace Mitfart.LeoECSLite.UniLeo {
   public class NoRegisteredWorldException : Exception {
      public NoRegisteredWorldException(string worldName)
         : base(
            $"Can't find World nameof: {(string.IsNullOrWhiteSpace(worldName) ? "Default" : worldName)}! \n"
          + $"(Each world should be register by: {nameof(EcsWorldsLocator.Register)}!)"
         ) { }
   }
}