using System;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ScriptCreator : EditorWindow
{
    private string scriptName;

    [MenuItem("Window/Custom Windows/Script Creator")]
    public static void ShowWindow()
    {
        GetWindow<ScriptCreator>("Script Creator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Script name:");

        scriptName = EditorGUILayout.TextField(String.Empty, scriptName);

        if(GUILayout.Button("Create Script"))
        {
            CreateScript();
        }
    }

    private bool CreateScript()
    {
        if (scriptName.Length == 0)
        {
            Debug.Log("Script name length cannot be zero!");
            return false;
        }

        // remove spaces and capitalize the first letter
        scriptName = scriptName.Replace(" ", "");
        scriptName = char.ToUpper(scriptName[0]) + scriptName[1..];

        string scriptPath = $"Assets/Scripts/{scriptName}.cs";

        // make sure this script doesn't already exist
        if (File.Exists(scriptPath))
        {
            Debug.Log("A file of that name already exists!");
            return false;
        }

        using StreamWriter outFile = new(scriptPath);
        outFile.WriteLine("using UnityEngine;");
        outFile.WriteLine();
        outFile.WriteLine($"public class {scriptName} : MonoBehaviour");
        outFile.WriteLine("{");
        outFile.WriteLine("    ");
        outFile.Write("}");

        AssetDatabase.Refresh();
        return true;
    }
}