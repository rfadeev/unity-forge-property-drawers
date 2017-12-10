using UnityEngine;

namespace UnityForge
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorLayerNameExample01 : MonoBehaviour
    {
        [SerializeField, AnimatorStateName]
        private string stateName;

        [SerializeField, AnimatorLayerName]
        private string layerName;

        private void Start()
        {
            var animator = GetComponent<Animator>();
            var layerIndex = animator.GetLayerIndex(layerName);
            animator.Play(stateName, layerIndex);
        }
    }
}
