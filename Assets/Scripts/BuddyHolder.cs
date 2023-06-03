using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Buddy Holder",menuName="Create Buddy")]
public class BuddyHolder : ScriptableObject
{
    public string name;
    public string[] messages;
    public string personalInfo;
    public bool status;
}
