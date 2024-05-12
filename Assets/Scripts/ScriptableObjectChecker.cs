using UnityEngine;
using UnityEditor;

public class ScriptableObjectChecker : MonoBehaviour
{
    [MenuItem("Tools/Check Scriptable Objects")]
    private static void CheckScriptableObjects()
    {
        string directoryPath = "Assets/ScriptableObjects"; // Modify this path to your desired directory

        string[] guids = AssetDatabase.FindAssets("t:ScriptableObject", new[] { directoryPath });

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ScriptableObject scriptableObject = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);

            // Check the value of a specific property
            if (scriptableObject != null)
            {
                Debug.Log("Found Scriptable Object: " + scriptableObject.name);
            }
        }
    }
}