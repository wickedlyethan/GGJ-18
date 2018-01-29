using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeScriptableObject {
    [MenuItem("Assets/Create/Hacking Info")]
    public static void CreateMyAsset()
    {
        HackingInfo asset = ScriptableObject.CreateInstance<HackingInfo>();

        AssetDatabase.CreateAsset(asset, "Assets/NewHackingInfo.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}