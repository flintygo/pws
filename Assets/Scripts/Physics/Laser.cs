using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Laser : MonoBehaviour
{
    private Vector3 LaserOrientation;

    private LineRenderer lineRenderer;

    private bool alive;

    [SerializeField] private Color laserColor;

    private Vector3 laserDirection;

    [SerializeField] private GameObject Trigger;

    private List<Vector3> points = new List<Vector3>();

    public LayerMask LaserEmitter;



    //Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
    }

     //Update is called once per frame
    void Update()
    {
         //Clear point list to not get duplicates
        points.Clear();

        laserDirection = transform.forward;

        lineRenderer = gameObject.GetComponent<LineRenderer>();

        alive = true;

         //Add starting point
        points.Add(transform.position);

        RaycastHit hit;

        //do a While loop, condition !dead, check hit.transform.gameObject i tink i forgor

        while (alive)
        {
            if (Physics.Raycast(points.ElementAt(points.Count-1), laserDirection, out hit, 50f, ~LaserEmitter))
            {
                 //Add (for now ending) point to laser point list
                points.Add(points.ElementAt(points.Count-1) + laserDirection * hit.distance);

                if (hit.transform.tag == "mirror"){
                    laserDirection = Vector3.Reflect(laserDirection, hit.normal);
                    points.Add(points.ElementAt(points.Count-1) + laserDirection * 0.1f);
                }
                else if(hit.transform.tag == "lasertrigger"){
                    var TriggerScript = Trigger.GetComponent<HandleTrigger>();
                    TriggerScript.trigger(laserColor);
                    alive = false;
                }
                else if(hit.transform.tag == "lasertrigger2"){
                    var TriggerScript = Trigger.GetComponent<HandleTrigger2>();
                    TriggerScript.trigger(laserColor);
                    alive = false;
                }
                else if(hit.transform.tag == "lasertriggerdefinitive"){
                    var TriggerScript = Trigger.GetComponent<HandleTriggerDefinitive>();
                    TriggerScript.trigger(laserColor);
                    alive = false;
                }
                else if(hit.transform.tag == "lasertriggerinverse"){
                    var TriggerScript = Trigger.GetComponent<HandleTriggerInverse>();
                    TriggerScript.trigger(laserColor);
                    alive = false;
                }
                else{
                    alive = false;
                }
            }
            else
            {
                points.Add(points.ElementAt(points.Count-1) + laserDirection * 100f);
                alive = false;
            }
        }
        
         //Render the points
        lineRenderer.positionCount = points.Count;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = new Color(laserColor.r, laserColor.g, laserColor.b);
        lineRenderer.endColor = new Color(laserColor.r, laserColor.g, laserColor.b);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.numCapVertices = 10;
        lineRenderer.numCornerVertices = 3;
        


        lineRenderer.SetPositions(points.ToArray());
    }
}