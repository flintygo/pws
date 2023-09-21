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
        // Clear point list to not get duplicates
        points.Clear();

        // Add starting point
        points.Add(new Vector3 (0, 0, 0));

        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        RaycastHit hit;

        // In which direction Raycast should go
        Vector3 LaserDirection = new Vector3 (1, 0, 0);

        //do a While loop, condition !dead, check hit.transform.gameObject i tink i forgor

        if (Physics.Raycast(transform.position, LaserDirection, out hit, 20f, ~LaserEmitter))
        {
            // Add (for now ending) point to laser point list
            points.Add(new Vector3 (0, 0, 1) * (hit.distance));
        }
        
        // Render the points
        lineRenderer.SetPositions(points.ToArray());
    }
}
