using UnityEngine;

public class treasure : MonoBehaviour
{
    [SerializeField]
    Gamemanger manager;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.GetComponent<UniGunner>() != null)
        {
            manager.EndGame();
        }
    }
}
