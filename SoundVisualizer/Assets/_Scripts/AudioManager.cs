using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public static float[] samples = new float[512];
    public static float[] freqBands = new float[8];

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        GetSpectrumAudioSource();
        CreateFrequencyBands();
    }


    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void CreateFrequencyBands()
    {
        // 22050Hz / 512 Samples = 43Hz per Sample

        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7) 
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
                
            }

            average /= count;
            freqBands[i] = average * 10;
        }
    }
}
