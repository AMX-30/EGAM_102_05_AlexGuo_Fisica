using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ReloadCurrentScene();
        }
    }
}
