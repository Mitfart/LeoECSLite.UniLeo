using Mitfart.LeoECSLite.UniLeo.Editor.Extentions.UIElement;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Mitfart.LeoECSLite.UniLeo.Editor {
   [CustomEditor(typeof(EcsProvider<>), editorForChildClasses: true)]
   public class ComponentEditor : UnityEditor.Editor {
      private const string _COMPONENT_PROPERTY_NAME = nameof(EcsProvider<Vector2>.component);

      private VisualElement _root;
      private VisualElement _fields;



      public override VisualElement CreateInspectorGUI() {
         CreateElements();
         AddElements();
         InitElements();
         return _root;
      }



      private void CreateElements() {
         _root   = new VisualElement();
         _fields = new VisualElement();
      }

      private void AddElements()
         => _root
           .AddScriptField(serializedObject)
           .AddChild(_fields);

      private void InitElements() => InitFields();



      private void InitFields() {
         SerializedProperty data = Component();

         if (data != null)
            _fields.AddChildProperties(data);
      }



      private SerializedProperty Component() => serializedObject.FindProperty(_COMPONENT_PROPERTY_NAME);
   }
}