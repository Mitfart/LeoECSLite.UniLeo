using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEditor;

namespace Mitfart.LeoECSLite.UniLeo.Editor{
   [CanEditMultipleObjects]
   [CustomEditor(typeof(EcsProvider<>), true)]
   public class EcsProviderEditor : UnityEditor.Editor{
      public override void OnInspectorGUI(){
         serializedObject.DrawScriptProperty();
         serializedObject.FindProperty("component")?.Draw(true, 1);
         serializedObject.ApplyModifiedProperties();
      }
   }
}
