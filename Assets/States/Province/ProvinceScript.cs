using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProvinceScript : MonoBehaviour
{
    public string Country;
    public int Infrastructure;
    public int Terrain;
    public int CitySize;

    public ProvinceScript provleftleft;
    public ProvinceScript provupright;
    public ProvinceScript provupleft;
    public ProvinceScript provrightright;
    public ProvinceScript provdownleft;
    public ProvinceScript provdownright;

    SpriteRenderer sprite;

    //runs before Start()
    private void Awake()
    {
        //must round position before finding neighbors
        RoundPosition();
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        FindNeighbors();
    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();
    }


    //runs when hovering over the unit
    void OnMouseOver()
    {
        //right click moves unit
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Province Rclicked");
            if (FindObjectOfType<EditorScript>().selectedUnits.Count != 0)
            {
                FindObjectOfType<EditorScript>().destProvince = this;
            }
            
        }

    }


    //changes province color
    void ColorChange()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Country == "GER")
            {
                sprite.color = new Color(63 / 255f, 112 / 255f, 161 / 255f, 1);
                Debug.Log("Color Changed1");
            }
            if (Country == "POL")
            {
                sprite.color = new Color(202 / 255f, 85 / 255f, 132 / 255f, 1);
                Debug.Log("Color Changed2");
            }
            Debug.Log("Color Changed");
        }
    }

    //rounds position when game starts
    void RoundPosition()
    {
        var currentPos = transform.position;
        transform.position = new Vector3 (Mathf.Round(currentPos.x * 4) / 4,
                                     Mathf.Round(currentPos.y * 4) / 4,
                                     Mathf.Round(currentPos.z * 4) / 4);
    }

    //finds the provinces adjacent and assigns them
    void FindNeighbors()
    {
        Collider2D[] colliders; //initialize colliders array
        if ((colliders = Physics2D.OverlapCircleAll(transform.position, .6f)).Length > 1) //Presuming the object you are testing also has a collider 0 otherwise
        {
            /*Debug.Log(gameObject);
            Debug.Log(colliders.Length);*/
            foreach (var collider in colliders)
            {
                var go = collider.gameObject.GetComponent<ProvinceScript>(); //This is the game object you collided with
                if (go == gameObject) continue; //Skip the object itself

                //assigns provinces above
                    if (go.transform.position.y > gameObject.transform.position.y)
                    {
                        if (go.transform.position.x > gameObject.transform.position.x)
                        {
                            provupright = go;
                        }
                        if (go.transform.position.x < gameObject.transform.position.x)
                        {
                             provupleft = go;
                        }
                    }
                //assigns provinces below
                    if (go.transform.position.y < gameObject.transform.position.y)
                    {
                        if (go.transform.position.x > gameObject.transform.position.x)
                        {
                            provdownright = go;
                        }
                        if (go.transform.position.x < gameObject.transform.position.x)
                        {
                             provdownleft = go;
                        }  
                    }
                //assigns provinces left or right
                    if (go.transform.position.y == gameObject.transform.position.y)
                    {
                        if (go.transform.position.x > gameObject.transform.position.x)
                        {
                            provrightright = go;
                        }
                        if (go.transform.position.x < gameObject.transform.position.x)
                        {
                             provleftleft = go;
                        }  
                    }  
            }
        }

    }
}