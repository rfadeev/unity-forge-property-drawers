using System;
using UnityEngine;

namespace UnityForge
{
    /// <summary>
    /// An attribute that can be placed on a string field to make it appear in
    /// the inspector as an object picker for the specified typeand the
    /// selected objects path will be saved to the string field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class AssetPathAttribute : PropertyAttribute
    {
        /// <summary>
        /// The type of the asset this field points to.
        /// </summary>
        public Type AssetType { get; private set; }

        /// <summary>
        /// Is the asset supposed to be in the resources directory? If so the
        /// path will automatically be made relative to the resources directory
        /// and the extension will be removed.
        /// </summary>
        public bool ResourcesRelative { get; private set; }

        /// <summary>
        /// Show full path in the PropertyDrawer, not just the ObjectField.
        /// </summary>
        public bool ShowFullPath { get; private set; }

        /// <summary>
        /// Flags a field to be inspected as an object picker where only the
        /// path is saved.
        /// </summary>
        /// <param name="assetType">The type of the asset this field points to.</param>
        /// <param name="resourcesRelative">
        /// Is the asset supposed to be in the resources directory? If so the
        /// path will automatically be made relative to the resources directory
        /// and the extension will be removed.
        /// </param>
        public AssetPathAttribute(Type assetType, bool resourcesRelative)
        {
            AssetType = assetType;
            ResourcesRelative = resourcesRelative;
            ShowFullPath = false;
        }

        /// <summary>
        /// Flags a field to be inspected as an object picker where only the
        /// path is saved.
        /// </summary>
        /// <param name="assetType">The type of the asset this field points to.</param>
        /// <param name="resourcesRelative">
        /// Is the asset supposed to be in the resources directory? If so the
        /// path will automatically be made relative to the resources directory
        /// and the extension will be removed.
        /// </param>
        /// <param name="showFullPath">
        /// Show full path in the PropertyDrawer, not just the ObjectField.
        /// </param>
        public AssetPathAttribute(Type assetType, bool resourcesRelative, bool showFullPath)
        {
            AssetType = assetType;
            ResourcesRelative = resourcesRelative;
            ShowFullPath = showFullPath;
        }
    }
}
