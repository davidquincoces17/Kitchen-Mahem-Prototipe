using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodObject : MonoBehaviour
{
    public int state = 0;
    public int type;

    public Sprite raw;
    public Sprite cooked;
    public Sprite burned;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0) { this.GetComponent<SpriteRenderer>().sprite = raw; }
        else if (state == 1) { this.GetComponent<SpriteRenderer>().sprite = cooked; }
        else if (state == 2) { this.GetComponent<SpriteRenderer>().sprite = burned; }
    }
}