using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
// -1 not asked, 0 raw, 1 cooked, 2 burned
int pasta;
int meat;
int vegetables;
int completed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void set(int p, int m, int v){
	pasta = p;
	meat = m;
	vegetables = v;
    }

   int check(DishObject dish){
	if(dish.pComponent.state==pasta){completed+=5;}
		else if (dish.pComponent.state!=0 && dish.pComponent.state!=2){completed+=1;}
		else {completed-=2;}
	if(dish.mComponent.state==meat){completed+=5;} 
		else if (dish.mComponent.state!=0 && dish.mComponent.state!=2){completed+=1;}
		else {completed-=2;}
	if(dish.vComponent.state==vegetables){completed+=5;}
		else if (dish.vComponent.state!=0 && dish.vComponent.state!=2){completed+=1;}
		else {completed-=2;}
	return completed;
   }

}
