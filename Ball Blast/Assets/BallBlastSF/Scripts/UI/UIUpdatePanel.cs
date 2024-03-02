using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdatePanel : MonoBehaviour
{
    [SerializeField] private Text fireRate;
    [SerializeField] private Text damage;
    [SerializeField] private Text projetctile;
    [SerializeField] private Turret turret;
    [SerializeField] private MoneyUI money;
    [SerializeField] private int price�oefficient = 5;

    private int fireRateLevel = 1;
    
    public int FireRateLevel => fireRateLevel;

    private void Awake()
    {
        Load();
    }
    private void Start()
    {
        fireRate.text = "����������������: " + fireRateLevel.ToString() + "\n���� :" + (price�oefficient * fireRateLevel).ToString();
        damage.text = "����: " + turret.Damage.ToString() + "\n���� :" + (price�oefficient * turret.Damage).ToString();
        projetctile.text = "���-�� ��������: " + turret.ProjectileAmount.ToString() + "\n���� :" + (price�oefficient * turret.ProjectileAmount).ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        fireRate.text = "����������������: " + fireRateLevel.ToString() + "\n���� :" + (price�oefficient * fireRateLevel).ToString();
        damage.text = "����: " + turret.Damage.ToString() + "\n���� :" + (price�oefficient * turret.Damage).ToString();
        projetctile.text = "���-�� ��������: " + turret.ProjectileAmount.ToString() + "\n���� :" + (price�oefficient * turret.ProjectileAmount).ToString();
    }

    public void addFireRateLevel(int amount)
    {
        fireRateLevel += amount;
    }

    public void ButtonClickFireRate()
    {
        if (money.MoneyAmount >= price�oefficient * fireRateLevel)
        {
            money.RemoveMoneyAmount(price�oefficient * fireRateLevel);
            turret.AddFireRate(0.1f);
            fireRateLevel++;
        }
    }

    public void ButtonClickDamage()
    {
        if (money.MoneyAmount >= price�oefficient * turret.Damage)
        {
            money.RemoveMoneyAmount(price�oefficient * turret.Damage);
            turret.AddDamage(1);
        }

    }

    public void ButtonClickProjectile()
    {
        if(money.MoneyAmount >= price�oefficient * turret.ProjectileAmount)
        {
            money.RemoveMoneyAmount(price�oefficient * turret.ProjectileAmount);
            turret.AddProjectileAmount(1);
        }

    }

    private void Load()
    {
        fireRateLevel = PlayerPrefs.GetInt("fireRateLevel", 1);
    }
}
