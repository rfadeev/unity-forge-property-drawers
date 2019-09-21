using UnityEngine;

namespace UnityForge
{
    public class GameObjectTagExample01 : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField, GameObjectTag]
        private string exampleTag;
#pragma warning restore 0649

        private void Awake()
        {
            Debug.LogFormat("Example tag: {0}", exampleTag);
        }
    }
}
