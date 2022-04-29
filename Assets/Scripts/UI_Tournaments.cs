using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Tournaments : MonoBehaviour
{
    [SerializeField] private GameObject prefabSlot;
    [SerializeField] private Transform content;

    [SerializeField] private Scrollbar scrollbar;

    private void Start()
    {
        StartCoroutine(ResetScroll());
    }

    public void Init(List<string> data)
    {
        var slot = Instantiate(prefabSlot, content).GetComponent<UI_TournamentSlot>();
        slot.Init(data);        
    }
    IEnumerator ResetScroll()
    {
        yield return new WaitForSeconds(1f);
        scrollbar.value = 1f;
    }

    
}
