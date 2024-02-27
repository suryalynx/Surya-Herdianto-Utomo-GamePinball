using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    public Button backToMenu;
    // Start is called before the first frame update
    void Start()
    {
        backToMenu.onClick.AddListener(MainMenu);
    }
    private void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
