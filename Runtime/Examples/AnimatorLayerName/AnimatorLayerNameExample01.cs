using UnityEngine;

namespace UnityForge
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorLayerNameExample01 : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField, AnimatorStateName]
        private string stateName;

        [SerializeField, AnimatorLayerName]
        private string layerName;
#pragma warning restore 0649

        private void Start()
        {
            var animator = GetComponent<Animator>();
            var layerIndex = animator.GetLayerIndex(layerName);
            animator.Play(stateName, layerIndex);
        }
    }
}
