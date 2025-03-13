using BlockBuster.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster
{
    public static class AdvancedRepositoryFunctions
    {
        public static void Create<IEntityType>(IEntityType newEntity)
            where IEntityType : class
        {
            using (var context = new Se407BlockBusterContext())
            {
                context.Add(newEntity);
                context.SaveChanges();
            }
        }


        public static IEntityType? GetById<IEntityType>(int entityId)
            where IEntityType : class
        {
            using (var context = new Se407BlockBusterContext())
            {
                return context.Find<IEntityType>(entityId);
            }
        }


        public static List<IEntityType> GetAll<IEntityType>()
            where IEntityType : class
        {
            using (var context = new Se407BlockBusterContext())
            {
                List<IEntityType> entities = [.. context.Set<IEntityType>()];
                return entities;
            }
        }



        public static void Update<IEntityType>
        (
            int entityId,
            IEnumerable<(string propName, object? propValue)> updateProps
        )
            where IEntityType : class
        {
            using (var context = new Se407BlockBusterContext())
            {
                var entityToUpdate = GetById<IEntityType>(entityId);

                if(entityToUpdate != null)
                {
                    foreach(var propTuple in updateProps)
                    {
                        PropertyInfo? propInfo =
                            entityToUpdate
                                .GetType()
                                .GetProperty(propTuple.propName);

                        if(propInfo != null)
                        {
                            propInfo
                                .SetValue
                                (
                                    entityToUpdate,
                                    propTuple.propValue
                                );
                        }
                    }

                    context.Update(entityToUpdate);
                    context.SaveChanges();
                }
            }
        }


        public static void Delete<TEntityType>(int entityId)
        {
            using (var context = new Se407BlockBusterContext())
            {
                var entityToDelete = GetById<IEntityType>(entityId);

                if (entityToDelete != null)
                {
                    context.Remove(entityToDelete);
                    context.SaveChanges();
                }
            }
        }
    }
}
