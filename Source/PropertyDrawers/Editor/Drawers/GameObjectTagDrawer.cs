using System;
using UnityEditor;
using UnityEngine;
using UnityForge;

[CustomPropertyDrawer(typeof(GameObjectTag))]
public class GameObjectTagDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType != SerializedPropertyType.String)
        {
            position = EditorGUI.PrefixLabel(position, label);
            EditorGUI.LabelField(position, String.Format("Error: {0} attribute can be applied only to {1} type", typeof(GameObjectTag), SerializedPropertyType.String));
            return;
        }

        property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
    }
}
