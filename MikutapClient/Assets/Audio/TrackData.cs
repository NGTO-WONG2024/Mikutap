using System;
using UnityEngine;

[CreateAssetMenu]
public class TrackData : ScriptableObject
{
    public Track[] Tracks;
}

[Serializable]
public class Track
{
    public int[] Beats;
    public float Volume = 1f;
}