using System.Collections;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    /// <summary>
    /// 每分钟节拍数
    /// </summary>
    public int BPM = 120;

    public int Beat = 4;

    public float DeltaTime
    {
        get
        {
            if (BPM == 0 || Beat == 0)
                return 100;
            return 60f / BPM / Beat;
        }
    }

    public bool PlayOnAwake;
    public TrackData TrackData;
    public AudioSource Source;
    public AudioClip[] Clips;

    protected void Awake()
    {
        if (PlayOnAwake)
            ProcessMusic();
    }

    protected void Start()
    {

    }

    private void ProcessMusic()
    {
        StartCoroutine(WaitProcessMusic());
    }

    public Controller Controller;
    private IEnumerator WaitProcessMusic()
    {
        var frame = 0;
        while (enabled)
        {
            foreach (var track in TrackData.Tracks)
            {
                var index = frame % track.Beats.Length;
                var beat = track.Beats[index];
                if (beat >= 0)
                {
                    if (Source == null)
                        AudioSource.PlayClipAtPoint(Clips[beat], transform.position, track.Volume);
                    else
                        Source.PlayOneShot(Clips[beat], track.Volume);
                }
            }

            Controller.PlayAudio();

            frame++;
            yield return new WaitForSecondsRealtime(DeltaTime);
        }
    }
}