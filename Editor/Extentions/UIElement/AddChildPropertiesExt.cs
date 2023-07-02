using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Mitfart.LeoECSLite.UniLeo.Editor.Extentions.UIElement {
   public static class AddChildPropertiesExt {
      public static void AddChildProperties(this VisualElement root, SerializedProperty property) {
         SerializedProperty rootProperty = property.Copy();
         SerializedProperty curProp      = property.Copy();

         if (!curProp.NextVisible(enterChildren: true))
            return;

         do {
            curProp = curProp.Copy();

            if (!curProp.ChildOf(rootProperty))
               break;

            root.Add(new PropertyField(curProp));
         } while (curProp.NextVisible(enterChildren: false));
      }

      private static bool ChildOf(this SerializedProperty curProp, SerializedProperty rootProperty) => curProp.propertyPath.Contains(rootProperty.propertyPath);
   }
}