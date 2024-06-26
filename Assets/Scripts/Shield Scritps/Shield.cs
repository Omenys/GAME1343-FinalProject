using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] ShieldChargeStat stats; //Accessing ShieldCharge scriptableObject
    [SerializeField] GameObject shield; //To access a shield object

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<MovementWithNewInput>() != null)
        {
            Destroy(shield); //Destroys shield objet from scene
            stats.currentShieldCount += 1; //Adds a charge to the player's current shield count

            if (stats.currentShieldCount > 3)
            {
                stats.currentShieldCount = stats.maxShieldCount;
            }
            if (stats.currentShieldCount <= 1)
            {
                SoundPlayer.playSound("warning");
            }
        }
    }
}
