using UnityEngine;

public class UpDownMove : MonoBehaviour
{
    public float amplitude = 2f;    // How far it moves vertically
    public float speed = 1f;        // Speed of vertical movement

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
}