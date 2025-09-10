using System;
using System.Reflection;

public class PureTestSomeThing
{
    public void TEST()
    {
        // BindingFlags
        // MemberTypes
        BindingFlags a;
        Type type = GetType();
        
        MemberInfo memberInfo = type.GetMember("1")[0];
        Type t1 = memberInfo.DeclaringType;    // get type of the class that this member belong
        Type t2 = memberInfo.ReflectedType;    // get type of this member
    }
}