using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityForge
{
    public class ScenePathExample01 : MonoBehaviour
    {
        [SerializeField, ScenePath]
        private string exampleScenePath;

        private void Awake()
        {
            // LoadScene method does not support full scene paths, only short
            // paths w/o "Assets/" prefix and ".unity" extension. In this
            // example attribute is used with default constructor parameters
            // so shortPathType is set to true to get short scene path for field.
            SceneManager.LoadScene(exampleScenePath, LoadSceneMode.Additive);
        }
    }
}
