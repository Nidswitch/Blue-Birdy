using UnityEngine;

public class SpecialFeather : MonoBehaviour
{
    [SerializeField] private float bonusMaxHealth = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 1. Donne le pouvoir de vol et ajuste la force de saut
            Playercontroller controller = collision.GetComponent<Playercontroller>();
            if (controller != null)
            {
                controller.canFly = true;
                controller.JumpingPower = controller.FlyJumpPower;
            }

            // 2. Ajoute la vie bonus
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.IncreaseMaxHealth(bonusMaxHealth);
            }

            // 3. Masque la plume
            gameObject.SetActive(false);
        }
    }

    public static void ResetAllFeathers()
    {
        SpecialFeather[] feathers = Resources.FindObjectsOfTypeAll<SpecialFeather>();

        foreach (SpecialFeather feather in feathers)
        {
            if (feather != null && feather.gameObject != null && feather.gameObject.scene.name != null)
            {
                feather.gameObject.SetActive(true);
            }
        }
    }
}