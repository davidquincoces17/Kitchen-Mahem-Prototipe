using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public FoodObject inHand;
    public FireExtinguisher inHandFE; // fire extinguisher
    public Order inHandO; // fire extinguisher

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inHandFE)
        {
            inHandFE.transform.position = transform.position + Vector3.up;
        }
        else if (inHand)
        {
            inHand.transform.position = transform.position + Vector3.up;
        } 
	else if (inHandO)
        {
            inHandO.transform.position = transform.position + Vector3.up;
        } 
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!inHandFE && !inHandO)
        {
            if (other.CompareTag("PastaFridge") || other.CompareTag("MeatFridge") || other.CompareTag("VegetableFridge") )
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

                        Debug.Log("Cooking", other);
                        fire.startCooking();
                    }
                }
                else if (fire.inOven)
                {
                    if (fire.inOven.state > 0 && !fire.fire.isPlaying)
                    {
                        inHand = fire.inOven;
                        fire.inOven = null;
                        Destroy(fire.timer.gameObject);

                        // Removing smoke
                        fire.smoke.gameObject.GetComponent<ParticleSystem>().Stop();
                    }
                }
            }
            else if (other.CompareTag("Counter") && inHand)
            {
                CounterSpace counter = other.gameObject.GetComponent<CounterSpace>();
                if (counter.components[inHand.type]) {Destroy(counter.components[inHand.type].gameObject);}
                counter.components[inHand.type] = inHand;
                counter.components[inHand.type].transform.position = counter.transform.position + new Vector3(inHand.type*7-7, 15, 0);
                inHand = null;
            }

            else if (other.CompareTag("FireExtinguisher") && !inHandO)
            {
                if (inHand != null)
                {
                    Destroy(inHand.gameObject);
                    inHand = null;
                }
                inHandFE = other.gameObject.GetComponent<FireExtinguisher>();
                Debug.Log("Grabbed FE");
                Debug.Log(inHandFE);
            }
	    
	    else if (other.CompareTag("OrderSpace"))
            {
		OrderHolder holder = other.gameObject.GetComponent<OrderHolder>();
		if(holder.order){
                	if (inHand != null)
                	{
                    		Destroy(inHand.gameObject);
                    		inHand = null;
                	}
                	inHandO = holder.order;
                	//Debug.Log("Grabbed order");
                	//Debug.Log(inHandO);
		}
		else{Debug.Log("no order");}
            }
        } 
	else if (!inHandFE && inHandO)
        {
	    if (other.CompareTag("Counter"))
            {
                CounterSpace counter = other.gameObject.GetComponent<CounterSpace>();
		int reward = inHandO.check(counter);
		Debug.Log(reward);
		for(int i=0; i<3; i++){
			if (counter.components[i]){
				Destroy(counter.components[i].gameObject);
				counter.components[i]=null;
			}
		}
                Destroy(inHandO.gameObject);
		inHandO = null;
            }
	}
        else if (inHandFE && !inHandO)
        {
            if (other.CompareTag("Oven"))
            {
                OvenFire fire = other.gameObject.GetComponent<OvenFire>();

                if (fire.inOven)
                {
                    if (fire.inOven.state == 2)
                    {
                        inHand = fire.inOven;
                        fire.inOven = null;
                        Destroy(fire.timer.gameObject);

                        // Removing smoke
                        fire.smoke.gameObject.GetComponent<ParticleSystem>().Stop();
                        Destroy(inHandFE.gameObject);
                        inHandFE = null;
                        fire.stopFire();
                    }
                }
            }
        }
    }
}