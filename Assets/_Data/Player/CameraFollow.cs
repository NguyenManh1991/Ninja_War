using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    [SerializeField] protected Vector3 follow;
    
    protected virtual void Update()
    {
        CameraFollowPlayer();
    }

    protected virtual void CameraFollowPlayer()
    {
        transform.position = new Vector3(player.position.x + 6, 0, -10);
    }
}
