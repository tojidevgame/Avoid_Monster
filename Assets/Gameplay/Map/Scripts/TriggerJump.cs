using UnityEngine;

public class TriggerJump : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Enemy")
        {
            // Get component of enemy

            // Trigger time to jump
        }
    }
}
