using UnityEngine;
using UnityEngine.Pool;

public class Banknote : MonoBehaviour
{
    public IObjectPool<Banknote> pool;

    [Header("Momevemnt")]
    [SerializeField] private float MoveForce = 6f;

    [SerializeField] private float GravityForce = 9.8f;

    [Tooltip("Коэффицент движения по горизонтали")]
    [SerializeField] private float randomHorizontalVelocity = 1.5f;

    [Header("Rotation")]
    [SerializeField] private float MinRotationSpeed = -30f;
    [SerializeField] private float MaxRotationSpeed = 40f;

    private float verticalVelocity;
    private float horizontalVelocity;
    private float randomRotationSpeed;

    private void OnEnable()
    {
        verticalVelocity = MoveForce + Random.Range(1, 2f);
        horizontalVelocity = Random.Range(-randomHorizontalVelocity, randomHorizontalVelocity);
        randomRotationSpeed = Random.Range(MinRotationSpeed, MaxRotationSpeed);
    }


    void Update()
    {
        if(verticalVelocity > -GravityForce)
            verticalVelocity -= GravityForce * Time.deltaTime;

        Vector3 movementDirection = new Vector3(horizontalVelocity, verticalVelocity, 0);
        transform.position += movementDirection * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, randomRotationSpeed);
    }

    private void OnBecameInvisible()
    {
        pool.Release(this);
    }
}
