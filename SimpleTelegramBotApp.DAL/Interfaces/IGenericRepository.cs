﻿using System;
using System.Collections.Generic;

namespace SimpleTelegramBotApp.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);

        TEntity FindById(int id);

        IEnumerable<TEntity> Get();

        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

        IEnumerable<TEntity> Get<TKey>(Func<TEntity, TKey> orderBy, bool isAsc = true, Func<TEntity, bool> predicate = null);

        void Remove(TEntity item);

        void Update(TEntity item);
    }
}