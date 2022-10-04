using MongoDB.Driver;
using Notification.Domain.Entities.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.ReadRepository.Common
{
    public class BaseReadRepository<TEntity>
       where TEntity : class, new()
    {
        public IMongoClient MongoClient { get; }
        public IMongoDatabase Db { get; }

        public IMongoCollection<TEntity> Collection { get; }

        public BaseReadRepository(IMongoDatabase db)
        {
            Db = db;
            MongoClient = db.Client;

            var tableName = typeof(TEntity).Name;
            Collection = Db.GetCollection<TEntity>(tableName);
        }

        public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Collection.Find(FilterDefinition<TEntity>.Empty).ToListAsync(cancellationToken);
        }

        public Task<List<TEntity>> GetWithFilterAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
        {
            return Collection.Find(filter).ToListAsync(cancellationToken);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
        {
            return Collection.Find(filter).FirstOrDefaultAsync(cancellationToken);
        }

        public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
        }

        public async Task UpdateCoulmnAsync(UpdateDefinition<TEntity> entity, Expression<Func<TEntity, bool>> filter, UpdateOptions option, CancellationToken cancellationToken = default)
        {
            var result = await Collection.UpdateOneAsync(filter, entity, options: option, cancellationToken: cancellationToken);
            if (!result.IsAcknowledged)
                throw new Exception($"Could not update the entity {entity.GetType().Name}");

        }

        //public async Task EditrecordAsync(TEntity entity, Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
        //{
        //    var result = await Collection.ReplaceOneAsync(filter, entity, cancellationToken: cancellationToken);

        //    if (!result.IsAcknowledged)
        //        throw new Exception($"Could not update the entity {entity.GetType().Name}");
        //}
        public async Task EditrecordAsync(TEntity entity, FilterDefinition<TEntity> filter, CancellationToken cancellationToken = default)
        {
            var result = await Collection.ReplaceOneAsync(filter, entity, cancellationToken: cancellationToken);

            if (!result.IsAcknowledged)
                throw new Exception($"Could not update the entity {entity.GetType().Name}");
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
        {
            var result = await Collection.DeleteOneAsync(filter, cancellationToken);

            if (!result.IsAcknowledged)
                throw new Exception($"Could not delete the entity {typeof(TEntity).Name}");
        }

        public async Task<List<TEntity>> GetAsync() => await Collection.Find(_ => true).ToListAsync();

        //public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter) =>
        //    await Collection.Find(filter).FirstOrDefaultAsync();

        public TEntity Getone(Expression<Func<TEntity, bool>> filter) =>
            Collection.Find(filter).FirstOrDefault();

        public TEntity GetoneFinal(Expression<Func<TEntity, bool>> filter,ProjectionDefinition<TEntity> p)
        {
           return (TEntity)Collection.Find(filter).Project(p);
        }

        public async Task CreateAsync(TEntity newentity) =>
            await Collection.InsertOneAsync(newentity);

        //public async Task UpdateAsync(Expression<Func<TEntity, bool>> filter, TEntity updatedBook) =>
        //    await Collection.ReplaceOneAsync(filter, updatedBook);

        public async Task RemoveAsync(Expression<Func<TEntity, bool>> filter) =>
            await Collection.DeleteOneAsync(filter);
        public async Task insercpinlmnAsync(Expression<Func<TEntity, bool>> filter,UpdateDefinition<TEntity> updatedBook) =>
           await Collection.UpdateOneAsync(filter, updatedBook);
        public async Task insercpinlmnAsyncfinal(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> updatedBook) =>
       await Collection.UpdateOneAsync(filter, updatedBook);

    }
}
