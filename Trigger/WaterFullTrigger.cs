using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PJW.FSM;

namespace PJW.FramingExperience
{
    /// <summary>
    /// 水打满的条件
    /// </summary>
    public class WaterFullTrigger : PJWTransition
    {
        public WaterFullTrigger(string name, IState from, IState to) : base(name, from, to)
        {
        }

    }
}
