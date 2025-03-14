using UnityEngine;
using UnityEngine.SceneManagement;


public class KillerFlies : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other) 
    {
        if(other.GetComponent<UniGunner>() != null)
        {
        Debug.Log("hit^2");
        SceneManager.LoadScene(0);
        }
    }

}
