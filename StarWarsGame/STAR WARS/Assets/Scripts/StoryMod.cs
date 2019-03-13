using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMod : MonoBehaviour
{

    public void ChangeStoryMod(string mod)
    {
        Application.LoadLevel(mod);

    }
}
