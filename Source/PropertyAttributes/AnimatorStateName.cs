using System;

namespace UnityForge
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class AnimatorStateName : AnimatorPropertyAttribute
    {
        public AnimatorStateName(string animatorField = null) : base(animatorField)
        {
        }
    }
}
