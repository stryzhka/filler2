using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlash : MonoBehaviour
{
    private Light lt; 
    public float Duration;
    Color color0 = Color.red;
    Color color1 = Color.black;
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time, Duration) / Duration;
        lt.color = Color.Lerp(color0, color1, t);
    }
}
