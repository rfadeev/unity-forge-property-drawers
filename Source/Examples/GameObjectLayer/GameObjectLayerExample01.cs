using UnityEngine;

namespace UnityForge
{
    public class GameObjectLayerExample01 : MonoBehaviour
    {
        [SerializeField, GameObjectLayer]
        private int exampleLayer;

        private void Awake()
        {
            Debug.LogFormat("Example layer: {0}", exampleLayer);
        }
    }
}
