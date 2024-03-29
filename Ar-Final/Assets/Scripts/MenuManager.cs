using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Animator panelAnimator;
    [SerializeField] private GameObject creditsUI;
    [SerializeField] private GameObject menuUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        panelAnimator.SetTrigger("Reverse");
        Invoke("OpenGame", 1.2f);
    }

    void OpenGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenCredits()
    {
        menuUI.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void BackToMenu()
    {
        creditsUI.SetActive(false);
        menuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
