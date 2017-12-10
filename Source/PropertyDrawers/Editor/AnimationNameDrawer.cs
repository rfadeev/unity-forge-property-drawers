using System;
using UnityEditor;
using UnityEngine;

namespace UnityForge.Editor
{
    [CustomPropertyDrawer(typeof(AnimationName))]
    public class AnimationNameDrawer : ComponentStringFieldPropertyDrawer<AnimationName, Animation>
    {
        protected override string GetPropertyPath(AnimationName attribute)
        {
            return attribute.AnimationField;
        }

        protected override void DrawComponentProperty(Rect position, SerializedProperty property, Animation animation)
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
