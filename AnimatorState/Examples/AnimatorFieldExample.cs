using UnityEngine;

namespace UnityForge
{
    public class AnimatorFieldExample : MonoBehaviour
    {
        [SerializeField]
        private Animator exampleAnimator;

        [SerializeField, AnimatorStateName(animatorField: "exampleAnimator")]
        private string stateName;

        private void Start()
        {
            if (exampleAnimator != null)
            {
                exampleAnimator.Play(stateName);
            }
        }
    }
}
