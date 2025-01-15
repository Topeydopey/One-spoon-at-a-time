using UnityEngine;

public class LegCollisionFootstep : MonoBehaviour
{
    [Header("Tag for the Stairs")]
    [SerializeField] private string stairTag = "Ground";

    [Header("Footstep Cooldown (seconds)")]
    [SerializeField] private float footstepCooldown = 0.2f;
    private float nextFootstepTime = 0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Only trigger if enough time has passed AND we collided with a stair
        if (Time.time >= nextFootstepTime && collision.gameObject.CompareTag(stairTag))
        {
            AudioManager.Instance.Play("Footstep");
            nextFootstepTime = Time.time + footstepCooldown;
        }
    }
}
