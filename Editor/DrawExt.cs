using UnityEditor;
using UnityEngine;

namespace Mitfart.LeoECSLite.UniLeo.Editor {
  public static class DrawExt {
    public static void DrawScriptProperty(this SerializedObject serializedObject) {
      var enabled =  GUI.enabled;
      GUI.enabled = false;
      
      var prop = serializedObject.FindProperty("m_Script");
      EditorGUILayout.PropertyField(prop, true);
      
      GUI.enabled = enabled;
    }
      
      
    public static void Draw(this SerializedProperty property, bool drawChildren = true, int skipFoldoutsCount = 0) {
      var lastPropPath = string.Empty;
         
      foreach (SerializedProperty prop in property){
        if (prop.isArray && prop.propertyType == SerializedPropertyType.Generic){
          if (skipFoldoutsCount <= 0){
            EditorGUILayout.BeginHorizontal();
            prop.isExpanded = EditorGUILayout.Foldout(prop.isExpanded, prop.displayName);
            EditorGUILayout.EndHorizontal();

            if (!prop.isExpanded) continue;
                  
            EditorGUI.indentLevel++;
            Draw(prop);
            EditorGUI.indentLevel--;
          }
          else skipFoldoutsCount--;

          EditorGUI.indentLevel++;
          Draw(prop);
          EditorGUI.indentLevel--;
        }
        else{
          if (!string.IsNullOrWhiteSpace(lastPropPath) && prop.propertyPath.Contains(lastPropPath))
            continue;
          lastPropPath = prop.propertyPath;

          EditorGUILayout.PropertyField(prop, drawChildren);
        }
      }
    }
  }
}
