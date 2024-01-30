using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

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

    private List<int> randomSizeList = new List<int>();


    private int stepStoneAmount;
    public int StepStoneAmount => stepStoneAmount;

    private int ñounter = 0;

    private float axisZStone = 0;
    private void Awake()
    {
        
    }
    private void Start()
    {
        GenerateSize(levelState.Level);
        amountSize();
        amount += levelState.Level;
        int damagePerSecond = (int)((turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate));
        stoneMaxHitPoints = (int)(damagePerSecond * maxHitPointsRate);
        stoneMinHitPoints = (int)(stoneMaxHitPoints * minHitPointsPercentage);
        timer = spawnRate;
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
        Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        spawnPosition.z -= axisZStone;
        axisZStone -= 0.001f;
        Stone stone = Instantiate(stonePrefab, spawnPosition, Quaternion.identity);
        stone.SetSize((Stone.Size)randomSizeList[ñounter]);
        ñounter++;
        stone.maxHitPoints = Random.Range(stoneMinHitPoints, stoneMaxHitPoints + 1);
        Material stoneMaterial = stone.GetComponentInChildren<Renderer>().material;
        stoneMaterial.color = colorsStone[Random.Range(0, colorsStone.Length)];
        amountSpawned++;
    }

    private void amountSize()
    {
        for (int i = 0; i < randomSizeList.Count; i++)
        {
            if (randomSizeList[i] == 1)
            {
                stepStoneAmount += 3; 
            }

            if (randomSizeList[i] == 2)
            {
                stepStoneAmount += 7; 
            }

            if (randomSizeList[i] == 3)
            {
                stepStoneAmount += 15;
            }
        }
    }

    private void GenerateSize(int level)
    {
        randomSizeList.Clear();

        for (int i = 0; i < level; i++)
        {
            int randomSize = Random.Range(1, 4);
            randomSizeList.Add(1);
            randomSizeList[i] = randomSize;
        }
    }
}