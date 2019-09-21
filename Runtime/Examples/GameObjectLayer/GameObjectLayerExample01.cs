using UnityEngine;

namespace UnityForge.PropertyDrawers
{
    public class GameObjectLayerExample01 : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField, GameObjectLayer]
        private int exampleLayer;
#pragma warning restore 0649

        private void Awake()
        {
            Debug.LogFormat("Example layer: {0}", exampleLayer);
        }
    }
}
