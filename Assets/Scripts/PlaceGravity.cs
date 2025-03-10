using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class PlaceGravity : MonoBehaviour
{
    public EnterNextScene enterNextScene;
    public GameObject gravityPrefab;
    public GameObject blackHoleEffectPrefab;
    public int maxGravity;
    public int maxUndo;
    private int sceneGravity;
    public TMP_Text gravityLable;
    public TMP_Text UndoLable;
    public TMP_Text countDownLable;
    public GameObject countDown;
    public GameObject failLable;
    private int placedGravity;
    public float failTimer;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private bool isCountingDown = false;
    private int countDownNumber = 10;

    void Start()
    {
        placedGravity = 0;
        sceneGravity = maxGravity;
    }

    void Update()
    {
        gravityLable.text = "GravityWell:" + sceneGravity.ToString();
        UndoLable.text = "Undo:" + maxUndo.ToString();

        if (Input.GetMouseButtonDown(0) && placedGravity < maxGravity)
        {
            audioSource.PlayOneShot(audioClip);

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0f;

            Instantiate(gravityPrefab, worldPos, Quaternion.identity);
            GameObject effect = Instantiate(blackHoleEffectPrefab, worldPos, Quaternion.identity);
            effect.transform.localScale = new Vector3(3f, 3f, 3f);

            placedGravity++;
            sceneGravity--;
        }

        if (Input.GetMouseButtonDown(1) && maxUndo >= 1)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.CompareTag("Gravity"))
            {
                Destroy(hit.collider.gameObject);
                maxUndo--;
                placedGravity--;
                sceneGravity++;
            }
        }

        if (maxUndo == 0 && !isCountingDown && enterNextScene.win.activeInHierarchy == false)
        {
            countDown.SetActive(true);
            isCountingDown = true;
            StartCoroutine(CountdownRoutine());
        }

        if(enterNextScene.win.activeInHierarchy == false)
        {
            countDown.SetActive(false);
            isCountingDown = false;
        }
    }

    IEnumerator CountdownRoutine()
    {
        while (countDownNumber > 0)
        {
            countDownLable.text = countDownNumber.ToString();
            yield return new WaitForSeconds(1f);
            countDownNumber--;
        }

        countDown.SetActive(false);
        failLable.SetActive(true);
    }
}

