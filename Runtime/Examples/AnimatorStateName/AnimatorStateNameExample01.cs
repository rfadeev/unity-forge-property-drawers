using UnityEngine;

namespace UnityForge.PropertyDrawers
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorStateNameExample01 : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField, AnimatorStateName]
        private string stateName;
#pragma warning restore 0649

        private void Start()
        {
            var animator = GetComponent<Animator>();
            animator.Play(stateName);
        }
    }
}
