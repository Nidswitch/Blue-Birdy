using UnityEngine;
using Unity.Netcode;

public class GunSpecial : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Playercontroller player = other.GetComponent<Playercontroller>();
        
        if (player != null)
        {
            player.EnableGun();
            
            Destroy(gameObject);
        }
    }
}
