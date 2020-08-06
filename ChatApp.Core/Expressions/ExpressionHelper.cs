using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChatApp.Core
{
    public static class ExpressionHelper
    {
        public static T GetPropertyValue<T>(this Expression<Func<T>> l)
        {
            return l.Compile().Invoke();
        }


        public static void SetPropertyValue<T>(this Expression<Func<T>> l, T value)
        {
            //converts a lambda () => some.property to just some.property
            var expression = (l as LambdaExpression).Body as MemberExpression;

            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            propertyInfo.SetValue(target, value);
        }
    }
}
