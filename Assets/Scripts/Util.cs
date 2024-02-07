using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    // 프리팹 객체화 시키고 객체 반환
    public static GameObject Instantiate<T>(string path = null, Transform parent = null) where T : UIBase
    {
        if (string.IsNullOrEmpty(path))
            path = "Prefabs";

        string fileName = typeof(T).Name; 

        GameObject prefab = Resources.Load<T>($"{path}/{fileName}").gameObject;
        
        GameObject go = Object.Instantiate(prefab, parent);
        go.name = fileName;

        return go;
    }

    // 이름으로 자식 가져오기
    public static T FindChild<T>(GameObject go, string componentName, bool isRecur = false) where T : UnityEngine.Object
    {
        if (go == null) return null;

        if(!isRecur)
        {
            for (int i = 0; i < go.transform.childCount; ++i)
            {
                Transform transform = go.transform.GetChild(i);
                if (transform.name == componentName)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else
        {
            foreach(T component in go.GetComponentsInChildren<T>())
            {
                if(componentName == component.name)
                    return component;
            }
        }

        return null;
    }
}
