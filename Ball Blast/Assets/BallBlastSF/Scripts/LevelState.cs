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

    [Space(5)]
    public UnityEvent Passed;
    public UnityEvent Defeat;
    public UnityEvent Start;

    private static int level = 1;

    public static int Level => level;

    private float timer;
    private bool checkPassed;
    private bool isPassed = false;
    private static bool isStart = false;

    public static bool IsStart => isStart;
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
            Reset();
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
                    level++;
                    Debug.Log("уровень " + level);
                    Save();
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
    }

    private void Save()
    {
        PlayerPrefs.SetInt("level", level);
    }
    private void Load()
    {
        level = PlayerPrefs.GetInt("level", 1);
    }

    private void Reset()
    {
        PlayerPrefs.DeleteKey("level");


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


