using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public OvenFire Fire1;
    public OvenFire Fire2;
    public int tech;
    
    // Start is called before the first frame update
    void Start()
    {
        Fire1.tech = tech;
	Fire2.tech = tech;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /*void Cook()
    {

    }*/
}
