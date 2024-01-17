using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cart : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float vehicleWidth;

    private Vector3 movementTarget;

    private void Start()
    {
        movementTarget = transform.position; //ѕри старте целевва€ точка повозки = текущей позиции повозки, что бы избежать движени€ повозки в случае неиницилазированного movementTarget (0, 0, 0)
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, movementTarget, movementSpeed * Time.deltaTime);
    }

    public void SetMovementTarget(Vector3 target)
    {
        movementTarget = ClampMovementTarget(target);
    }

    private Vector3 ClampMovementTarget(Vector3 target)
    {
        float leftBorder = -8.8f + vehicleWidth * 0.5f;
        float rightBorder = 8.8f - vehicleWidth * 0.5f;

        Vector3 moveTarget = target;
        moveTarget.z = transform.position.z;
        moveTarget.y = transform.position.y;

        if(moveTarget.x < leftBorder) moveTarget.x = leftBorder;
        if (moveTarget.x > rightBorder) moveTarget.x = rightBorder;

        return moveTarget;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position - new Vector3(vehicleWidth * 0.5f,0.5f, 0), transform.position + new Vector3(vehicleWidth * 0.5f, -0.5f, 0));
    }
#endif
}
