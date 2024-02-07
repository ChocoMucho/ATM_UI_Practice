using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainMenu : UIBase
{
    private UIManager UI;

    [SerializeField] private Button buttonDeposit;
    [SerializeField] private Button buttonWithdraw;

    private void Start()
    {
        UI = ATM.instance.UIManager;

        // 가져오기
        buttonDeposit = Util.FindChild<Button>(gameObject, "Button_Deposit");
        buttonWithdraw = Util.FindChild<Button>(gameObject, "Button_Withdraw");

        // 이벤트 등록
        buttonDeposit.onClick.AddListener(ShowDepositMenu);
        buttonWithdraw.onClick.AddListener(ShowWithdrawMenu);
    }

    public void ShowDepositMenu() => UI.ShowDeposit();

    public void ShowWithdrawMenu() => UI.ShowWithdraw();
}
