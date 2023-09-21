using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Vector3 LaserOrientation;

    private LineRenderer lineRenderer;

    [SerializeField] private GameObject Emitter;

    private List<Vector3> points = new List<Vector3>();

    public LayerMask LaserEmitter;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        points.Clear();
        points.Add(new Vector3 (0, 0, 0));

        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        RaycastHit hit;

        Vector3 LaserDirection = new Vector3 (1, 0, 0);

        if (Physics.Raycast(transform.position, LaserDirection, out hit, 20f, ~LaserEmitter))
        {
            points.Add(new Vector3 (0, 0, 1) * (hit.distance+1f));
        }
        

        lineRenderer.SetPositions(points.ToArray());
    }
}
