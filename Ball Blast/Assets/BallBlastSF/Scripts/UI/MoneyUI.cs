using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private LevelState levelState;

    public static MoneyUI Instance;
    [SerializeField] private Text textMoney;


    private int moneyAmount = 0;

    public int MoneyAmount => moneyAmount;
    private void Awake()
    {
        Load();
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    private void Start()
    {

        textMoney.text = "Money: " + moneyAmount.ToString();

    }

    private void Update()
    {
        if (moneyAmount < 0)
        {
            moneyAmount = 0;
        }
        textMoney.text = "Money: " + moneyAmount.ToString();
    }
    public void AddMoneyAmount(int amount)
    {
        moneyAmount += amount;
        textMoney.text = "Money: " + moneyAmount.ToString();
    }

    public void RemoveMoneyAmount(int amount)
    {
        moneyAmount -= amount;
        textMoney.text = "Money: " + moneyAmount.ToString();
    }


    private void Load()
    {
        moneyAmount = PlayerPrefs.GetInt("moneyAmount", 0);
    }
}
