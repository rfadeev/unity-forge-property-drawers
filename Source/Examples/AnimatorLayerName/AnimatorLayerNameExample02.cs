using UnityEngine;

namespace UnityForge
{
    public class AnimatorLayerNameExample02 : MonoBehaviour
    {
        [SerializeField]
        private Animator exampleAnimator;

        [SerializeField, AnimatorStateName(animatorField: "exampleAnimator")]
        private string stateName;

        [SerializeField, AnimatorLayerName(animatorField: "exampleAnimator")]
        private string layerName;

        private void Start()
        {
            var layerIndex = exampleAnimator.GetLayerIndex(layerName);
            exampleAnimator.Play(stateName, layerIndex);
        }
    }
}
