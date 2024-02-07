using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Withdraw : UIBase
{
    private UIManager UI;
    private ATM ATM;

    [SerializeField] private Button ten;
    [SerializeField] private Button thirty;
    [SerializeField] private Button fifty;
    [SerializeField] private Button deposit;
    [SerializeField] private Button goBack;

    [SerializeField] private InputField inputField;

    void Start()
    {
        UI = ATM.instance.UIManager;
        ATM = ATM.instance;

        // 가져오기
        ten = Util.FindChild<Button>(gameObject, "Ten");
        thirty = Util.FindChild<Button>(gameObject, "Thirty");
        fifty = Util.FindChild<Button>(gameObject, "Fifty");
        deposit = Util.FindChild<Button>(gameObject, "Withdraw");
        goBack = Util.FindChild<Button>(gameObject, "GoBack");
        inputField = Util.FindChild<InputField>(gameObject, "InputField");

        // 이벤트 등록
        ten.onClick.AddListener(RequestWithdrawTen);
        thirty.onClick.AddListener(RequestWithdrawThirty);
        fifty.onClick.AddListener(RequestWithdrawFifty);
        deposit.onClick.AddListener(WithdrawAmountInput);
        goBack.onClick.AddListener(UI.ShowMainMenu);
    }

    private void RequestWithdrawTen() => ATM.RequestWithdraw(10000);
    private void RequestWithdrawThirty() => ATM.RequestWithdraw(30000);
    private void RequestWithdrawFifty() => ATM.RequestWithdraw(50000);

    private void WithdrawAmountInput()
    {
        int amount;
        if (int.TryParse(inputField.text, out amount))
        {
            ATM.RequestWithdraw(amount);
        }
        else
        {
            UI.ShowPopup(POPUP.INPUT_ERROR);
        }
    }
}
