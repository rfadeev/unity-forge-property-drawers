using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityForge
{
    public class ScenePathExample02 : MonoBehaviour
    {
        [SerializeField, ScenePath(shortPathType: false)]
        private string exampleScenePath;

        private void Awake()
        {
            // LoadSceneAsync supports both full and short scene paths. In this
            // example attribute is used with shortPathType set to false to get
            // full scene path for field. This is to emphasize difference from
            // LoadScene method which does not support full scene paths.
            SceneManager.LoadSceneAsync(exampleScenePath, LoadSceneMode.Additive);
        }
    }
}
