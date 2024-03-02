using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusTimer : MonoBehaviour
{
    [SerializeField] private LevelState levelState;
    [SerializeField] private StoneMovement movement;
    [SerializeField] private Cart cart;
    [SerializeField] private GameObject BonusInvulnerabilityPanel;
    [SerializeField] private GameObject bonusFreezingPanel;
    [SerializeField] private Text freezingText;
    [SerializeField] private Text InvulnerabilityText;
    private static bool bonusFreezing = false;
    private static bool bonusInvulnerability = false;
    private float timerBonus = 5;

    private void Awake()
    {
        bonusFreezing = false;
        bonusInvulnerability = false;
        bonusFreezingPanel.SetActive(false);
        BonusInvulnerabilityPanel.SetActive(false);
        movement.FreezingStop();
        cart.bonusInvulnerabilityStop();
    }
    private void Update()
    {
        if (levelState.IsStart == true)
        {
            if (bonusFreezing == true && bonusInvulnerability == false)
            {
                bonusFreezingPanel.SetActive(true);
                movement.FreezingStart();
                timerBonus -= Time.deltaTime;
                /*Debug.Log("Замороска актив" + timerBonus);*/
                freezingText.text = "Заморозка: " + ((int)timerBonus).ToString();

                if (timerBonus <= 0)
                {
                    bonusFreezingPanel.SetActive(false);
                    /*Debug.Log("Замороска ДЕактив");*/
                    movement.FreezingStop();
                    bonusFreezing = false;
                    timerBonus = 5;
                }
            }
            if (bonusInvulnerability == true && bonusFreezing == false)
            {
                BonusInvulnerabilityPanel.SetActive(true);
                cart.bonusInvulnerabilityStart();
                timerBonus -= Time.deltaTime;
                /*Debug.Log("Неуязвисмость актив" + timerBonus);*/
                InvulnerabilityText.text = "Неуязвимость: " + ((int)timerBonus).ToString();

                if (timerBonus <= 0)
                {
                    BonusInvulnerabilityPanel.SetActive(false);
                    /*Debug.Log("Неуязвисмость ДЕактив");*/
                    cart.bonusInvulnerabilityStop();
                    bonusInvulnerability = false;
                    timerBonus = 5;
                }
            }
        }
    }

    public static void FreezingBonusTrue()
    {
        if (bonusFreezing == false && bonusInvulnerability == false)
        {
            bonusFreezing = true;
        }  

    }

    public static void BonusInvulnerabilityTrue()
    {
        if (bonusFreezing == false && bonusInvulnerability == false)
        {
            bonusInvulnerability = true;
        }   
    }

}


