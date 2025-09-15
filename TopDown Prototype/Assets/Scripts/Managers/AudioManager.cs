using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource musicSource , musicSound;
    [SerializeField] private AudioClip musicClip , fireSound;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        PlayMusic();
    }


    void PlayMusic()
    {
        if(musicClip != null && musicSound != null)
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }
    }

    public void FireSound()
    {
        if(musicSound != null)
        {
            musicSound.PlayOneShot(fireSound);
        }
    }


}
