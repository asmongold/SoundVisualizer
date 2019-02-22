using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int band;
    public float startScale;
    public float scaleLevel;
    public bool useBuffer;

   
    void Update()
    {
        if(useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioManager.bandBuffer[band] * scaleLevel) + startScale, transform.localScale.z);
        }
        if(!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioManager.freqBands[band] * scaleLevel) + startScale, transform.localScale.z);
        }
        
    }
}
