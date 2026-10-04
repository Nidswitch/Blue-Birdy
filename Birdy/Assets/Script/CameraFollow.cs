using Unity.Netcode;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0f;
    private Vector3 velocity = Vector3.zero;

    private Transform target;

    void Update()
{
    if (target == null)
    {
        FindLocalPlayer();
        return; 
    }

    Vector3 targetPosition = target.position + offset;
    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
}

    private void FindLocalPlayer()
    {
        if (NetworkManager.Singleton != null && NetworkManager.Singleton.LocalClient != null)
        {
            var localPlayer = NetworkManager.Singleton.LocalClient.PlayerObject;
            if (localPlayer != null)
            {
                target = localPlayer.transform;
            }
        }
    }
}
