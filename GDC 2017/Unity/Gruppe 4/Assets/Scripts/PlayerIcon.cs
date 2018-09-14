using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// This object handles the in-game player icon. The icon changes depending on whether the player is currently alive or dead.
/// </summary>
public class PlayerIcon : MonoBehaviour
{
    public Sprite alive;
    public Sprite dead;
    public Image image;

    /// <summary>
    /// updates the state of the icon
    /// </summary>
    /// <param name="alive">the new state of the icon; dead or alive</param>
    public void UpdateIconAlive (bool alive)
    {
        if(alive)
        {
            image.sprite = this.alive;
        }
        else
        {
            image.sprite = dead;
        }
    }
}
