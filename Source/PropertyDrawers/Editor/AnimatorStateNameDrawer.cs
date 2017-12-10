using System;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace UnityForge.Editor
{
    [CustomPropertyDrawer(typeof(AnimatorStateName))]
    public class AnimatorStateNameDrawer : ComponentStringFieldPropertyDrawer<AnimatorStateName, Animator>
    {
        protected override string GetPropertyPath(AnimatorStateName attribute)
        {
            return attribute.AnimatorField;
        }

        protected override void DrawComponentProperty(Rect position, SerializedProperty property, Animator animator)
        {
            var runtimeAnimatorController = animator.runtimeAnimatorController;
            if (runtimeAnimatorController != null)
            {
                var animatorController = runtimeAnimatorController as AnimatorController;
                if (animatorController != null)
                {
                    StateNameButton(position, property, animatorController);
                }
                else
                {
                    var animatorOverrideController = runtimeAnimatorController as AnimatorOverrideController;
                    if (animatorOverrideController != null)
                    {
                        animatorController = animatorOverrideController.runtimeAnimatorController as AnimatorController;
                        if (animatorController != null)
                        {
                            StateNameButton(position, property, animatorController);
                        }
                        else
                        {
                            EditorGUI.LabelField(position, String.Format("Error: not supported type of overridden controller {0} for AnimatorStateName attribute", animatorController.GetType()));
                        }
                    }
                    else
                    {
                        EditorGUI.LabelField(position, String.Format("Error: not supported type of controller {0} for AnimatorStateName attribute", runtimeAnimatorController.GetType()));
                    }
                }
            }
            else
            {
                EditorGUI.LabelField(position, "Error: animator controller not found for AnimatorStateName attribute");
            }
        }

        private static void StateNameButton(Rect position, SerializedProperty property, AnimatorController animatorController)
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
