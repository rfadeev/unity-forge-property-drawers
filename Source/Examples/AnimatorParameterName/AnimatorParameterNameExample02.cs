using UnityEngine;

namespace UnityForge
{
    public class AnimatorParameterNameExample02 : MonoBehaviour
    {
        [SerializeField]
        private Animator exampleAnimator;

        [SerializeField]
        [AnimatorParameterName(AnimatorControllerParameterType.Float, animatorField: "exampleAnimator")]
        private string exampleFloatParameter;

        [SerializeField]
        [AnimatorParameterName(AnimatorControllerParameterType.Int, animatorField: "exampleAnimator")]
        private string exampleIntParameter;

        [SerializeField]
        [AnimatorParameterName(AnimatorControllerParameterType.Bool, animatorField: "exampleAnimator")]
        private string exampleBoolParameter;

        [SerializeField]
        [AnimatorParameterName(AnimatorControllerParameterType.Trigger, animatorField: "exampleAnimator")]
        private string exampleTriggerParameter;

        private void Start()
        {
            if (exampleAnimator != null)
            {
                Debug.LogFormat("Example float parameter value: {0}", exampleAnimator.GetFloat(exampleFloatParameter));
                Debug.LogFormat("Example int parameter value: {0}", exampleAnimator.GetInteger(exampleIntParameter));
                Debug.LogFormat("Example bool parameter value: {0}", exampleAnimator.GetBool(exampleBoolParameter));
                exampleAnimator.SetTrigger(exampleTriggerParameter);
            }
        }
    }
}
