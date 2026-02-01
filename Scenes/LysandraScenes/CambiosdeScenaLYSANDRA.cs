using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiosdeScenaLYSANDRA : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Lysandra0Introduccion()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        SceneManager.LoadScene("Lysandra-1  Puertas");
    }

    public void LysandraPuertaMala()
    {
        SceneManager.LoadScene("Puerta Mala");
    }

    public void LysandraRatas()
    {
        SceneManager.LoadScene("Ratas");
    }

    public void LysandraCieno()
    {
        SceneManager.LoadScene("CienoAlquitran");
    }

    public void LysandraEsqueleto()
    {
        SceneManager.LoadScene("Esqueleto");
    }

    public void LysandraSombra()
    {
        SceneManager.LoadScene("Sombra");
    }

    public void Doppelabuela()
    {
        SceneManager.LoadScene("Doppel.abuela");
    }

    public void Doppelfamilia()   
    {
        SceneManager.LoadScene("Doppel.familia");
    }

    public void LysandraAraña()
    {
        SceneManager.LoadScene("araña");
    }

    public void LysandraEspectro()
    {
        SceneManager.LoadScene("Espectro");
    }

    public void Doppel1()
    {
        SceneManager.LoadScene("Doppel.final");
    }

    public void Doppel2()
    {
        SceneManager.LoadScene("Doppel.final 2");
    }

    public void Doppel3()
    {
        SceneManager.LoadScene("Doppel.final 3");
    }
    
    public void EscenaFinal1()
    {
        SceneManager.LoadScene("QuimeraSorren");
    }

    public void EscenaFinal2()
    {
        SceneManager.LoadScene("QuimeraGarrick");
    }

    public void EscenaFinal3()
    {
        SceneManager.LoadScene("QuimeraLysandra");
    }

    public void MidpointScene()
    {
        SceneManager.LoadScene("MidpointScene");
    }
}