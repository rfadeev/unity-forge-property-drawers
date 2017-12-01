using UnityEngine;

namespace UnityForge
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorStateControllerExample : MonoBehaviour
    {
        [SerializeField, AnimatorStateName]
        private string stateName;

        private void Start()
        {
            var animator = GetComponent<Animator>();
            animator.Play(stateName);
        }
    }
}
