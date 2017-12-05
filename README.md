# animator-state-property-drawer [![License](https://img.shields.io/badge/license-MIT-lightgrey.svg?style=flat)](http://mit-license.org)
Custom propery drawers to ease animation parameters selection in Unity editor.

## Animator state name

![screencast](Documentation/animator-state-controller-example.gif)

### Attribute usage

Import `UnityForge` namespace and mark animator state name field with `AnimatorStateName` attribute. After that you will be able to select animator state name value from dropdown list in Unity editor if Animator component is attached to inspected object.

```csharp
using UnityEngine;
using UnityForge;

public class AnimatorStateNameExample : MonoBehaviour
{
    [SerializeField, AnimatorStateName]
    private string stateName;

    private void Start()
    {
        var animator = GetComponent<Animator>();
        animator.Play(stateName);
    }
}
```

For the case of animator component field use `animatorField` constructor parameter.

```csharp
using UnityEngine;
using UnityForge;

public class AnimatorFieldExample : MonoBehaviour
{
    [SerializeField]
    private Animator exampleAnimator;

    [SerializeField, AnimatorStateName(animatorField: "exampleAnimator")]
    private string stateName;

    private void Start()
    {
        if (exampleAnimator != null)
        {
            exampleAnimator.Play(stateName);
        }
    }
}
```

### Caveats

Since layer index is [decoupled](https://docs.unity3d.com/ScriptReference/Animator.Play.html) from animator state name in Unity API, state name alone does not determine state and state index value should be managed separately. If only one animation layer is used, it's not the problem and `Play(string stateName)` overload can be used safely for fields using `AnimatorStateName` attribute.

## Animation name

![screencast](Documentation/animation-name-example.png)

### Attribute usage

Import `UnityForge` namespace and mark animator state name field with `AnimationName` attribute. After that you will be able to select animator state name value from dropdown list in Unity editor if Animator component is attached to inspected object.

```csharp
using UnityEngine;
using UnityForge;


[RequireComponent(typeof(Animation))]
public class AnimationNameExample : MonoBehaviour
{
    [SerializeField, AnimationName]
    private string animationName;

    private void Start()
    {
        var animation = GetComponent<Animation>();
        animation.Play(animationName);
    }
}
```

For the case of animation component field use `animationField` constructor parameter.

```csharp
using UnityEngine;
using UnityForge;

public class AnimationFieldExample : MonoBehaviour
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
```

### Caveats

Unity manages clips internally specifically so for some reason order of clips returned by [AnimationUtility.GetAnimationClips](https://docs.unity3d.com/ScriptReference/AnimationUtilityGetAnimationClips.html) differs from the one displayed in the editor.
