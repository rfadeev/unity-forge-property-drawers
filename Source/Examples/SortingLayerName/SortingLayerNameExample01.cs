using UnityEngine;

namespace UnityForge
{
    public class SortingLayerNameExample01 : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField, SortingLayerName]
        private string exampleSortingLayerName;
#pragma warning restore 0649

        private void Awake()
        {
            Debug.LogFormat("Example sorting layer name: {0}", exampleSortingLayerName);
        }
    }
}
