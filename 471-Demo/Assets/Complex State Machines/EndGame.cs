using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    GameObject Player1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider Player1) 
    {
        SceneManager.LoadScene(1);
    }

}
