using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public OvenFire Fire1;
    public OvenFire Fire2;
    
    //public OvenFire Circle;
    public int tech;
    Color32[] ColorTech = new Color32[] {new Color32(255, 255, 255, 255),new Color32(200, 200, 0, 255),new Color32(255, 25, 25, 255),new Color32(0, 25, 200, 255)};
    
    // Start is called before the first frame update
    void Start()
    {
        Fire1.tech = tech;
        Fire2.tech = tech;
        transform.GetChild(2).GetComponent<SpriteRenderer>().color = ColorTech[tech];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /*void Cook()
    {

    }*/
}
