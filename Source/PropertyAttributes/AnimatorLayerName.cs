using System;

namespace UnityForge
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class AnimatorLayerName : AnimatorPropertyAttribute
    {
        public AnimatorLayerName(string animatorField = null) : base(animatorField)
        {
        }
    }
}
