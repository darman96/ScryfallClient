using System;
using System.Reflection;

namespace ScryfallClient.Extensions
{
    internal static class MemberInfoExtensions
    {
        public static bool HasCustomAttribute<T>(this MemberInfo memberInfo)
            where T : Attribute
        {
            return memberInfo.GetCustomAttributes(typeof(T), false).Length > 0;
        }
    }
}