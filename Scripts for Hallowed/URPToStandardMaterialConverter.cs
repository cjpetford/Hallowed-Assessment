using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class URPToStandardMaterialConverter : EditorWindow
{
    [MenuItem("Tools/URP to Standard Material Converter")]
    public static void ShowWindow()
    {
        GetWindow<URPToStandardMaterialConverter>("URP to Standard Material Converter");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Convert URP Materials to Standard"))
        {
            ConvertURPToStandard();
        }
    }

    private void ConvertURPToStandard()
    {
        // Define a mapping between URP shaders and Standard shaders
        Dictionary<string, string> shaderMapping = new Dictionary<string, string>
        {
            { "Universal Render Pipeline/Lit", "Standard" },
            { "Universal Render Pipeline/Simple Lit", "Standard" },
            { "Universal Render Pipeline/Unlit", "Unlit/Texture" }
            // Add other mappings as necessary
        };

        // Find all materials in the project
        string[] materialGuids = AssetDatabase.FindAssets("t:Material");
        foreach (string guid in materialGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material material = AssetDatabase.LoadAssetAtPath<Material>(path);

            // Check if the material uses a URP shader and replace it
            if (shaderMapping.ContainsKey(material.shader.name))
            {
                string standardShaderName = shaderMapping[material.shader.name];
                Shader standardShader = Shader.Find(standardShaderName);
                if (standardShader != null)
                {
                    material.shader = standardShader;
                    EditorUtility.SetDirty(material);
                    Debug.Log($"Converted {material.name} from {material.shader.name} to {standardShaderName}");
                }
                else
                {
                    Debug.LogWarning($"Standard shader {standardShaderName} not found for material {material.name}");
                }
            }
        }

        // Save the changes to the assets
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
