using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public string Country;
    public ProvinceScript currentProvince;
    public bool clicked = false;
    public List<ProvinceScript> pathPlan = new List<ProvinceScript>();
    private float startTime = -1;
    public float unitSpeed = 3;
    private float universalTime = -1;

    //public EditorScript editorScript;

    void Start()
    {

    }

    void Update()
    {
        ReCenter();
        UnClick();
        MoveUnit();
    }


    //runs when hovering over the unit
    void OnMouseUp()
    {
        Debug.Log("Unit LClicked");
        FindObjectOfType<EditorScript>().selectedUnits.Add(this);
        clicked = true;
    }

    //unlckicks the unit on left mouse press
    void UnClick()
    {
        if (clicked)
        {   //left click 
            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
            {
                Debug.Log("Unit unclicked");
                clicked = false;
                FindObjectOfType<EditorScript>().selectedUnits.Clear();
            }
        }
    }

    //relocates unit to assigned province
    void ReCenter()
    {
        Vector2 pos = currentProvince.transform.position;
        transform.position = pos;
    }

    void MoveUnit()
    {
        if (pathPlan.Count != 0)
        {
            universalTime = FindObjectOfType<TimerScript>().MasterDay;
            if (startTime == -1)
            {
                startTime = universalTime;
            }
            if (startTime + unitSpeed < universalTime)
            {
                currentProvince = pathPlan[0];
                pathPlan.RemoveAt(0);
                startTime = -1;
            }

        }

    }

}
