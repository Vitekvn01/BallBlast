using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StoneSpawner : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;

    [Header("Balance")]
    [SerializeField] private Turret turret;
    [SerializeField][Range(0.0f, 1.0f)] private float minHitPointsPercentage;
    [SerializeField] private float maxHitPointsRate;
    [SerializeField] private int amount;


    private float timer;
    private float amountSpawned;


    private void Awake()
    {
        timer = spawnRate;
    }

    private void Start()
    {
        int damagePerSecond = (int)((turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate));
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            Spawn();

            timer = 0;
        }

    }
    private void Spawn()
    {
        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        stone.SetSize((Stone.Size)Random.Range(1, 4));

        amountSpawned++;
    }
}