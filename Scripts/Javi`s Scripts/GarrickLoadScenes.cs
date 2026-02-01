using UnityEngine;
using UnityEngine.SceneManagement;

public class GarrickLoadScenes : MonoBehaviour
{
    public void CambiarEscena(string nameOfNextScene)
    {
        PlayerPrefs.SetInt("PersonajeSeleccionado", 1);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: PersonajeSeleccionado= {0}", PlayerPrefs.GetInt("PersonajeSeleccionado")));
        SceneManager.LoadScene(nameOfNextScene);
    }
}