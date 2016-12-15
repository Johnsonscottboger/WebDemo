using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Web.Data.ExpressionExtend
{
    public static class ExpressionExtension
    {
        private static Expression<T> Compose<T>(this Expression<T> exp1,Expression<T> exp2,Func<Expression,Expression,Expression> merge)
        {
            //创建参数映射
            var map = exp1.Parameters.Select((f,i) => new { f,s = exp2.Parameters[i] }).ToDictionary(p => p.s,p => p.f);
            var exp2Body = ParameterRebinder.ReplaceParameters(map,exp2.Body);
            return Expression.Lambda<T>(merge(exp1.Body,exp2Body),exp1.Parameters);
        }

        /*动态拼接表达式树*/
        #region 使用方式
        //private static void Test()
        //{
        //    var source = new List<string>()
        //    {
        //        "The first string",
        //        "The second string",
        //        "The third string"
        //    };

        //    var builder = new StringBuilder();

        //    Func<string,bool> predicate = null;

        //    /*模拟查询条件*/
        //    Expression<Func<string,bool>> predicate1 = p1 => p1 == source.ElementAt(0);
        //    Expression<Func<string,bool>> predicate2 = p2 => p2 == source.ElementAt(1);
        //    Expression<Func<string,bool>> predicate3 = p3 => p3 == source.ElementAt(2);
        //    var preList = new List<Expression<Func<string,bool>>>()
        //    {
        //        predicate1,predicate2,predicate3
        //    };

        //    Expression<Func<string,bool>> predicateOr = null;

        //    foreach(var item in preList)
        //    {
        //        predicateOr = predicateOr.Or(item);
        //    }
        //    //拼接完成之后 编译 转换为委托
        //    predicate = predicateOr.Compile();
        //    //执行查询
        //    var result3 = source.Where(predicate).ToList();
        //    result3.ForEach(p => builder.AppendLine(p));
        //    builder.AppendLine();

        //    Console.WriteLine(builder.ToString());
        //    Console.ReadKey();
        //}
        #endregion

        #region Add，另一种方式
        //public static Expression<Func<T,bool>> And<T>(this Expression<Func<T,bool>> expr1,Expression<Func<T,bool>> expr2)
        //{
        //    if(expr1 == null)
        //        return expr2;
        //    var param = expr1.Parameters;
        //    var invokedExpr = Expression.Invoke(expr2,param);
        //    return Expression.Lambda<Func<T,bool>>(Expression.And(expr1.Body,invokedExpr),param);
        //}
        #endregion

        public static Expression<Func<T,bool>> And<T>(this Expression<Func<T,bool>> first,Expression<Func<T,bool>> second)
        {
            if(first == null)
                return second;
            return first.Compose(second,Expression.And);
        }

        #region Or,另一种方式
        //public static Expression<Func<T,bool>> Or<T>(this Expression<Func<T,bool>> expr1,Expression<Func<T,bool>> expr2)
        //{
        //    if(expr1 == null)
        //        return expr2;
        //    var param = expr1.Parameters;
        //    var invokedExpr = Expression.Invoke(expr2,param);
        //    return Expression.Lambda<Func<T,bool>>(Expression.Or(expr1.Body,invokedExpr),param);
        //}
        #endregion
        
        public static Expression<Func<T,bool>> Or<T>(this Expression<Func<T,bool>> first,Expression<Func<T,bool>> second)
        {
            if(first == null)
                return second;
            return second.Compose(second,Expression.Or);
        }
    }

    class ParameterRebinder :ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression,ParameterExpression> _map;
        public ParameterRebinder(Dictionary<ParameterExpression,ParameterExpression> map)
        {
            this._map =map ?? new Dictionary<ParameterExpression,ParameterExpression>();
        }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression,ParameterExpression> map,Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if(_map.TryGetValue(p,out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }
}
