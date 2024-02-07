using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    public void Show()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(true);
        }
    }

    public void Hide()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false);
        }
    }
}
