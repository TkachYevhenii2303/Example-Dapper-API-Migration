﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Base_Entity;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        public Task<IEnumerable<TEntity>> Get_all_Information();
        public Task<TEntity> Get_by_Id(int id);
        public Task Insert_Entity(TEntity entity);
        public Task Update_Entity(TEntity entity);
        public Task Delete_Entity(int id);
    }
}