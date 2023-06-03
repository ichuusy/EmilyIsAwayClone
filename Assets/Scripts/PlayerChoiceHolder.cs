using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Friend/Player Holder",menuName="Create Choice")]
public class PlayerChoiceHolder : ScriptableObject
{
    public string friendName;
    public string[] choices;
}
