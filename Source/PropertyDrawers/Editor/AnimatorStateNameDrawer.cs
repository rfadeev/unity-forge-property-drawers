using System;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace UnityForge.Editor
{
    [CustomPropertyDrawer(typeof(AnimatorStateName))]
    public class AnimatorStateNameDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position = EditorGUI.PrefixLabel(position, label);

            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.LabelField(position, "Error: AnimatorStateName attribute can be applied only to string type");
                return;
            }

            // User can pass null or empty string as animator field value in AnimatorStateName constructor,
            // treat this as not set animator field - fallback to search of Animator component attached to inspected object
            var animatorField = ((AnimatorStateName)attribute).AnimatorField;
            if (!String.IsNullOrEmpty(animatorField))
            {
                var animatorProperty = property.serializedObject.FindProperty(animatorField);
                if (animatorProperty != null)
                {
                    var objectReferenceValue = animatorProperty.objectReferenceValue;
                    if (objectReferenceValue != null)
                    {
                        var animatorReference = objectReferenceValue as Animator;
                        if (animatorReference != null)
                        {
                            StateNameField(position, property, animatorReference.runtimeAnimatorController);
                            return;
                        }
                        else
                        {
                            EditorGUI.LabelField(position, "Error: field type is not Animator");
                            return;
                        }
                    }
                    else
                    {
                        EditorGUI.LabelField(position, "Error: animator field is not set");
                        return;
                    }
                }
                else
                {
                    EditorGUI.LabelField(position, String.Format("Error: animator field {0} not found in inspected object", animatorField));
                    return;
                }
            }

            var component = property.serializedObject.targetObject as Component;
            if (component == null)
            {
                EditorGUI.LabelField(position, "Error: inspected object type is not Component");
                return;
            }

            var animator = component.GetComponent<Animator>();
            if (animator == null)
            {
                EditorGUI.LabelField(position, "Error: missing Animator component in inspected object");
                return;
            }

            StateNameField(position, property, animator.runtimeAnimatorController);
        }

        private static void StateNameField(Rect position, SerializedProperty property, RuntimeAnimatorController runtimeAnimatorController)
        {
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
