using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartInputConrol : MonoBehaviour
{
    [SerializeField] private LevelState levelState;
    [SerializeField] private Cart cart;
    [SerializeField] private Turret turret;
    
    private void Update()
    {
        if (levelState.IsStart == true)
        {
            cart.SetMovementTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            if (Input.GetMouseButton(0) == true)
            {
                turret.Fire();
            }
        }
  
    }
}
