using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    MeatObject inHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inHand.transform.position = transform.position;
    }
        private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Meat"))
        {
            inHand = other.gameObject.spawnIngredient();
            Debug.Log("meat",other);
        }
    }
}
