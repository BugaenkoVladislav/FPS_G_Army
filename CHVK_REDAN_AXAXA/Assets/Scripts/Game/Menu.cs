using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Canvas death;
    public Canvas menu;
    public Canvas UI;
    public Camera player_camera;
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        menu.gameObject.SetActive(false);
        death.gameObject.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            player_camera.gameObject.SetActive(false);
            UI.gameObject.SetActive(false);
            menu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Resume()
    {
        player_camera.gameObject.SetActive(true);
        Time.timeScale = 1;
        UI.gameObject.SetActive(true);
        menu.gameObject.SetActive(false);
    }
    public void Res()
    {
        SceneManager.LoadScene(sceneName);
        Resume();
    }
    public void DeathScreen()
    {
        Time.timeScale = 0;
        player_camera.gameObject.SetActive(false);
        death.gameObject.SetActive(true);
    }

}
