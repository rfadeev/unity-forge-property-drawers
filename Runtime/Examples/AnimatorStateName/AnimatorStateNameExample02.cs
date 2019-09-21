using UnityEngine;

namespace UnityForge.PropertyDrawers
{
    public class AnimatorStateNameExample02 : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private Animator exampleAnimator;

        [SerializeField, AnimatorStateName(animatorField: "exampleAnimator")]
        private string stateName;
#pragma warning restore 0649

        private void Start()
        {
            if (exampleAnimator != null)
            {
                exampleAnimator.Play(stateName);
            }
        }
    }
}
