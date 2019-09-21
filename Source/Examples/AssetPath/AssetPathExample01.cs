using UnityEngine;

namespace UnityForge
{
    public class AssetPathExample01 : MonoBehaviour
    {
#pragma warning disable 0649
        [Header("Fields without path preview")]
        [SerializeField, AssetPath(typeof(Sprite), false)]
        private string spriteProjectPath01;
        [SerializeField, AssetPath(typeof(Sprite), true)]
        private string spriteResourcesPath01;
        [Header("Fields with path preview")]
        [SerializeField, AssetPath(typeof(Sprite), false, true)]
        private string spriteProjectPath02;
        [SerializeField, AssetPath(typeof(Sprite), true, true)]
        private string spriteResourcesPath02;
#pragma warning restore 0649

        private void Awake()
        {
            Debug.LogFormat("spriteProjectPath01 {0}", spriteProjectPath01);
            Debug.LogFormat("spriteResourcesPath01 {0}", spriteResourcesPath01);
            Debug.LogFormat("spriteProjectPath02 {0}", spriteProjectPath02);
            Debug.LogFormat("spriteResourcesPath02 {0}", spriteResourcesPath02);
        }
    }
}
