using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDrawer : MonoBehaviour
{
    public Vector3 cubeSize = new Vector3(1f, 1f, 1f);
    public Vector3 translation = new Vector3(0f, 0f, 0f);
    public Vector3 scale = new Vector3(1f, 1f, 1f);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3[] scaledCorners = ScaleCube(cubeSize, scale);
        Vector3[] translatedCorners = TranslateCube(scaledCorners, transform.position + translation);
        DrawCube(translatedCorners);
    }

    private Vector3[] ScaleCube(Vector3 size, Vector3 scale)
    {
        Vector3[] corners = new Vector3[8];
        Vector3 halfSize = size / 2;

        for (int i = 0; i < 8; i++)
        {
            corners[i] = new Vector3(
                (i & 1) == 0 ? -halfSize.x : halfSize.x,
                (i & 2) == 0 ? -halfSize.y : halfSize.y,
                (i & 4) == 0 ? -halfSize.z : halfSize.z
            );
            corners[i].x *= scale.x;
            corners[i].y *= scale.y;
            corners[i].z *= scale.z;
        }

        return corners;
    }

    private Vector3[] TranslateCube(Vector3[] corners, Vector3 translation)
    {
        for (int i = 0; i < 8; i++)
        {
            corners[i] += translation;
        }
        return corners;
    }

    private void DrawCube(Vector3[] corners)
    {

        // Dibujar líneas que conectan las esquinas para formar el cubo
        Gizmos.DrawLine(corners[0], corners[1]);
        Gizmos.DrawLine(corners[1], corners[3]);
        Gizmos.DrawLine(corners[3], corners[2]);
        Gizmos.DrawLine(corners[2], corners[0]);

        Gizmos.DrawLine(corners[4], corners[5]);
        Gizmos.DrawLine(corners[5], corners[7]);
        Gizmos.DrawLine(corners[7], corners[6]);
        Gizmos.DrawLine(corners[6], corners[4]);

        Gizmos.DrawLine(corners[0], corners[4]);
        Gizmos.DrawLine(corners[1], corners[5]);
        Gizmos.DrawLine(corners[2], corners[6]);
        Gizmos.DrawLine(corners[3], corners[7]);

        // Dibujar puntos en las esquinas del cubo
        for (int i = 0; i < 8; i++)
        {
            Gizmos.DrawSphere(corners[i], 0.02f);
        }
    }
}