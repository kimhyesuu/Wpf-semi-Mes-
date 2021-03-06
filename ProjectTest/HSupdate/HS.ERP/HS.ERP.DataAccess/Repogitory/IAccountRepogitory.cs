﻿namespace HS.ERP.DataAccess.Repogitory
{
   using System.Collections.Generic;

   public interface IAccountRepogitory<TEntity>
   {
      IEnumerable<TEntity> GetAll();
      TEntity GetById(object id);
      TEntity Insert(TEntity parameter);
      void Update(TEntity parameter);
      void Delete(TEntity parameter);   
   }
}
