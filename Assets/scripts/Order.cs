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

   int check(CounterSpace dish){
	if(dish.components[0].state==meat){completed+=5;}
		else if (dish.components[0].state!=0 && dish.components[0].state!=2){completed+=1;}
		else {completed-=2;}
	if(dish.components[1].state==pasta){completed+=5;} 
		else if (dish.components[1].state!=0 && dish.components[1].state!=2){completed+=1;}
		else {completed-=2;}
	if(dish.components[2].state==vegetables){completed+=5;}
		else if (dish.components[2].state!=0 && dish.components[2].state!=2){completed+=1;}
		else {completed-=2;}
	return completed;
   }

}
