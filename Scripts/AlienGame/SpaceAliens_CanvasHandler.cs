using UnityEngine;
using UnityEngine.UI;

public class SpaceAliens_CanvasHandler : MonoBehaviour
{
    [Header("---Components")]
    [SerializeField] private Transform _playerT;
    [SerializeField] private TerrainGenerator _terraingGenerator;

    [Header("---UI Components")]
    [SerializeField] private Slider _slider;

    private float _distance = 1;

    void Start()
    {
        _distance = _terraingGenerator.GroundCount;
        _slider.maxValue = _distance;
    }
    void Update()
    {
        CalculateSliderValue();
    }
    private void CalculateSliderValue()
    {
        if (_playerT.position.x >= _distance) return;
        _slider.value = _playerT.position.x - 69.8f;
    }
}
