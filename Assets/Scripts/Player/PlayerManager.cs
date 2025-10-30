using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonManager<PlayerManager>
{
    #region 私有变量
    private int _coins;//金币数量
    [SerializeField]
    private int _maxStamina;//最大体力值
    private int _curStamina;//当前体力值
    [SerializeField]
    private string _curPlot;//当前剧情的名称
    #endregion
    #region 生命周期
    protected override void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("多余的玩家单例");
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        _curStamina = _maxStamina;
       
    }
    #endregion
    #region 金币相关
    public int GetCoins()
    {
        return _coins;
    }
    public void AddCoins(int coins)
    {
        _coins += coins;
    }
    public void SubCoins(int coins)
    {
        _coins -= coins;
    }
    public bool CanAffordCoins(int coins)
    {
        return _coins >= coins;
    }
    #endregion
    #region 体力相关
    public int GetStamina()
    {
        return _curStamina;
    }
    public void AddStamina(int stamina)
    {
        if (stamina < 0)
        {
            Debug.LogWarning("体力值无效增加");
            return;
        }
        _curStamina = Mathf.Max(_curStamina + stamina, _maxStamina);
    }
    public void SubStamina(int stamina)
    {
        if(stamina<0)
        {
            Debug.LogWarning("体力值无效减少");
            return;
        }
        _curStamina -= stamina;
    }
    public bool CanAffordStamina(int stamina)
    {
        return _curStamina >= stamina;
    }
    public void RecoverStamina()
    {
        _curStamina = _maxStamina;
    }
    #endregion
    #region 剧情相关
    public string GetCurPlot()
    {
        return _curPlot;
    }
    public void SetCurPlot(string plot)
    {
        if(!Setting.PLOTS.Contains(plot))
        {
            Debug.LogWarning("没有这个剧情名");
            return;
        }
        _curPlot = plot;
    }
    #endregion
}
