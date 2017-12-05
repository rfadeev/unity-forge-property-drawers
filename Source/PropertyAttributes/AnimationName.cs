using System;
using UnityEngine;

namespace UnityForge
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class AnimationName : PropertyAttribute
    {
        public string AnimationField { get; private set; }

        public AnimationName(string animationField = null)
        {
            AnimationField = animationField;
        }
    }
}
