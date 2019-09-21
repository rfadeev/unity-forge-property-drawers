using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityForge
{
    public class ScenePathExample01 : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField, ScenePath]
        private string exampleScenePath;
#pragma warning restore 0649

        private void Awake()
        {
            // LoadSceneAsync supports both full and short scene paths. In this
            // example attribute is used with default constructor to get
            // full scene path for field. This is to emphasize difference from
            // LoadScene method which does not support full scene paths.
            SceneManager.LoadSceneAsync(exampleScenePath, LoadSceneMode.Additive);
        }
    }
}
