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

    private void Awake()
    {
        Load();
        levelState.Passed.AddListener(Save);
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


    public void UpdateMoneyAmount(int amount)
    {
        moneyAmount += amount;
        textMoney.text = "Money: " + moneyAmount.ToString();
    }


    private void Save()
    {
        PlayerPrefs.SetInt("moneyAmount", moneyAmount);
    }

    private void Load()
    {
        moneyAmount = PlayerPrefs.GetInt("moneyAmount", 0);
    }
}
