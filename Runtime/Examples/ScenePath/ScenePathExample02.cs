using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityForge.PropertyDrawers
{
    public class ScenePathExample02 : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField, ScenePath(fullProjectPath: false)]
        private string exampleScenePath;
#pragma warning restore 0649

        private void Awake()
        {
            // LoadScene method does not support full scene paths, only short
            // paths w/o "Assets/" prefix and ".unity" extension. In this
            // example attribute is used with fullProjectPath set to false
            // to get short scene path for field.
            SceneManager.LoadScene(exampleScenePath, LoadSceneMode.Additive);
        }
    }
}
