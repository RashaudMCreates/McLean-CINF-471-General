using UnityEngine;

public class MovingTarger : MonoBehaviour
{

    public GameObject cube;
    Transform t;
    Transform t2;
    Transform t3;
    Transform t4;
    Transform t5;
    float speed = 0.01f;
    float startingpointx = 0;
    float startingpointx2 = 0;
    float startingpointx3 = 0;
    float startingpointy4 = 0;
    float startingpointy5 = 0;
    [SerializeField]
    GameObject cube2;
    [SerializeField]
    GameObject cube3;
    [SerializeField]
    GameObject cube4;
    [SerializeField]
    GameObject cube5;

    
    void Start()
    {
        t = cube.GetComponent<Transform>();
        t2 = cube2.GetComponent<Transform>();
        t3 = cube3.GetComponent<Transform>();
        t4 = cube4.GetComponent<Transform>();
        t5 = cube5.GetComponent<Transform>();
        float startingpointx = t.position.x;
        float startingpointx2 = t2.position.x;
        float startingpointx3 = t3.position.x;
//I MADE THIS PROJECT WORK OFF OF BROKEN CODEEEEEEEEEEEEEEEEEE!!!!
//It's Cooked. It's Wrapped. Will do better Next Time
        float startingpointy4 = t2.position.x;
        float startingpointy5 = t3.position.x;


    }

    // Update is called once per frame
    void Update()
    {
        if (t != null ) 
        {
        if (startingpointx > t.position.x + 3)
        {
            speed = speed * -1;
        } 
        else if (startingpointx < t.position.x - 3)
        {
            speed = speed * -1;
        }
        
        t.Translate(speed,0,0);
        }

        if (t2 != null ) 
        {
        //Line For Cube 2
        if (startingpointx2 > t2.position.x + 3)
        {
            speed = speed * -1;
        } 
        else if (startingpointx2 < t2.position.x - 3)
        {
            speed = speed * -1;
        }
        
        t2.Translate(speed,0,0);
        }

        if (t3 != null ) 
        {
        //Line for Cube 3
        if (startingpointx3 > t3.position.x + 3)
        {
            speed = speed * -1;
        } 
        else if (startingpointx3 < t3.position.x - 3)
        {
            speed = speed * -1;
        }
        
        t3.Translate(speed,0,0);
        }

        if (t4 != null ) 
        {
        //Line for Cube 4
        if (startingpointy4 > t4.position.y + 3)
        {
            speed = speed * -1;
        } 
        else if (startingpointy4 < t4.position.y - 3)
        {
            speed = speed * -1;
        }
        
        t4.Translate(0,speed,0);
        }

        if (t5 != null ) 
        {
        //Line for Cube 5
        if (startingpointy5 > t5.position.y + 3)
        {
            speed = speed * -1;
        } 
        else if (startingpointy5 < t5.position.y - 3)
        {
            speed = speed * -1;
        }
        
        t5.Translate(0,speed,0);
        }
    }
}
