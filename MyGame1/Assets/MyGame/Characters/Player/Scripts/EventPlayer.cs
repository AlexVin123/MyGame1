using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventPlayer
{
    public static UnityAction<float, float> ChaingedHealth;
    public static UnityAction Dying;
}
