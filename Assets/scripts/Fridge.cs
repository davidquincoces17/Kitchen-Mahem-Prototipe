using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    public GameObject foodPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject spawnIngredient()
    {
        return Instantiate(foodPrefab,transform.position,foodPrefab.transform.rotation);
    }
}
