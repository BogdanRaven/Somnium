using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MenuPanel;
    public GameObject SetingPanel;
    public GameObject AvtorPanel;

    void Start()
    {
        MenuPanel.SetActive(true);
        SetingPanel.SetActive(false);
        AvtorPanel.SetActive(false);
    }

    public void NewGame()
    {
        MenuPanel.SetActive(false);
        SetingPanel.SetActive(false);
        AvtorPanel.SetActive(false);

        SceneManager.LoadScene("Chapter1");
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Options()
    {
        MenuPanel.SetActive(false);
        SetingPanel.SetActive(true);
        AvtorPanel.SetActive(false);
    }

    public void Avtor()
    {
        MenuPanel.SetActive(false);
        SetingPanel.SetActive(false);
        AvtorPanel.SetActive(true);
    }

    public void Back()
    {
        MenuPanel.SetActive(true);
        SetingPanel.SetActive(false);
        AvtorPanel.SetActive(false);
    }
    
}
