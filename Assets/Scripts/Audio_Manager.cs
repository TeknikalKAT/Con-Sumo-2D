
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [Header("-----Audio Source-----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-----Audio Clip-----")]
    [SerializeField] AudioClip background;
    // [SerializeField] AudioClip gameOver;
    [Header("Sumo Pushes")]
    public AudioClip[] sumoPushes;
    [Header("Bite Sounds")]
    public AudioClip[] biteSounds;
    [Header("Losing Sounds")]
    public AudioClip[] loseSounds;
    [Header("Bad Food Sounds")]
    public AudioClip[] badFoodSounds;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
