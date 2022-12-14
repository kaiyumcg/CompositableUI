using DG.Tweening;
using DTExt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityExt;

namespace CompositableUI
{
    #region Fade
    [System.Serializable]
    internal class FadeGroup : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] float within = 0.4f;
        [SerializeField] List<MaskableGraphic> graphics;
        List<Tween> tws = null;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            tws.ExResetDT();
            tws = graphics.ExFade(appear ? 1.0f : 0.0f, within);
            tweens = tws;
        }
    }

    [System.Serializable]
    internal class FadeSingle : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] float within = 0.4f;
        [SerializeField] MaskableGraphic graphic;
        Tween tw = null;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            tw.ExResetDT();
            tw = graphic.DOFade(appear ? 1.0f : 0.0f, within);
            tweens = new List<Tween>();
            tweens.Add(tw);
        }
    }

    [System.Serializable]
    internal class FadeGroupAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] float within = 0.4f;
        [SerializeField] List<MaskableGraphic> graphics;
        List<Tween> tws = null;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            tws.ExResetDT();
            tws = graphics.ExFade(appear ? 1.0f : 0.0f, within, runner, OnComplete);
            tweens = tws;
        }
    }

    [System.Serializable]
    internal class FadeSingleAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] float within = 0.4f;
        [SerializeField] MaskableGraphic graphic;
        Tween tw = null;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            tw.ExResetDT();
            tw = graphic.DOFade(appear ? 1.0f : 0.0f, within).OnComplete(() => { OnComplete?.Invoke(); });
            tweens = new List<Tween>();
            tweens.Add(tw);
        }
    }

    //
    [System.Serializable]
    internal class SetAlphaGroup : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] float alpha = 1.0f;
        [SerializeField] List<MaskableGraphic> graphics;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            graphics.ExSetAlpha(alpha);
            tweens = new List<Tween>();
        }
    }

    [System.Serializable]
    internal class SetAlphaSingle : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] float alpha = 1.0f;
        [SerializeField] MaskableGraphic graphic;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            graphic.ExSetAlpha(alpha);
            tweens = new List<Tween>();
        }
    }

    [System.Serializable]
    internal class SetAlphaGroupAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] float alpha = 1.0f;
        [SerializeField] List<MaskableGraphic> graphics;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            graphics.ExSetAlpha(alpha);
            tweens = new List<Tween>();
            OnComplete?.Invoke();
        }
    }

    [System.Serializable]
    internal class SetAlphaSingleAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] float alpha = 1.0f;
        [SerializeField] MaskableGraphic graphic;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            graphic.ExSetAlpha(alpha);
            tweens = new List<Tween>();
            OnComplete?.Invoke();
        }
    }
    #endregion

    #region Color
    [System.Serializable]
    internal class ColorGroup : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] Color color = Color.white;
        [SerializeField] float within = 0.4f;
        [SerializeField] List<MaskableGraphic> graphics;
        List<Tween> tws = null;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            tws.ExResetDT();
            tws = graphics.ExColor(color, within);
            tweens = tws;
        }
    }

    [System.Serializable]
    internal class ColorSingle : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] Color color = Color.white;
        [SerializeField] float within = 0.4f;
        [SerializeField] MaskableGraphic graphic;
        Tween tw = null;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            tw.ExResetDT();
            tw = graphic.DOColor(color, within);
            tweens = new List<Tween>();
            tweens.Add(tw);
        }
    }

    [System.Serializable]
    internal class ColorGroupAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] Color color = Color.white;
        [SerializeField] float within = 0.4f;
        [SerializeField] List<MaskableGraphic> graphics;
        List<Tween> tws = null;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            tws.ExResetDT();
            tws = graphics.ExColor(color, within, runner, OnComplete);
            tweens = tws;
        }
    }

    [System.Serializable]
    internal class ColorSingleAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] Color color = Color.white;
        [SerializeField] float within = 0.4f;
        [SerializeField] MaskableGraphic graphic;
        Tween tw = null;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            tw.ExResetDT();
            tw = graphic.DOColor(color, within).OnComplete(() => { OnComplete?.Invoke(); });
            tweens = new List<Tween>();
            tweens.Add(tw);
        }
    }

    //
    [System.Serializable]
    internal class SetColorGroup : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] Color color = Color.white;
        [SerializeField] List<MaskableGraphic> graphics;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            graphics.ExForEachSafe((g) => { g.color = color; });
            tweens = new List<Tween>();
        }
    }

    [System.Serializable]
    internal class SetColorSingle : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] Color color = Color.white;
        [SerializeField] MaskableGraphic graphic;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            graphic.color = color;
            tweens = new List<Tween>();
        }
    }

    [System.Serializable]
    internal class SetColorGroupAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] Color color = Color.white;
        [SerializeField] List<MaskableGraphic> graphics;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            graphics.ExForEachSafe((g) => { g.color = color; });
            tweens = new List<Tween>();
            OnComplete?.Invoke();
        }
    }

    [System.Serializable]
    internal class SetColorSingleAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] Color color = Color.white;
        [SerializeField] MaskableGraphic graphic;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            graphic.color = color;
            tweens = new List<Tween>();
            OnComplete?.Invoke();
        }
    }
    #endregion

    #region Activation
    [System.Serializable]
    internal class ActivationGroup : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] List<GameObject> gameObjects;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            gameObjects.ExSetActiveObjects(appear);
            tweens = new List<Tween>();
        }
    }

    [System.Serializable]
    internal class ActivationSingle : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] GameObject gameObject;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            gameObject.SetActive(appear);
            tweens = new List<Tween>();
        }
    }

    [System.Serializable]
    internal class ComponentActivationGroup : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] List<Behaviour> unityComponents;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            unityComponents.ExForEachSafe((com) => { com.enabled = appear; });
            tweens = new List<Tween>();
        }
    }

    [System.Serializable]
    internal class ComponentActivationSingle : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] Behaviour unityComponents;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            unityComponents.enabled = appear;
            tweens = new List<Tween>();
        }
    }

    [System.Serializable]
    internal class ScriptActivationGroup : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] List<MonoBehaviour> scripts;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            scripts.ExForEachSafe((com) => { com.enabled = appear; });
            tweens = new List<Tween>();
        }
    }

    [System.Serializable]
    internal class ScriptActivationSingle : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] MonoBehaviour script;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            script.enabled = appear;
            tweens = new List<Tween>();
        }
    }
    #endregion

    #region ActivationAsync
    [System.Serializable]
    internal class ActivationGroupAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] List<GameObject> gameObjects;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            gameObjects.ExSetActiveObjects(appear);
            tweens = new List<Tween>();
            OnComplete?.Invoke();
        }
    }

    [System.Serializable]
    internal class ActivationSingleAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] GameObject gameObject;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            gameObject.SetActive(appear);
            tweens = new List<Tween>();
            OnComplete?.Invoke();
        }
    }

    [System.Serializable]
    internal class ComponentActivationGroupAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] List<Behaviour> unityComponents;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            unityComponents.ExForEachSafe((com) => { com.enabled = appear; });
            tweens = new List<Tween>();
            OnComplete?.Invoke();
        }
    }

    [System.Serializable]
    internal class ComponentActivationSingleAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] Behaviour unityComponents;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            unityComponents.enabled = appear;
            tweens = new List<Tween>();
            OnComplete?.Invoke();
        }
    }

    [System.Serializable]
    internal class ScriptActivationGroupAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] List<MonoBehaviour> scripts;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            scripts.ExForEachSafe((com) => { com.enabled = appear; });
            tweens = new List<Tween>();
            OnComplete?.Invoke();
        }
    }

    [System.Serializable]
    internal class ScriptActivationSingleAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] MonoBehaviour script;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            script.enabled = appear;
            tweens = new List<Tween>();
            OnComplete?.Invoke();
        }
    }
    #endregion

    #region TweenScale
    [System.Serializable]
    internal class ScaleGroup : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] float within = 0.4f, appearScale = 1.0f;
        [SerializeField] List<Transform> transforms;
        List<Tween> tws = null;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            tws.ExResetDT();
            tws = transforms.ExScale(appear ? Vector3.one * appearScale : Vector3.zero, within);
            tweens = tws;
        }
    }

    [System.Serializable]
    internal class ScaleSingle : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] float within = 0.4f, appearScale = 1.0f;
        [SerializeField] Transform transform;
        Tween tw = null;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            tw.ExResetDT();
            tw = transform.DOScale(appear ? Vector3.one * appearScale : Vector3.zero, within);
            tweens = new List<Tween>();
            tweens.Add(tw);
        }
    }

    [System.Serializable]
    internal class ScaleGroupAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] float within = 0.4f, appearScale = 1.0f;
        [SerializeField] List<Transform> transforms;
        List<Tween> tws = null;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            tws.ExResetDT();
            tws = transforms.ExScale(appear ? Vector3.one * appearScale : Vector3.zero, within, runner, OnComplete);
            tweens = tws;
        }
    }

    [System.Serializable]
    internal class ScaleSingleAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] bool appear = false;
        [SerializeField] float within = 0.4f, appearScale = 1.0f;
        [SerializeField] Transform transform;
        Tween tw = null;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            tw.ExResetDT();
            tw = transform.DOScale(appear ? Vector3.one * appearScale : Vector3.zero, within).OnComplete(() => { OnComplete?.Invoke(); });
            tweens = new List<Tween>();
            tweens.Add(tw);
        }
    }
    #endregion

    #region TweenScaleRange
    [System.Serializable]
    internal class ScaleRangeGroup : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] float within = 0.4f, from = 0.8f, to = 1.0f;
        [SerializeField] List<Transform> transforms;
        List<Tween> tws = null;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            tws.ExResetDT();
            transforms.ExForEachSafe((t) => { t.localScale = from * Vector3.one; });
            tws = transforms.ExScale(to * Vector3.one, within);
            tweens = tws;
        }
    }

    [System.Serializable]
    internal class ScaleRangeSingle : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] float within = 0.4f, from = 0.8f, to = 1.0f;
        [SerializeField] Transform transform;
        Tween tw = null;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            tw.ExResetDT();
            transform.localScale = from * Vector3.one;
            tw = transform.DOScale(to * Vector3.one, within);
            tweens = new List<Tween>();
            tweens.Add(tw);
        }
    }

    [System.Serializable]
    internal class ScaleRangeGroupAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] float within = 0.4f, from = 0.8f, to = 1.0f;
        [SerializeField] List<Transform> transforms;
        List<Tween> tws = null;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            tws.ExResetDT();
            transforms.ExForEachSafe((t) => { t.localScale = from * Vector3.one; });
            tws = transforms.ExScale(to * Vector3.one, within, runner, OnComplete);
            tweens = tws;
        }
    }

    [System.Serializable]
    internal class ScaleRangeSingleAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] float within = 0.4f, from = 0.8f, to = 1.0f;
        [SerializeField] Transform transform;
        Tween tw = null;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            tw.ExResetDT();
            transform.localScale = from * Vector3.one;
            tw = transform.DOScale(to * Vector3.one, within).OnComplete(() => { OnComplete?.Invoke(); });
            tweens = new List<Tween>();
            tweens.Add(tw);
        }
    }
    #endregion

    #region SetLocalTransform
    [System.Serializable]
    internal class SetTransformGroup : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] Vector3 position, rotation, scale;
        [SerializeField] List<Transform> transforms;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            transforms.ExForEachSafe((t) =>
            {
                t.localPosition = position;
                t.localEulerAngles = rotation;
                t.localScale = scale;
            });
            tweens = new List<Tween>();
        }
    }

    [System.Serializable]
    internal class SetTransformSingle : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] Vector3 position, rotation, scale;
        [SerializeField] Transform transform;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            transform.localPosition = position;
            transform.localEulerAngles = rotation;
            transform.localScale = scale;
            tweens = new List<Tween>();
        }
    }

    [System.Serializable]
    internal class SetTransformGroupAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] Vector3 position, rotation, scale;
        [SerializeField] List<Transform> transforms;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            transforms.ExForEachSafe((t) =>
            {
                t.localPosition = position;
                t.localEulerAngles = rotation;
                t.localScale = scale;
            });
            tweens = new List<Tween>();
            OnComplete?.Invoke();
        }
    }

    [System.Serializable]
    internal class SetTransformSingleAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] Vector3 position, rotation, scale;
        [SerializeField] Transform transform;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            transform.localPosition = position;
            transform.localEulerAngles = rotation;
            transform.localScale = scale;
            tweens = new List<Tween>();
            OnComplete?.Invoke();
        }
    }
    #endregion

    #region SetScale
    [System.Serializable]
    internal class SetScaleGroup : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] float setScale = 1.0f;
        [SerializeField] List<Transform> transforms;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            transforms.ExForEachSafe((t) =>
            {
                t.localScale = Vector3.one * setScale;
            });
            tweens = new List<Tween>();
        }
    }

    [System.Serializable]
    internal class SetScaleSingle : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] float setScale = 1.0f;
        [SerializeField] Transform transform;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            transform.localScale = Vector3.one * setScale;
            tweens = new List<Tween>();
        }
    }

    [System.Serializable]
    internal class SetScaleGroupAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] float setScale = 1.0f;
        [SerializeField] List<Transform> transforms;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            transforms.ExForEachSafe((t) =>
            {
                t.localScale = Vector3.one * setScale;
            });
            tweens = new List<Tween>();
            OnComplete?.Invoke();
        }
    }

    [System.Serializable]
    internal class SetScaleSingleAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] float setScale = 1.0f;
        [SerializeField] Transform transform;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            transform.localScale = Vector3.one * setScale;
            tweens = new List<Tween>();
            OnComplete?.Invoke();
        }
    }
    #endregion

    #region Show
    [System.Serializable]
    internal class ShowGroup : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] float appearScale = 1.0f;
        [SerializeField] List<Transform> transforms;
        List<Tween> tws = null;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            tws.ExResetDT();
            transforms.ExForEachSafe((t) => { t.gameObject.SetActive(true); });
            tws = transforms.ExScale(appearScale * Vector3.one, UICompositeConst.defaultTweenAnimationTime);
            tweens = tws;
        }
    }

    [System.Serializable]
    internal class Show : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] float appearScale = 1.0f;
        [SerializeField] Transform transform;
        Tween tw = null;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            tw.ExResetDT();
            transform.gameObject.SetActive(true);
            tw = transform.DOScale(appearScale * Vector3.one, UICompositeConst.defaultTweenAnimationTime);
            tweens = new List<Tween>();
            tweens.Add(tw);
        }
    }

    [System.Serializable]
    internal class ShowGroupAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] float appearScale = 1.0f;
        [SerializeField] List<Transform> transforms;
        List<Tween> tws = null;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            tws.ExResetDT();
            transforms.ExForEachSafe((t) => { t.gameObject.SetActive(true); });
            tws = transforms.ExScale(Vector3.one * appearScale, UICompositeConst.defaultTweenAnimationTime, runner, OnComplete);
            tweens = tws;
        }
    }

    [System.Serializable]
    internal class ShowAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] float appearScale = 1.0f;
        [SerializeField] Transform transform;
        Tween tw = null;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            tw.ExResetDT();
            transform.gameObject.SetActive(true);
            tw = transform.DOScale(Vector3.one * appearScale, UICompositeConst.defaultTweenAnimationTime).OnComplete(() => { OnComplete?.Invoke(); });
            tweens = new List<Tween>();
            tweens.Add(tw);
        }
    }
    #endregion

    #region Hide
    [System.Serializable]
    internal class HideGroup : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] List<Transform> transforms;
        List<Tween> tws = null;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            tws.ExResetDT();
            transforms.ExForEachSafe((t) => { t.gameObject.SetActive(true); });
            tws = transforms.ExScale(Vector3.zero, UICompositeConst.defaultTweenAnimationTime);
            tweens = tws;
        }
    }

    [System.Serializable]
    internal class Hide : IUICompositableTask
    {
        [SerializeField] string about = "";
        [SerializeField] Transform transform;
        Tween tw = null;
        void IUICompositableTask.Execute(ref List<Tween> tweens)
        {
            tw.ExResetDT();
            transform.gameObject.SetActive(true);
            tw = transform.DOScale(Vector3.zero, UICompositeConst.defaultTweenAnimationTime);
            tweens = new List<Tween>();
            tweens.Add(tw);
        }
    }

    [System.Serializable]
    internal class HideGroupAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] List<Transform> transforms;
        List<Tween> tws = null;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            tws.ExResetDT();
            transforms.ExForEachSafe((t) => { t.gameObject.SetActive(true); });
            tws = transforms.ExScale(Vector3.zero, UICompositeConst.defaultTweenAnimationTime, runner, OnComplete);
            tweens = tws;
        }
    }

    [System.Serializable]
    internal class HideAsync : IUICompositableTaskAsync
    {
        [SerializeField] string about = "";
        [SerializeField] Transform transform;
        Tween tw = null;
        void IUICompositableTaskAsync.Execute(ref List<Tween> tweens, MonoBehaviour runner, System.Action OnComplete)
        {
            tw.ExResetDT();
            transform.gameObject.SetActive(true);
            tw = transform.DOScale(Vector3.zero, UICompositeConst.defaultTweenAnimationTime).OnComplete(() => { OnComplete?.Invoke(); });
            tweens = new List<Tween>();
            tweens.Add(tw);
        }
    }
    #endregion
}