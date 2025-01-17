using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private Transform _groundPrefab;
    [SerializeField] private int _groundCount;
    [SerializeField] private float _noiseScale = 0.1f;
    [SerializeField] private float _noiseScale2 = 0.02f;
    [SerializeField] private float _heightMultiplier = 5f;
    [SerializeField] private float _maxHeightDifference = 0.2f;
    [SerializeField] private float _randomOffsetRange = 100f;
    [SerializeField] private Transform _parent;
    private float _nextSpawnX = 0f;
    private float _previousHeight = 0f;
    private float _randomSeed, _randomSeed2;

    void Start()
    {
        _randomSeed = Random.Range(0f, _randomOffsetRange);
        _randomSeed2 = Random.Range(0f, _randomOffsetRange);

        GenerateGround();
    }

    private void GenerateGround()
    {


        for (int i = 0; i <= _groundCount; i++)
        {
            float noiseInput = (_nextSpawnX * _noiseScale) + _randomSeed;
            float noiseInput2 = (_nextSpawnX * _noiseScale2) + _randomSeed2;
            float height = Mathf.PerlinNoise(noiseInput - noiseInput2, 0) * _heightMultiplier;

            float heightDifference = Mathf.Abs(height - _previousHeight);
            if (heightDifference <= _maxHeightDifference)
            {
                height = _previousHeight;
            }

            // Renk hesaplama: 0 (kırmızı) -> 1 (mavi)
            float t = i / (float)_groundCount; // 0 ile 1 arasında normalize
            Color tempColor = new Color(1 - t, 0, t); // Kırmızıdan maviye geçiş

            Vector3 spawnPosition = new Vector3(_nextSpawnX, height, 0);
            Transform spawnedGrid = Instantiate(_groundPrefab);
            spawnedGrid.SetParent(_parent);
            spawnedGrid.GetComponent<SpriteRenderer>().color = tempColor;

            spawnedGrid.localPosition = spawnPosition;
            _nextSpawnX += 1;
            _previousHeight = height;
        }

    }
}
