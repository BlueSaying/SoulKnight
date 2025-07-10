using System.Collections.Generic;
using UnityEngine.Events;

// NOTE:在此处注册事件
public enum EventType
{

}

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
    //    public EventInfo(UnityAction<T, U> action)
    //    {
    //        this.action = action;
    //    }
    //}

    public Dictionary<EventType, List<IEventInfo>> eventDic;

    private EventCenter()
    {
        eventDic = new Dictionary<EventType, List<IEventInfo>>();
    }

    public void RigisterEvent(EventType type, UnityAction action)
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
            eventDic.Add(type, new List<IEventInfo> { new EventInfo(action) });
        }
    }

    public void RigisterEvent<T>(EventType type, UnityAction<T> action)
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
            eventDic.Add(type, new List<IEventInfo> { new EventInfo<T>(action) });
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

    public void ClearEvent()
    {
        eventDic.Clear();
    }
}