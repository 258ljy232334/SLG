using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlotManager :SingletonManager<PlotManager>
{
    [Header("引用组件")]
    [SerializeField] private TextMeshProUGUI SpeakerName;
    [SerializeField] private Image SpeakerAvatar;
    [SerializeField] private TextMeshProUGUI SpeakerContent;
    [SerializeField] private Image BackGroundImage;
    [SerializeField] private Image Character1Image;
    [SerializeField] private Image Character2Image;
    [SerializeField] private Button AutoButton;
    [SerializeField] private Button SkipButton;
    [SerializeField] private Button CloseUIButton;
    [SerializeField] private Button MenuButton;
    [SerializeField] private Button SettingButton;
    [SerializeField] private GameObject ButtonsPanel;
    [SerializeField] private GameObject DialogueBox;

    [Header("私有变量")]
    private int _defaultLine = 1;//默认故事行
    private int _currentLine = 0;//当前故事行
    private List<ExcelReader.ExcelData> _storyData;//故事内容
    private TypeWriteEffect _typeWriteEffect;//打字效果

    #region 生命周期
    protected override void Awake()
    {
        base.Awake();
        _typeWriteEffect = GetComponent<TypeWriteEffect>();
    }
    private void Start()
    {
        ResetButtons();
        InitializeStory(PlayerManager.Instance.GetCurPlot());
        BindButtons();
    }
    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            if (!DialogueBox.activeSelf)
            {
               //打开UI面板 
            }
            else if (!IsHittingBottonButton())
            {
                DisplayNextLine();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!DialogueBox.activeSelf)
            {
               //打开UI面板 
            }
            else
            {
              //关闭UI面板  ;
            }
        }
    }
    #endregion
    #region 成员函数
    #region 初始化方法
    private void InitializeStory(string storyName)
    {
        string path = Plot_Constants.STORY_PAHT + storyName + Plot_Constants.EXCEL;
        _storyData=ExcelReader.Read(path);
        _currentLine=_defaultLine;
        DisplayCurrentLine();
    }
  
    //重置按钮方法
    private void ResetButtons()
    {
        AutoButton.onClick.RemoveAllListeners();
        SkipButton.onClick.RemoveAllListeners();
        CloseUIButton.onClick.RemoveAllListeners();
        MenuButton.onClick.RemoveAllListeners();
        SettingButton.onClick.RemoveAllListeners();
    }
    //绑定按钮方法
    private void BindButtons()
    {
         
    }
    #endregion
    #region 显示图像相关
    private void SetBackGroundImage(string imageName)
    {
        string   path = Plot_Constants.BACKGROUND_PATH + imageName;
        SetImage(BackGroundImage, path);
    }
    private void SetCharacterImage(string imageName,bool isCharacter1)
    {
        string path = Plot_Constants.CHARACTER_PATH + imageName;
        if (isCharacter1)
        {
            SetImage(Character1Image, path);
        }
        else
        {
            SetImage(Character2Image, path);
        }
    }
    private void SetAvatarImage(string imageName)
    {
        string path = Plot_Constants.AVATAR_PATH + imageName;
        SetImage(SpeakerAvatar, path);
    }
    private void SetImage(Image image,string imagePath)
    {
        Sprite sprite=Resources.Load<Sprite>(imagePath);
        if(sprite==null)
        {
            Debug.LogWarning(imagePath + "路径不存在");
            return;
        }
        image.sprite = sprite;
    }
    #endregion
    #region 播放音频相关

    #endregion
    #region 主要方法
    //展示下一行
    private void DisplayNextLine()
    {
        if(_currentLine>_storyData.Count-1)
        {
            Debug.LogError("文件行出问题了");
            return;
        }
        if(_currentLine==_storyData.Count-1)
        {
            switch(_storyData[_currentLine].SpeakerName)
            {
                case "choices":
                    //不同的选择
                    break;
                case "next":
                    //改变玩家的故事名
                    break;
                case "end":
                    //故事结束
                    break;
                default:
                    Debug.LogWarning("未出现的协议名");
                    break;
            }
            return;
        }
        if (_typeWriteEffect.IsTyping)
        {
            _typeWriteEffect.CompleteLine();
        }
        else
        {
            DisplayCurrentLine();
        }
    }
    //展示当前行
    private void DisplayCurrentLine()
    {
        var data = _storyData[_currentLine];
        if(!string.IsNullOrEmpty(data.SpeakerName))
        {
            SpeakerName.text = data.SpeakerName;
        }
        if(!string.IsNullOrEmpty(data.SpeakerAvatar))
        {
            SetAvatarImage(data.SpeakerAvatar);
        }
        if(!string.IsNullOrEmpty(data.SpeakerContent))
        {
            _typeWriteEffect.StartType(data.SpeakerContent);
        }
        if(!string.IsNullOrEmpty(data.BackGroundImage))
        {
            SetBackGroundImage(data.BackGroundImage);
        }
        if(!string.IsNullOrEmpty(data.BackGroundMusic))
        {
            //播放背景音乐
        }
        if(!string.IsNullOrEmpty(data.Character1Image))
        {
            SetCharacterImage(data.Character1Image, true);
        }
        if(!string.IsNullOrEmpty(data.Character2Image))
        {
            SetCharacterImage(data.Character2Image, false);
        }
        if(!string.IsNullOrEmpty(data.Character1Action))
        {
            //为立绘1执行相关操作
        }
        if(!string.IsNullOrEmpty(data.Character2Action))
        {
            //为立绘2执行相关操作
        }
    }
    #endregion
    #region 辅助方法
    //判断是否按到按钮面板的地方
    private bool IsHittingBottonButton()
    {
        return RectTransformUtility.RectangleContainsScreenPoint
            (ButtonsPanel.GetComponent<RectTransform>(), Input.mousePosition, Camera.main);
    }
    #endregion
    #region 按钮绑定方法
    private void AutoPlay()
    {

    }
    private void Skip()
    {

    }
    private void OpenMenu()
    {

    }
    private void OpenUI()
    {

    }
    private void CloseUI()
    {

    }

    #endregion
    #endregion
}
