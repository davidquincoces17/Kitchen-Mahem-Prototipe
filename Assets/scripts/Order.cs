using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Order : MonoBehaviour
{
	int completed = 0;

	[SerializeField] public Text vegetableText;
	[SerializeField] public Text meatText;
	[SerializeField] public Text pastaText;

	[SerializeField] public Image vegetableCircle;
	[SerializeField] public Image meatCircle;
	[SerializeField] public Image pastaCircle;

	private int vegetableTech = 0;
	private int meatTech = 0;
	private int pastaTech = 0;

	List<string> techinques = new List<string>(new string[] {"Not wanted","Fried","Baked","Boiled"});

	Color32[] ColorTech = new Color32[] {new Color32(0, 0, 0, 255),new Color32(200, 200, 0, 255),new Color32(255, 25, 25, 255),new Color32(0, 25, 200, 255)};

	public bool done;

    // Start is called before the first frame update
    void Start()
    { 	
		while(vegetableTech == 0 && meatTech == 0 && pastaTech == 0){
			vegetableTech = Random.Range(0, 4);
			vegetableText.text = techinques[vegetableTech];
			vegetableCircle.color = ColorTech[vegetableTech];

			meatTech = Random.Range(0, 3);
			meatText.text = techinques[meatTech];
			meatCircle.color = ColorTech[meatTech];

			pastaTech = Random.Range(0, 4);
			if(pastaTech > 1){
				pastaTech = 3;
			}else{
				pastaTech = 0;
			};
			Debug.Log(pastaTech);
			pastaText.text = techinques[pastaTech];
			Debug.Log(techinques[pastaTech]);
			pastaCircle.color = ColorTech[pastaTech];
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int check(CounterSpace dish){
 	if(dish.components[0]){
		if(dish.components[0] && dish.components[0].tech==meatTech && dish.components[0].state==1){completed+=5;}
 			else if(dish.components[0].tech!=meatTech && dish.components[0].state==1){completed+=2;}
 			else {completed-=2;}
	}
 	if(dish.components[1]){
		if(dish.components[1] && dish.components[1].tech==pastaTech && dish.components[1].state==1){completed+=5;}
 			else if(dish.components[1].tech!=pastaTech && dish.components[1].state==1){completed+=2;}
 			else {completed-=2;}
	}
 	if(dish.components[2]){
		if(dish.components[2].tech==vegetableTech && dish.components[2].state==1){completed+=5;}
 			else if(dish.components[2].tech!=vegetableTech && dish.components[2].state==1){completed+=2;}
 			else {completed-=2;}
	}

	//Play Order Completion sound
	if(completed < 0)
	{
		SoundManager.Instance.PlayOrderBad();
	}
	else if(completed == 6)
	{
		SoundManager.Instance.PlayOrderVeryGood();
	}
	else
	{
		SoundManager.Instance.PlayOrderGood();
	}

 	return completed;
    }

}
