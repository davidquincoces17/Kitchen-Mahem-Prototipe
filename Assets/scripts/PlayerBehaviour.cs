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
        if (inHand)
        {
            inHand.transform.position = transform.position + Vector3.up;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MeatFridge"))
        {
            if (inHand != null)
            {
                Debug.Log("kkkkkkkkkkkkkkkkkkkk");
                inHand.DestroyMeat();
            }
            Fridge fridge = other.gameObject.GetComponent<Fridge>();
            inHand = fridge.spawnIngredient().GetComponent<MeatObject>();
            //Destroy(gameObject);
            Debug.Log("meat",other);
        }

        else if(other.CompareTag("Oven") && inHand)
        {
            Oven oven = other.gameObject.GetComponent<Oven>();
            oven.inOven = inHand;
            inHand = null;
            Debug.Log("Cooking", other);
            //oven.Cook();
        }
    }
}
