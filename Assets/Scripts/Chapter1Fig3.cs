﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In this example, we will be subtracting Vector3's from one another
//The following example demonstrates vector subtraction by taking the difference between two points—the mouse location and the center sphere

public class Chapter1Fig3 : MonoBehaviour
{

    //Create variables to mark the origin of our line
    public GameObject centerSphere;
    private Vector3 centerSpherePosition;

    //Create variables to track the mouse gameObject and position
    private Vector3 mousePos;
    public GameObject mouseCursor;

    //Create variables for rendering the line between two vectors
    private GameObject lineDrawing;
    private LineRenderer lineRender;

    //Float coordinates for our new vector3 we create via  "void subtractVector"
    private float x, y, z;

    //Our new vector3 we create via  "void subtractVector"
    private Vector3 subtractedVector;

    // Start is called before the first frame update
    void Start()
    {

        // Get the Vector3 (x,y,z) float coordinates of the center transform
        centerSpherePosition = centerSphere.transform.position;

        //Instantiate a cursor GameObject to track the location of the mouse
        mouseCursor = Instantiate(mouseCursor, new Vector3(0, 0, 0), Quaternion.identity);

        // Create a GameObject that will be the line
        lineDrawing = new GameObject();

        //Add the Unity Component "LineRenderer" to the GameObject lineDrawing. We will see a bright pink line.
        lineRender = lineDrawing.AddComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Track the Vector3 of the mouse's position
        mousePos = Input.mousePosition;

        //Get the center of the transform
        centerSpherePosition = centerSphere.transform.position;

        //Subtract the vector of the center from that of the mice position via "void subtractVector"
        subtractVector(mousePos, centerSpherePosition);

        //Begin rendering the line between the two objects. Set the first point (0) at the centerSphere Position
        //Make sure the end of the line (1) appears at the new Vector3 we are creating via the "void subtractVector" 
        lineRender.SetPosition(0, centerSpherePosition);
        lineRender.SetPosition(1, new Vector3(x, y, z));

        //Move the cursor to that same Vector3 we are creating via the "void subtractVector" 
        mouseCursor.transform.position = subtractedVector;

    }

    void subtractVector(Vector3 originalV3, Vector3 v)
    {
        // Dividing the subtraction by 100 to keep the cursor on the screen in this example
        x = (originalV3.x - v.x) / 100;
        y = (originalV3.y - v.y) / 100;
        z = (originalV3.z - v.z) / 100;

        subtractedVector = new Vector3(x, y, z);
    }

}