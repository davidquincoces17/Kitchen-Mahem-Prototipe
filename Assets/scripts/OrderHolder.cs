using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderHolder : MonoBehaviour
{
    public Order order;
    public GameObject orderPrefab;

    // Start is called before the first frame update
    void Start()
    {
        newOrder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newOrder()
    {
        order = Instantiate(orderPrefab, transform.position, orderPrefab.transform.rotation, GameObject.FindGameObjectWithTag("Canvas").transform).GetComponent<Order>();
        order.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
    }
}
