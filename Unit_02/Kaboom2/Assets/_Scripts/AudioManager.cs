using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlaySound(string sound)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.name.Equals(sound))
            {
                transform.GetChild(i).GetComponent<AudioSource>().Play();
            }
        }
    }
}
