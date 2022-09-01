using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorScript : MonoBehaviour
{
    public ProvinceScript destProvince;
    public List<UnitScript> selectedUnits = new List<UnitScript>();
    public List<ProvinceScript> curProvince = new List<ProvinceScript>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UnselectUnits();
        CreatePath();
    }

    void UnselectUnits()
    {
        if(!Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(0))
        {
            selectedUnits.Clear();
        }
    }





    //generates list of provinces for each unit to follow
    void CreatePath()
    {
        //to start we must have a list of provinces and destination
        if (selectedUnits.Count != 0 && destProvince != null)
        {
            //gets the current province of selected units
            getCurrentProvince();
            
            //Holding shift appends new path
            if (Input.GetKey(KeyCode.LeftShift))
            {
                shiftPath();
            }
            else //Not holding Shift creates an entire new path
            {
                clearPath();
            }


            // still a problem with multiple buttons being presses           
            if (Input.GetKey(KeyCode.Z))
            {
                smartPath(); //uses a search algorithm, greedy breadth-first search, migh
                             //t become the base algorithm
            }  
            else if (Input.GetKey(KeyCode.X))
            {
                superSmartPath(); //uses same search algorithm but account for terrain
            }
            else if (Input.GetKey(KeyCode.C))
            {
                railPath(); //finds fastest path using rail, for long distance travel
            }
            else if (Input.GetKey(KeyCode.V))
            {
                oceanPath(); //creates a path that convoys over water
            }
            else if (Input.GetKey(KeyCode.B))
            {
                avoidUnitPath(); //crerates a path that avoids provinces with units, might be only for AI
            }
            else
            {
                regularPath(); //creates a path with the least amount of processing power
            }



            //selectedUnits.Clear();
            curProvince.Clear();
            destProvince = null;
            
        }
    }







    void getCurrentProvince()
    {
        for (int i = 0; i < selectedUnits.Count; i++)
        {
            curProvince.Add(selectedUnits[i].currentProvince);
        }
    }
    
    void shiftPath()
    {
        for (int i = 0; i < selectedUnits.Count; i++)
        {
            if (selectedUnits[i].pathPlan.Count != 0)
            {
                int temp = selectedUnits[i].pathPlan.Count - 1;
                curProvince[i] = selectedUnits[i].pathPlan[temp];
              
            }
        }
    }

    void clearPath()
    {
        for (int i = 0; i < selectedUnits.Count; i++)
        {
            selectedUnits[i].pathPlan.Clear();
        }
    }

    void regularPath()
    {
        for (int i = 0; i < selectedUnits.Count; i++)
        {
            UnitScript unit = selectedUnits[i]; //unit currently being tested
            ProvinceScript prov = curProvince[i]; //province currently being tested
            while (destProvince.transform.position.x != prov.transform.position.x || destProvince.transform.position.y != prov.transform.position.y)
            {
                float dx = destProvince.transform.position.x - prov.transform.position.x; //difference in x pos
                float dy = destProvince.transform.position.y - prov.transform.position.y; //difference in y pos
                if (dx == 0) // need this step because if x ==0, tan^-1() will be undefined
                {
                    if (dy > 0) //ties go clockwise
                    {
                        prov = prov.provupright;
                    }
                    if (dy < 0)
                    {
                        prov = prov.provdownleft;
                    }
                }
                else
                {
                    if (dx > 0)
                    {
                        if (dy > 0)
                        {
                            if (dx * .5 < dy)
                            {
                                prov = prov.provupright;
                            }
                            else
                            {
                                prov = prov.provrightright;
                            }
                        }
                        else
                        {
                            if (dx * .5 < -dy)
                            {
                                prov = prov.provdownright;
                            }
                            else
                            {
                                prov = prov.provrightright;
                            }
                        }


                    }
                    if (dx < 0)
                    {
                        if (dy > 0)
                        {
                            if (-dx * .5 < dy)
                            {
                                prov = prov.provupleft;
                            }
                            else
                            {
                                prov = prov.provleftleft;
                            }
                        }
                        else
                        {
                            if (-dx * .5 < -dy)
                            {
                                prov = prov.provdownleft;
                            }
                            else
                            {
                                prov = prov.provleftleft;
                            }
                        }
                    }
                }
                unit.pathPlan.Add(prov);
            }
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                unit.clicked = false;
            }

        }
    }

    void smartPath()
    {
        for (int i = 0; i < selectedUnits.Count; i++)
        {
            UnitScript unit = selectedUnits[i]; //unit currently being tested
            ProvinceScript prov = curProvince[i]; //province currently being tested
            List<ProvinceScript> searchedProvinces = new List<ProvinceScript>();
            while (destProvince.transform.position.x != prov.transform.position.x || destProvince.transform.position.y != prov.transform.position.y)
            {

            }
        }
    }

    void superSmartPath()
    {

    }

    void railPath()
    {

    }

    void oceanPath()
    {

    }

    void avoidUnitPath()
    {

    }

}
