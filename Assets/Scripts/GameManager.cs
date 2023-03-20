using UnityEngine;
using System.Collections.Generic;
using MyGrid;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private List<Unit> _listUnit = new List<Unit>();

    [SerializeField] GameObject winPanel, losePanel;
    [SerializeField] GameObject restartButton, quitButton;

    [SerializeField] private int mineAmaount;

    private bool _isGameOver;



    private void Awake()
    {
        Instance = this;
        losePanel.SetActive(false);
        restartButton.SetActive(false);
        quitButton.SetActive(false);
    }

    private void Start()
    {
        PrepareGame();


    }

    private void PrepareGame()
    {
        //Fill List
        foreach (var item in GridManager.Instance.ListGridController)
        {
            var unit = item.GetComponent<Unit>();
            _listUnit.Add(unit);
        }

        //Set Mine
        var list = new List<Unit>(_listUnit);
        for (int i = 0; i < mineAmaount; i++)
        {
            var index = Random.Range(0, list.Count);
            var unit = list[index];
            unit.Prepare(UnitState.Mine);
            list.RemoveAt(index);
        }
        foreach (var item in _listUnit)
        {
            item.PrepareText();
        }
    }

    public void GameOver()
    {

        if (_isGameOver)
        {
            return;
            _isGameOver = true;
        }

        Debug.Log("GameOver");
        losePanel.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);

        foreach (var item in _listUnit)
        {
            if (item.UnitState == UnitState.Mine)
            {
                item.Open();
            }
        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }


}
