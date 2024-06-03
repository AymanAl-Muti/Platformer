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
        GUIStyle titleStyle = new()
        {
            alignment = TextAnchor.MiddleCenter,
            fontStyle = FontStyle.Bold,
            normal = new(){textColor = Color.white}
        };

        GUILayout.Label("Script Creator", titleStyle);
        GUILayout.Label("Script name:");

        scriptName = EditorGUILayout.TextField("", scriptName);

        if(GUILayout.Button("Create Script"))
        {
            CreateScript();
        }
    }

    private void CreateScript()
    {
        if (scriptName.Length == 0)
        {
            Debug.Log("Script name length cannot be zero!");
            return;
        }

        // remove spaces and capitalize the first letter
        scriptName = scriptName.Replace(" ", "");
        scriptName = char.ToUpper(scriptName[0]) + scriptName[1..];

        string scriptPath = $"Assets/Scripts/{scriptName}.cs";

        // make sure this script doesn't already exist
        if (File.Exists(scriptPath))
        {
            Debug.Log("A file of that name already exists!");
            return;
        }

        using StreamWriter outfile = new(scriptPath);
        outfile.WriteLine("using UnityEngine;");
        outfile.WriteLine();
        outfile.WriteLine($"public class {scriptName} : MonoBehaviour");
        outfile.WriteLine("{");
        outfile.WriteLine("\t");
        outfile.Write("}");

        AssetDatabase.Refresh();
    }
}