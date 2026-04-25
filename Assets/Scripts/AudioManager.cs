using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance;

    public AudioSource musicSource;
   
    public AudioSource sfxSource;

    public AudioClip bgMusic;
    
    public AudioClip buttonClick;
    
    public AudioClip cellClick;
    
    public AudioClip winWoosh;

    public AudioClip popupSound;

    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start() {
        ApplySettings();
        PlayMusic();
    }

    public void ApplySettings() {
        bool musicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
        bool sfxOn = PlayerPrefs.GetInt("SFXOn", 1) == 1;

        //musicSource.mute = !musicOn;

        if (musicOn) {
            musicSource.mute = false;

            if (!musicSource.isPlaying) {
                PlayMusic();
            }
        } else {
            musicSource.mute = true;
        }

        sfxSource.mute = !sfxOn;
    }

    public void PlayMusic() {
        bool musicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;

        if (musicOn && !musicSource.isPlaying)
        {
            musicSource.clip = bgMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlayButton() {
        if (PlayerPrefs.GetInt("SFXOn", 1) == 1) {
            sfxSource.PlayOneShot(buttonClick);
        }
    }

    public void PlayCell() {
        if (PlayerPrefs.GetInt("SFXOn", 1) == 1) {  
            sfxSource.PlayOneShot(cellClick);        
        }
    }

    public void PlayWin() {
        if (PlayerPrefs.GetInt("SFXOn", 1) == 1) {
            sfxSource.PlayOneShot(winWoosh);
        }
    }

    public void PlayPopup() {
        if (PlayerPrefs.GetInt("SFXOn", 1) == 1) {
            sfxSource.PlayOneShot(popupSound);
        }
    }
}