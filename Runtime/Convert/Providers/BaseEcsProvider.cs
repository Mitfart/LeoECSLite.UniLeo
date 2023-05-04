using Leopotam.EcsLite;
using UnityEngine;

namespace Mitfart.Plugins.Mitfart.LeoECSLite.UniLeo.Convert.Providers {
  [RequireComponent(typeof(ConvertToEntity))]
  public abstract class BaseEcsProvider : MonoBehaviour, IConvertToEntity {
    public abstract void Convert(int e, EcsWorld world);
  }
}