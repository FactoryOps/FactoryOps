﻿using FactoryOps.Api.Database.Contexts;
using FactoryOps.Api.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FactoryOps.Api.Database.Repositories;
public class Repository<T> : IRepository<T> where T : BaseEntity
{

	private readonly FactoryOpsContext context;
	private readonly DbSet<T> entities;

	public Repository(FactoryOpsContext context)
	{
		this.context = context;
		this.entities = this.context.Set<T>();
	}


	public async Task<T?> Get(int id)
	{
		return await this.entities.SingleOrDefaultAsync(s => s.Id == id);
	}

	public IAsyncEnumerable<T> GetAll()
	{
		return this.entities.AsAsyncEnumerable();
	}


	public IQueryable<T> GetAllQueryable()
	{
		return this.entities.AsQueryable();
	}

	public async Task Insert(T entity)
	{
		if (entity is null) throw new ArgumentNullException("Provided entity is null.");

		this.entities.Add(entity);
		await this.context.SaveChangesAsync();
	}

	public async Task Update(T entity)
	{
		if (entity is null) throw new ArgumentNullException("Provided entity is null.");
		this.context.Update(entity);
		await this.context.SaveChangesAsync();
	}
	public async Task Delete(T entity)
	{
		if (entity is null) throw new ArgumentNullException("Provided entity is null.");

		this.entities.Remove(entity);
		await this.context.SaveChangesAsync();
	}
}
