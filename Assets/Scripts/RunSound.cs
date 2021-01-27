using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Run時のサウンド
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class RunSound : MonoBehaviour
{
  [SerializeField] AudioClip[] runSoundClip;
  [SerializeField] bool randomizePitch = true;
  [SerializeField] float pitchRange = 0.1f;

  protected AudioSource source;

  private void Awake()
  {
    // アタッチしたオーディオソースのうち1番目を使用する
    source = GetComponents<AudioSource>()[0];
  }

  public void PlayFootstepSE()
  {
    if(randomizePitch)
      source.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);

    source.PlayOneShot(runSoundClip[Random.Range(0, runSoundClip.Length)]);
  }

}




/*[RequireComponent(typeof(AudioSource))]
public class RunSound : MonoBehaviour
{
    [SerializeField]
    AudioClip[] runSoundClip;

    [SerializeField]
    bool randomizePitch;

    [SerializeField]
    float pitchRange = 0.1f;

    protected AudioSource audioSource;

    private void Awake()
    {
        //アタッチしたオーディオソースのうち１番目を使用する
        audioSource = GetComponents<AudioSource>()[0];
    }

    public void PlayFootstepSE()
    {
        if (randomizePitch)
        {
            audioSource.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        }

        //PlayOneShot関数は、何種類かの短い音を再生するのに適している
        audioSource.PlayOneShot(runSoundClip[Random.Range(0, runSoundClip.Length)]);
    }
}
*/