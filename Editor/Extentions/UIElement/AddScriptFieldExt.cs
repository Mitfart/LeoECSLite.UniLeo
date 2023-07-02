using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Mitfart.LeoECSLite.UniLeo.Editor.Extentions.UIElement {
   public static class AddScriptFieldExt {
      private const string _UNITY_SCRIPT = "m_Script";

      public static VisualElement AddScriptField(this VisualElement root, SerializedObject serializedObject) {
         SerializedProperty scriptProperty = serializedObject.FindProperty(_UNITY_SCRIPT);

         if (scriptProperty == null)
            throw new Exception(message: "Cant find Script property");

         var propertyField = new PropertyField(scriptProperty);
         propertyField.SetEnabled(value: false);

         root.Add(propertyField);
         return root;
      }
   }
}