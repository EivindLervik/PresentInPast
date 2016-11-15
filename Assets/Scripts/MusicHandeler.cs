using UnityEngine;
using System.Collections;

public enum MusicSong
{
    FirstCave, FirstBoss
}

public class MusicHandeler : MonoBehaviour {
    [Header("Initial")]
    public bool activeAtStart;
    public MusicSong initialSong;
    public float initialMusicDelay;

    [Header("Clips")]
    public AudioClip[] clips;

    private AudioSource mx;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
        mx = GetComponent<AudioSource>();

        if (activeAtStart)
        {
            PlaySong(initialSong, initialMusicDelay);
        }
	}

    public void PlaySong(MusicSong s, float delay)
    {
        mx.Stop();

        switch (s)
        {
            case MusicSong.FirstCave:
                mx.clip = clips[0];
                break;
            case MusicSong.FirstBoss:
                mx.clip = clips[1];
                break;
            default:
                // Nothing
                break;
        }

        mx.PlayDelayed(delay);
    }
    public void PlaySong(MusicSong s)
    {
        PlaySong(s, 0.0f);
    }
}
