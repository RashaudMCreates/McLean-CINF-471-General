using UnityEngine;

public class Spring : MonoBehaviour
{
    //Code by a literal child
    [Range(100, 10000)]
    public float bounceheight;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject bouncer = collision.gameObject;
        Rigidbody rb = bouncer.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * bounceheight);
    }

    //Messed up code
   /* public GameObject spring;
    Transform t;
    float speed = 1f;


    void Start()
    {
        t = spring.GetComponent<Transform>();
    }

    void Update()
    {
    
    }

    //Experiment
    private void OnCollisionEnter (Collision collision)
    {
        speed = speed * 30;
    }
    
    private void OnCollisionStay(Collision collision) 
    {
        t.Translate(0,speed,0);
        if (t.position.y > 6)
        {
            speed = speed * -30;
        } 
    }

    private void OnCollisionExit(Collision collision)
    {
        t.transform.position = new Vector3(-6.04f, 0.01f, 7.03f);
        speed = 0.01f;
    }*/
}
