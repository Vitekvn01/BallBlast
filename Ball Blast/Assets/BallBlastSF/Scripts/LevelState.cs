using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelState : MonoBehaviour
{

    [SerializeField] private StoneSpawner spawner;
    [SerializeField] private Cart cart;

    [Space(5)]
    public UnityEvent Passed;
    public UnityEvent Defeat;

    private float timer;
    private bool checkPassed;
    private bool isPassed = false;
    private void Awake()
    {
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
    }
    private void OnSpawnCompleted()
    {
        checkPassed = true;
    }

    private void Update()
    {
        if (isPassed == true) return;

        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            if (checkPassed == true)
            {
                if (FindObjectsOfType<Stone>().Length == 0)
                {
                    Passed.Invoke();
                    isPassed = true;

                }
            }

            timer = 0;
        }
    }


}
