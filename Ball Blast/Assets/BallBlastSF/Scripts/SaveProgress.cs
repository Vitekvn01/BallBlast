using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SaveProgress : MonoBehaviour
{
    [SerializeField] private Turret turret;
    [SerializeField] private MoneyUI money;
    [SerializeField] private LevelState levelState;
    [SerializeField] private UIUpdatePanel updatePanel;




    public void Save()
    {
        PlayerPrefs.SetInt("level", levelState.Level);
        PlayerPrefs.SetInt("moneyAmount", money.MoneyAmount);
        PlayerPrefs.SetFloat("fireRate", turret.FireRate);
        PlayerPrefs.SetInt("damage", turret.Damage);
        PlayerPrefs.SetInt("projectileAmount", turret.ProjectileAmount);
        PlayerPrefs.SetInt("fireRateLevel", updatePanel.FireRateLevel);
    }


    public void Reset()
    {
        PlayerPrefs.DeleteAll();


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
