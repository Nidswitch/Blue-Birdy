using Unity.Netcode;
using UnityEngine;

public class PlayerSpawnTeleport : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        // Si c'est l'hôte et que c'est bien son propre joueur
        if (IsServer && IsOwner)
        {
            // Cherche l'objet invisible dans la scène "Test Zone" par son nom
            GameObject spawnPoint = GameObject.Find("RespawnPoint");

            if (spawnPoint != null)
            {
                transform.position = spawnPoint.transform.position;
                transform.rotation = spawnPoint.transform.rotation;
            }
        }
    }
}
