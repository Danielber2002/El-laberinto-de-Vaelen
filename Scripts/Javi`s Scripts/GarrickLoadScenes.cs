using UnityEngine;
using UnityEngine.SceneManagement;

public class GarrickLoadScenes : MonoBehaviour
{
    public void CambiarEscena(string nameOfNextScene)
    {
        SceneManager.LoadScene(nameOfNextScene);
    }
}