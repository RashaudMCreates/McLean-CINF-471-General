using UnityEngine;

public class SSM_Enemy : MonoBehaviour
{
[SerializeField]
GameObject bulletSpawner;
[SerializeField]
GameObject bullet;


    private enum State
    {
        Pace,
        Follow,
        Dead,
    }

    [SerializeField]
    GameObject[] route;
    GameObject target;

    int routeIndex = 0;

    float speed = 2.0f;

    private State currentState = State.Pace;

    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        switch(currentState)
        {
            case State.Pace:
                OnPace();
                break;
            case State.Follow:
                OnFollow();
                break;
            case State.Dead:
                OnDead();
                break;
        }
        
        //Fail safe incase I run out of time...
        /*if(currentState == State.Follow)
        {
            currentState = State.Dead;
        }*/

    }


    void OnPace()
    {
        anim.SetBool("Following", false);
        //What do we do while pacing?
       print("Where are ya, Son?");
       target = route[routeIndex];

        MoveTo(target);

       if(Vector3.Distance(transform.position, target.transform.position) < 0.1)
       {
        routeIndex += 1;

        if(routeIndex >= route.Length)
        {

            routeIndex = 0;
        }
       }

       //On what condition do we switch?

       GameObject obstacle = CheckForward();

       if(obstacle != null)
       {
        target = obstacle;
        currentState = State.Follow;

       }
    }

    void OnFollow()
    {
        anim.SetBool("Following", true);
        //what do we do when we are following?
       print("I see you, Son!");
       MoveTo(target);
       Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);

       //When do we stop following


       GameObject obstacle = CheckForward();
       if (obstacle == null)
       {
        currentState = State.Pace;
       }
    }


    //GET THE COLLISION TO WORK
    private void OnCollisionEnter(Collision collision) 
    {
        print("Ay I'm dying here!!!");
        currentState = State.Dead;
    }

    void OnDead()
    {
        Destroy(gameObject);
    }

    void MoveTo(GameObject t)
    {
        transform.position = Vector3.MoveTowards(transform.position, t.transform.position, speed * Time.deltaTime);
        transform.LookAt(t.transform, Vector3.up);
    }

    GameObject CheckForward()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 10, Color.blue);

        if( Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            FirstPersonController player = hit.transform.gameObject.GetComponent<FirstPersonController>();

            if(player != null)
            {
                print(hit.transform.gameObject.name);
                return hit.transform.gameObject;
            }
        }

        return null;
    }
}
