using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartInputConrol : MonoBehaviour
{
    [SerializeField] private Cart cart;

    private void Update()
    {
        cart.SetMovementTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
