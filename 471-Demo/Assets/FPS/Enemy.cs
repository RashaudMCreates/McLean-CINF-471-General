using UnityEngine;

public class Enemy : MonoBehaviour
{
    int health = 5; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter()
    {
        health -= 1;
    }

    //Will have to get help with the score Tomorrow.
}
