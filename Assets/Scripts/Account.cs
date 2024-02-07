using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Account : MonoBehaviour
{
    public Customer Customer { get; set; }
    public int balance = 50000;

    void Start()
    {
        Customer = ATM.instance.customer;
    }



    public bool Deposit(int amount) //입금
    {
        if(Customer.cash < amount)
            return false;
        else
        {
            Customer.cash -= amount;
            balance += amount;

            return true;
        }
    }

    public bool Withdraw(int amount) //출금
    {
        if(balance < amount)
            return false;
        else
        {
            balance -= amount;
            Customer.cash += amount;

            return true;
        }
    }
}
