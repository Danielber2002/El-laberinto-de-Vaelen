using UnityEngine;
using UnityEngine.SceneManagement;

public class GarrickLoadScenes : MonoBehaviour
{
    public void CambiarEscena(string nameOfNextScene)
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 1);
        SceneManager.LoadScene(nameOfNextScene);
    }
}