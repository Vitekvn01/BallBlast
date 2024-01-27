using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float fireRate;
    [SerializeField] private int projectileAmount;
    [SerializeField] private float projectileInterval;
    [SerializeField] private int damage;
    public int Damage => damage;
    public int ProjectileAmount => projectileAmount;

    public float FireRate => fireRate;

    private float timer;

    private void Awake()
    {
        Load();
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void SpawnProjectile()
    {
        float startposX = shootPoint.position.x - projectileInterval * (projectileAmount - 1) * 0.5f;

        for (int i = 0; i < projectileAmount; i++)
        {
            Projectile projectile = Instantiate(projectilePrefab, new Vector3(startposX + i * projectileInterval, shootPoint.position.y, shootPoint.position.z), transform.rotation);
            projectile.SetDamage(damage);
        }


    }
    public void Fire()
    {
        if (timer >= fireRate)
        {
            SpawnProjectile();

            timer = 0;
        }
    }

    public void AddDamage(int amount)
    {
        damage += amount;
    }
    public void AddFireRate(float amount)
    {
        fireRate -= amount;
    }

    public void AddProjectileAmount(int amount)
    {
        projectileAmount += amount;
    }

    private void Load()
    {
        fireRate = PlayerPrefs.GetFloat("fireRate", 1);
        damage = PlayerPrefs.GetInt("damage", 1);
        projectileAmount = PlayerPrefs.GetInt("projectileAmount", 1);
    }
}

