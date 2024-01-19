using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destructible : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int maxHitPoints;

    public UnityEvent Die;

    public UnityEvent ChangeHitPoints;

    private int hitPoints;

    private void Start()
    {
        hitPoints = maxHitPoints;
    }
    public void AplyDamage(int damage)
    {
        hitPoints -= damage;

        ChangeHitPoints.Invoke();

        if (hitPoints <= 0)
        {
            Kill();
        }
    }
    public void Kill()
    {
        hitPoints = 0;

        ChangeHitPoints.Invoke();

        Die.Invoke();
    }

    public void AddHitPoints(int addHitPoints)
    {
        hitPoints += addHitPoints;
        ChangeHitPoints.Invoke();
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }
    public int GetMaxHitPoints()
    {
        return maxHitPoints;
    }

}
