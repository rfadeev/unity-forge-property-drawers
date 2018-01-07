using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace UnityForge.Editor
{
    [CustomPropertyDrawer(typeof(AssetPathAttribute))]
    public class AssetPathDrawer : PropertyDrawer
    {
        private const string ResourcesFolderPath = "/Resources/";

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                position = EditorGUI.PrefixLabel(position, label);
                EditorGUI.LabelField(position, String.Format("Error: {0} attribute can be applied only to {1} type", typeof(AssetPathAttribute), SerializedPropertyType.String));
                return;
            }

            var assetPathAttribute = (AssetPathAttribute)attribute;
            var assetPath = property.stringValue;
            UnityEngine.Object asset = null;
            if (!String.IsNullOrEmpty(assetPath))
            {
                if (assetPathAttribute.ResourcesRelative)
                {
                    asset = Resources.Load(assetPath);
                }
                else
                {
                    asset = AssetDatabase.LoadAssetAtPath(assetPath, assetPathAttribute.AssetType);
                }
            }

            EditorGUI.BeginChangeCheck();
            asset = EditorGUI.ObjectField(position, label, asset, assetPathAttribute.AssetType, false);
            if (EditorGUI.EndChangeCheck())
            {
                if (asset == null)
                {
                    property.stringValue = null;
                }
                else
                {
                    assetPath = AssetDatabase.GetAssetPath(asset);
                    if (assetPathAttribute.ResourcesRelative)
                    {
                        if (assetPath.Contains(ResourcesFolderPath))
                        {
                            assetPath = assetPath
                                .Substring(assetPath.IndexOf(ResourcesFolderPath) + ResourcesFolderPath.Length)
                                .Replace(Path.GetExtension(assetPath), String.Empty);
                            property.stringValue = assetPath;
                        }

                    }
                    else
                    {
                        property.stringValue = assetPath;
                    }
                }
            }

            // TODO: [rfadeev] - Support showing asset path
            if (assetPathAttribute.ShowFullPath)
            {
            }
        }
    }
}
