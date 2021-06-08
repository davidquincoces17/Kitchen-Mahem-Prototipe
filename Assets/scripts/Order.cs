using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Order : MonoBehaviour
{
// -1 not asked, 0 raw, 1 cooked, 2 burned
int pasta;
int meat;
int vegetables;
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



    // Start is called before the first frame update
    void Start()
    { 	
		while(vegetableTech == 0 && meatTech == 0 && pastaTech == 0){
			vegetableTech = Random.Range(0, 3);
			vegetableText.text = techinques[vegetableTech];
			vegetableCircle.color = ColorTech[vegetableTech];

			meatTech = Random.Range(0, 2);
			meatText.text = techinques[meatTech];
			meatCircle.color = ColorTech[meatTech];

			pastaTech = Random.Range(0, 1)*3;
			//if(pastaTech >= 1){
			//	pastaTech = 3;
			//}else{
			//	pastaTech = 0;
			//};
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

//     void set(int p, int m, int v){
// 	pasta = p;
// 	meat = m;
// 	vegetables = v;
//     }

//    int check(CounterSpace dish){
// 	if(dish.components[0].state==meat){completed+=5;}
// 		else if (dish.components[0].state!=0 && dish.components[0].state!=2){completed+=1;}
// 		else {completed-=2;}
// 	if(dish.components[1].state==pasta){completed+=5;} 
// 		else if (dish.components[1].state!=0 && dish.components[1].state!=2){completed+=1;}
// 		else {completed-=2;}
// 	if(dish.components[2].state==vegetables){completed+=5;}
// 		else if (dish.components[2].state!=0 && dish.components[2].state!=2){completed+=1;}
// 		else {completed-=2;}
// 	return completed;
//    }

}
