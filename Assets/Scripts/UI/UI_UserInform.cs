using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_UserInform : UIBase
{
    private ATM ATM;

    [SerializeField] private Text customerName;
    [SerializeField] private Text cash;
    [SerializeField] private Text balance;


    private void Start()
    {
        ATM = ATM.instance;

        customerName = Util.FindChild<Text>(gameObject, "CustomerName");
        cash = Util.FindChild<Text>(gameObject, "Cash", true);
        balance = Util.FindChild<Text>(gameObject, "Balance");

        RefreshUserInform();
    }

    public void RefreshUserInform()
    {
        customerName.text = ATM.customer.name;
        cash.text = ATM.customer.cash.ToString();
        balance.text = ATM.account.balance.ToString();
    }
}
