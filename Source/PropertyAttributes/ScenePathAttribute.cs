using UnityEngine;

namespace UnityForge
{
    /// <summary>
    /// An attribute that can be applied to string field for it to
    /// have scene path value which can be selected via inspector
    /// dropdown menu.
    /// </summary>
    public class ScenePathAttribute : PropertyAttribute
    {
        /// <summary>
        /// If true, path will not contain "Assets/" prefix and ".unity"
        /// extension and can be used in SceneManager API. If false,
        /// path will be full project path.
        /// </summary>
        public bool SceneManagerPathType { get; private set; }

        /// <summary>
        /// If true, only scenes from build settings will be shown
        /// by inspector. If false, scenes from asset database will
        /// be shown instead.
        /// </summary>
        public bool FromBuildSettings { get; private set; }

        /// <summary>
        /// If true, only enabled scenes from build settings will
        /// be shown in inspector. If false, all scenes from
        /// build settings will be shown instead. Flag has no effect if
        /// SceneInBuild is false.
        /// </summary>
        public bool OnlyEnabled { get; private set; }

        public ScenePathAttribute(bool sceneManagerPathType = true, bool fromBuildSettings = true, bool onlyEnabled = true)
        {
            SceneManagerPathType = sceneManagerPathType;
            FromBuildSettings = fromBuildSettings;
            OnlyEnabled = onlyEnabled;
        }
    }
}
