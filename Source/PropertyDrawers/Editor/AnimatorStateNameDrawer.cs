using System;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace UnityForge.Editor
{
    [CustomPropertyDrawer(typeof(AnimatorStateName))]
    public class AnimatorStateNameDrawer : RuntimeAnimatorControllerPropertyDrawer<AnimatorStateName>
    {
        public AnimatorStateNameDrawer() : base(SerializedPropertyType.String)
        {
        }

        protected override string GetPropertyPath(AnimatorStateName attribute)
        {
            return attribute.AnimatorField;
        }

        protected override void DrawAnimatorControllerProperty(Rect position, SerializedProperty property, AnimatorController animatorController)
        {
            var propertyStringValue = property.hasMultipleDifferentValues ? "-" : property.stringValue;
            var content = String.IsNullOrEmpty(propertyStringValue) ? new GUIContent("<None>") : new GUIContent(propertyStringValue);
            if (GUI.Button(position, content, EditorStyles.popup))
            {
                StateSelector(property, animatorController);
            }
        }

        private static void StateSelector(SerializedProperty property, AnimatorController animatorController)
        {
            var menu = new GenericMenu();
            foreach (var layer in animatorController.layers)
            {
                var stateNamePrefix = layer.name + "/";
                foreach (var childState in layer.stateMachine.states)
                {
                    var stateName = childState.state.name;
                    menu.AddItem(new GUIContent(stateNamePrefix + stateName),
                        stateName == property.stringValue,
                        StringPropertyPair.HandlePairObjectSelect,
                        new StringPropertyPair(stateName, property));
                }
            }
            menu.ShowAsContext();
        }
    }
}
