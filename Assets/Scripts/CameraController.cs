using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [Header("Move")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform corner1;
    [SerializeField] private Transform corner2;
    [SerializeField] private float xInput;
    [SerializeField] private float zInput;

    [Header("Zoom")]
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float zoomModifier;

    [SerializeField] private float minZoomDist;
    [SerializeField] private float maxZoomDist;

    [SerializeField] private float dist;

    [Header("Rotate")]
    [SerializeField] private float rotationAmount;
    [SerializeField] private Quaternion newRotation;

    public static CameraController instance;

    private void Awake()
    {
        instance = this;
        cam = Camera.main;

        newRotation = transform.rotation;
        rotationAmount = 1;

        
    }

    private void Start()
    {
        moveSpeed = 50f;

        zoomSpeed = 25f;
        minZoomDist = 0f;
        maxZoomDist = 50f;

    }

    private void Update()
    {
        MoveByKB();
        Zoom();
        Rotate();
    }

    private void MoveByKB()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        Vector3 dir = (transform.forward * zInput) + (transform.right * xInput);

        transform.position += dir * moveSpeed * Time.deltaTime;
        transform.position = Clamp(corner1.position, corner2.position);


    }

    private Vector3 Clamp(Vector3 lowerLeft, Vector3 topRight)
    {
        Vector3 pos = new Vector3
            (Mathf.Clamp(transform.position.x, lowerLeft.x, topRight.x),     //X-Axis
            transform.position.y,                                            //Y-Axis Not Clamp**
            Mathf.Clamp(transform.position.z, lowerLeft.z, topRight.z));    //Z-Axis

        return pos;
    }

    private void Zoom()
    {
        zoomModifier = Input.GetAxis("Mouse ScrollWheel");

        if(Input.GetKey(KeyCode.Z))
            zoomModifier = 0.01f;

        if(Input.GetKey(KeyCode.X))
            zoomModifier = -0.01f;


        dist = Vector3.Distance(transform.position, cam.transform.position);

        if (dist < minZoomDist && zoomModifier > 0f) //ZoomIn
            return;
        
        else if(dist > maxZoomDist && zoomModifier < 0f) //ZoomOut
            return;

        cam.transform.position += cam.transform.forward * zoomModifier * zoomSpeed;
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);

        }

        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, moveSpeed * Time.deltaTime);
    }

    
}