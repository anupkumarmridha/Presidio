﻿using PizzaHutAPI.Models.DB_Models;

namespace PizzaHutAPI.Repositories.Interfaces
{
    public interface IPizzaRepository:IRepository<int, Pizza>
    {
        public Task<Pizza> GetPizzaByName(string name);
    }
}
