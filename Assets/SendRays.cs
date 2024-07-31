using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendRays : MonoBehaviour
{
    public List<GameObject> frontRays = new List<GameObject>();
    public List<GameObject> upRays = new List<GameObject>();
    public List<GameObject> leftRays = new List<GameObject>();


    public List<GameObject> frontPieces = new List<GameObject>();
    public List<GameObject> upPieces = new List<GameObject>();
    public List<GameObject> leftPieces = new List<GameObject>();


    private int layerMask = 1 << 8;

    void Update()
    {
        foreach (GameObject frontRay in frontRays)
        {
            Transform rayTransform = frontRay.transform;
            Vector3 ray = frontRay.transform.position;
            RaycastHit hit;

            if (Physics.Raycast(ray, rayTransform.forward, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(ray, rayTransform.forward * hit.distance, Color.yellow);

                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.name == "Right" || hitObject.name == "Left" || hitObject.name == "Up" || hitObject.name == "Down" || hitObject.name == "Front" || hitObject.name == "Back")
                {
                    GameObject parentObject = hitObject.transform.parent.gameObject;

                    if (!frontPieces.Contains(parentObject))
                    {
                        frontPieces.Add(parentObject);
                    }
                }
                else
                {
                    if (!frontPieces.Contains(hitObject))
                    {
                        frontPieces.Add(hit.collider.gameObject);
                    }
                }
            }
            else
            {
                Debug.DrawRay(ray, rayTransform.forward * 1000, Color.green);
            }
        }

        foreach (GameObject leftRay in leftRays)
        {
            Transform rayTransform = leftRay.transform;
            Vector3 ray = leftRay.transform.position;
            RaycastHit hit;

            if (Physics.Raycast(ray, rayTransform.forward, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(ray, rayTransform.forward * hit.distance, Color.yellow);
                //leftPieces.Add(hit.collider.gameObject);
                //print(hit.collider.gameObject.name);
            }
            else
            {
                Debug.DrawRay(ray, rayTransform.forward * 1000, Color.green);
            }
        }

        foreach (GameObject upRay in upRays)
        {
            Transform rayTransform = upRay.transform;
            Vector3 ray = upRay.transform.position;
            RaycastHit hit;

            if (Physics.Raycast(ray, rayTransform.forward, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(ray, rayTransform.forward * hit.distance, Color.yellow);
                //upPieces.Add(hit.collider.gameObject);
                //print(hit.collider.gameObject.name);
            }
            else
            {
                Debug.DrawRay(ray, rayTransform.forward * 1000, Color.green);
            }
        }
    }
}
