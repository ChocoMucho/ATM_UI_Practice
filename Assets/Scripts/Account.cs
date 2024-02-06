using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Account : MonoBehaviour
{
    Customer customer;
    string customerId = "";
    public int balance = 50000;

    void Start()
    {
        customer = ATM.instance.customer;
    }

    void Update()
    {
        
    }


    // TODO : 입출금 유효 판단
    public bool Deposit(int _cash)
    {
        customer.cash -= _cash;
        balance += _cash;

        return true;
    }

    public bool Withdraw(int _cash)
    {
        balance -= _cash;
        customer.cash += _cash;

        return true;
    }
}
