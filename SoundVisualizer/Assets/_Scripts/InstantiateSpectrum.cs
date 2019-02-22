using UnityEngine;

public class InstantiateSpectrum : MonoBehaviour
{
    public GameObject sampleCubePrefab;
    public float scaleLevel;
    GameObject[] sampleCube = new GameObject[512];
    
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject instanceSampleCube = Instantiate(sampleCubePrefab);
            instanceSampleCube.transform.position = transform.position;
            instanceSampleCube.transform.parent = transform;
            instanceSampleCube.name = "SampleCube" + i;

            //512 Cubes / 360° Circle = 0.703125° rotation per spawned cube 
            transform.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            instanceSampleCube.transform.position = Vector3.forward * 100;
            sampleCube[i] = instanceSampleCube;

        } 
    }

    
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if(sampleCube != null)
            {
                sampleCube[i].transform.localScale = new Vector3(10, (AudioManager.samples[i] * scaleLevel) + 2, 10);
            }
        }
    }
}
