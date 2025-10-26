using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public string portalColor; // e.g. "Blue", "Gold", "Purple"
    public int points = 10;
    public AudioClip successSound;
    public AudioClip failSound;

    private AudioSource audioSource;
    private GameManager gameManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ColorMatch orb = other.GetComponent<ColorMatch>();

        if (orb != null)
        {
            if (orb.colorTag == portalColor)
            {
                // ADD SCORE HERE
                FindObjectOfType<GameManager>().AddScore(10);

                if (successSound) audioSource.PlayOneShot(successSound);
                Destroy(other.gameObject); // remove orb
            }
            else
            {
                if (failSound) audioSource.PlayOneShot(failSound);
                FindObjectOfType<GameManager>().AddScore(-5); // optional penalty
            }
        }
    }
}
