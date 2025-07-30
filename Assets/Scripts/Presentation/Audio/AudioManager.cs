using UnityEngine;

public enum AudioType
{
    gun,
}

public enum AudioName
{
    /// <summary>
    /// 手枪开火
    /// </summary>
    fx_gun_1,
}

public class AudioManager
{
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null) instance = new AudioManager();
            return instance;
        }
    }

    private AudioSource audioSource;
    public AudioSource AudioSource
    {
        get
        {
            if (audioSource == null) audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
            if (audioSource == null) throw new System.Exception("未找到AudioSource!");
            return audioSource;
        }
    }

    public void PlayBGM(AudioType audioType, AudioName audioName, float volume = 1f)
    {
        AudioClip audioClip = ResourcesLoader.Instance.LoadAudioClip(audioType.ToString(), audioName.ToString());

        StopBGM();
        AudioSource.clip = audioClip;
        AudioSource.volume = volume;
        AudioSource.Play();
    }

    public void StopBGM()
    {
        AudioSource.Stop();
    }

    public void PlaySound(AudioType audioType, AudioName audioName, float volume = 1f)
    {
        AudioClip audioClip = ResourcesLoader.Instance.LoadAudioClip(audioType.ToString(), audioName.ToString());
        AudioSource.PlayOneShot(audioClip, volume);
    }
}