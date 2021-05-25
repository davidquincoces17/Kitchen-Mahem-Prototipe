using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public FoodObject inHand;

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
                Destroy(inHand.gameObject);
                inHand = null;
                Debug.Log("Left");
            }
            Fridge fridge = other.gameObject.GetComponent<Fridge>();
            inHand = fridge.spawnIngredient().GetComponent<FoodObject>();
            //Destroy(gameObject);
            Debug.Log("Grabbed");
        }

        if (other.CompareTag("PastaFridge"))
        {
            if (inHand != null)
            {
                Destroy(inHand.gameObject);
                inHand = null;
                Debug.Log("Left");
            }
            Fridge fridge = other.gameObject.GetComponent<Fridge>();
            inHand = fridge.spawnIngredient().GetComponent<FoodObject>();
            //Destroy(gameObject);
            Debug.Log("Grabbed");
        }

        else if(other.CompareTag("Oven") && inHand)
        {
            OvenFire fire = other.gameObject.GetComponent<OvenFire>();
            if (!fire.inOven) {
                fire.inOven = inHand;
                fire.inOven.transform.position = fire.transform.position + new Vector3(0,15,0);
                inHand = null;
                Debug.Log("Cooking", other);
                fire.startCooking();
            }
        }
    }
}
