using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousescript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            /*Debug.Log("Left Mouse pressed");
            Vector3 mousePos = Input.mousePosition;
            Debug.Log(mousePos.x);
            Debug.Log(mousePos.y);*/
        }

        float edgeSize = 10f;
        if (Input.mousePosition.x > Screen.width - edgeSize)
        {


        }
    }
}