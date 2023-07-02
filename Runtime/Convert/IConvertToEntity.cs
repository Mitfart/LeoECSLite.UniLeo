using Leopotam.EcsLite;

namespace Mitfart.Plugins.Mitfart.LeoECSLite.UniLeo.Convert {
  public interface IConvertToEntity {
    void Convert(int e, EcsWorld world);
  }
}