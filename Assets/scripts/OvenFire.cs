using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenFire : MonoBehaviour
{
    public FoodObject inOven;
    public Timer timer;
    public GameObject timerPrefab;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inOven) { inOven.state = timer.state; }
    }

    public void startCooking()
    {
        timer = Instantiate(timerPrefab, transform.position + offset, timerPrefab.transform.rotation, GameObject.FindGameObjectWithTag("Canvas").transform).GetComponent<Timer>();
    }
}
