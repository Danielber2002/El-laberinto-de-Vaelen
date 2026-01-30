using UnityEngine;
using UnityEngine.SceneManagement;

public class GarrickLoadScenes : MonoBehaviour
{
    public void CambiarEscena(string nameOfNextScene)
    {
        PlayerPrefs.SetInt("PersonajeSeleccionado", 1);
        PlayerPrefs.Save();

        SceneManager.LoadScene(nameOfNextScene);
    }
}