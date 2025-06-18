using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneController : MonoBehaviour
{
    [System.Serializable]
    public class ZonaInteractiva
    {
        public Transform referenciaZona;
        public string nombreEscena;
        public Color colorZona;
    }

    public ZonaInteractiva[] zonas;
    public CanvasGroup panelUI;
    private ZonaInteractiva zonaActual;

    void Update()
    {
        Ray rayo = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(rayo, out RaycastHit hit, 2f))
        {
            foreach (var zona in zonas)
            {
                if (hit.collider.transform == zona.referenciaZona)
                {
                    MostrarUI(zona);
                    return;
                }
            }
        }

        OcultarUI();
    }

    void MostrarUI(ZonaInteractiva zona)
    {
        if (zona != zonaActual)
        {
            zonaActual = zona;
            panelUI.alpha = 1;
            panelUI.interactable = true;
            panelUI.blocksRaycasts = true;
        }
    }

    void OcultarUI()
    {
        zonaActual = null;
        panelUI.alpha = 0;
        panelUI.interactable = false;
        panelUI.blocksRaycasts = false;
    }

    public void ConfirmarCambioEscena()
    {
        if (zonaActual != null)
        {
            PlayerPrefs.SetString("colorZona", ColorUtility.ToHtmlStringRGB(zonaActual.colorZona));
            SceneManager.LoadScene(zonaActual.nombreEscena);
        }
    }
}

