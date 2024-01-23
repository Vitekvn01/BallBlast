using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class StoneSpawner : MonoBehaviour
{
    

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

    private void Start()
    {
        int damagePerSecond = (int)((turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate));

        stoneMaxHitPoints = (int)(damagePerSecond * maxHitPointsRate);
        stoneMinHitPoints = (int)(stoneMaxHitPoints * minHitPointsPercentage);
        timer = spawnRate;
    }


    private void Update()
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
    private void Spawn()
    {
        
        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        stone.SetSize((Stone.Size)Random.Range(1, 4));
        stone.maxHitPoints = Random.Range(stoneMinHitPoints, stoneMaxHitPoints + 1);
        Material stoneMaterial = stone.GetComponentInChildren<Renderer>().material;
        stoneMaterial.color = colorsStone[Random.Range(0, colorsStone.Length)];
        amountSpawned++;
    }
}