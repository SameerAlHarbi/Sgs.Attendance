using Microsoft.EntityFrameworkCore;
using Sameer.Shared;
using Sameer.Shared.Data;
using Sgs.Attendance.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Sgs.Attendance.BusinessLogic
{
    public class WorkShiftsSystemsManager : GeneralManager<WorkShiftsSystem>
    {
        public WorkShiftsSystemsManager(IRepository repo) : base(repo)
        {
        }

        //protected override async Task<ICollection<ValidationResult>> ValidateUniqueItemAsync(WorkShiftsSystem newItem)
        //{
        //    var vResults = new List<ValidationResult>();

        //    PropertyInfo[] properties = newItem.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

        //    var valProps = from prp in properties
        //                   where prp.GetCustomAttributes(typeof(UniqueAttribute), inherit: true).Count() > 0
        //                   select new
        //                   {
        //                       property = prp,
        //                       uniqAttr = prp.GetCustomAttributes(typeof(UniqueAttribute), inherit: true)
        //                   };

        //    if (valProps.Any())
        //    {
        //        var expressionsList = new List<Expression>();
        //        ParameterExpression e = Expression.Parameter(typeof(WorkShiftsSystem), name: "e");

        //        foreach (var prp in valProps)
        //        {
        //            Expression left = Expression.MakeMemberAccess(e, prp.property);
        //            Expression right;

        //            object propertyValue = newItem.GetType().GetProperty(prp.property.Name).GetValue(newItem, index: null);
        //            if (propertyValue == null)
        //            {
        //                right = Expression.Constant(value: null);
        //            }
        //            else
        //            {
        //                right = Expression.Constant(propertyValue, propertyValue.GetType());
        //            }

        //            BinaryExpression resultExpression = Expression.Equal(left, right);

        //            var unqAttr = prp.uniqAttr.First() as UniqueAttribute;
        //            foreach (var parentName in unqAttr.ParentsPropertiesNames)
        //            {
        //                left = Expression.MakeMemberAccess(e, newItem.GetType().GetProperty(parentName));
        //                propertyValue = newItem.GetType().GetProperty(parentName).GetValue(newItem, index: null);

        //                if (propertyValue == null)
        //                {
        //                    right = Expression.Constant(value: null);
        //                }
        //                else
        //                {
        //                    right = Expression.Constant(propertyValue, newItem.GetType().GetProperty(parentName).PropertyType);
        //                }

        //                BinaryExpression resultExpression2 = Expression.Equal(left, right);
        //                resultExpression = Expression.AndAlso(resultExpression, resultExpression2);
        //            }

        //            if (unqAttr.UniqueValue != null)
        //            {
        //                left = Expression.MakeMemberAccess(e, prp.property);
        //                right = Expression.Constant(unqAttr.UniqueValue, propertyValue.GetType());
        //                resultExpression = Expression.AndAlso(resultExpression, Expression.Equal(left, right));
        //            }

        //            expressionsList.Add(resultExpression);

        //        }

        //        if (expressionsList.Any())
        //        {
        //            Expression exps = expressionsList.First();
        //            if (expressionsList.Count > 1)
        //            {
        //                for (int i = 1; i < expressionsList.Count; i++)
        //                {
        //                    exps = Expression.OrElse(exps, expressionsList[i]);
        //                }
        //            }

        //            MethodCallExpression whereCallExpression = Expression.Call(
        //            typeof(Queryable),
        //            "Where",
        //            new Type[] { this.GetAll().ElementType },
        //            this.GetAll(i => i.Id != newItem.Id).Expression,
        //            Expression.Lambda<Func<WorkShiftsSystem, bool>>(exps, new ParameterExpression[] { e }));

        //            List<WorkShiftsSystem> results = await this.GetAll(i => i.Id != newItem.Id).Provider.CreateQuery<WorkShiftsSystem>(whereCallExpression).AsNoTracking().ToListAsync();

        //            if (results.Count() > 0)
        //            {
        //                foreach (var prp in valProps)
        //                {

        //                    object prpValue = newItem.GetType().GetProperty(prp.property.Name).GetValue(newItem, index: null);

        //                    if (prpValue == null)
        //                    {
        //                        if (results.Any(i => i.GetType().GetProperty(prp.property.Name).GetValue(i, index: null) == null))
        //                        {
        //                            vResults.Add(new ValidationResult((prp.uniqAttr.First() as UniqueAttribute).ErrorMessage, new string[] { prp.property.Name }));
        //                        }
        //                    }
        //                    else if (prp.property.PropertyType == typeof(string))
        //                    {
        //                        if (results.Where(i => i.GetType().GetProperty(prp.property.Name).GetValue(i, index: null) != null)
        //                            .Any(i => i.GetType().GetProperty(prp.property.Name).GetValue(i, index: null).ToString().Trim().ToUpper()
        //                            == prpValue.ToString().Trim().ToUpper()))
        //                        {
        //                            vResults.Add(new ValidationResult((prp.uniqAttr.First() as UniqueAttribute).ErrorMessage, new string[] { prp.property.Name }));
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (results.Where(i => i.GetType().GetProperty(prp.property.Name).GetValue(i, index: null) != null).Any(i => i.GetType().GetProperty(prp.property.Name).GetValue(i, index: null).Equals(prpValue)))
        //                        {
        //                            vResults.Add(new ValidationResult((prp.uniqAttr.First() as UniqueAttribute).ErrorMessage, new string[] { prp.property.Name }));
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    return vResults;
        //}

    }
}
