using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//[RequireComponent(typeof(Button))]

public class LobbyController : MonoBehaviour
{
    public GameObject levelSelectPopup;
    public void PlayGame()
    {
       levelSelectPopup.SetActive(true);
    }

    public void LoadLevel1()
    {
        onClick(1);    
    }

    public void LoadLevel2()
    {
        onClick(2);
    }

    public void LoadLevel3()
    {
        onClick(3);
    }

    private void onClick(int level)
    {
        string selected_level = EventSystem.current.currentSelectedGameObject.tag;
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(selected_level);

        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Level has not been unlocked yet");
                break;

            case LevelStatus.Unlocked:
                Debug.Log("Starting " + selected_level);
                SceneManager.LoadScene(level);
                break;

            case LevelStatus.Completed:
                Debug.Log("Level has already been completed. Replaying " + selected_level);
                SceneManager.LoadScene(level);
                break;
        }
    }


}
