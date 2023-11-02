using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoSingleton<UiManager>
{
    [SerializeField]
    private Image _selectBarImage;
    [SerializeField]
    private Image[] _healthBarGraphic;
    [SerializeField]
    private Text _gemCount;
    public override void init()
    {
        base.init();
    }
    //SelectBar UI
    public void SelectBarPos(float YValue)
    {
        _selectBarImage.gameObject.SetActive(true);
        _selectBarImage.rectTransform.anchoredPosition = new Vector2(_selectBarImage.rectTransform.anchoredPosition.x, YValue);
    }
    public void HideSelectBar()
    {
        _selectBarImage.gameObject.SetActive(false);
    }
    //Gem Count
    public void GemCount(int count)
    {
        _gemCount.text = count.ToString();
    }
    //Health
    public void HealthDamageGraphic(int HealthLeft)
    {
       
       for(int i = 0; i <= HealthLeft; ++i)
        {
          
            if (i == HealthLeft)
            {
                _healthBarGraphic[i].enabled = false;
            }
        }
    }
    






}
