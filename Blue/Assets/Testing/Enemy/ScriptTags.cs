using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTags : MonoBehaviour
{
    [SerializeField] private List<Tags> _tags;
    public List<Tags> All => _tags;

    public bool HasTag(Tags tag)
    {
        return _tags.Contains(tag);
    }

    public bool HasTag(string tagName)
    {
        return _tags.Exists(tag => tag.Name.Equals(tagName, StringComparison.InvariantCultureIgnoreCase));
    }
}
