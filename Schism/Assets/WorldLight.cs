using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;
using UnityEngine;

namespace WorldTime {
    
    [RequireComponent(typeof(Light2D))]

public class WorldLight : MonoBehaviour
{
    public float duration = 5f;

    [SerializeField] private Gradient gradient;
    private Light2D _light;
    private float _startTime;

    private void Awake()
    {
        _light = GetComponent<Light2D>();
        _startTime = Time.time;
    }


    void Update()
    {
        var timeElapsed = Time.time - _startTime;
        var percentage = Mathf.Sin(timeElapsed/duration * Mathf.PI*2) * 0.5f + 0.5f;
        percentage = Mathf.Clamp01(percentage);

        _light.color = gradient.Evaluate(percentage);        
    }
}

}
