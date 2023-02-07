using System;

namespace Mitfart.LeoECSLite.UniLeo {
  public class NoRegisteredWorldException : Exception {
    public NoRegisteredWorldException(string worldName) : base(GetExceptionText(worldName)) { }

    private static string GetExceptionText(string worldName) {
      return $"Can't find World nameof: {worldName}! \n (Each world should be register by: {nameof(EcsWorldsLocator.Register)}!)";
    }
  }
}
