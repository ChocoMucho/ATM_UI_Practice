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

        // ��������
        buttonDeposit = Util.FindChild<Button>(gameObject, "Button_Deposit");
        buttonWithdraw = Util.FindChild<Button>(gameObject, "Button_Withdraw");

        // �̺�Ʈ ���
        buttonDeposit.onClick.AddListener(ShowDepositMenu);
        buttonWithdraw.onClick.AddListener(ShowWithdrawMenu);
    }

    public void ShowDepositMenu() => UI.ShowDeposit();

    public void ShowWithdrawMenu() => UI.ShowWithdraw();
}
