using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TagExtension
{
    public static bool HasTag(this GameObject gameObject, Tags tag)
    {
        return gameObject.TryGetComponent<ScriptTags>(out var tags) && tags.HasTag(tag);
    }

    public static bool HasTag(this GameObject gameObject, string tagName)
    {
        return gameObject.TryGetComponent<ScriptTags>(out var tags) && tags.HasTag(tagName);
    }
}
