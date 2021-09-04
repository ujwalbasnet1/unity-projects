using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : IPlayerController
{
    private HeroController() : base(KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.LeftArrow) { }
}
