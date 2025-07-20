using System;
using System.Collections.Generic;
using UnityEngine.Events;

// NOTE:在此处注册事件
public enum EventType
{
    /// <summary>
    /// 当场景完成切换
    /// </summary>
    OnSceneSwitchComplete,

    /// <summary>
    /// 当角色选择完毕
    /// </summary>
    OnSelectPlayerComplete,

    /// <summary>
    /// 当皮肤选择完毕
    /// </summary>
    OnSelectSkinComplete,

    /// <summary>
    /// 当房间生成完毕
    /// </summary>
    OnFinishRoomCreate,
}

public class EventCenter : Singleton<EventCenter>
{
    public class IEventInfo
    {
        // 标识一个事件是否永久不被注销
        public bool isPermanent;

        public IEventInfo(bool isPermanent)
        {
            this.isPermanent = isPermanent;
        }
    }

    // 无参事件
    public class EventInfo : IEventInfo
    {
        public UnityAction action;

        public EventInfo(UnityAction action, bool isPermanent) : base(isPermanent)
        {
            this.action = action;
        }
    }

    // 1个参数事件
    public class EventInfo<T> : IEventInfo
    {
        public UnityAction<T> action;

        public EventInfo(UnityAction<T> action, bool isPermanent) : base(isPermanent)
        {
            this.action = action;
        }
    }

    // 2个参数事件
    //public class EventInfo<T, U> : IEventInfo
    //{
    //    public UnityAction<T, U> action;
    //
    //    public EventInfo(UnityAction<T, U> action,bool isPermanent):base(isPermanent)
    //    {
    //        this.action = action;
    //    }
    //}

    public Dictionary<EventType, List<IEventInfo>> eventDic;

    private EventCenter()
    {
        eventDic = new Dictionary<EventType, List<IEventInfo>>();
    }

    public void RigisterEvent(EventType type, bool isPermanent, UnityAction action)
    {
        if (eventDic.ContainsKey(type))
        {
            foreach (IEventInfo info in eventDic[type])
            {
                if (info is EventInfo)
                {
                    (info as EventInfo).action += action;
                }
            }
        }
        else
        {
            eventDic.Add(type, new List<IEventInfo> { new EventInfo(action, isPermanent) });
        }
    }

    public void RigisterEvent<T>(EventType type, bool isPermanent, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(type))
        {
            foreach (IEventInfo info in eventDic[type])
            {
                if (info is EventInfo<T>)
                {
                    (info as EventInfo<T>).action += action;
                }
            }
        }
        else
        {
            eventDic.Add(type, new List<IEventInfo> { new EventInfo<T>(action, isPermanent) });
        }
    }

    public void NotifyEvent(EventType type)
    {
        if (!eventDic.ContainsKey(type)) return;

        foreach (IEventInfo info in eventDic[type])
        {
            if (info is EventInfo)
            {
                (info as EventInfo).action.Invoke();
            }
        }
    }

    public void NotifyEvent<T>(EventType type, T param)
    {
        if (!eventDic.ContainsKey(type)) return;

        foreach (IEventInfo info in eventDic[type])
        {
            if (info is EventInfo<T>)
            {
                (info as EventInfo<T>).action.Invoke(param);
            }
        }
    }

    public void ClearNonPermanentEvents()
    {
        var keysToRemove = new List<EventType>();

        foreach (EventType type in eventDic.Keys)
        {
            // 创建待删除项列表
            var toRemove = new List<IEventInfo>();

            foreach (var info in eventDic[type])
            {
                if (!info.isPermanent && UnityTools.Instance.isGenericType(info.GetType(), typeof(EventInfo<>)))
                {
                    toRemove.Add(info);
                }
            }
            foreach (var item in toRemove)
            {
                eventDic[type].Remove(item);
            }

            if (eventDic[type].Count == 0)
            {
                keysToRemove.Add(type);
            }
        }

        foreach (var key in keysToRemove)
        {
            eventDic.Remove(key);
        }
    }
}