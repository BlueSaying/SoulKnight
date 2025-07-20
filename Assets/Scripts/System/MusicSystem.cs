using UnityEngine;

public enum AudioType
{
    gun,
}

public enum AudioName
{
    fx_gun_1,
}

public class MusicSystem : AbstractSystem
{
    private AudioSource audioSource;

    protected override void OnInit()
    {
        base.OnInit();

        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioType audioType, AudioName audioName)
    {
        AudioClip audioClip = ResourcesFactory.Instance.GetAudioClip(audioType.ToString(), audioName.ToString());

        audioSource.PlayOneShot(audioClip);
    }
}