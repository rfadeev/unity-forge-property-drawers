using UnityEngine;

namespace UnityForge
{
    public class AnimationNameExample02 : MonoBehaviour
    {
        [SerializeField]
        private Animation exampleAnimation;

        [SerializeField, AnimationName(animationField: "exampleAnimation")]
        private string animationName;

        private void Start()
        {
            if (exampleAnimation != null)
            {
                exampleAnimation.Play(animationName);
            }
        }
    }
}
