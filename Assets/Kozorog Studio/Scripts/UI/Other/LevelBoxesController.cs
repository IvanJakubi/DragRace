using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelBoxesController : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> levelTexts;
    [SerializeField] private List<Image> levelTextBackground;

    [Header("")]
    [SerializeField] private Color currentLevelColor;
    [SerializeField] private Color otherLevelColor;
    [SerializeField] private Color completedLevelColor;

    // Start is called before the first frame update
    private void PopulateUI()
    {
        var currentLevel = SaveData.current.currentLevel;
        var numOfLevelsToDisplay = levelTexts.Count + 1;
        var currentLevelIndex = (currentLevel - 1) % numOfLevelsToDisplay;

        foreach (var levelText in levelTexts)
        {
            levelText.text = (currentLevel++ - currentLevelIndex).ToString();
        }
    }

    private void ColorLevelUI()
    {
        var currentLevel = SaveData.current.currentLevel;
        var numOfLevelsToDisplay = levelTextBackground.Count + 1;
        var currentLevelIndex = (currentLevel - 1) % numOfLevelsToDisplay;

        foreach (var levelBackground in levelTextBackground)
        {
            if (currentLevelIndex == levelTextBackground.IndexOf(levelBackground))
                levelBackground.color = currentLevelColor;
            if (currentLevelIndex > levelTextBackground.IndexOf(levelBackground))
                levelBackground.color = completedLevelColor;
            if(currentLevelIndex < levelTextBackground.IndexOf(levelBackground))
                levelBackground.color = otherLevelColor;
        }
    }

    // Update is called once per frame
    void Awake()
    {
        PopulateUI();
        ColorLevelUI();
    }
}
