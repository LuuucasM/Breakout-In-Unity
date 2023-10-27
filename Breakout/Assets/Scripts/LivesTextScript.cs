using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesTextScript : MonoBehaviour
{

    public Text ValueText;

    // Update is called once per frame
    private void FixedUpdate()
    {
        ValueText.text = "Lives: " + GameData.PlayerLives.ToString();
    }
}
