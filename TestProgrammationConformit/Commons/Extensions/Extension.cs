
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace TestProgrammationConformit.Commons.Extensions
{
    public static class Extension 
    {

        public static IOrderedQueryable<T> CustomOrderBy<T>(this IQueryable<T> source, String propertyName, bool isAsc = true) where T : class
        {
            var parameter = Expression.Parameter(typeof(T), "Entity");

            PropertyInfo property;
            Expression propertyAccess;
            if (propertyName.Contains("."))
            {
                var childProperties = propertyName.Split('.');
                property = typeof(T).GetProperty(childProperties[0], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
                for (int i = 1; i < childProperties.Length; i++)
                {
                    property = property.PropertyType.GetProperty(childProperties[i], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
            }
            else
            {
                property = typeof(T).GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
            }

            var lambdaExpression = Expression.Lambda(propertyAccess, parameter);
            
            var methodName = isAsc ? "OrderBy" : "OrderByDescending";
            var resultExp = Expression.Call(typeof(Queryable), methodName,
                            new[] { typeof(T), property.PropertyType },
                            source.Expression, Expression.Quote(lambdaExpression));


            return source.Provider.CreateQuery<T>(resultExp) as IOrderedQueryable<T>;
        }
    }
}
