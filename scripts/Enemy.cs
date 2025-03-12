using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform targetPosition;
    private GameObject target;
    private Vector3 moveDirection;
    private AtributosJugador targetAttributes;
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target == null) return;

        targetPosition = target.transform;
        moveDirection = (targetPosition.position - transform.position).normalized;
        targetAttributes = target.GetComponent<AtributosJugador>();

        if (targetAttributes.health > 0)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= moveDirection * moveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
