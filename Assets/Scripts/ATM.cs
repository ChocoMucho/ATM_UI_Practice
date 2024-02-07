using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATM : MonoBehaviour
{
    public static ATM instance;

    public Customer customer;
    public Account account;

    public UIManager UIManager;

    private void Awake()
    {
        instance = this;
        account = gameObject.AddComponent<Account>();
        customer = new Customer();

        UIManager = gameObject.AddComponent<UIManager>();
    }


    public void RequestDeposit(int _cash)
    {
        if (!account.Deposit(_cash))
            UIManager.ShowPopup(POPUP.INSUFFICIENT);
        UIManager.ResetUserInform();
    }

    public void RequestWithdraw(int _cash)
    {
        if (!account.Withdraw(_cash))
            UIManager.ShowPopup(POPUP.INSUFFICIENT);
        UIManager.ResetUserInform();
    }
}