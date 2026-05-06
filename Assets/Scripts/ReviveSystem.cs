using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveSystem : MonoBehaviour
{
    public Vector3 spawnPosition;

    private void Start()
    {
        spawnPosition = transform.position;
    }

    public void RevivePlayer()
    {
        transform.position = spawnPosition;
    }

}
