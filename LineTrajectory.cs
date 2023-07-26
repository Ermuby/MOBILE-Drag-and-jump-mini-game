using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTrajectory : MonoBehaviour
{
    private int size = 10;

    public LineRenderer _lineRenderer;

    public Vector3 position;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = size;
        _lineRenderer.startWidth = 0.01f;
        _lineRenderer.endWidth = 0.1f;
    }

    public void Trajectory(Vector3 posOne, Vector3 posTwo, Vector3 posThree, Vector3 posFour,
        Vector3 posFive, Vector3 posSix, Vector3 posSeven, Vector3 posEight, Vector3 posNine, Vector3 posTen)
    {
        _lineRenderer.SetPosition(0, posOne);
        _lineRenderer.SetPosition(1, posTwo);
        _lineRenderer.SetPosition(2, posThree);
        _lineRenderer.SetPosition(3, posFour);
        _lineRenderer.SetPosition(4, posFive);
        _lineRenderer.SetPosition(5, posSix);
        _lineRenderer.SetPosition(6, posSeven);
        _lineRenderer.SetPosition(7, posEight);
        _lineRenderer.SetPosition(8, posNine);
        _lineRenderer.SetPosition(9, posTen);
    }
}
