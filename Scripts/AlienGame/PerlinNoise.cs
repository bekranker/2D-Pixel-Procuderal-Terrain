using System;
using UnityEngine;
[Serializable]
public class PerlinNoise
{
    public AnimationCurve FrequencyCurve;
    public float GetNoise(float noiseInput)
    {
        Debug.Log("NoiseInput: " + FrequencyCurve.Evaluate(noiseInput));
        return Mathf.PerlinNoise(FrequencyCurve.Evaluate(noiseInput), 0);
    }
}