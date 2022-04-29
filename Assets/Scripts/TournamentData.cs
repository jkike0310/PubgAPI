using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class TournamentData
{
    public Tournament[] data;
}
[Serializable]
public class Tournament
{
    public string type;
    public string id;
    public TournamentAttributes attributes;

}
[Serializable]
public class TournamentAttributes
{
    public string createdAt;
}
