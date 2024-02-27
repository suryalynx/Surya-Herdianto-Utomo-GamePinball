using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditMenu : MonoBehaviour
{
    public Button menu;
    // Start is called before the first frame update
     void Start()
    {
        menu.onClick.AddListener(MainMenu);
    }
    private void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
