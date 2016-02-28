using UnityEngine;
using System.Collections;

public class FireflyJar : MonoBehaviour {

    public int fly_count;
    public int max_fly_count;
    public float intensity_increase = 0.5f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addFly()
    {
        Light lt = GetComponent<Light>();

        if(fly_count < max_fly_count)
        {
            lt.intensity += intensity_increase;
            fly_count++;
        }
            
    }
}
