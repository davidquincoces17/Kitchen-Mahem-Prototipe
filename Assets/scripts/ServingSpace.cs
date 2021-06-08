using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingSpace : MonoBehaviour
{
    //public OrderHolder OrderHolder1;
    //public OrderHolder OrderHolder2;
    //public OrderHolder OrderHolder3;
    public int active_orders = 0;
    public bool accept_new = false;
    public float last_order_t = 0;
    public float order_delay;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
	if(Time.time-last_order_t >= order_delay && !accept_new){accept_new=true;}
	//Debug.Log(Time.time);
    }
}
