using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Prefabs de zona")]
    [SerializeField] private GameObject prefabZonaRoja;
    [SerializeField] private GameObject prefabZonaAmarilla;

    [Header("UI")]
    [SerializeField] private TMPro.TMP_Text tituloPantalla;

    // Distancia frontal (m) a la que aparecerán las zonas
    [SerializeField] private float distancia = 2.0f;

    // Separación lateral (m) entre ambas zonas
    [SerializeField] private float separacion = 0.6f;

    private void Start()
    {
        // Mensaje inicial
        if (tituloPantalla != null)
            tituloPantalla.text = "Selecciona una zona para comenzar";

        // Referencia a la cámara principal (jugador)
        var cam = Camera.main.transform;

        // Posición base (2?m enfrente de la cámara)
        Vector3 basePos = cam.position + cam.forward * distancia;

        // Ajuste de altura opcional (al nivel de la cámara o un poco más bajo)
        basePos.y = cam.position.y - 0.1f;

        // Coordenadas finales de cada zona
        Vector3 posRoja = basePos - cam.right * separacion;
        Vector3 posAmarilla = basePos + cam.right * separacion;

        // Instanciar prefabs
        GameObject zonaRoja = Instantiate(prefabZonaRoja, posRoja, Quaternion.identity);
        GameObject zonaAmarilla = Instantiate(prefabZonaAmarilla, posAmarilla, Quaternion.identity);

        // Hacer que miren hacia el jugador
        zonaRoja.transform.LookAt(cam);
        zonaAmarilla.transform.LookAt(cam);
    }
}
