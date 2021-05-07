using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteAnimationsConfig", menuName = "Configs/SpriteAnimationsConfig", order = 1)]
public class SpriteAnimatorConfig : ScriptableObject
{
    [Serializable]
    public class SpritesSequence
    {
        public AnimState Track;
        public List<Sprite> Sprites = new List<Sprite>();
    }

    public List<SpritesSequence> Sequences = new List<SpritesSequence>();  
}




