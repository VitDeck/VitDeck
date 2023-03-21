using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// 指定のフレーム数待ってからアクションを行う機構。
    /// </summary>
    public class EditorDelayedAction : IDisposable
    {
        bool watching = false;
        int delayedFrames = 0;
        readonly int delayCount = 0;
        readonly Action action = null;
        readonly bool resetOnMoreReserved;

        public EditorDelayedAction(Action action, int delayCount) : this(action, delayCount, false) { }

        public EditorDelayedAction(Action action, int delayCount, bool resetOnMoreReserved)
        {
            if (delayCount < 0)
                throw new ArgumentOutOfRangeException("delayCountは0未満の指定はできません。");
            if (action == null)
                throw new ArgumentNullException("actionにnullを指定することはできません。");

            this.delayCount = delayCount;
            this.action = action;
            this.resetOnMoreReserved = resetOnMoreReserved;
        }

        public void Reserve()
        {
            if (!watching)
                StartWatching();

            if (resetOnMoreReserved)
                delayedFrames = 0;
        }

        void StartWatching()
        {
            if (watching)
                return;

            EditorApplication.update += Update;
            watching = true;
            delayedFrames = 0;
        }

        void StopWatching()
        {
            if (!watching)
                return;

            EditorApplication.update -= Update;
            watching = false;
            delayedFrames = 0;
        }

        void Update()
        {
            if (delayedFrames >= delayCount)
            {
                action.Invoke();
                StopWatching();
            }
            delayedFrames++;
        }

        public void Dispose()
        {
            StopWatching();
        }
    }
}