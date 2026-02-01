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
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("Lysandra-1  Puertas");
    }

    public void LysandraPuertaMala()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("Puerta Mala");
    }

    public void LysandraRatas()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("Ratas");
    }

    public void LysandraCieno()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("CienoAlquitran");
    }

    public void LysandraEsqueleto()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("Esqueleto");
    }

    public void LysandraSombra()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("Sombra");
    }

    public void Doppelabuela()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("Doppel.abuela");
    }

    public void Doppelfamilia()   
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("Doppel.familia");
    }

    public void LysandraAraña()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("araña");
    }

    public void LysandraEspectro()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("Espectro");
    }

    public void Doppel1()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("Doppel.final");
    }

    public void Doppel2()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("Doppel.final 2");
    }

    public void Doppel3()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("Doppel.final 3");
    }
    
    public void EscenaFinal1()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("QuimeraSorren");
    }

    public void EscenaFinal2()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("QuimeraGarrick");
    }

    public void EscenaFinal3()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("QuimeraLysandra");
    }

    public void MidpointScene()
    {
        PlayerPrefs.GetInt("PersonajeSeleccionado", 2);
        PlayerPrefs.Save();
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", PlayerPrefs.GetInt("EsFinalBueno")));
        SceneManager.LoadScene("MidpointScene");
    }
}