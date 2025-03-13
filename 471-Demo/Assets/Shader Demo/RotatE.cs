using UnityEngine;

public class RotatE : MonoBehaviour
{

    [SerializeField]
    public GameObject Minigun;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            {
                Minigun.transform.Rotate(0, 0, 5);
            }
    }
}
