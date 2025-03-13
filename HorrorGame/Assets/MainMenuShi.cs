using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuShi : MonoBehaviour
{
    private bool start;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject mainMenu;
    private void Start()
    {
        start = false;
    }

    private void Update()
    {
        if (start)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
                start = false;
            }
        }
    }

    public void StartGame()
    {
        startMenu.SetActive(true);
        mainMenu.SetActive(false);
        start = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
