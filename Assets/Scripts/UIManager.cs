using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Shared;    
    [SerializeField] private GameObject tableData;
    [SerializeField] private GameObject loadingBar;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject windowAlert;
    [SerializeField] private Button retryButton;
    private void Awake()
    {
        if(Shared==null){
            Shared = this;
        }
        else{
            Destroy(gameObject);
        }

        retryButton.onClick.AddListener(()=>{SceneManager.LoadScene(SceneManager.GetActiveScene().name);});
    }
    public void ShowHideTable(bool status)
    {
        tableData.SetActive(status);
    }

    public void ShowHideLoadingbar(bool status)
    {
        loadingBar.SetActive(status);
        credits.SetActive(status);
    }

    public void ShowHideWindowAlert(bool status, string message = "")
    {
        windowAlert.SetActive(status);
        if(status){
            windowAlert.GetComponentInChildren<TextMeshProUGUI>().text = message;
        }
    }
}
