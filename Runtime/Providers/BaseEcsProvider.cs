using Leopotam.EcsLite;
using UnityEngine;

namespace Mitfart.LeoECSLite.UniLeo.Providers{
   [RequireComponent(typeof(ConvertToEntity))]
   public abstract class BaseEcsProvider : MonoBehaviour, IConvertToEntity{
      public abstract void Convert(int e, EcsWorld world);
   }
}
