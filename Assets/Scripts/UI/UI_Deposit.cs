using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Deposit : UIBase
{
    private UIManager UI;
    private ATM ATM;

    [SerializeField] private Button ten;
    [SerializeField] private Button thirty;
    [SerializeField] private Button fifty;
    [SerializeField] private Button deposit;
    [SerializeField] private Button goBack;

    [SerializeField] private InputField inputField;


    private void Start()
    {
        UI = ATM.instance.UIManager;
        ATM = ATM.instance;
        
        // 가져오기
        ten = Util.FindChild<Button>(gameObject, "Ten");
        thirty = Util.FindChild<Button>(gameObject, "Thirty");
        fifty = Util.FindChild<Button>(gameObject, "Fifty");
        deposit = Util.FindChild<Button>(gameObject, "Deposit");
        goBack = Util.FindChild<Button>(gameObject, "GoBack");
        inputField = Util.FindChild<InputField>(gameObject, "InputField");

        // 이벤트 등록
        ten.onClick.AddListener(RequestDepositTen);
        thirty.onClick.AddListener(RequestDepositThirty);
        fifty.onClick.AddListener(RequestDepositFifty);
        deposit.onClick.AddListener(DepositAmountInput);
        goBack.onClick.AddListener(UI.ShowMainMenu);
    }

    private void RequestDepositTen() => ATM.RequestDeposit(10000);
    private void RequestDepositThirty() => ATM.RequestDeposit(30000);
    private void RequestDepositFifty() => ATM.RequestDeposit(50000);

    // 값 입력 받아야해서 경유지 만듦
    private void DepositAmountInput()
    {
        int amount;
        if(int.TryParse(inputField.text, out amount))
        {
            ATM.RequestDeposit(amount);
        }
        else
        {
            UI.ShowPopup(POPUP.INPUT_ERROR);
        }
    }
}
