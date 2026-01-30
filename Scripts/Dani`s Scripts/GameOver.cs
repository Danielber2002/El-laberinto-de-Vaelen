using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void Retry()
    {
        SceneManager.LoadScene("CharacterSelection");
    }

    public void Rules()
    {
        SceneManager.LoadScene("Reglas");
    }   

    public void Exit()
    {
        Application.Quit();
    }
}
