using UnityEngine;

namespace UnityForge
{
    public class SortingLayerNameExample01 : MonoBehaviour
    {
        [SerializeField, SortingLayerName]
        private string exampleSortingLayerName;

        private void Awake()
        {
            Debug.LogFormat("Example sorting layer name: {0}", exampleSortingLayerName);
        }
    }
}
