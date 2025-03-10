using UnityEngine;
using UnityEngine.SceneManagement;
public class EnterNextScene : MonoBehaviour
{
    public string nextSceneName;
    public GameObject win;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            win.SetActive(true);
            Invoke("LoadNextScene", 3f);
        }
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
