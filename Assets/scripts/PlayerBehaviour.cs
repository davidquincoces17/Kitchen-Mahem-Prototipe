using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public FoodObject inHand; // Food object
    public FireExtinguisher inHandFE; // fire extinguisher
    public Order inHandO; // Order
    public Dish inHandDish; // dish
    public TimerInteraction interT;
    public GameObject timerPrefab;
    public Collider other;

    //public ParticleSystem healingRing;
    //public GameObject healingRingPrefab;

    // Start is called before the first frame update
    void Start()
    {
	    interT = Instantiate(timerPrefab, transform.position, timerPrefab.transform.rotation, GameObject.FindGameObjectWithTag("Canvas").transform).GetComponent<TimerInteraction>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (inHandFE)
        {
            inHandFE.transform.position = transform.position + 15*Vector3.up;
        }
        else if (inHand)
        {
            inHand.transform.position = transform.position + 15*Vector3.up;
        } 
	    else if (inHandO)
        {
            inHandO.transform.position = transform.position + 15*Vector3.up;
        }
        else if (inHandDish)
        {
            inHandDish.transform.position = transform.position + 15 * Vector3.up;
        }
        interT.transform.position = transform.position + Vector3.up*15;
	    checkInteraction();
	    //other = null;
	    if(interT.state != 0)
        {
            interT.state=-1;
        }
    }

    private void beginInteraction(Collider c_other)
    {
	    other = c_other;
	    if(interT.state == -1)
        {
                interT.Begin(interT.Duration);
        }
    }
    
    private void OnTriggerEnter(Collider c_other)
    {
	    beginInteraction(c_other);
    }

    private void OnTriggerExit(Collider c_other)
    {
	    other = null;
	    interT.state = -1;
        Debug.Log("out");
    }

    private void checkInteraction(){
	    if(other && interT.state == 1){
            if (!inHandFE && !inHandO && !inHandDish)
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
		            else
                    {
                        Debug.Log("no order");
                    }
                }
            } 
	        else if (!inHandFE && inHandO)
            {
	            if (other.CompareTag("Counter"))
                {
                    CounterSpace counter = other.gameObject.GetComponent<CounterSpace>();
                    FoodObject[] components = counter.components;
                    string dishName = "dish";
                    if(components[0])
                    {
                        dishName += "1";
                    } 
                    else
                    {
                        dishName += "0";
                    }

                    if (components[1])
                    {
                        dishName += "1";
                    }
                    else
                    {
                        dishName += "0";
                    }

                    if (components[2])
                    {
                        dishName += "1";
                    }
                    else
                    {
                        dishName += "0";
                    }

                    int reward = inHandO.check(counter);

                    Destroy(inHandO.gameObject);
                    inHandO = null;

                    inHandDish = counter.generateDish(dishName, reward).GetComponent<Dish>();
                    
                    for (int i = 0; i < 3; i++)
                    {
                        if (counter.components[i])
                        {
                            Destroy(counter.components[i].gameObject);
                            counter.components[i] = null;
                        }
                    }

                    Debug.Log("Dish completed");

                }
            }
            else if (inHandDish)
            {
                if (other.CompareTag("ServeryCounter"))
                {
                    GameObject totalcash = GameObject.FindWithTag("TotalCash");
                    totalcash.GetComponent<Points>().add(inHandDish.reward);

                    Destroy(inHandDish.gameObject);
                    inHandDish = null;
                    Debug.Log(inHandDish.reward);
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
	        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                PlayerBehaviour otherPlayer = other.gameObject.GetComponent<PlayerBehaviour>();
                if(otherPlayer.inHand && otherPlayer.inHand.state == 2)
                {
                    otherPlayer.inHand.state = 1;
                }
                if (this.inHand && this.inHand.state == 2)
                {
                    this.inHand.state = 1;
                }
            }
	        interT.state=-1;
	    }
    }
}