using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroSelectionMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI heroName;
    [SerializeField] TextMeshProUGUI heroDesc;
    [SerializeField] TextMeshProUGUI heroFirstSkillName;
    [SerializeField] TextMeshProUGUI heroFirstSkillDesc;
    
    [SerializeField] TextMeshProUGUI heroSecondSkillName;
    [SerializeField] TextMeshProUGUI heroSecondSkillDesc;
    
    KnightCharDetails knightCharDetails;

    [SerializeField] Button continueButton;
    [SerializeField] Button homeButton;
    // Start is called before the first frame update
    void Awake()
    {
        knightCharDetails = FindObjectOfType<KnightCharDetails>();
        continueButton.onClick.AddListener(OnContinueButtonClick);
        homeButton.onClick.AddListener(OnHomeButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateField();
    }

    void UpdateField()
    {
        heroName.text = knightCharDetails.GetHeroName();
        heroDesc.text = knightCharDetails.GetHeroDescription();
        heroFirstSkillName.text = knightCharDetails.GetFirstSkillName();
        heroFirstSkillDesc.text = knightCharDetails.GetFirstSkillDesc();
        heroSecondSkillName.text = knightCharDetails.GetSecondSkillName();
        heroSecondSkillDesc.text = knightCharDetails.GetSecondSkillDesc();
    }

    void OnContinueButtonClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    void OnHomeButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
