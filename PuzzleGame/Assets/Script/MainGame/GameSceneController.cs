using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : Singleton<GameSceneController>
{
    public GameObject introPanel, resultPanel, endText;
    public Button replaybutton, nextButton;

    public List<GameObject> sceneList;

    public GameObject scenePosition;
    public GameObject collection1, collection2, collection3;
    public Sprite starOn, starOff;
    public List<Image> starsList;
    [SerializeField]
    private int currScene;

    private void Start()
    {
        OnClickOpenIntro();
        introPanel.SetActive(true);
        currScene = PlayerPrefs.GetInt("PlayerLevel",0);
        
        replaybutton.onClick.AddListener(OnClickReplay);
        nextButton.onClick.AddListener(OnClickNext);
        nextButton.gameObject.SetActive(false);
        endText.SetActive(false);
        resultPanel.SetActive(false);
        InitialGameScene();
    }

    private void InitialGameScene()
    {
        
        GameObject g = Instantiate(sceneList[currScene]);
        g.transform.SetParent(scenePosition.transform);
        g.transform.position = scenePosition.transform.position;
        g.transform.rotation = scenePosition.transform.rotation;
        g.transform.localScale = new Vector3(1, 1, 1);
    }

    private void Update()
    {
        CloseIntroEvent();
        
    }

    public void EndEvent()
    {
        resultPanel.SetActive(true);
        endText.SetActive(true);
        starsList[0].sprite = starOff;
        starsList[1].sprite = starOff;
        starsList[2].sprite = starOff;
    }
    public void ResultEvent()
    {
        resultPanel.SetActive(true);
        endText.SetActive(false);
        if (currScene + 1 < sceneList.Count)
        {
            nextButton.gameObject.SetActive(true);
        }
        else
        {
            nextButton.gameObject.SetActive(false);
        }

        UpdateStarCount();
    }

    private void UpdateStarCount()
    {
        if (!collection1.activeSelf && !collection2.activeSelf && !collection3.activeSelf)
        {
            starsList[0].sprite = starOn;
            starsList[1].sprite = starOn;
            starsList[2].sprite = starOn;
            //SaveLoadManager.Instance.UpdateCurrLevelCollection(3);
        }
        else if ((!collection1.activeSelf && !collection2.activeSelf) || (!collection1.activeSelf && !collection3.activeSelf) || (!collection3.activeSelf && !collection2.activeSelf))
        {
            starsList[0].sprite = starOn;
            starsList[1].sprite = starOn;
            starsList[2].sprite = starOff;
            //SaveLoadManager.Instance.UpdateCurrLevelCollection(2);
        }
        else if (!collection1.activeSelf || !collection2.activeSelf || !collection3.activeSelf)
        {
            starsList[0].sprite = starOn;
            starsList[1].sprite = starOff;
            starsList[2].sprite = starOff;
            //SaveLoadManager.Instance.UpdateCurrLevelCollection(1);
        }
        else
        {
            starsList[0].sprite = starOff;
            starsList[1].sprite = starOff;
            starsList[2].sprite = starOff;
            //SaveLoadManager.Instance.UpdateCurrLevelCollection(0);
        }
        

    }

    #region OnClick Event

    public void OnClickNext()
    {
        
        currScene++;
        OnClickReplay();
        //LoadingManager.Instance.LoadingScene(SceneIndex.GameScene, SceneIndex.GameScene);

    }

    public void OnClickReplay()
    {

        //LoadingManager.Instance.LoadingScene(SceneIndex.GameScene, SceneIndex.GameScene);
        PlayerPrefs.SetInt("PlayerLevel", currScene);
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        
    }

    private void CloseIntroEvent()
    {
        if (introPanel.activeSelf)
        {
            if (Input.anyKeyDown)
            {
                introPanel.SetActive(false);
                
            }
            
        }
        
    }

    private void OnClickOpenIntro()
    {
        introPanel.SetActive(true);
        
    }
    #endregion
}
