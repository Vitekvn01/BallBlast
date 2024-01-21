using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneHitPointsText : MonoBehaviour
{
    private Destructible destructible;
    [SerializeField] private Text hitPointText;

    private void Awake()
    {
        destructible = GetComponent<Destructible>();

        destructible.ChangeHitPoints.AddListener(OnChangeHitPoints);
    }

    private void OnDestroy()
    {
        destructible.ChangeHitPoints.RemoveListener(OnChangeHitPoints);
    }
    private void OnChangeHitPoints()
    {
        int hitPoints = destructible.GetHitPoints();

        if (hitPoints >= 1000)
        {
            hitPointText.text = hitPoints / 1000 + "Ê";
        }
        else
        {
            hitPointText.text = hitPoints.ToString();
        }



    }
}
