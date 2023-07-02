using System;

namespace Mitfart.Plugins.Mitfart.LeoECSLite.UniLeo.WorldsLocator {
  public class NoRegisteredWorldException : Exception {
    public NoRegisteredWorldException(string worldName) : base(GetExceptionText(worldName)) { }

    private static string GetExceptionText(string worldName) => $"Can't find World nameof: {worldName}! \n (Each world should be register by: {nameof(EcsWorldsLocator.Register)}!)";
  }
}