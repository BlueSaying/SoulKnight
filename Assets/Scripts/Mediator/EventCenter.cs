using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCenter : Singleton<EventCenter>
{
    public class IEventInfo { }

    // 无参事件
    public class EventInfo : IEventInfo
    {
        public UnityAction action;

        public EventInfo(UnityAction action)
        {
            this.action = action;
        }
    }

    // 1个参数事件
    public class EventInfo<T> : IEventInfo
    {
        public UnityAction<T> action;

        public EventInfo(UnityAction<T> action)
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

    private bool isPermanentEvent(EventType eventType)
    {
        return eventType < EventType.isPermanentPoint;
    }

    public void RegisterEvent(EventType type, UnityAction action)
    {
        if (!eventDic.TryGetValue(type, out var infoList))
        {
            infoList = new List<IEventInfo>();
            eventDic.Add(type, infoList);
        }

        foreach (var info in infoList)
        {
            if (info is EventInfo)
            {
                (info as EventInfo).action += action;
                return;
            }
        }

        infoList.Add(new EventInfo(action));
    }

    public void RegisterEvent<T>(EventType type, UnityAction<T> action)
    {
        if (!eventDic.TryGetValue(type, out var infoList))
        {
            infoList = new List<IEventInfo>();
            eventDic.Add(type, infoList);
        }

        foreach (var info in infoList)
        {
            if (info is EventInfo<T>)
            {
                (info as EventInfo<T>).action += action;
                return;
            }
        }

        infoList.Add(new EventInfo<T>(action));
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

    public void RemoveEvent(EventType type, UnityAction action)
    {
        if (!eventDic.TryGetValue(type, out var infoList)) return;

        foreach (var info in eventDic[type])
        {
            if (info is EventInfo eventInfo)
            {
                eventInfo.action -= action;
            }
        }
    }

    public void RemoveEvent<T>(EventType type, UnityAction<T> action)
    {
        if (!eventDic.TryGetValue(type, out var infoList)) return;

        foreach (var info in eventDic[type])
        {
            if (info is EventInfo<T> eventInfo)
            {
                eventInfo.action -= action;
            }
        }
    }

    public void ClearNonPermanentEvents()
    {
        foreach (EventType type in eventDic.Keys)
        {
            if (isPermanentEvent(type)) continue;

            eventDic[type].Clear();
        }
    }
}