using UnityEngine;

namespace UnityForge
{
    public class AnimatorParameterNameExample02 : MonoBehaviour
    {
        [SerializeField]
        private Animator exampleAnimator;

        [SerializeField]
        [AnimatorParameterName(AnimatorControllerParameterType.Float, animatorField: "exampleAnimator")]
        private string exampleFloatParameterName;

        [SerializeField]
        [AnimatorParameterName(AnimatorControllerParameterType.Int, animatorField: "exampleAnimator")]
        private string exampleIntParameterName;

        [SerializeField]
        [AnimatorParameterName(AnimatorControllerParameterType.Bool, animatorField: "exampleAnimator")]
        private string exampleBoolParameterName;

        [SerializeField]
        [AnimatorParameterName(AnimatorControllerParameterType.Trigger, animatorField: "exampleAnimator")]
        private string exampleTriggerParameterName;

        private void Start()
        {
            if (exampleAnimator != null)
            {
                Debug.LogFormat("Example float parameter value: {0}", exampleAnimator.GetFloat(exampleFloatParameterName));
                Debug.LogFormat("Example int parameter value: {0}", exampleAnimator.GetInteger(exampleIntParameterName));
                Debug.LogFormat("Example bool parameter value: {0}", exampleAnimator.GetBool(exampleBoolParameterName));
                exampleAnimator.SetTrigger(exampleTriggerParameterName);
            }
        }
    }
}
