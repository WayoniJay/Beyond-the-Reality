using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------Audio Source-------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------Audio Clip_______")]
    public AudioClip background;
    public AudioClip success;
    public AudioClip fail;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }


}
