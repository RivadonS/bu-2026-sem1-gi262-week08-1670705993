using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skill
{
    public string name;
    public bool isUnlocked;
    public bool isAvailable;
    public List<Skill> nextSkills;

        
    public Skill(string name)
    {
    // 1. set the name of the skill, 
    // initialize isUnlocked to false, 
    // and create an empty list of nextSkills
        this.name = name;
        this.isUnlocked = false;
        this.nextSkills = new List<Skill>();
    }

    public void Unlock()
    {
        if (!isAvailable)
        {
            // 2. throw an exception if the skill is not available to unlock
            throw new System.Exception("Skill is not available to unlock");
        }

        if (isUnlocked)
        {
            // 3. if the skill is already unlocked, log message and return
            Debug.Log("Skill is already unlocked");
            return;
        }
        
        // 4. set isUnlocked to true
        isUnlocked = true;

        // 5. set isAvailable to true for all nextSkills
        for (int i = 0; i < nextSkills.Count; i++)
        {
            nextSkills[i].isAvailable = true;
        }

        /*
        ทางเลือกอื่นที่เขียนให้สั้นลงได้:
        * แบบที่ 1: foreach
        foreach (Skill skill in nextSkills)
        {
            skill.isAvailable = true;
        }

        * แบบที่ 2: List.ForEach (Lambda expression)
        nextSkills.ForEach(skill => skill.isAvailable = true);
        */
    }


    public void PrintSkillTree()
    {
        Debug.Log($"Skill: {name}, IsAvailable: {isAvailable}, IsUnlocked: {isUnlocked}");
        for (int i = 0; i < nextSkills.Count; i++)
        {
            nextSkills[i].PrintSkillTree();
        }
        // 6. log the name of the skill, isAvailable, and isUnlocked
        // and call PrintSkillTree() on all nextSkills
    }

    public void PrintSkillTreeHierarchy(string indent)
    {
        // 7. log the name of the skill, isAvailable, and isUnlocked with indentation
        Debug.Log($"{indent}Skill: {name}, IsAvailable: {isAvailable}, IsUnlocked: {isUnlocked}");
        foreach (Skill skill in nextSkills)
        {
            skill.PrintSkillTreeHierarchy(indent + "====");
        }
        // and call PrintSkillTreeHierarchy() on all nextSkills

    }

}

public class SkillTree
{
    public Skill rootSkill;

    public SkillTree(Skill rootSkill)
    {
        this.rootSkill = rootSkill;
    }
}

