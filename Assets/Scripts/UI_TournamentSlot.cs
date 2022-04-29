using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_TournamentSlot : MonoBehaviour
{    
    [SerializeField] private GameObject prefabText;
    
    public void Init(List<string> data)
    {        
        for (int i = 0; i < data.Count; i++)
        {
            var text = Instantiate(prefabText, this.transform).GetComponent<TextMeshProUGUI>();
            text.text = data[i];
        }

    }
}
