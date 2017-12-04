using UnityEngine;

namespace UnityForge
{
    [RequireComponent(typeof(Animation))]
    public class AnimationNameExample01 : MonoBehaviour
    {
        [SerializeField, AnimationName]
        private string animationName;

        private void Start()
        {
            var animation = GetComponent<Animation>();
            animation.Play(animationName);
        }
    }
}
