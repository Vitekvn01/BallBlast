using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{

    public static MoneyUI Instance;
    [SerializeField] private Text textMoney;


    private int moneyAmount = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
     
     textMoney.text = "Money: " + moneyAmount.ToString();
     
    }


    public void UpdateMoneyAmount(int amount)
    {
        moneyAmount += amount;
        textMoney.text = "Money: " + moneyAmount.ToString();
    }

}
