using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        int actualScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Escena actual: " + actualScene + " | " + "Siguiente escena: " + actualScene+1);
        SceneManager.LoadScene(actualScene + 1);
    }

    public void Exit()
    {
        Debug.Log("Se pulsó en el botón Salir.");
        Application.Quit();
    }
}
