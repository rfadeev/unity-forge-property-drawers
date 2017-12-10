using UnityEngine;

namespace UnityForge
{
    public class GameObjectTagExample01 : MonoBehaviour
    {
        [SerializeField, GameObjectTag]
        private string exampleTag;

        private void Awake()
        {
            Debug.LogFormat("Example tag: {0}", exampleTag);
        }
    }
}
