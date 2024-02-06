using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ALERTS
{
    INSUFFICIENT,
    INPUT_ERROR,

}

public class ATM : MonoBehaviour
{
    public static ATM instance;

    public Text textName;
    public Text textCash;
    public Text textBalance;

    public GameObject mainMenu; //TODO : main +
    public GameObject depositMenu; //TODO :  + menu
    public GameObject withdrawMenu; //TODO :  + menu

    public Customer customer;
    Account account;

    public InputField depositAmount;
    public InputField withdrawAmount;

    public GameObject[] Alerts;

    private void Awake()
    {
        instance = this;
        account = gameObject.AddComponent<Account>(); // Get 말고 Add로
        customer = new Customer();
    }

    void Start()
    {
        textCash.text = customer.cash.ToString();
        textBalance.text = account.balance.ToString();

        //TODO : 로그인 매니저 할당??
    }



    public void ShowMenu()
    {
        mainMenu.SetActive(true);
        depositMenu.SetActive(false);
        withdrawMenu.SetActive(false);
    }

    public void ShowDeposit()
    {
        mainMenu.SetActive(false);
        depositMenu.SetActive(true);
        withdrawMenu.SetActive(false);
    }

    public void ShowWithdraw()
    {
        mainMenu.SetActive(false);
        depositMenu.SetActive(false);
        withdrawMenu.SetActive(true);
    }

    public void RequestDeposit(int _cash)
    {
        if(_cash == -1)
            _cash = int.Parse(depositAmount.text);

        if (!account.Deposit(_cash))
            ShowAlert(ALERTS.INSUFFICIENT);

        ShowCustomerInform();
    }

    public void RequestWithdraw(int _cash)
    {
        if (_cash == -1)
            _cash = int.Parse(withdrawAmount.text);
        
        if (!account.Withdraw(_cash))
            ShowAlert(ALERTS.INSUFFICIENT);
        ShowCustomerInform();
    }

    public void ShowCustomerInform()
    {
        textCash.text = customer.cash.ToString();
        textBalance.text = account.balance.ToString();
    }

    private void ShowAlert(ALERTS alert)
    {
        Alerts[(int)alert].SetActive(true);
    }

    public void HideAlert(ALERTS alert)
    {
        Alerts[(int)alert].SetActive(false);
    }
}