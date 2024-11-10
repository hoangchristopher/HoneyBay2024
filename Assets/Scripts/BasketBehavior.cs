using Unity.VisualScripting;
using UnityEngine;

public class BasketBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Apple"){
            Destroy(other.gameObject);
            Spawner.Instance.Spawn();
        }
    }
}
