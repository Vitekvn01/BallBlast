using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelState : MonoBehaviour
{
    [SerializeField] private StoneSpawner spawner;
    [SerializeField] private Cart cart;
    [SerializeField] private GameObject defeatPanel;
    [SerializeField] private GameObject passedPanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private SaveProgress saveProgress;
    [Space(5)]
    public UnityEvent Passed;
    public UnityEvent Defeat;
    public UnityEvent Start;

    private int level = 1;

    public int Level => level;

    private float timer;
    private bool checkPassed;
    private bool isPassed = false;
    private bool isStart = false;

    public bool IsStart => isStart;
    private void Awake()
    {
        Load();
        spawner.Completed.AddListener(OnSpawnCompleted);
        cart.CollisionStone.AddListener(OnCartCollisionStone);
    }
    private void OnDestroy()
    {
        spawner.Completed.RemoveListener(OnSpawnCompleted);
        cart.CollisionStone.RemoveListener(OnCartCollisionStone);
    }

    private void OnCartCollisionStone()
    {
        Defeat.Invoke();
        defeatPanel.SetActive(true);
        upgradePanel.SetActive(true);
        isStart = false;
    }
    private void OnSpawnCompleted()
    {
        checkPassed = true;
    }


    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.F1) == true)
        {
            saveProgress.Reset();
        }
#endif
        if (isPassed == true) return;

        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            if (checkPassed == true)
            {
                if (FindObjectsOfType<Stone>().Length == 0 && isPassed == false)
                {
                    Passed.Invoke();
                    isPassed = true;
                    passedPanel.SetActive(true);
                    upgradePanel.SetActive(true);
                    level++;
                    Debug.Log("уровень " + level);
                    saveProgress.Save();
                    isStart = false;
                }
            }

            timer = 0;
        }
    }

    public void onStart()
    {
        isStart = true;
        startPanel.SetActive(false);
        upgradePanel.SetActive(false);
    }

   
    private void Load()
    {
        level = PlayerPrefs.GetInt("level", 1);
    }

    
}


