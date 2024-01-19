using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartInputConrol : MonoBehaviour
{
    [SerializeField] private Cart cart;
    [SerializeField] private Turret turret;
    [SerializeField] private float fireRate;
    private void Update()
    {
        cart.SetMovementTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButton(0) == true)
        {
            Turret.Fire();
        }
    }
}
