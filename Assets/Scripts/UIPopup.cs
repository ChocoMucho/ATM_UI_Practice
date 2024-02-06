using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : UIBase
{
    [SerializeField] private GameObject popupCanvas;
    
    public void Show()
    {
        if(popupCanvas != null)
        {
            popupCanvas.SetActive(true);
        }
    }

    public void Hide()
    {
        if (popupCanvas != null)
        {
            popupCanvas.SetActive(false);
        }
    }
}
