using System.Collections;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class InitManager : MonoBehaviour
{
    private bool haPulsadoBoton = false;

    [Header("Referencias de Objetos")]
    public GameObject videoPlayer, UiGameObject, backgroundGameObject;
    public Image playerUI, backgroundImage;
    public TextMeshProUGUI textMeshPro;
    public Button botonAceptar;

    [Header("Configuración de Imágenes")]
    public Sprite lysandraImage, garrickImage, sorremImage, madreImage;
    public Sprite dungeonBackground, granjaBackground, cuartoMamaBackground, cocinaBackground;

    [Header("Ajustes")]
    public float typingSpeed = 0.05f;
    public float waitTimeBetweenDialog = 35.0f;
    public float waitTimeBetweenLoadScene = 2.0f;

    void Start()
    {
        // En lugar de iniciar la secuencia en Start,le decimos al VideoPlayer que nos avise.
        videoPlayer.GetComponent<VideoPlayer>().loopPointReached += IniciarSecuencia;
    }

    private void Update()
    {
        // More velocity:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            typingSpeed = 0.001f;
        }
    }

    void IniciarSecuencia(VideoPlayer vp)
    {
        StartCoroutine(ExecuteSequence());
        // Opcional: desuscribirse para que no se repita
        vp.loopPointReached -= IniciarSecuencia;
    }

    IEnumerator ExecuteSequence()
    {
        // ----------------------------------------------------------  En la Dungeon
        // 1. Desactivar VideoPlayer, ya vimos la intro, activamos la UI y asignamos el background de un pasillo en la dungeon.
        videoPlayer.SetActive(false);
        UiGameObject.SetActive(true);
        backgroundGameObject.SetActive(true);
        backgroundImage.sprite = dungeonBackground;

        // 2. Asignar primera imagen de Lysandra y escribir primer texto.
        playerUI.sprite = lysandraImage;
        yield return StartCoroutine(TypeText("Lysandra: Hemos estado muy cerca de morir. Aaaah! no puedo ni moverme."));

        // 4. Cambiar imagen y escribir texto de Garrick.
        playerUI.sprite = garrickImage;
        yield return StartCoroutine(TypeText("Garrick: Uuf si que estuvo cerca, esto ya no se parece ni de lejos a casa..."));

        // ----------------------------------------------------------  En casa
        // 5. Desactivamos la UI del textBox y cambiar imagen de Background (la granja).
        UiGameObject.gameObject.SetActive(false);
        backgroundImage.sprite = granjaBackground;

        // 6. Esperar unos segundos y volver a cambiar el background a la habitación de la madre.
        yield return new WaitForSeconds(3.0f);
        backgroundImage.sprite = cuartoMamaBackground;
        UiGameObject.gameObject.SetActive(true);

        // 7. Cambiar imagen a la de la madre y su texto.
        playerUI.sprite = madreImage;
        yield return StartCoroutine(TypeText("Madre: Hijos míos, han pasado 5 días y vuestro padre no aparece. Papá ha ido a un lugar lejano, en busca de una hierba curativa con propiedades milagrosas."));
        yield return StartCoroutine(TypeText("Madre: No os queriamos asustar pero hace dos semanas apareció en la granja una pequeña criatura mágica que me maldijo y desapareció. Al principio no le di importancia pero día a día fuí notando como mi salud empeoraba."));
        yield return StartCoroutine(TypeText("Madre: Sin esa hierba moriré, así que hacedme el favor de ir a buscar a papá para que él cuide de vosotros. No quiero que este infortunio acabe con todos muertos."));

        // 8. Esperar unos segundos y volver a cambiar el background (cocina).
        yield return new WaitForSeconds(3.0f);
        backgroundImage.sprite = cocinaBackground;

        playerUI.sprite = lysandraImage;
        yield return StartCoroutine(TypeText("Lysandra: No me creo que nos esté pasando esto (empieza a hiperventilar)."));
        playerUI.sprite = garrickImage;
        yield return StartCoroutine(TypeText("Garrick: Calma Lys, seguro que papá ya estrá de vuelta con la hierba."));
        playerUI.sprite = sorremImage;
        yield return StartCoroutine(TypeText("Sorrem: O no, sin papá hay que ponerse en lo peor. Creo que tenemos que hacer algo."));
        playerUI.sprite = garrickImage;
        yield return StartCoroutine(TypeText("Garrick: Si y ¿qué propones? ya oiste a mamá, ese lugar está lejos y ninguno de los tres le llemagos a la suela de nuestro padre. ¿Qué haremos estando allí?"));
        playerUI.sprite = sorremImage;
        yield return StartCoroutine(TypeText("Sorrem: Yaa, por eso toca unirnos y ser fuerte por la familia. Necesitamos un plan."));

        yield return new WaitForSeconds(waitTimeBetweenLoadScene);
        SceneManager.LoadScene("CharacterSelection");
    }

    // Corrutina para el efecto de escribir letra por letra
    IEnumerator TypeText(string message)
    {
        textMeshPro.text = "";
        foreach (char letter in message.ToCharArray())
        {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        Debug.Log("Terminó de escribir todo el dialogo.");
        yield return new WaitUntil(() => haPulsadoBoton);
        haPulsadoBoton = false;
    }

    public void AlPulsarBotonContinuar()
    {
        haPulsadoBoton = true;
    }
}
