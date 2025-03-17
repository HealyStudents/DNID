using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    public bool isPaused;
    public GameObject theMenu;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        HidePauseMenu();
    }

    public void ShowPauseMenu()
    {
        isPaused = true;
        theMenu.SetActive(true);
    }

    public void HidePauseMenu() 
    {
        isPaused = false;
        theMenu.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Quitting game!");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused)
            {
                HidePauseMenu();
            }
            else
            {
                ShowPauseMenu();
            }
        }
    }
}
