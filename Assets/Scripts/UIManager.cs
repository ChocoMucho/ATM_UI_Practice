using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum POPUP
{
    INSUFFICIENT,
    INPUT_ERROR,
}

public class UIManager : MonoBehaviour
{
    GameObject UI_Title;
    GameObject UI_UserInform;
    GameObject UI_MainMenu;
    GameObject UI_Deposit;
    GameObject UI_Withdraw;

    public GameObject[] Popups = new GameObject[(int)POPUP.INPUT_ERROR+1];

    // Start is called before the first frame update
    void Awake()
    {
        Init();
    }

    void Init()
    {
        UI_Title = Util.Instantiate<UI_Title>("Prefabs/UI", GameObject.Find("Canvas").transform);
        UI_UserInform = Util.Instantiate<UI_UserInform>("Prefabs/UI", GameObject.Find("Canvas").transform);
        UI_MainMenu = Util.Instantiate<UI_MainMenu>("Prefabs/UI", GameObject.Find("Canvas").transform);
        UI_Deposit = Util.Instantiate<UI_Deposit>("Prefabs/UI", GameObject.Find("Canvas").transform);
        UI_Withdraw = Util.Instantiate<UI_Withdraw>("Prefabs/UI", GameObject.Find("Canvas").transform);

        Popups[(int)POPUP.INSUFFICIENT] = Util.Instantiate<UI_Insufficient>("Prefabs/UI");
        Popups[(int)POPUP.INPUT_ERROR] = Util.Instantiate<UI_Input_Error>("Prefabs/UI");
        
        //처음에 숨길 UI들
        UI_Deposit.SetActive(false);
        UI_Withdraw.SetActive(false);
        Popups[(int)POPUP.INSUFFICIENT].SetActive(false);
        Popups[(int)POPUP.INPUT_ERROR].SetActive(false);
    }

    public void ResetUserInform() => UI_UserInform.GetComponent<UI_UserInform>().RefreshUserInform();

    public void ShowMainMenu()
    {
        UI_MainMenu.SetActive(true);
        UI_Deposit.SetActive(false);
        UI_Withdraw.SetActive(false);
    }

    public void ShowDeposit()
    {
        UI_MainMenu.SetActive(false);
        UI_Deposit.SetActive(true);
        UI_Withdraw.SetActive(false);
    }

    public void ShowWithdraw()
    {
        UI_MainMenu.SetActive(false);
        UI_Deposit.SetActive(false);
        UI_Withdraw.SetActive(true);
    }

    public void ShowPopup(POPUP popup)
    {
        Popups[(int)popup].SetActive(true);
    }

    public void HidePopup(POPUP popup)
    {
        Popups[(int)popup].SetActive(false);
    }
}
