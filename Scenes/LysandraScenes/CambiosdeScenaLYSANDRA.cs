using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiosdeScenaLYSANDRA : MonoBehaviour
{
    public void Lysandra0Introduccion()
    {
        CargarEscena("Lysandra-1  Puertas");
    }

    public void LysandraPuertaMala()
    {
        CargarEscena("Puerta Mala");
    }

    public void LysandraRatas()
    {
        CargarEscena("Ratas");
    }

    public void LysandraCieno()
    {
        CargarEscena("CienoAlquitran");
    }

    public void LysandraEsqueleto()
    {
        CargarEscena("Esqueleto");
    }

    public void LysandraSombra()
    {
        CargarEscena("Sombra");
    }

    public void Doppelabuela()
    {
        CargarEscena("Doppel.abuela");
    }

    public void Doppelfamilia()   
    {
        CargarEscena("Doppel.familia");
    }

    public void LysandraAraña()
    {
        CargarEscena("araña");
    }

    public void LysandraEspectro()
    {
        CargarEscena("Espectro");
    }

    public void Doppel1()
    {
        CargarEscena("Doppel.final");
    }

    public void Doppel2()
    {
        CargarEscena("Doppel.final 2");
    }

    public void Doppel3()
    {
        CargarEscena("Doppel.final 3");
    }
    
    public void EscenaFinal1()
    {
        CargarEscena("QuimeraSorren");
    }

    public void EscenaFinal2()
    {
        CargarEscena("QuimeraGarrick");
    }

    public void EscenaFinal3()
    {
        CargarEscena("QuimeraLysandra");
    }

    public void MidpointScene()
    {
        CargarEscena("MidpointScene");
    }

    private void CargarEscena(string nombreEscena)
    {
        PlayerPrefs.SetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: PersonajeSeleccionado= {0}", PlayerPrefs.GetInt("PersonajeSeleccionado")));
        SceneManager.LoadScene(nombreEscena);
    }
}