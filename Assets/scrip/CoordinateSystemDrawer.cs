using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateSystemDrawer : MonoBehaviour
{
    public float axisLength = 1f; // Longitud de los ejes

    private void OnDrawGizmos()
    {
        // Dibuja el sistema de coordenadas (ejes X, Y y Z) en el origen.
        Gizmos.color = Color.red; // Eje X (rojo)
        Gizmos.DrawLine(new Vector3(-axisLength, 0f, 0f), new Vector3(axisLength, 0f, 0f)); // Eje X
        Gizmos.color = Color.green; // Eje Y (verde)
        Gizmos.DrawLine(new Vector3(0f, -axisLength, 0f), new Vector3(0f, axisLength, 0f)); // Eje Y
        Gizmos.color = Color.blue; // Eje Z (azul)
        Gizmos.DrawLine(new Vector3(0f, 0f, -axisLength), new Vector3(0f, 0f, axisLength)); // Eje Z
    }
}


