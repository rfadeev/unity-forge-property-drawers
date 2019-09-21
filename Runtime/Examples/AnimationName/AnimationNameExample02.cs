using UnityEngine;

namespace UnityForge
{
    public class AnimationNameExample02 : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private Animation exampleAnimation;

        [SerializeField, AnimationName(animationField: "exampleAnimation")]
        private string animationName;
#pragma warning restore 0649

        private void Start()
        {
            if (exampleAnimation != null)
            {
                exampleAnimation.Play(animationName);
            }
        }
    }
}
