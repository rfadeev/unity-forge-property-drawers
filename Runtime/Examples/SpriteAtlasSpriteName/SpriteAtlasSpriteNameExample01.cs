#if UNITY_2017_1_OR_NEWER

using UnityEngine;
using UnityEngine.U2D;

namespace UnityForge
{
    public class SpriteAtlasSpriteNameExample01 : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private SpriteAtlas atlas;
        [SerializeField, SpriteAtlasSpriteName(spriteAtlasField: "atlas")]
        private string spriteName;
        [SerializeField]
        private SpriteRenderer spriteRenderer;
#pragma warning restore 0649

        private void Update()
        {
            spriteRenderer.sprite = atlas.GetSprite(spriteName);
        }
    }
}

#endif
