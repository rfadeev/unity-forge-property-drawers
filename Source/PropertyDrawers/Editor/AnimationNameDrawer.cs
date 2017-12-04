using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UnityForge.Editor
{
    [CustomPropertyDrawer(typeof(AnimationName))]
    public class AnimationNameDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position = EditorGUI.PrefixLabel(position, label);

            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.LabelField(position, "Error: AnimationName attribute can be applied only to string type");
                return;
            }

            var component = property.serializedObject.targetObject as Component;
            if (component == null)
            {
                EditorGUI.LabelField(position, "Error: missing Animation component in inspected object");
                return;
            }

            var animation = component.GetComponent<Animation>();
            if (animation == null)
            {
                EditorGUI.LabelField(position, "Error: missing Animation component in inspected object");
                return;
            }

            StateNameButton(position, property, animation);
        }

        private static void StateNameButton(Rect position, SerializedProperty property, Animation animation)
        {
            var propertyStringValue = property.hasMultipleDifferentValues ? "-" : property.stringValue;
            var content = String.IsNullOrEmpty(propertyStringValue) ? new GUIContent("<None>") : new GUIContent(propertyStringValue);
            if (GUI.Button(position, content, EditorStyles.popup))
            {
                StateSelector(property, animation);
            }
        }

        private static void StateSelector(SerializedProperty property, Animation animation)
        {
            var menu = new GenericMenu();

            var animationClips = AnimationUtility.GetAnimationClips(animation.gameObject);
            foreach (var animationClip in animationClips)
            {
                var name = animationClip.name;
                menu.AddItem(new GUIContent(name),
                    name == property.stringValue,
                    StringPropertyPair.HandlePairObjectSelect,
                    new StringPropertyPair(name, property));
            }

            menu.ShowAsContext();
        }
    }
}
