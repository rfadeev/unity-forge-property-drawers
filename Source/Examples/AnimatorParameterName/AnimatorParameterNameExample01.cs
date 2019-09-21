using UnityEngine;

namespace UnityForge
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorParameterNameExample01 : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField, AnimatorParameterName(AnimatorControllerParameterType.Float)]
        private string exampleFloatParameterName;

        [SerializeField, AnimatorParameterName(AnimatorControllerParameterType.Int)]
        private string exampleIntParameterName;

        [SerializeField, AnimatorParameterName(AnimatorControllerParameterType.Bool)]
        private string exampleBoolParameterName;

        [SerializeField, AnimatorParameterName(AnimatorControllerParameterType.Trigger)]
        private string exampleTriggerParameterName;
#pragma warning restore 0649

        private void Start()
        {
            var animator = GetComponent<Animator>();
            Debug.LogFormat("Example float parameter value: {0}", animator.GetFloat(exampleFloatParameterName));
            Debug.LogFormat("Example int parameter value: {0}", animator.GetInteger(exampleIntParameterName));
            Debug.LogFormat("Example bool parameter value: {0}", animator.GetBool(exampleBoolParameterName));
            animator.SetTrigger(exampleTriggerParameterName);
        }
    }
}
