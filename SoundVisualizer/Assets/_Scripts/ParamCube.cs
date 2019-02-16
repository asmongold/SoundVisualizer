using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int band;
    public float startScale;
    public float scaleLevel;

    void Start()
    {
       
    }

   
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, (AudioManager.freqBands[band] * scaleLevel) + startScale, transform.localScale.z);
    }
}
