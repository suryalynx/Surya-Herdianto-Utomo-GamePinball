using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public Button creditButton;

    void Start()
    {
        startButton.onClick.AddListener(PlayBtn);
        quitButton.onClick.AddListener(ExitBtn);
        creditButton.onClick.AddListener(CreditBtn);
    }
    private void PlayBtn(){
        SceneManager.LoadScene("Pinball");
    }
    private void CreditBtn(){
        SceneManager.LoadScene("Credits");
    }

    private void ExitBtn(){
        Application.Quit();
    }
}
