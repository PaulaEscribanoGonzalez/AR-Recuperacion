using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    [Header("Nombre de la escena principal")]
    [SerializeField] private string escenaInicial = "Zone0";

    public void Volver()
    {
        if (!string.IsNullOrEmpty(escenaInicial))
        {
            SceneManager.LoadScene(escenaInicial);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el nombre de la escena en el Inspector.");
        }
    }
}
