using UnityEditor;
using System.IO;

public class ScriptCreator : EditorWindow
{
    private const string ScriptText = "using UnityEngine;\n\npublic class $1 : MonoBehaviour\n{\n    \n}";
    
    [MenuItem("Assets/Create/Good C# Script", false, 50)]
    private static void CreateCustomScript()
    {
        ProjectWindowUtil.CreateAssetWithContent("NewScript.cs", string.Empty);
 
        Selection.selectionChanged += SelectionHook;
    }
    
    private static void SelectionHook()
    {
        if(Selection.activeObject is null)
        {
            return;
        }
        
        Selection.selectionChanged -= SelectionHook;
        
        string assetPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        string scriptName = Path.GetFileNameWithoutExtension(assetPath);
        File.WriteAllText(assetPath, ScriptText.Replace("$1", scriptName));
        AssetDatabase.Refresh();
    }
}