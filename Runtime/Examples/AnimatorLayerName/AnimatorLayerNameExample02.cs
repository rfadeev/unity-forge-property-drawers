using UnityEngine;

namespace UnityForge
{
    public class AnimatorLayerNameExample02 : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private Animator exampleAnimator;

        [SerializeField, AnimatorStateName(animatorField: "exampleAnimator")]
        private string stateName;

        [SerializeField, AnimatorLayerName(animatorField: "exampleAnimator")]
        private string layerName;
#pragma warning restore 0649

        private void Start()
        {
            var layerIndex = exampleAnimator.GetLayerIndex(layerName);
            exampleAnimator.Play(stateName, layerIndex);
        }
    }
}
