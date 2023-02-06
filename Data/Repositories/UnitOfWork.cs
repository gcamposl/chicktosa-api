using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Data.Context;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        // readonly só permite ser alimentado dentro do construtor
        private readonly ApplicationDbContext _db;
        private IDbContextTransaction _transaction;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task BeginTransaction()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
        }
    }
}