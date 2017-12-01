using System;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace UnityForge.Editor
{
    public struct AnimatorStateDrawerPair
    {
        public string str;
        public SerializedProperty property;

        public AnimatorStateDrawerPair(string str, SerializedProperty property)
        {
            this.str = str;
            this.property = property;
        }
    }

    [CustomPropertyDrawer(typeof(AnimatorStateName))]
    public class AnimatorStateDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position = EditorGUI.PrefixLabel(position, label);

            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.LabelField(position, "Error: AnimatorStateName attribute can be applied only to string type");
                return;
            }

            var animatorController = GetAnimatorController(property);
            if (animatorController != null)
            {
                var propertyStringValue = property.hasMultipleDifferentValues ? "-" : property.stringValue;
                var content = String.IsNullOrEmpty(propertyStringValue) ? new GUIContent("<None>") : new GUIContent(propertyStringValue);
                if (GUI.Button(position, content, EditorStyles.popup))
                {
                    StateSelector(property, animatorController);
                }
            }
            else
            {
                EditorGUI.LabelField(position, "Error: animator controller not found for AnimatorStateName attribute");
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
                        HandleStateSelect,
                        new AnimatorStateDrawerPair(stateName, property));
                }
            }
            menu.ShowAsContext();
        }

        private static void HandleStateSelect(object menuItemObject)
        {
            var clickedItem = (AnimatorStateDrawerPair)menuItemObject;
            clickedItem.property.stringValue = clickedItem.str;
            clickedItem.property.serializedObject.ApplyModifiedProperties();
        }

        private static AnimatorController GetAnimatorController(SerializedProperty property)
        {
            var component = property.serializedObject.targetObject as Component;
            if (component == null)
            {
                Debug.LogError("Inspected object type is not Component");
                return null;
            }

            var animator = component.GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("Missing Animator component in inspected object");
                return null;
            }

            return animator.runtimeAnimatorController as AnimatorController;
        }
    }
}
