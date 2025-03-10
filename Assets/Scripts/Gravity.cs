using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravityForce;

    void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;
        if(rb)
        {
            Vector2 direction = (transform.position - other.transform.position).normalized;
            float distance = Vector2.Distance(transform.position, other.transform.position);
            rb.AddForce(direction * (gravityForce / distance));
        }
    }
}