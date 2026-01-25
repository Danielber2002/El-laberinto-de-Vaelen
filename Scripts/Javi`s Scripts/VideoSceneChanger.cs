using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSceneChanger : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private string nombreDeLaEscena; // Nombre de la escena a cargar
    private VideoPlayer videoPlayer;

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void OnEnable()
    {
        // Nos suscribimos al evento que se activa cuando el video llega al final
        videoPlayer.loopPointReached += CambiarEscena;
    }

    void OnDisable()
    {
        // Es una buena práctica desuscribirse para evitar errores de memoria
        videoPlayer.loopPointReached -= CambiarEscena;
    }

    void CambiarEscena(VideoPlayer vp)
    {
        // Cargamos la siguiente escena
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}
