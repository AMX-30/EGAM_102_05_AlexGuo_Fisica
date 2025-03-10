using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
