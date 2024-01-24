using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.GetComponent<Cart>() != null)
        {
            MoneyUI.Instance.UpdateMoneyAmount(1);
            Destroy(gameObject);
        }
    }

}
