namespace Mitfart.LeoECSLite.UniLeo.Extensions.String {
   public static class ToValidWorldNameExt {
      public static string AsValidWorldName(this string str)
         => string.IsNullOrWhiteSpace(str)
            ? string.Empty
            : str;
   }
}