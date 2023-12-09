//Dit script zorgt ervoor dat lasers volledig werken

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


    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>(); //Maak de component om de lijn te renderen
    }

    void Update()
    {
        //Punten van de lijn van de vorige frame weghalen zodat er geen duplicaten ontstaan
        points.Clear();

        laserDirection = transform.forward;

        lineRenderer = gameObject.GetComponent<LineRenderer>();

        alive = true;

        //Voeg beginnend punt toe
        points.Add(transform.position);

        RaycastHit hit;

        //Doe een while loop, en zolang de laser nog leeft, punten teovoegen
        while (alive)
        {
            if (Physics.Raycast(points.ElementAt(points.Count-1), laserDirection, out hit, 50f, ~LaserEmitter))
            {
                //Voeg een tijdelijk eindpunt toe
                points.Add(points.ElementAt(points.Count-1) + laserDirection * hit.distance);

                if (hit.transform.tag == "mirror"){ //Als de laser een spiegel raakt
                    laserDirection = Vector3.Reflect(laserDirection, hit.normal); //Reflecteer de laserrichting
                    points.Add(points.ElementAt(points.Count-1) + laserDirection * 0.1f); //Voeg punt toe
                }
                else if(hit.transform.tag == "lasertrigger"){ //Als de laser verschillende soorten recievers raakt, dan roept hij de bijbehorende functies aan en de laser leeft niet meer want hij raakt iets
                    var TriggerScript = Trigger.GetComponent<HandleTrigger>();
                    TriggerScript.trigger(laserColor);
                    alive = false;
                }
                else if(hit.transform.tag == "lasertrigger2"){ //Als de laser verschillende soorten recievers raakt, dan roept hij de bijbehorende functies aan en de laser leeft niet meer want hij raakt iets
                    var TriggerScript = Trigger.GetComponent<HandleTrigger2>();
                    TriggerScript.trigger(laserColor);
                    alive = false;
                }
                else if(hit.transform.tag == "lasertriggerdefinitive"){ //Als de laser verschillende soorten recievers raakt, dan roept hij de bijbehorende functies aan en de laser leeft niet meer want hij raakt iets
                    var TriggerScript = Trigger.GetComponent<HandleTriggerDefinitive>();
                    TriggerScript.trigger(laserColor);
                    alive = false;
                }
                else if(hit.transform.tag == "lasertriggerinverse"){ //Als de laser verschillende soorten recievers raakt, dan roept hij de bijbehorende functies aan en de laser leeft niet meer want hij raakt iets
                    var TriggerScript = Trigger.GetComponent<HandleTriggerInverse>();
                    TriggerScript.trigger(laserColor);
                    alive = false;
                }
                else{ //Als de laser iets anders raakt, zet hem uit.
                    alive = false;
                }
            }
            else
            { //Als de laser niks raakt voor 50 meter, zetten we hem uit zodat hij niet oneindig doorgaat.
                points.Add(points.ElementAt(points.Count-1) + laserDirection * 50f);
                alive = false;
            }
        }
        
        //Laser klaarmaken voor rendering
        lineRenderer.positionCount = points.Count;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = new Color(laserColor.r, laserColor.g, laserColor.b);
        lineRenderer.endColor = new Color(laserColor.r, laserColor.g, laserColor.b);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.numCapVertices = 10;
        lineRenderer.numCornerVertices = 3;
        

        //De punten in het lijn-element zetten voor rendering
        lineRenderer.SetPositions(points.ToArray());
    }
}