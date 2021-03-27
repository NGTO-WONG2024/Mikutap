using UnityEngine;

public class Controller : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip[] Clips;
    public float Volume = 1;

    [SerializeField]
    private int m_index = -1;
    private int m_lastIndex = -1;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_index = GetIndex();
            m_lastIndex = m_index;
            return;
        }
        if (Input.GetMouseButton(0))
        {
            var index = GetIndex();
            if (m_lastIndex != index)
            {
                m_lastIndex = index;
                m_index = index;
            }
            return;
        }


    }

    private int GetIndex()
    {
        var pos = Input.mousePosition;
        var deltax = Screen.width / 8;
        var deltay = Screen.height / 4;
        var x = (int)(pos.x / deltax);
        var y = (int)((Screen.height - pos.y) / deltay);
        return y * 8 + x;
    }

    public void PlayAudio()
    {
        if (m_index >= 0 && m_index < Clips.Length)
        {
            Source.PlayOneShot(Clips[m_index], Volume);
            m_index = -1;
        }
    }
}