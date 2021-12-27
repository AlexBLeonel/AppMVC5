using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Alex.Business.Core.Data;
using Alex.Business.Core.Models;
using Alex.Infra.Data.Context;

#region Estratégia de Repositório Genérico
/*
 * Alguns métodos estão definidos como virtuais, para que seja possível modificá-los
 * no momento da sua implementação no Repositório Especialidado
 */
#endregion

namespace Alex.Infra.Data.Repository {
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new() {
        protected readonly AppDBContext Db; // Acesso ao contexto
        protected readonly DbSet<TEntity> DbSet; // Atalho para a entidade

        protected Repository(AppDBContext db) {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetById(Guid id) {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll() {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Add(TEntity entity) {
            entity.Created_at = DateTime.UtcNow;
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid id) {
            //DbSet.Remove(await DbSet.FindAsync(id));
            var entry = Db.Entry(new TEntity { Id = id });
            entry.State = EntityState.Deleted;
            entry.Entity.Deleted_at = DateTime.UtcNow;
            await SaveChanges();
        }

        public virtual async Task<int> SaveChanges() {
            return await Db.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity) {
            entity.Updated_at = DateTime.UtcNow;
            Db.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }

        public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate) {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Dispose() {
            Db?.Dispose();
        }
    }
}
