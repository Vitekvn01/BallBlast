using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[RequireComponent(typeof(StoneMovement))]
public class Stone : Destructible
{
    public enum Size
    {
        Small,
        Normal,
        Big,
        Huge
    }
    [SerializeField] private Size size;
    [SerializeField] private Stone stoneObject;
    [SerializeField] private Money moneyPrefab;
    [SerializeField] private float spawnUpForce;
    private UILevelProgress UIlevelProgress;
    public UnityEvent StoneDestroy;
    private StoneMovement movement;
    private void Awake()
    {
        UIlevelProgress = FindObjectOfType<UILevelProgress>();

        movement = GetComponent<StoneMovement>();

        Die.AddListener(OnStoneDestroyed);

        SetSize(size);
    }
   
    private void OnDestroy()
    {
        Die.RemoveListener(OnStoneDestroyed);
    }
    private void OnStoneDestroyed()
    {
        int randomBonus = Random.Range(1, 5);
        int randomSpawnMoney = Random.Range(1, 5); 
        if (size != Size.Small)
        {
            SpawnStones();
            UIlevelProgress.AddFillAmount();
        }
        else
        {
            UIlevelProgress.AddFillAmount();
        }

        if (randomSpawnMoney == 1)
        {
            SpawnMoney();
        }
        if (randomBonus == 1)
        {
            int random = Random.Range(1, 3);
            if (random == 1)
            {
                BonusTimer.FreezingBonusTrue();
                Debug.Log("Заморозка");
            }
            if (random == 2)
            {
                BonusTimer.BonusInvulnerabilityTrue();
                Debug.Log("Неуязвисмость");
            }

        }
        Destroy(gameObject);
    }
    private void SpawnMoney()
    {
        Money money = Instantiate(moneyPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity); 
    }
    private void SpawnStones()
    {
        float axisZ = 0;
        for (int i = 0; i < 2; i++)
        {
            axisZ -= 0.001f;
            Stone stone = Instantiate(stoneObject, new Vector3(transform.position.x, transform.position.y, transform.position.z - axisZ), Quaternion.identity);
            stone.SetSize(size - 1);
            stone.maxHitPoints = Mathf.Clamp(maxHitPoints / 2, 1, maxHitPoints);
            stone.movement.AddVerticalVelocity(spawnUpForce);
            stone.movement.SetHorizontalDirection((i % 2 * 2) - 1);
            
        }
    }
    public void SetSize(Size size)
    {
        if (size < 0) return;
        transform.localScale = GetVectorFromSize(size);
        this.size = size;
    }
    private Vector3 GetVectorFromSize(Size size)
    {
        if (size == Size.Huge) return new Vector3(1, 1, 1);
        if (size == Size.Big) return new Vector3(0.75f, 0.75f, 0.75f);
        if (size == Size.Normal) return new Vector3(0.6f, 0.6f, 0.6f);
        if (size == Size.Small) return new Vector3(0.4f, 0.4f, 0.4f);
        return Vector3.one;
    }

    
   

}
