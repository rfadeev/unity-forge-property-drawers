using UnityEngine;

namespace UnityForge
{
    public class AssetPathExample01 : MonoBehaviour
    {
        [SerializeField, AssetPath(typeof(Sprite), false)]
        private string spriteProjectPath;
        [SerializeField, AssetPath(typeof(Sprite), true)]
        private string spriteResourcesPath;

        private void Awake()
        {
            Debug.LogFormat("spriteProjectPath {0}", spriteProjectPath);
            Debug.LogFormat("spriteResourcesPath {0}", spriteResourcesPath);
        }
    }
}
