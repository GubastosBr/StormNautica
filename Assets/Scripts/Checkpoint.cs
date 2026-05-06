using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    [SerializeField] private Transform spawnPoint;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out ReviveSystem reviveSystem))
        {
            reviveSystem.spawnPosition = transform.position;
        }
    }

}

