using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{

    // Instanciar
    //public GameObject prefab;
   // private GameObject newObj;

    Vector3 startPosition;

    public GameObject pauseMenu;
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        //startPosition = gameObject.transform.position;
        //newObj = Instantiate(prefab, startPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.Return) && !newObj)
        {
            newObj = Instantiate(prefab, startPosition, Quaternion.identity);
        }*/

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (pauseMenu)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            active = !active;
            Time.timeScale = active ? 0.0f : 1.0f;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
