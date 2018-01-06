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
            SceneManager.LoadScene(exampleScenePath, LoadSceneMode.Additive);
        }
    }
}
