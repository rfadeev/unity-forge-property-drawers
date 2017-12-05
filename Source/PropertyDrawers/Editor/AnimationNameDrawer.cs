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

            // User can pass null or empty string as animation field value in AnimationName constructor,
            // treat this as not set animation field - fallback to search of Animation component attached to inspected object
            var animationField = ((AnimationName)attribute).AnimationField;
            if (!String.IsNullOrEmpty(animationField))
            {
                var animationProperty = property.serializedObject.FindProperty(animationField);
                if (animationProperty != null)
                {
                    var objectReferenceValue = animationProperty.objectReferenceValue;
                    if (objectReferenceValue != null)
                    {
                        var animationReference = objectReferenceValue as Animation;
                        if (animationReference != null)
                        {
                            StateNameButton(position, property, animationReference);
                            return;
                        }
                        else
                        {
                            EditorGUI.LabelField(position, "Error: field type is not Animation");
                            return;
                        }
                    }
                    else
                    {
                        EditorGUI.LabelField(position, "Error: animation field is not set");
                        return;
                    }
                }
                else
                {
                    EditorGUI.LabelField(position, String.Format("Error: animator field {0} not found in inspected object", animationField));
                    return;
                }
            }

            var component = property.serializedObject.targetObject as Component;
            if (component == null)
            {
                EditorGUI.LabelField(position, "Error: inspected object type is not Component");
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
