using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
