using System;
using UnityEditor;
using UnityEngine;

namespace UnityForge.Editor
{
    // Base class for property drawers for string properties which require component of specific type
    // with component field optionally specified by attribute
    public abstract class ComponentFieldPropertyDrawer<TAttribute, TComponent> : PropertyDrawer
        where TAttribute : PropertyAttribute
        where TComponent : Component
    {
        private SerializedPropertyType propertyType_;

        protected ComponentFieldPropertyDrawer(SerializedPropertyType propertyType)
        {
            propertyType_ = propertyType;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position = EditorGUI.PrefixLabel(position, label);

            if (property.propertyType != propertyType_)
            {
                EditorGUI.LabelField(position, String.Format("Error: {0} attribute can be applied only to {1} type", typeof(TAttribute), propertyType_));
                return;
            }

            // User can pass null or empty string as field value in property attribute constructor so GetField can return null or empty string,
            // treat this as not set field - fallback to search of TComponent component attached to inspected object
            var field = GetPropertyPath((TAttribute)attribute);
            if (!String.IsNullOrEmpty(field))
            {
                var fieldProperty = property.serializedObject.FindProperty(field);
                if (fieldProperty != null)
                {
                    var fieldObjectReferenceValue = fieldProperty.objectReferenceValue;
                    if (fieldObjectReferenceValue != null)
                    {
                        var componentReference = fieldObjectReferenceValue as TComponent;
                        if (componentReference != null)
                        {
                            DrawComponentProperty(position, property, componentReference);
                            return;
                        }
                        else
                        {
                            EditorGUI.LabelField(position, String.Format("Error: field type is not {0}", typeof(TComponent)));
                            return;
                        }
                    }
                    else
                    {
                        EditorGUI.LabelField(position, String.Format("Error: {0} field is not set", typeof(TComponent)));
                        return;
                    }
                }
                else
                {
                    EditorGUI.LabelField(position, String.Format("Error: {0} field {1} not found in inspected object", typeof(TComponent), field));
                    return;
                }
            }

            var inspectedObjectComponent = property.serializedObject.targetObject as Component;
            if (inspectedObjectComponent == null)
            {
                EditorGUI.LabelField(position, "Error: inspected object type is not Component");
                return;
            }

            var component = inspectedObjectComponent.GetComponent<TComponent>();
            if (component == null)
            {
                EditorGUI.LabelField(position, String.Format("Error: missing {0} component in inspected object", typeof(TComponent)));
                return;
            }

            DrawComponentProperty(position, property, component);
        }

        protected abstract string GetPropertyPath(TAttribute attribute);

        protected abstract void DrawComponentProperty(Rect position, SerializedProperty property, TComponent component);
    }
}
