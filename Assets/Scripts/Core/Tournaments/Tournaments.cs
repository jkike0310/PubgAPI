using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Core.Enpoints;
using Core.Request;
using System;
using UnityEngine.UI;

public class Tournaments : MonoBehaviour
{
    [SerializeField] private UI_Tournaments uI_Tournaments;
    
    private void Start()
    {
        StartCoroutine(RequestManager.MakeRequest(Enpoints.TOURNAMENT_ENDPOINT, "", (response)=>DeployResponse(response)));
    }

    public void DeployResponse(string res)
    {
        UIManager.Shared.ShowHideLoadingbar(false);
        if(!res.Contains("Error")){
            UIManager.Shared.ShowHideTable(true);
            TournamentData responseData = JsonUtility.FromJson<TournamentData>(res);
            int count = 0;
            foreach (var tournament in responseData.data)
            {            
                if(count==0){
                    List<string> headers = new List<string>();
                    headers.Add(nameof(tournament.id));
                    headers.Add(nameof(tournament.attributes.createdAt));
                    uI_Tournaments.Init(headers);
                }else{
                    List<string> dataObtained = new List<string>();
                    DateTime date = DateTime.Parse(tournament.attributes.createdAt);
                    string dateFormated = date.ToString("dd/MM/yyyy HH:mm");
                    dataObtained.Add(tournament.id);
                    dataObtained.Add(dateFormated);   
                    uI_Tournaments.Init(dataObtained); 
                }
                count++;
            }
        }else{
            UIManager.Shared.ShowHideTable(false);
            UIManager.Shared.ShowHideWindowAlert(true, res);
        }
        

        
    }


    
}