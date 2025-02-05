using UnityEngine;
using UnityEngine.SceneManagement;

public class UWIN : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(1);
    }
}