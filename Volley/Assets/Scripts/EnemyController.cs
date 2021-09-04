using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController :IPlayerController
{
    private EnemyController() : base(KeyCode.W, KeyCode.D, KeyCode.A) { }
}
