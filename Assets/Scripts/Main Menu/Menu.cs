using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public List<MenuSection> sections;
    public MainMenuInputCapture menuInputCapture;

    private int selectedSectionIndex;
    private int selectedOptionIndex;

    // Start is called before the first frame update
    void Start()
    {
        selectedSectionIndex = 0;
        selectedOptionIndex = 0;
        menuInputCapture.OnSelectOptionPressed += OnSelectOptionPressed;
        menuInputCapture.OnDownPressed += OnDownPressed;
        menuInputCapture.OnUpPressed += OnUpPressed;
        ShowSection();
    }

    private void OnUpPressed()
    {
        var section = sections[selectedSectionIndex];
        section.Options.ForEach(option => option.menuOption.Deselect());
        var optionIndex = selectedOptionIndex - 1;
        if (optionIndex < 0)
        {
            optionIndex = section.Options.Count - 1;
        }
        selectedOptionIndex = optionIndex;
        section.Options[selectedOptionIndex].menuOption.Select();
    }

    private void OnDownPressed()
    {
        var section = sections[selectedSectionIndex];
        section.Options.ForEach(option => option.menuOption.Deselect());
        var optionIndex = selectedOptionIndex + 1;
        if (optionIndex > section.Options.Count - 1)
        {
            optionIndex = 0;
        }
        selectedOptionIndex = optionIndex;
        section.Options[selectedOptionIndex].menuOption.Select();
    }

    private void ShowSection()
    {
        selectedOptionIndex = 0;

        sections.ForEach(section => section.sectionPanel.SetActive(false));
        MenuSection section = sections[selectedSectionIndex];
        section.sectionPanel.SetActive(true);
        section.Options.ForEach(option => option.menuOption.Deselect());
        section.Options[selectedOptionIndex].menuOption.Select();
    }

    private void OnSelectOptionPressed()
    {
        var targetSectionIndex = sections[selectedSectionIndex].Options[selectedOptionIndex].targetSection;

        switch (targetSectionIndex)
        {
            case -1:
                var option = sections[selectedSectionIndex].Options[selectedOptionIndex];
                option.execute.Invoke();
                break;
            default:
                selectedSectionIndex = targetSectionIndex;

                ShowSection();
                break;
        }
    }

    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("Court");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    [Serializable]
    public class MenuSection
    {
        public GameObject sectionPanel;
        public List<MenuOptionDetails> Options;
    }

    [Serializable]
    public class MenuOptionDetails
    {
        public MenuOption menuOption;
        public int targetSection;
        public UnityEvent execute; 
    }
}
