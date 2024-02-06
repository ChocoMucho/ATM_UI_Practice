using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static GameObject Instantiate<T>(string path = null, Transform parent = null) where T : UIBase
    {
        if (string.IsNullOrEmpty(path))
            path = "Prefabs";

        // Take Class Name
        string fileName = typeof(T).Name; 

        // Take prefab
        GameObject prefab = Resources.Load<T>($"{path}/{fileName}").gameObject;
        
        // Instantiate a prefab
        GameObject go = Object.Instantiate(prefab, parent);
        go.name = fileName;

        return go;
    }
}
