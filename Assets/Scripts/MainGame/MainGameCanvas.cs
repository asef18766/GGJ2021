using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameCanvas : MonoBehaviour
{

    public GameObject gameOverObject;

    void Awake()
    {
        gameOverObject.SetActive(false);
    }
    public void PlayerDiedAnimation()
    {
        Time.timeScale = 0.5f;
        StartCoroutine(PlayerDied());
    }

    IEnumerator PlayerDied()
    {
        gameOverObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        Time.timeScale = 1f;
        gameOverObject.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
