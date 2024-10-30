using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BodyPartSpawner : MonoBehaviour
{
    [SerializeReference] List<BodyPart> _bodyParts;
    [SerializeReference] Collider2D _spawnArea;
    [SerializeReference] float _spawnRate;
    float _spawnRateTimer;
    void Update()
    {
        HandleBodyPartSpawning();
    }
    void HandleBodyPartSpawning()
    {
        _spawnRateTimer -= Time.deltaTime;
        if (_spawnRateTimer <= 0)
        {
            SpawnBodyPart();
            _spawnRateTimer = _spawnRate;
        }
    }
    void SpawnBodyPart()
    {
        BodyPart bodyPart = _bodyParts[Random.Range(0, _bodyParts.Count)];
        Vector2 randomPoint = GetRandomPointOnCollider(_spawnArea);
        Instantiate(bodyPart, randomPoint, Quaternion.identity);
    }
    Vector2 GetRandomPointOnCollider(Collider2D collider)
    {
        Vector2 point;
        do
        {
            point = (Vector2)collider.bounds.center + new Vector2(
                Random.Range(-collider.bounds.extents.x, collider.bounds.extents.x),
                Random.Range(-collider.bounds.extents.y, collider.bounds.extents.y)
            );
        } while (!collider.OverlapPoint(point));
        return point;
    }
}