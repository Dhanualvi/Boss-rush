using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightCharDetails : MonoBehaviour
{
    [SerializeField] string heroName;

    [TextArea(2,6)]
    [SerializeField] string heroDescription;
    [SerializeField] string heroFirstSkillName;

    [TextArea(2, 6)]
    [SerializeField] string heroFirstSkillDesc;
    [SerializeField] string heroSecondSkillName;

    [TextArea(2, 6)]
    [SerializeField] string heroSecondSkillDesc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetHeroName()
    {
        return heroName;
    }

    public string GetHeroDescription()
    {
        return heroDescription;
    }

    public string GetFirstSkillName() 
    { 
        return heroFirstSkillName;
    }

    public string GetFirstSkillDesc()
    {
        return heroFirstSkillDesc;
    }

    public string GetSecondSkillName()
    {
        return heroSecondSkillName;
    }

    public string GetSecondSkillDesc()
    {
        return heroSecondSkillDesc;
    }
}
