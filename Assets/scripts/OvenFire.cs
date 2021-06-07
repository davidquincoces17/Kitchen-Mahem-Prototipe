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
    }

    // Update is called once per frame
    void Update()
    {
        if (inOven) { inOven.state = timer.state; }
    }

    public void startCooking()
    {
        timer = Instantiate(timerPrefab, transform.position + offset, timerPrefab.transform.rotation, GameObject.FindGameObjectWithTag("Canvas").transform).GetComponent<Timer>();
        // Showing smoke
        smoke.Play();
    }
}
