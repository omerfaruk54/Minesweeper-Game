using UnityEngine;
using System.Collections.Generic;
using MyGrid;
using TMPro;
public class Unit : MonoBehaviour
{
    public UnitState UnitState => _unitState;
    public UnitState _unitState;

    [SerializeField] private SpriteRenderer mySpriteRenderer;


    public SpriteRenderer MyMask => myMask;
    [SerializeField] private SpriteRenderer myMask;



    public SpriteRenderer MyFlag => myFlag;
    [SerializeField] private SpriteRenderer myFlag;




    [SerializeField] private TextMeshPro myText;

    [SerializeField] private TileController myTile;

    private int _mineAmount;


    public void Prepare(UnitState state)
    {
        _unitState = state;

        mySpriteRenderer.color = _unitState == UnitState.Mine ? Color.red : Color.white;
    }

    public void PrepareText()
    {
        if (_unitState == UnitState.Mine)
        {
            myText.text = "";
        }
        else
        {
            var list = myTile.GetAllNeighbour();

            int count = 0;

            foreach (var item in list)
            {
                if (item.myUnit.UnitState == UnitState.Mine)
                {
                    count++;
                }
            }

            var result = count > 0 ? count.ToString() : "";

            myText.text = result;

            _mineAmount = count;
        }
    }


    public void Open()
    {

        if (!CanOpen())
        {
            return;
        }
        myMask.enabled = false;

        if (_unitState == UnitState.Mine)
        {
            GameManager.Instance.GameOver();
            return;
        }

        if (_mineAmount == 0) 
        {
            var list = myTile.GetAllNeighbour();
            foreach (var item in list)
            {
                item.myUnit.Open();
            }
        }

    }
    public void ToggleFlag()
    {
        myFlag.enabled = !myFlag.enabled;
    }

    public bool CanOpen()
    {
        return myMask.enabled && !myFlag.enabled;
    }

}



