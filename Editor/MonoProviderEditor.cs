using Mitfart.LeoECSLite.UniLeo.LeoECSLite.UniLeo.Runtime.Providers;
using UniLeo_Lite.Editor;
using UnityEditor;

namespace Mitfart.LeoECSLite.UniLeo.Editor.LeoECSLite.UniLeo.Editor{
   [CanEditMultipleObjects]
   [CustomEditor(typeof(EcsProvider<>), true)]
   public class MonoProviderEditor : UnityEditor.Editor{
      public override void OnInspectorGUI(){
         serializedObject.DrawScriptProperty();
         serializedObject.FindProperty("component")?.Draw(true, 1);
         serializedObject.ApplyModifiedProperties();
      }
   }
}
