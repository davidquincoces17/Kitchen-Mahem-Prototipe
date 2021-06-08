using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderHolder : MonoBehaviour
{
    public Order order;
    public GameObject orderPrefab;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	if(transform.parent.gameObject.GetComponent<ServingSpace>().accept_new){
        	if (transform.parent.gameObject.GetComponent<ServingSpace>().active_orders==id){
			newOrder();
			transform.parent.gameObject.GetComponent<ServingSpace>().active_orders+=1;
			transform.parent.gameObject.GetComponent<ServingSpace>().accept_new=false;
			transform.parent.gameObject.GetComponent<ServingSpace>().last_order_t = Time.time;
		}
	}
	//else{Debug.Log("I couldnt");}
    }

    public void newOrder()
    {
        order = Instantiate(orderPrefab, transform.position, orderPrefab.transform.rotation, GameObject.FindGameObjectWithTag("Canvas").transform).GetComponent<Order>();
        order.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
    }
}
