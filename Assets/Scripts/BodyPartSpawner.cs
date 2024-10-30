using System.Collections.Generic;
using UnityEngine;

public class BodyPartSpawner : MonoBehaviour
{
    [SerializeReference] private List<BodyPart> _bodyParts;
    [SerializeReference] private Collider2D _spawnArea;
    
    void Start()
    {
        Vector3 randomPoint = GetRandomPointOnCollider(GetComponent<Collider>());
        Debug.Log("Random Point: " + randomPoint);
    }

    Vector3 GetRandomPointOnCollider(Collider collider)
    {
        Vector3 point;
        do
        {
            point = collider.bounds.center + new Vector3(
                Random.Range(-collider.bounds.extents.x, collider.bounds.extents.x),
                Random.Range(-collider.bounds.extents.y, collider.bounds.extents.y),
                Random.Range(-collider.bounds.extents.z, collider.bounds.extents.z)
            );
        } while (!collider.bounds.Contains(point) || !collider.Raycast(new Ray(point, Vector3.down), out _, 0));
        return point;
    }
}
