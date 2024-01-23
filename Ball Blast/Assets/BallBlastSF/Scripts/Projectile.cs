using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    private int damage;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destructible destructible = collision.transform.root.GetComponent<Destructible>();

        if (destructible != null)
        {
            destructible.AplyDamage(damage);
        }

        Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}
