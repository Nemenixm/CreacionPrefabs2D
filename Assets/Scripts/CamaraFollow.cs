using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;   // Player
    [SerializeField] private float fixedX = 0f;   // X fija
    [SerializeField] private float fixedZ = -10f; // Z típica de cámara 2D (ajusta si usas otra)

    void LateUpdate()
    {
        if (!target) return;

        var p = target.position;
        transform.position = new Vector3(fixedX, p.y, fixedZ);
    }

    // Opción útil: para fijar X automáticamente al empezar
    private void Start()
    {
        fixedX = transform.position.x;
    }
}
