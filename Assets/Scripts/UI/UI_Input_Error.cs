using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Input_Error : UIBase
{
    [SerializeField] private Button close;

    private void Start()
    {
        close = Util.FindChild<Button>(gameObject, "Close", true);

        close.onClick.AddListener(Hide);
    }
}
