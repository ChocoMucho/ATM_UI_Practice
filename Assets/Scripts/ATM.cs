using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ATM : MonoBehaviour
{
    public static ATM instance;

    public Text textCash;
    public Text textBalance;

    public GameObject Menu; //TODO : main +
    public GameObject Deposit; //TODO :  + menu
    public GameObject Withdraw; //TODO :  + menu

    public Customer customer;
    Account account;

    public List<GameObject> Alerts;

    private void Awake()
    {
        instance = this;
        account = gameObject.AddComponent<Account>(); // Get ���� Add��
        customer = new Customer();
    }

    void Start()
    {
        textCash.text = customer.cash.ToString();
        textBalance.text = account.balance.ToString();

        //TODO : �α��� �Ŵ��� �Ҵ�??
    }



    public void ShowMenu()
    {
        Menu.SetActive(true);
        Deposit.SetActive(false);
        Withdraw.SetActive(false);
    }

    public void ShowDeposit()
    {
        Menu.SetActive(false);
        Deposit.SetActive(true);
        Withdraw.SetActive(false);
    }

    public void ShowWithdraw()
    {
        Menu.SetActive(false);
        Deposit.SetActive(false);
        Withdraw.SetActive(true);
    }

    public void RequestDeposit(int _cash)
    {
        if(account.Deposit(_cash))
        {
        }
        else
        {
            // TODO : �Ա� �Ұ� �˾�
        }

        ShowCustomerInform();
    }

    public void RequestWithdraw(int _cash)
    {
        if (account.Withdraw(_cash))
        { }
        else { }

        ShowCustomerInform();
    }

    public void ShowCustomerInform()
    {
        textCash.text = customer.cash.ToString();
        textBalance.text = account.balance.ToString();
    }
}