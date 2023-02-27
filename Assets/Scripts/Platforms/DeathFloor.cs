using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    [SerializeField] private AudioClip deathSound;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<SoulControl>().LoadCheckPoint();
            SoundManager.instance.PlaySound(deathSound);
        }
    }
}
