using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class UILevelProgress : MonoBehaviour
{
    [SerializeField] private Stone stone;
    [SerializeField] private LevelState levelState;
    [SerializeField] private StoneSpawner stoneSpawner;

    [SerializeField] private Text currentLevelText;
    [SerializeField] private Text nextLevelText;
    [SerializeField] private Image fill;

    private float fillAmountStep;

    private void Start()
    {
        currentLevelText.text = levelState.Level.ToString();
        nextLevelText.text = (levelState.Level + 1).ToString();
        fill.fillAmount = 0;

        
    }


    public void AddFillAmount()
    {
        fillAmountStep = 1.0f / (float)stoneSpawner.StepStoneAmount;
        /*Debug.Log("шаг " + fillAmountStep);*/
        fill.fillAmount += fillAmountStep;
        
    }



}
