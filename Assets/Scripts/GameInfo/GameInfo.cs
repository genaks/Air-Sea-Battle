using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameInfo
{
    [SerializeField] private int time_limit;
    public int timeLimit { get { return time_limit; } }

    [SerializeField] private int default_high_score;
    public int defaultHighScore { get { return default_high_score; } }

    [SerializeField] private int points_per_plane;
    public int pointsPerPlane { get { return points_per_plane; } }

    public string id;
}