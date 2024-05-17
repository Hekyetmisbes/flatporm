using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip menuMusic;
    public AudioClip[] levelMusicClips;
    private AudioSource audioSource;
    private float musicTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMenuMusic()
    {
        if (audioSource.clip != menuMusic)
        {
            audioSource.clip = menuMusic;
            audioSource.time = 0;
            audioSource.Play();
        }
    }

    public void PlayLevelMusic()
    {
        if (levelMusicClips.Length > 0)
        {
            int randomIndex = Random.Range(0, levelMusicClips.Length);
            audioSource.clip = levelMusicClips[randomIndex];
            audioSource.time = musicTime;
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (audioSource.isPlaying)
        {
            musicTime = audioSource.time;
        }
    }
}
