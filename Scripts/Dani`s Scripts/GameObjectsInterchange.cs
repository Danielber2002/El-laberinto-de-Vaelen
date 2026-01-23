using UnityEngine;

public class GameObjetsInterchange : MonoBehaviour
{
    [Header("Listas de Objetos")]
    [Tooltip("Define el tamaño de la lista y arrastra los objetos que quieres OCULTAR.")]
    public GameObject[] objectsforQuit;

    [Tooltip("Define el tamaño de la lista y arrastra los objetos que quieres MOSTRAR.")]
    public GameObject[] objectsforAdd;

    public void Lists()
    {
        foreach (GameObject obj in objectsforQuit)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        foreach (GameObject obj in objectsforAdd)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}