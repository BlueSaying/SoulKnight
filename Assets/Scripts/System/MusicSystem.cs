using UnityEngine;

public enum AudioType
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

    public void PlayAudio(AudioType type)
    {
        AudioClip audioClip = ResourcesFactory.Instance.GetAudioClip(type.ToString());

        audioSource.PlayOneShot(audioClip);
    }
}