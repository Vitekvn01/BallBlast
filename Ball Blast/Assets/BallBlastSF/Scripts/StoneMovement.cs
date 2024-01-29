using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class StoneMovement : MonoBehaviour
{

    private Vector3 velocity;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float redoundSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float gravitiOffSet;

    private float horizontalSpeedSave;
    private float gravitySave;
    private float reboundSpeedSave;
    private float rotationSpeedSave;

    private static bool UseGravity = true;
    
    
    private void Awake()
    {
        velocity.x = -Mathf.Sign(transform.position.x) * horizontalSpeed;

    }
    private void Update()
    {
        Move();
    }
    private void TryEneubleGravity()
    {
        if (math.abs(transform.position.x) <= math.abs(LevelBoundary.Instance.LeftBorder) - gravitiOffSet)
        {
            UseGravity = true;
        }
    }


    private void Move()
    {
        if (UseGravity == true)
        {
            velocity.y -= gravity * Time.deltaTime;
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            velocity.x = Mathf.Sign(velocity.x) * horizontalSpeed;
            transform.position += velocity * Time.deltaTime;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelEdge levelEdge = collision.GetComponent<LevelEdge>();
        if (levelEdge != null)
        {
            if (levelEdge.Type == edgeType.Bottom)
            {

                velocity.y = redoundSpeed;
            }
            if (levelEdge.Type == edgeType.left && velocity.x < 0 || levelEdge.Type == edgeType.Right && velocity.x > 0)
            {

                velocity.x *= -1;
            }
        }
    }
    public void AddVerticalVelocity(float velocity)
    {
        this.velocity.y += velocity;
    }

    public void SetHorizontalDirection(float direction)
    {
        velocity.x = Mathf.Sign(direction) * horizontalSpeed;
    }

   
    public void FreezingStart()
    {

        UseGravity = false;
        /*horizontalSpeedSave = horizontalSpeed;
        gravitySave = gravity;
        reboundSpeedSave = redoundSpeed;
        rotationSpeedSave = rotationSpeed;

        

        timerBonus = 0;
        horizontalSpeed = 0;
        gravity = 0;
        redoundSpeed = 0;
        rotationSpeed = 0;*/

    }

    public void FreezingStop()
    {

        UseGravity = true;
        /* horizontalSpeed = horizontalSpeedSave;
         gravity = gravitySave;
         redoundSpeed = reboundSpeedSave;
         rotationSpeed = rotationSpeedSave;*/


    }

}
