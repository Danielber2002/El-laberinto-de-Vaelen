using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiosdeScenaSORREM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Sorrem0Introduccion()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 0);
        SceneManager.LoadScene("Sorrem-0 Introduccion");
    }

    public void Sorrem1Skeleton()
    {
        SceneManager.LoadScene("Sorrem-1 Skeleton");
    }

    public void Sorrem1Goblin()
    {
        SceneManager.LoadScene("Sorrem-1 Goblin");
    }

    public void Sorrem2Necrofago()
    {
        SceneManager.LoadScene("Sorrem-2 Necrofago");
    }

    public void Sorrem2ArañaGigante()
    {
        SceneManager.LoadScene("Sorrem-2 Araña Gigante");
    }

    public void Sorrem3CienoGris()
    {
        SceneManager.LoadScene("Sorrem-3 Cieno Gris");
    }

    public void Sorrem3Enjambre()
    {
        SceneManager.LoadScene("Sorrem-3 Enjambre");
    }

    public void Sorrem4Introduccion()   
    {
        SceneManager.LoadScene("Sorrem-4 Introduccion");
    }

    public void Sorrem4Fantasma()
    {
        SceneManager.LoadScene("Sorrem-4 Fantasma");
    }

    public void Sorrem4Doppelganger()
    {
        SceneManager.LoadScene("Sorrem-4 Doppelganger");
    }

    public void Sorrem5ReyTumulario()
    {
        SceneManager.LoadScene("Sorrem-5 Rey Tumulario");
    }

    public void Sorrem5Liche()
    {
        SceneManager.LoadScene("Sorrem-5 Liche");
    }

    public void Sorrem6Khull()
    {
        SceneManager.LoadScene("Sorrem-6 Khull");
    }

    public void Sorrem6Basilisco()
    {
        SceneManager.LoadScene("Sorrem-6 Basilisco");
    }
}