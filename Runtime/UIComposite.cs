using AttributeExt2;
using DG.Tweening;
using DTExt;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExt;

namespace CompositableUI
{
    [System.Serializable]
    public class UIComposite
    {
        [SerializeReference, SerializeReferenceButton] List<IUICompositableTask> works;
        List<Tween> tws;
        public void Execute(ref List<Tween> tweens)
        {
            tws.ExResetDT();
            var lst = new List<Tween>();
            works.ExForEachSafeCustomClass((w) =>
            {
                var l = new List<Tween>();
                w.Execute(ref l);
                if (l != null && l.Count > 0) { lst.AddRange(l); }
            });
            tweens = lst;
        }
    }

    [System.Serializable]
    public class UICompositeAsync
    {
        [SerializeReference, SerializeReferenceButton] List<IUICompositableTaskAsync> works;
        List<Tween> tws;
        public void Execute(ref List<Tween> tweens, MonoBehaviour runner, Action OnComplete)
        {
            tws.ExResetDT();
            var validCount = works.ExNotNullCountCustomClass();
            int completedCount = 0;
            var lst = new List<Tween>();
            works.ExForEachSafeCustomClass((w) =>
            {
                var l = new List<Tween>();
                w.Execute(ref l, runner, () =>
                {
                    completedCount++;
                });
                if (l != null && l.Count > 0) { lst.AddRange(l); }
            });
            tweens = lst;

            runner.StartCoroutine(COR());
            IEnumerator COR()
            {
                while (true)
                {
                    if (completedCount >= validCount) { break; }
                    yield return null;
                }
                OnComplete?.Invoke();
            }
        }
    }

    [System.Serializable]
    public class UICompositePlaylist
    {
        [SerializeReference, SerializeReferenceButton] List<IUICompositableTaskAsync> works;
        List<Tween> tws;
        public void Execute(MonoBehaviour runner)
        {
            tws.ExResetDT();
            runner.StartCoroutine(COR());
            IEnumerator COR()
            {
                tws = new List<Tween>();
                for (int i = 0; i < works.Count; i++)
                {
                    var work = works[i];
                    if (work == null) { continue; }
                    var l = new List<Tween>();
                    var done = false;
                    work.Execute(ref l, runner, () =>
                    {
                        done = true;
                    });
                    if (l.ExIsValid()) { tws.AddRange(l); }
                    while (!done) { yield return null; }
                }
            }
        }
    }

    [System.Serializable]
    public class TypeIDEntry
    {
        [SerializeField] string typeID;
        [SerializeReference, SerializeReferenceButton] IUICompositableTask work;
        internal string TypeID { get { return typeID; } }
        internal IUICompositableTask Work { get { return work; } }
    }

    [System.Serializable]
    public class TypeIDEntryAsync
    {
        [SerializeField] string typeID;
        [SerializeReference, SerializeReferenceButton] IUICompositableTaskAsync work;
        internal string TypeID { get { return typeID; } }
        internal IUICompositableTaskAsync Work { get { return work; } }
    }

    [System.Serializable]
    public class UICompositeTypeID
    {
        [SerializeField] List<TypeIDEntry> works;
        List<Tween> tws;

        public void Execute(string typeID, ref List<Tween> tweens)
        {
            tws.ExResetDT();
            var lst = new List<Tween>();
            works.ExForEachSafeCustomClass((w) =>
            {
                var l = new List<Tween>();
                if (w.TypeID == typeID)
                {
                    w.Work.Execute(ref l);
                }
                if (l != null && l.Count > 0) { lst.AddRange(l); }
            });
            tweens = lst;
        }
    }

    [System.Serializable]
    public class UICompositeTypeIDAsync
    {
        [SerializeField] List<TypeIDEntryAsync> works;
        List<Tween> tws;
        public void Execute(string typeID, ref List<Tween> tweens, MonoBehaviour runner, Action OnComplete)
        {
            tws.ExResetDT();
            var validCount = works.ExNotNullCountCustomClass();
            int completedCount = 0;
            var lst = new List<Tween>();
            works.ExForEachSafeCustomClass((w) =>
            {
                var l = new List<Tween>();
                if (w.TypeID == typeID)
                {
                    w.Work.Execute(ref l, runner, () =>
                    {
                        completedCount++;
                    });
                }
                if (l != null && l.Count > 0) { lst.AddRange(l); }
            });
            tweens = lst;

            runner.StartCoroutine(COR());
            IEnumerator COR()
            {
                while (true)
                {
                    if (completedCount >= validCount) { break; }
                    yield return null;
                }
                OnComplete?.Invoke();
            }
        }
    }
}