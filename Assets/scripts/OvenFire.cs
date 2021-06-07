using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenFire : MonoBehaviour
{
    public FoodObject inOven;
    public Timer timer;
    public GameObject timerPrefab;
    public Vector3 offset;
    public ParticleSystem smoke;
    public GameObject smokePrefab;
    public ParticleSystem fire;
    public GameObject firePrefab;
    // Start is called before the first frame update
    void Start()
    {
        smoke = Instantiate(smokePrefab, transform.position + new Vector3(0, 20, 0), smokePrefab.transform.rotation).GetComponent<ParticleSystem>();
        smoke.Stop();

        fire = Instantiate(firePrefab, transform.position + new Vector3(0, 20, 0), firePrefab.transform.rotation).GetComponent<ParticleSystem>();
        fire.Stop();

        FireLight fireLight = GameObject.FindGameObjectWithTag("FireLight").GetComponent<FireLight>();
        fireLight.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (inOven) { inOven.state = timer.state; }
        if (inOven && inOven.state == 2 && !fire.isPlaying)
        {
            // Start the fire
            fire.Play();
            
            // Show fire extinguisher
            GameObject fireExtinguisherPrefab = (GameObject)Resources.Load("Fire_Extinguisher/Prefab/fire extinguisher", typeof(GameObject));
            GameObject fireExtinguisher = Instantiate(fireExtinguisherPrefab, fireExtinguisherPrefab.transform.position, fireExtinguisherPrefab.transform.rotation).GetComponent<GameObject>();
            
            // Start flickering fire light
            FireLight fireLight = GameObject.FindGameObjectWithTag("FireLight").GetComponent<FireLight>();
            fireLight.isActive = true;

            // TODO: Start Alarm sound
        }
    }

    public void startCooking()
    {
        timer = Instantiate(timerPrefab, transform.position + offset, timerPrefab.transform.rotation, GameObject.FindGameObjectWithTag("Canvas").transform).GetComponent<Timer>();
        // Showing smoke
        smoke.Play();
    }

    public void stopFire()
    {
        // Stop fire
        fire.Stop();
        
        // Stop flickering fire light
        FireLight fireLight = GameObject.FindGameObjectWithTag("FireLight").GetComponent<FireLight>();
        fireLight.isActive = false;

        // TODO: Stop Alarm sound
    }
}
