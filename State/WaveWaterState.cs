using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PJW.FSM;
namespace PJW.FramingExperience
{
    /// <summary>
    /// 打水状态
    /// </summary>
    public class WaveWaterState : PJWState
    {

        private string stateName = "waveWater";
        public WaveWaterState(string StateName) : base(StateName)
        {
        }
        /// <summary>
        /// 进入状态
        /// </summary>
        /// <param name="lastState"></param>
        public override void EnterStateCallBack(IState lastState)
        {
            base.EnterStateCallBack(lastState);

        }
        /// <summary>
        /// 退出状态时
        /// </summary>
        /// <param name="nextState"></param>
        public override void ExitStateCallBack(IState nextState)
        {
            base.ExitStateCallBack(nextState);

        }
    }
}
