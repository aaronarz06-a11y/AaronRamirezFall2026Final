using UnityEngine;

public class Player : MonoBehaviour
{
    public float acceleration = 5f;
    public float maxSpeed = 15f;
    public float reverseSpeed = 8f;
    public float deceleration = 8f;
    public float boostMaxSpeed = 25f;
    public TurnPoint turnPoint;
    private Rigidbody rb;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = 0f;
    }

    void Update()
    {
        Accelerate();
        TurnCar();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void Accelerate()
    {
        float maxAllowedSpeed = maxSpeed;

        if (Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.W))
        {
            maxAllowedSpeed = boostMaxSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -reverseSpeed, maxAllowedSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentSpeed -= acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -reverseSpeed, maxSpeed);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
        }
    }

    void MovePlayer()
    {
        Vector3 movement = transform.forward * currentSpeed;
        movement.y = rb.linearVelocity.y;
        rb.linearVelocity = movement;
    }

    void TurnCar()
    {
        if (turnPoint == null)
        return;

        float steeringAngle = turnPoint.GetSteeringAngle();
        float turnAmount = steeringAngle * Mathf.Abs(currentSpeed) * 0.1f;
        rb.MoveRotation( rb.rotation * Quaternion.Euler(0f, turnAmount * Time.deltaTime, 0f) );
    }
}