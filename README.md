# Unity Forge Property Drawers [![License](https://img.shields.io/badge/license-MIT-lightgrey.svg?style=flat)](http://mit-license.org)
Custom propery drawers to ease fields value management in Unity editor.

## Attributes list

* [AnimatorStateName](#animatorstatename)
* [AnimatorLayerName](#animatorlayername)
* [AnimationName](#animationname)

## Attributes usage

Import `UnityForge` namespace to be able to use attribute from the [attributes list](#attributes-list)

## AnimatorStateName

![screencast](Documentation/animator-state-controller-example.gif)

### Attribute usage

Add attribute to string field to enable selection of animator state name value from dropdown list in Unity editor. Attribute without parameters works on Animator component attached to inspected object. Specify animator component via `animatorField` constructor parameter to enable state name selection from that component.

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

## AnimatorLayerName

```csharp
using UnityEngine;
using UnityForge;

public class AnimatorLayerName : MonoBehaviour
{
    [SerializeField, AnimatorStateName]
    private string stateName;

    [SerializeField, AnimatorLayerName]
    private string layerName;

    private void Start()
    {
        var animator = GetComponent<Animator>();
        if (animator != null)
        {
            var layerIndex = animator.GetLayerIndex(layerName);
            animator.Play(stateName, layerIndex);
        }
    }
}
```

## AnimationName

![screencast](Documentation/animation-name-example.png)

### Attribute usage

Add attribute to string field to enable selection of animation name value from dropdown list in Unity editor. Attribute without parameters works on Animation component attached to inspected object. Specify animator component via `animationField` constructor parameter to enable state name selection from that component.

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
