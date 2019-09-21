using UnityEngine;

namespace UnityForge.PropertyDrawers
{
    [RequireComponent(typeof(Animation))]
    public class AnimationNameExample01 : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField, AnimationName]
        private string animationName;
#pragma warning restore 0649

        private void Start()
        {
            var animation = GetComponent<Animation>();
            animation.Play(animationName);
        }
    }
}
