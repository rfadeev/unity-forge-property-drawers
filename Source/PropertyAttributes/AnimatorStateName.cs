using System;
using UnityEngine;

namespace UnityForge
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class AnimatorStateName : PropertyAttribute
    {
        public string AnimatorField { get; private set; }

        public AnimatorStateName(string animatorField = null)
        {
            AnimatorField = animatorField;
        }
    }
}
