using Codice.CM.SEIDInfo;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class RemoveMissingScript : MonoBehaviour
{
    //https://docs.unity3d.com/2020.1/Documentation/ScriptReference/PrefabUtility.EditPrefabContentsScope.html
    [MenuItem("MyMenu/RemoveMissingPrefabsWithScropt")]
    static void RemoveMissingPrefabsWithScope()
    {
        string assetPath = "Assets/New Prefab.prefab";
        using (var editingScope = new PrefabUtility.EditPrefabContentsScope(assetPath))
        {
            var prefabRoot = editingScope.prefabContentsRoot;

            for (var i = prefabRoot.transform.childCount - 1; i >= 0; i--)
            {
                if (prefabRoot.transform.GetChild(0).gameObject.name.Contains("Missing"))
                    Object.DestroyImmediate(prefabRoot.transform.GetChild(0).gameObject);
            }
        }
    }
}

