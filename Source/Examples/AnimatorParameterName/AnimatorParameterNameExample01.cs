using UnityEngine;

namespace UnityForge
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorParameterNameExample01 : MonoBehaviour
    {
        [SerializeField, AnimatorParameterName(AnimatorControllerParameterType.Float)]
        private string exampleFloatParameter;

        [SerializeField, AnimatorParameterName(AnimatorControllerParameterType.Int)]
        private string exampleIntParameter;

        [SerializeField, AnimatorParameterName(AnimatorControllerParameterType.Bool)]
        private string exampleBoolParameter;

        [SerializeField, AnimatorParameterName(AnimatorControllerParameterType.Trigger)]
        private string exampleTriggerParameter;

        private void Start()
        {
            var animator = GetComponent<Animator>();
            Debug.LogFormat("Example float parameter value: {0}", animator.GetFloat(exampleFloatParameter));
            Debug.LogFormat("Example int parameter value: {0}", animator.GetInteger(exampleIntParameter));
            Debug.LogFormat("Example bool parameter value: {0}", animator.GetBool(exampleBoolParameter));
            animator.SetTrigger(exampleTriggerParameter);
        }
    }
}
