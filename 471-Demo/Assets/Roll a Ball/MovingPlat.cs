using UnityEngine;

public class MovingPlat : MonoBehaviour
{

    public GameObject cube;
    Transform t;
    float speed = 0.01f;
    void Start()
    {
        t = cube.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (t.position.y > 3.5)
        {
            speed = speed * -1;
        } 
        else if (t.position.y < 0.8)
        {
            speed = speed * -1;
        }
        
        t.Translate(0,speed,0);

        print(t.position.y);
    }
}
