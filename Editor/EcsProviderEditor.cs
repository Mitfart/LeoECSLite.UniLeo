using Mitfart.Plugins.Mitfart.LeoECSLite.UniLeo.Convert.Providers;
using Mitfart.Plugins.Mitfart.LeoECSLite.UniLeo.Editor.Extentions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Mitfart.Plugins.Mitfart.LeoECSLite.UniLeo.Editor {
  [CustomEditor(typeof(EcsProvider<>), true)]
  public class ComponentEditor : UnityEditor.Editor {
    private const string        COMPONENT_PROPERTY_NAME = nameof(EcsProvider<Vector2>.component);
    private       VisualElement _fields;

    private VisualElement _root;



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



    private SerializedProperty Component() => serializedObject.FindProperty(COMPONENT_PROPERTY_NAME);
  }
}