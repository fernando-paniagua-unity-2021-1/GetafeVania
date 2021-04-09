using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip sonidoPowerItem;
    public AudioClip sonidoKey;
    public AudioClip sonidoStar;
    private AudioSource audioSource;
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            audioSource = GetComponent<AudioSource>();
        }
    }
    public void PlaySound(string tag)
    {
        switch(tag)
        {
            case "PowerItem":
                audioSource.PlayOneShot(sonidoPowerItem);
                break;
            case "Key":
                audioSource.PlayOneShot(sonidoKey);
                break;
            case "Star":
                audioSource.PlayOneShot(sonidoStar);
                break;
            default:
                Debug.LogWarning("NO HAY SONIDO ASIGNADO PARA ESE ITEM");
                break;
        }
    }
}
