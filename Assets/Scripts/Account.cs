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



    public bool Deposit(int amount) //�Ա�
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

    public bool Withdraw(int amount) //���
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
