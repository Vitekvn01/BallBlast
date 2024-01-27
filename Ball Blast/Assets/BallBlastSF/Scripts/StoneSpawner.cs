using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField] private LevelState levelState;

    [Header("Spawn")]
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;
    [SerializeField] private Color[] colorsStone;

    [Header("Balance")]
    [SerializeField] private Turret turret;
    [SerializeField][Range(0.0f, 1.0f)] private float minHitPointsPercentage;
    [SerializeField] private float maxHitPointsRate;
    [SerializeField] private int amount;
    [Space(10)] public UnityEvent Completed;

    private int stoneMaxHitPoints;
    private int stoneMinHitPoints;

    private float timer;
    private float amountSpawned;

    private int stepStoneAmount;
    public int StepStoneAmount => stepStoneAmount;
    private void Start()
    {
        amount += levelState.Level;
        int damagePerSecond = (int)((turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate));
        stoneMaxHitPoints = (int)(damagePerSecond * maxHitPointsRate);
        stoneMinHitPoints = (int)(stoneMaxHitPoints * minHitPointsPercentage);
        timer = spawnRate;
        Debug.Log("спавн" + amount);
    }


    private void Update()
    {
        if (levelState.IsStart == true)
        {
            timer += Time.deltaTime;

            if (timer >= spawnRate)
            {
                Spawn();

                timer = 0;
            }
            if (amountSpawned == amount)
            {
                enabled = false;

                Completed.Invoke();
            }
        }
    }
    private void Spawn()
    {
        int randomSize = Random.Range(1, 4);
        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        stone.SetSize((Stone.Size)randomSize);
        amountSize(randomSize);
        stone.maxHitPoints = Random.Range(stoneMinHitPoints, stoneMaxHitPoints + 1);
        Material stoneMaterial = stone.GetComponentInChildren<Renderer>().material;
        stoneMaterial.color = colorsStone[Random.Range(0, colorsStone.Length)];
        amountSpawned++;
    }

    private void amountSize(int randomSize)
    {
        
        if (randomSize == 1) stepStoneAmount += 3;
        if (randomSize == 2) stepStoneAmount += 7;
        if (randomSize == 3) stepStoneAmount += 15;
        Debug.Log("делений " + stepStoneAmount);
    }

}