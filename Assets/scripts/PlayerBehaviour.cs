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
        if (other.CompareTag("MeatFridge"))
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

        else if (other.CompareTag("Oven"))
        {
            OvenFire fire = other.gameObject.GetComponent<OvenFire>();
            if (inHand)
            {
                if (inHand.state == 0 && !fire.inOven)
                {
                    fire.inOven = inHand;
                    fire.inOven.transform.position = fire.transform.position + new Vector3(0, 15, 0);
                    inHand = null;
                    
                    // Showing smoke
                    var emission = fire.smoke.emission;
                    emission.enabled = true;
                    fire.smoke.gameObject.GetComponent<ParticleSystem>().Play();
                    //fire.smoke.gameObject.GetComponent<ParticleSystem>().enableEmission = true;
                    fire.smoke.transform.position = fire.transform.position + new Vector3(0, 17, 0);

                    Debug.Log("Cooking", other);
                    fire.startCooking();
                }
            }
            else if (fire.inOven)
            {
                if (fire.inOven.state > 0)
                {
                    inHand = fire.inOven;
                    fire.inOven = null;
                    Destroy(fire.timer.gameObject);

                    // Removing smoke
                    var emission = fire.smoke.emission;
                    emission.enabled = false;
                    //fire.smoke.transform.position = fire.transform.position + new Vector3(0, 17, 0);
                }
            }
        }
        else if (other.CompareTag("Counter") && inHand)
        {
            CounterSpace counter = other.gameObject.GetComponent<CounterSpace>();
            if (!counter.inPreparation)
            {
                counter.inPreparation = inHand;
                counter.inPreparation.transform.position = counter.transform.position + new Vector3(0, 15, 0);
                inHand = null;
            }
        }
    }
}