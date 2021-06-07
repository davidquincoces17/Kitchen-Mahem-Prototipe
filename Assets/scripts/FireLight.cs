using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLight : MonoBehaviour
{
    private bool isFlickering = false;
    public float timeDelay;
    public bool isActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFlickering && isActive)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
