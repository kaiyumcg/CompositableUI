using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

namespace CompositableUI
{
    public interface IUICompositableTask
    {
        void Execute(ref List<Tween> tweens);
    }

    public interface IUICompositableTaskAsync
    {
        void Execute(ref List<Tween> tweens, MonoBehaviour runner, Action OnComplete);
    }
}