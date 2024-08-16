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

    public GameObject frontSelector;
    public GameObject upSelector;
    public GameObject leftSelector;
    public GameObject cube;



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
                        if (frontPieces.Count == 4)
                        {
                            frontPieces.Clear();
                        }

                        frontPieces.Add(parentObject);
                    }
                }
                else
                {
                    if (!frontPieces.Contains(hitObject))
                    {
                        if (frontPieces.Count == 4)
                        {
                            frontPieces.Clear();
                        }

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

                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.name == "Right" || hitObject.name == "Left" || hitObject.name == "Up" || hitObject.name == "Down" || hitObject.name == "Front" || hitObject.name == "Back")
                {
                    GameObject parentObject = hitObject.transform.parent.gameObject;

                    if (!leftPieces.Contains(parentObject))
                    {
                        if (leftPieces.Count == 4)
                        {
                            leftPieces.Clear();
                        }

                        leftPieces.Add(parentObject);
                    }
                }
                else
                {
                    if (!leftPieces.Contains(hitObject))
                    {
                        if (leftPieces.Count == 4)
                        {
                            leftPieces.Clear();
                        }

                        leftPieces.Add(hit.collider.gameObject);
                    }
                }
            }
            else
            {
                Debug.DrawRay(ray, rayTransform.forward * 1000, Color.green);
            }
        }

        foreach(GameObject upRay in upRays)
        {
            Transform rayTransform = upRay.transform;
            Vector3 ray = upRay.transform.position;
            RaycastHit hit;

            if (Physics.Raycast(ray, rayTransform.forward, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(ray, rayTransform.forward * hit.distance, Color.yellow);

                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.name == "Right" || hitObject.name == "Left" || hitObject.name == "Up" || hitObject.name == "Down" || hitObject.name == "Front" || hitObject.name == "Back")
                {
                    GameObject parentObject = hitObject.transform.parent.gameObject;

                    if (!upPieces.Contains(parentObject))
                    {
                        if (upPieces.Count == 4)
                        {
                            upPieces.Clear();
                        }

                        upPieces.Add(parentObject);
                    }
                }
                else
                {
                    if (!upPieces.Contains(hitObject))
                    {
                        if (upPieces.Count == 4)
                        {
                            upPieces.Clear();
                        }

                        upPieces.Add(hit.collider.gameObject);
                    }
                }
            }
            else
            {
                Debug.DrawRay(ray, rayTransform.forward * 1000, Color.green);
            }
        }
    }

    void Select(List<GameObject> pieces, string selectSide)
    {
        foreach (GameObject piece in pieces)
        {
            if (selectSide == "Front 90")
            {
                piece.transform.SetParent(frontSelector.transform);
            }

            if (selectSide == "Front -90")
            {
                piece.transform.SetParent(frontSelector.transform);
            }

            if (selectSide == "Left -90")
            {
                piece.transform.SetParent(leftSelector.transform);
            }

            if (selectSide == "Left 90")
            {
                piece.transform.SetParent(leftSelector.transform);
            }

            if (selectSide == "Up 90")
            {
                piece.transform.SetParent(upSelector.transform);
            }

            if (selectSide == "Up -90")
            {
                piece.transform.SetParent(upSelector.transform);
            }
        }
    }

    public void TurningInfo(string side)
    {
        List<GameObject> selectedSide = new List<GameObject>();
        int degrees = 0;
        GameObject selectedParent = null;

        if (side == "Front 90")
        {
            selectedSide = frontPieces;
            degrees = 90;
            selectedParent = frontSelector;
            
        }

        if (side == "Front -90")
        {
            selectedSide = frontPieces;
            degrees = -90;
            selectedParent = frontSelector;

        }

        if (side == "Left 90")
        {
            selectedSide = leftPieces;
            degrees = 90;
            selectedParent = leftSelector;

        }

        if (side == "Left -90")
        {
            selectedSide = leftPieces;
            degrees = -90;
            selectedParent = leftSelector;

        }

        if (side == "Up 90")
        {
            selectedSide = upPieces;
            degrees = 90;
            selectedParent = upSelector;

        }

        if (side == "Up -90")
        {
            selectedSide = upPieces;
            degrees = -90;
            selectedParent = upSelector;

        }

        Select(selectedSide, side);
        Turn(selectedParent, degrees);

    }

    void Turn(GameObject parentObject, int degreeTurn)
    {
        float zRotation = 0;
        float yRotation = 0;
        float xRotation = 0;


        if (parentObject.name == "Front")
        {
            zRotation = degreeTurn;
            parentObject.transform.Rotate(xRotation, yRotation, zRotation);
            
            foreach (GameObject piece in frontPieces)
            {
                piece.transform.SetParent(cube.transform);
            }
        }

        if (parentObject.name == "Left")
        {
            xRotation = degreeTurn;
            parentObject.transform.Rotate(xRotation, yRotation, zRotation);

            foreach (GameObject piece in leftPieces)
            {
                piece.transform.SetParent(cube.transform);
            }
        }

        if (parentObject.name == "Up")
        {
            yRotation = degreeTurn;
            parentObject.transform.Rotate(xRotation, yRotation, zRotation);

            foreach (GameObject piece in upPieces)
            {
                piece.transform.SetParent(cube.transform);
            }
        }
    }
}
